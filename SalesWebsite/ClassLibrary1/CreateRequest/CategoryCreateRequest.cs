namespace SalesWebsite.Shared
{
    public class CategoryCreateRequest
    {
        
        public string Name { get; set; }
        public string Description { get; set; }
        public bool IsDeleted { get; set; }
    }
}