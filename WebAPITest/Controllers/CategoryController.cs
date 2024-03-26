using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebAPITest.Data;
using WebAPITest.Models;
using WebAPITest.Models.DTO;

namespace WebAPITest.Controllers;

[Route("/asdf/[controller]")]
public class CategoryController : ControllerBase
{
	private readonly DataContext _context;

	public CategoryController(DataContext context)
	{
		_context = context;
	}

	[HttpGet]
	public IActionResult Get()
	{
		var allCategories = _context.Categories.ToList().ToDTO();
	 	return Ok(allCategories);
	}

	// [HttpGet]
	// public IActionResult GetCategory(int id){
	// 	var cat = _context.Categories.Find(id);
	// 	if(cat is null){
	// 		return NotFound("Category not found");
	// 	}

	// 	return Ok(cat);
	// }

	// [HttpPost]
	// public IActionResult CreateCategory(Category? cat){
	// 	if(cat is null){
	// 		return BadRequest();
	// 	}

	// 	_context.Add(cat);

	// 	return Ok(cat);
	// }

 
	[HttpDelete]
	public IActionResult DeleteCategory(int id){
		var category = _context.Categories.Find(id);
		if(category is null){
			return NotFound();
		}
		// _context.Entry(category).State = EntityState.Detached;
		_context.Categories.Remove(category);
		_context.SaveChanges();
		return Ok(category);
	}
}