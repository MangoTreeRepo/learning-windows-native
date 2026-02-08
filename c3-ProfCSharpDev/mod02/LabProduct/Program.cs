using LabProduct.TestData; // to use the class in LabProduct/TestData/Test.cs
using LabProduct.Products; // to use the class in LabProduct/Products/Product.cs
using System.Diagnostics; 

namespace LabProduct;

class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("\n--- Comparing speed in searches in a List and a Dictionary ---");

        const int MAX_SIZE = 1_00_000;
        string LAST_PROD = $"PROD{(MAX_SIZE-1):D6}";
        Stopwatch stopwatch = new();

        Console.WriteLine("\n--- Linear search - O(n) ---");
        List<Product> products = Test.CreateProductsList(MAX_SIZE);
        stopwatch.Start();
        var foundProduct = products.FirstOrDefault(p => p.SKU == LAST_PROD);
        stopwatch.Stop();
        // Console.WriteLine($"List lookup took: {stopwatch.ElapsedMilliseconds}ms");
        Console.WriteLine($"Ticks: {stopwatch.ElapsedTicks}");
        Console.WriteLine($"Total MS: {stopwatch.Elapsed.TotalMilliseconds}ms");

        stopwatch.Reset();

        Console.WriteLine("\n--- Fast search - O(1) ---");
        Dictionary<string, Product> productsDict = Test.CreateProductsDict(MAX_SIZE);
        stopwatch.Start();
        var fastFound = productsDict[LAST_PROD];
        stopwatch.Stop();
        Console.WriteLine($"Ticks: {stopwatch.ElapsedTicks}");
        Console.WriteLine($"Total MS: {stopwatch.Elapsed.TotalMilliseconds}ms");


        stopwatch.Reset();

        Console.WriteLine("\n--- Comparing removing duplicates in List vs HashSet ---");
        Console.WriteLine("\n--- Using List<string> ---");
        stopwatch.Start();
        List<string> emailList = Test.CreateEmailList();
        stopwatch.Stop();
        Console.WriteLine($"Ticks: {stopwatch.ElapsedTicks}");
        Console.WriteLine($"Total MS: {stopwatch.Elapsed.TotalMilliseconds}ms");

        stopwatch.Reset();

        Console.WriteLine("\n--- Using HashSet<string> ---");
        stopwatch.Start();
        HashSet<string> emailHashSet = Test.CreateEmailHashSet();
        stopwatch.Stop();
        Console.WriteLine($"Ticks: {stopwatch.ElapsedTicks}");
        Console.WriteLine($"Total MS: {stopwatch.Elapsed.TotalMilliseconds}ms");

        // Verify that there are no duplicates
        // if (emailList.Count() != emailList.Distinct().Count())
        // {
        //     Console.WriteLine("The list contains duplicates.");
        // }
        // else
        // {
        //     Console.WriteLine("The list does not contain duplicates.");
        // }

        Console.WriteLine("\n--- Email List ---");
        foreach(var email in emailList)
        {
            Console.WriteLine(email);
        }

        Console.WriteLine("\n--- Email Hash Set ---");
        foreach(var email in emailHashSet)
        {
            Console.WriteLine(email);
        }

        Console.WriteLine();
    }
}
