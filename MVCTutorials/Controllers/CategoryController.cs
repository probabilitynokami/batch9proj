using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using MVCTutorial.Data;
using MVCTutorial.Models;

namespace MVCTutorial.Controllers;

public class CategoryController : Controller
{
	private readonly DataContext _context;

	public CategoryController(DataContext context)
	{
		_context = context;
	}

	public IActionResult Index()
	{
		var categories = _context.Categories;
		return View(categories);
	}

	public IActionResult Update(int? id){
		if(id is null){
			TempData["error"] = $"id is null";
			return RedirectToAction("Index");
		}
		var c = _context.Categories.Find(id);
		if(c is null){
			TempData["error"] = $"No Category of ID {id} found";
			return RedirectToAction("Index");
		}
		return View(c);
	}

	[HttpPost]
	public IActionResult Update(Category category){
        Category old_category = _context.Categories.Find(category.CategoryId)!;
		_context.Entry(old_category).State = EntityState.Detached;
		if(old_category.CategoryName == category.CategoryName &&
		   old_category.Description == category.Description){
			TempData["info"] = $"No changes were made to Category of ID {category.CategoryId}";
			return RedirectToAction("Index");
		}
		_context.Categories.Update(category);
		// string query = "Categories SET CategoryName='"+category.CategoryName.ToString()+ "' WHERE CategoryId="+category.CategoryId.ToString();
		// _context.Database.ExecuteSql($"UPDATE {query}");
		_context.SaveChanges();
		TempData["info"] = $"Category of ID {category.CategoryId} successfully updated";
		return RedirectToAction("Index");
	}

	public IActionResult Create() 
	{
		return View();
	}

	[HttpPost]
	public IActionResult Create(Category category) 
	{
		//input the ccategory to database
		_context.Categories.Add(category);
		_context.SaveChanges();
		return RedirectToAction("Index");
	}

	public IActionResult Delete(int? id){
		if(id is null){
			TempData["error"] = $"id is null";
			return RedirectToAction("Index");
		}

		var c = _context.Categories.Find(id);

		if(c is null){
			TempData["error"] = $"No Category of ID {id} found";
			return RedirectToAction("Index");
		}

		TempData["info"] = $"Category of ID {id} successfuly deleted";

		return RedirectToAction("Index");
	}
}
