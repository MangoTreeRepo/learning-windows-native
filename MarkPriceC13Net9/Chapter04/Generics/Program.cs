namespace Generics;

class Program
{
    static void Main(string[] args)
    {
        int age = InputHelper.PromptFor<int>("Enter your age: ");
        double price = InputHelper.PromptFor<double>("Enter the price: ");
        decimal debt = InputHelper.PromptFor<decimal>("Enter the balance: ");

        WriteLine($"\nSummary: Age {age}, Price {price}, Debt {debt}");
    }
}
