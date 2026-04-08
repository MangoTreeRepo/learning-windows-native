// Problem Set for Chapter 2: Speaking C#

// 1a. Command-Line Arguments
bool hasVerbose = args.Contains("--verbose");

// 1b. Type Exploration
const int col1 = 13;
const int col2 = 13;
const int col3 = 32;
const int col4 = 32;
string line = new('-', col1 + col2 + col3 + col4 + 10);

WriteLine("\nTable 1: Attributes of CLR Types");
WriteLine(line);
WriteLine($"{"CLR Type", col1} | {"Size (bytes)", -col2} | {"Minimum", -col3}  | {"Maximum", -col4}");
WriteLine(line);
WriteLine($"{"sbyte", col1} | {sizeof(sbyte), -col2} | {sbyte.MinValue, -col3}  | {sbyte.MaxValue, -col4}");
WriteLine($"{"int", col1} | {sizeof(int), -col2} | {int.MinValue, -col3}  | {int.MaxValue, -col4}");
WriteLine($"{"double", col1} | {sizeof(double), -col2} | {double.MinValue, -col3}  | {double.MaxValue, -col4}");
WriteLine($"{"decimal",col1} | {sizeof(decimal), -col2} | {decimal.MinValue, -col3}  | {decimal.MaxValue, -col4}");
WriteLine(line);
WriteLine();

// 2a. User Interaction
Write("Enter the server name: ");
string serverName = ReadLine() ?? string.Empty;
Write("Enter the allocated memory in gigabytes: ");
decimal memorySizeGB = decimal.TryParse(ReadLine(), out decimal result) ? result : 0M;

// 2b. String Interpolation & Variables
const int mBPerGB = 1024;
decimal memorySizeMB = (decimal) memorySizeGB * mBPerGB;
WriteLine($"Hello, there. The server name is {serverName} and the memory size is {memorySizeMB:N2} MB.");