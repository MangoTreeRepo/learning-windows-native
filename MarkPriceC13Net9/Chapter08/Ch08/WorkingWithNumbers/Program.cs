using System.Numerics; // for BigInteger
using System.Text; // for String Builder

// Big numbers
const int width = 40;
WriteLine("ulong.MaxValue vs a 30-digit BigInteger");
WriteLine(new string('-', width));
ulong big = ulong.MaxValue;
WriteLine($"{big,width:N0}");
BigInteger bigger = BigInteger.Parse("123456789012345678901234567890");
WriteLine($"{bigger,width:N0}");

// GUID
WriteLine($"Empty GUID: {Guid.Empty}.");
Guid g = Guid.NewGuid();
WriteLine($"Random GUID: {g}.");

byte[] guidAsBytes = g.ToByteArray();
Write("GUID as byte array: ");
for (int i = 0; i < guidAsBytes.Length; i++)
{
    Write($"{guidAsBytes[i]:X2} ");
}
WriteLine();

WriteLine("Generating three v7 GUIDs: ");
for (int i = 0; i < 3; i++)
{
    Guid g7 = Guid.CreateVersion7(DateTimeOffset.UtcNow);
    WriteLine($" {g7}.");
}

// Uisng StringBuilder
var fruits = new string[] { "Apple", "Banana", "Cherry", "Dragonfruit" };
        
// 1. Initialize with optional starting capacity for better performance
StringBuilder sb = new StringBuilder("Fruit List:\n");

foreach (var fruit in fruits)
{
    // 2. Efficiently append new strings
    sb.Append("- ");
    sb.AppendLine(fruit);
}

// 3. You can also perform "Fluent" operations
sb.Replace("Apple", "Green Apple")
  .Insert(0, "COLLECTION REPORT\n");

// 4. Convert back to a standard string when finished
string result = sb.ToString();

WriteLine(result);