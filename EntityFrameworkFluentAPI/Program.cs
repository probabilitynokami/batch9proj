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
		//optionsBuilder.UseSqlite("Data Source=Southwind2.db");
        optionsBuilder.UseNpgsql("Host=localhost;Port=5432;Database=testDB;Username=postgres;Password=postgres");
    }
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Category>(c =>
            {
                c.HasKey(c=>c.ID).HasName("CategoryID");
                c.Property(c=>c.CategoryName).IsRequired().HasMaxLength(15);
                c.Property(c=>c.Discontinued);
            }
        );
        modelBuilder.Entity<Product>(p =>
            {
                p.HasKey(p=>p.ID).HasName("ProductID");
                p.Property(p=>p.CategoryID);
                p.Property(p=>p.ProductName)
                    .HasColumnName("Name")
                    .HasColumnType("text")
                    .HasMaxLength(40);
                p.Property(p=>p.DistributorName)
                    .HasColumnName("Distributor")
                    .HasColumnType("text")
                    .HasMaxLength(15);
            }
        );


        // data seeding

        modelBuilder.Entity<Category>().HasData(
            new Category(){
                ID = 1,
                CategoryName = "hehoho",
                Discontinued = 1,
            },
            new Category(){
                ID = 2,
                CategoryName = "hihihi",
                Discontinued = 2,
            }
        );

        modelBuilder.Entity<Product>().HasData(
            new Product(){
                ID = 1,
                CategoryID = 1,
                ProductName = "hi",
                DistributorName = "hoi",
            },
            new Product(){
                ID = 2,
                CategoryID = 2,
                ProductName = "hii",
                DistributorName = "hoii",
            },
            new Product(){
                ID = 3,
                CategoryID = 1,
                ProductName = "hoo",
                DistributorName = "hooo",
            }
        );
    }
}


public class Category{

    public int ID{get; set;}

    public string CategoryName{get;set;} = null!;

    public int Discontinued{get; set;}

    public ICollection<Product> Products{get;set;}

    public Category(){
        Products = [];
    }
}

public class Product{

    public int ID{get; set;}

    public int CategoryID{get;set;}

    public string ProductName{get;set;} = null!;
    public string DistributorName{get;set;} = null!;
}

  
