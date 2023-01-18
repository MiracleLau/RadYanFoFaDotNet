namespace RadYanFoFaDotNet.Models
{
    public class StatsResult
    {
        public bool? Error { get; set; }
        public Distinct? Distinct { get; set; }
        public Aggs? Aggs { get; set; }
        public string? Lastupdatetime { get; set; }
    }

    public class Distinct
    {
        public int IP { get; set; }
        public int Title { get; set; }
    }

    public class Aggs
    {
        public Title[]? Title { get; set; }
    }

    public class Title
    {
        public int Count { get; set; }
        public string? Name { get; set; }
    }

}
