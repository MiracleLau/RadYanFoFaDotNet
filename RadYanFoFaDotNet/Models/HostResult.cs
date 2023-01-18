namespace RadYanFoFaDotNet.Models
{
    public class HostResult
    {
        public bool Error { get; set; }
        public string? Host { get; set; }
        public string? Ip { get; set; }
        public int Asn { get; set; }
        public string? Org { get; set; }
        public string? Country_name { get; set; }
        public string? Country_code { get; set; }
        public string[]? Protocol { get; set; }
        public int[]? Port { get; set; }
        public string[]? Category { get; set; }
        public string[]? Product { get; set; }
        public PortList[]? Ports { get; set; }
        public string? Update_time { get; set; }
    }


    public class HostResultDetail
    {
        public bool Error { get; set; }
        public string? Host { get; set; }
        public string? Ip { get; set; }
        public int Asn { get; set; }
        public string? Org { get; set; }
        public string? Country_name { get; set; }
        public string? Country_code { get; set; }
        public PortList[]? Ports { get; set; }
        public string? Update_time { get; set; }
    }

    public class PortList
    {
        public int Port { get; set; }
        public string? Protocol { get; set; }
        public ProductList[]? Products { get; set; }
    }

    public class ProductList
    {
        public string? Product { get; set; }
        public string? Category { get; set; }
        public int Level { get; set; }
        public int Sort_hard_code { get; set; }
    }

}
