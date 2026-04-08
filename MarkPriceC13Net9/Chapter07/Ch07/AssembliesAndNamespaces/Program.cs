using System.Xml.Linq; // To use XDocument

XDocument doc = new();

WriteLine($"Environment.Is64BitProcess = {Environment.Is64BitProcess}");
WriteLine($"int.MaxValue = {int.MaxValue}");
WriteLine($"nint.MaxValue = {nint.MaxValue}");