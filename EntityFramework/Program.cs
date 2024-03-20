using System.Linq.Expressions;
using System.Runtime.ConstrainedExecution;
using Microsoft.EntityFrameworkCore;
// See https://aka.ms/new-console-template for more information

using (var db = new NorthWindDB()){
    if(db.Database.CanConnect()){
        Console.WriteLine("yey");
    }
    else{
        Console.WriteLine("no");
    }
    
    // READ
    var allCategories = db.Categories.Where(c => c.CategoryName!.Contains("food"));
    foreach(var cat in allCategories){
        Console.WriteLine(cat.CategoryName);
    }

    // Create
    Category toInsert = new Category();
    toInsert.CategoryName="Dogfood";
    toInsert.Description="desc...";
    db.Categories.Add(toInsert);
    db.SaveChanges();

    Console.WriteLine("===================================");

    // Read
    allCategories = db.Categories.Where(c => c.CategoryName!.Contains("food"));
    foreach(var cat in allCategories){
        Console.WriteLine(cat.CategoryName);
    }

    var dogfood = db.Categories.Where(c=> c.CategoryName!.Contains("Dog")).FirstOrDefault();
    if(dogfood is not null){
        dogfood.Description = "this is dog food btw";
        db.SaveChanges();
    }

    Console.WriteLine("===================================");
    // Read
    allCategories = db.Categories.Where(c => c.CategoryName!.Contains("food"));
    foreach(var cat in allCategories){
        Console.WriteLine(cat.CategoryName);
        if(cat.Products is null)
            continue;
        foreach(var prod in cat.Products){
            Console.Write(prod.ProductName + ",");
        }
    }
    allCategories = db.Categories
        .Where(c => c.CategoryName!.Contains("Condiments"))
        .Include(c => c.Products);

    Console.WriteLine("===================================");

    foreach(var cat in allCategories){
        Console.WriteLine(cat.CategoryName);
        if(cat.Products is null)
            continue;
        foreach(var prod in cat.Products){
            Console.Write(prod.ProductName + ",");
        }
    }

    // SELECT * FROM Categories WHERE ....idk
    allCategories = db.Categories
        .Where(c => 
            c.Products.Intersect(
                db.Products.Where(p => p.ProductName.Contains("Cha"))
            ).Count() > 0
        );
    Console.WriteLine("\n==============querying from category=================");

    foreach(var cat in allCategories){
        Console.WriteLine(cat.CategoryName);
    }

    // SELECT Category FROM Products WHERE "Cha" in ProductName
    allCategories = db.Products.Where(p => p.ProductName.Contains("Cha")).Select(c => c.Category).Distinct();

    Console.WriteLine("\n==============querying from product, then use select=================");
    foreach(var cat in allCategories){
        Console.WriteLine(cat.CategoryName);
    }

}



class Category{
    public int CategoryID{get; set;}
    public string? CategoryName{get; set;}
    public string? Description{get; set;}
    public ICollection<Product> Products { get; set; } = [];
}

class Product{
    public int ProductID { get; set; }
    public string ProductName{get; set;}
    public int CategoryID { get; set; }
    public bool Discontinued{get;set;}
    public Category Category{get;set;}
}

class NorthWindDB : DbContext
{
    public DbSet<Category> Categories{get; set;}
    public DbSet<Product> Products{get; set;}

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlite("Data Source=Northwind.db");
    }

}