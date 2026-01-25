// See https://aka.ms/new-console-template for more information
using System.Drawing;
using Pastel;

Console.WriteLine("Hello, World!");

// public record Project(Guid Id, string Name, string DatabasePath);

string workstationName = "Sovereign-Ironclad";
decimal currentBalance = 5000.75m;
bool isAirGapped = true;

Console.WriteLine(workstationName);
Console.WriteLine(currentBalance);
Console.WriteLine(isAirGapped);

if (currentBalance < 10000.00m)
{
    Console.WriteLine("Warning: Low Liquidity");
}
else
{
    Console.WriteLine("Liquidity Sufficient");
}

string ticker = "AAPL";

string institutionName = ticker switch
{
    "AAPL" => "Apple Inc.",
    "MSFT" => "Microsoft Corp.",
    _ => "Private Entity"
};

Console.WriteLine(institutionName.Pastel(Color.LightGreen));