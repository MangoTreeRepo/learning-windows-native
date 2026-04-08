string fileName = "servers.json";
string pathToDesktop = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
string pathToFile = System.IO.Path.Combine(pathToDesktop, fileName);
WriteLine(pathToFile);