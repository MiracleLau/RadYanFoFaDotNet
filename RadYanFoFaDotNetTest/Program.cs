// See https://aka.ms/new-console-template for more information

using RadYanFoFaDotNet;

var file = "favicon.ico";

Console.WriteLine("通过文件计算：");
Console.WriteLine(Utils.GetIconHashFromFile(file));

Console.WriteLine("通过url计算：");
Console.WriteLine(Utils.GetIconHashFromHttp("https://github.com/favicon.ico"));

var email = "";
var key = "";
var client = new FoFaClient(email, key);
client.SetApiDomain("https://fofa.info");

var result = client.GetUserInfo();
Console.WriteLine(result);

var search = client.Search("title=\"百度\"", 1);
Console.WriteLine(search);

var host = client.SearchHost("78.48.50.249", true);
Console.WriteLine(host);

var stats = client.SearchStats("domain=\"baidu.com\"");
Console.WriteLine(stats);