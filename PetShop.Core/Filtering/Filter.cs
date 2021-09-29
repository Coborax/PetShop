namespace PetShop.Core.Filtering
{
    public class Filter
    {
        public int Count { get; set; }
        public int Page { get; set; }
        public string SortType { get; set; }
        public string SearchTerm { get; set; }
    }
}