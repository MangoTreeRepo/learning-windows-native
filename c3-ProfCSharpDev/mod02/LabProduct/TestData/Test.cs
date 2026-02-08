using LabProduct.Products; // to use the class in LabProduct/Products/Product.cs

namespace LabProduct.TestData;
public class Test
{
    public static List<Product> CreateProductsList(int count)
    {
        var products = new List<Product>();

        for (int i = 0; i < count; i++)
        {
            products.Add
            (
                new Product
                {
                    SKU = $"PROD{i:D6}",
                    Name = $"Product {i}",
                    Price = 19.99m + i
                }
            );
        }

        return products;
    }

    public static Dictionary<string, Product> CreateProductsDict(int count)
    {
        var products = new Dictionary<string, Product>();

        for (int i = 0; i < count; i++)
        {
            var sku = $"PROD{i:D6}";
            var product = new Product
            {
                SKU = $"PROD{i:D6}",
                Name = $"Product {i}",
                Price = 19.99m + i
            };
            products.Add(sku, product);
        }
        
        return products;
    }

    private static string[] EmailList()
    {
        return
        [
            "user1@example.com", "user2@example.com", "user1@example.com",
            "user3@example.com", "user2@example.com", "user4@example.com",
            "user5@example.com", "user1@example.com", "user6@example.com",
            "user3@example.com", "user7@example.com", "user2@example.com"
        ];
    }

    private static readonly string[] emails = 
        [
            "user1@example.com", "user2@example.com", "user1@example.com",
            "user3@example.com", "user2@example.com", "user4@example.com",
            "user5@example.com", "user1@example.com", "user6@example.com",
            "user3@example.com", "user7@example.com", "user2@example.com"
        ];

    public static List<string> CreateEmailList()
    {
        List<string> emailList = [];
        foreach(var email in emails)
        {
            if (!emailList.Contains(email))
            {
                emailList.Add(email);
            }
        }
        return emailList;
    }

    // public static HashSet<string> CreateEmailHashSet()
    // {
    //     HashSet<string> emailHashSet = new HashSet<string>(emails); 
    //     return emailHashSet;
    // }

    public static HashSet<string> CreateEmailHashSet() => new(emails);
}