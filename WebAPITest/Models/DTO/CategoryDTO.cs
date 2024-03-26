namespace WebAPITest.Models.DTO;

public class CategoryDTO
{
	public int CategoryId { get; set; }
	public string CategoryName { get; set; } = null!;
	public string? Description { get; set; }
}

public static class CategoryDTOMapper{
    public static CategoryDTO ToDTO(this Category cat){
        return new CategoryDTO(){
            CategoryId = cat.CategoryId,
            CategoryName = cat.CategoryName,
            Description = cat.Description
        };
    }
    public static Category UnDTO(this CategoryDTO cat){
        return new Category(){
            CategoryId = cat.CategoryId,
            CategoryName = cat.CategoryName,
            Description = cat.Description
        };
    }

    public static IEnumerable<CategoryDTO> ToDTO(this IEnumerable<Category> cats){
        List<CategoryDTO> retCats = [];
        foreach(var cat in cats){
            retCats.Add(cat.ToDTO());
        }
        return retCats;
    }
    public static IEnumerable<Category> UnDTO(this IEnumerable<CategoryDTO> cats){
        List<Category> retCats = [];
        foreach(var cat in cats){
            retCats.Add(cat.UnDTO());
        }
        return retCats;
    }
}

