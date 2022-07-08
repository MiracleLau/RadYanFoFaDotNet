namespace RadYanFoFaDotNet.Models;

public class SearchResult
{
    public bool Error { get; set; }
    public int Size { get; set; }
    public int Page { get; set; }
    public string Mode { get; set; }
    public string Query { get; set; }
    public List<List<string>> Results { get; set; }
}