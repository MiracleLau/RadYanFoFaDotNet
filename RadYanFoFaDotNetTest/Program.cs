// See https://aka.ms/new-console-template for more information

using RadYanFoFaDotNet;

#if DEBUG
var email = "";
var key = "";
var client = new FoFaClient(email, key);
var result = client.SearchAsync("domain=\"sodsec.com\"");
Console.WriteLine(result.Result!.Query);

#endif