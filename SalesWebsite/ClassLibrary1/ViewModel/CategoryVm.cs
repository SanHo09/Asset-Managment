﻿

namespace SalesWebsite.ViewModels
{
    public class CategoryVm
    {
        
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public bool IsDeleted { get; set; }
        virtual public List<ProductVm> Products { get; set; }
    }
}
