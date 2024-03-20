using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

// See https://aka.ms/new-console-template for more information
// Console.WriteLine("Hello, World!");

// dotnet ef migrations add "message"
// dotent ef database update

public class Program{
    static async Task Main(){
        Console.WriteLine("Halowarudo");
        Category toInsert = new()
        {
            CategoryName = "Hello",
            Discontinued = 1
        };

        using var db = new SouthWind();
        db.Categories.Add(toInsert);
        db.SaveChanges();
        await db.SaveChangesAsync();
        Console.WriteLine("Halowarudo");
    }
}

public class SouthWind : DbContext
{
	public DbSet<Category> Categories { get; set; }
	public DbSet<Product> Products { get; set; }
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
		optionsBuilder.UseSqlite("Data Source=Southwind.db");
    }
}


public class Category{

    [Column("CategoryID"), Key]
    public int ID{get; set;}

    [Required, MaxLength(15)]
    public string CategoryName{get;set;} = null!;

    [Column(TypeName = "bit")]
    public int Discontinued{get; set;}

    public ICollection<Product> Products{get;set;}

    public Category(){
        Products = [];
    }
}

public class Product{

    [Column("ProductID"),Key]
    public int ID{get; set;}

    public int CategoryID{get;set;}

    [Required, Column("Name",TypeName="text"), MaxLength(40)]
    public string ProductName{get;set;} = null!;

    [Required, Column("Distributor",TypeName="text"), MaxLength(15)]
    public string DistributorName{get;set;} = null!;

    public Category Category{get;set;} = null!;
}
