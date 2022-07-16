// See https://aka.ms/new-console-template for more information

using RadYanFoFaDotNet;

var file = "favicon.ico";

Console.WriteLine("通过文件计算：");
Console.WriteLine(Utils.GetIconHashFromFile(file));

Console.WriteLine("通过url计算：");
Console.WriteLine(Utils.GetIconHashFromHttp("https://github.com/favicon.ico"));