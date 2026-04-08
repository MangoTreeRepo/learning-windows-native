using System.ComponentModel.DataAnnotations.Schema; // To use [Column]

namespace Northwind.EntityModels;

public class Category
{
    public int CategoryId { get; set; } // the primary key

    public string CategoryName { get; set; } = null!;

    [Column(TypeName = "ntext")]
    public string? Description { get; set; }

    public virtual ICollection<Product> Products { get; set; } = new HashSet<Product>();
}
