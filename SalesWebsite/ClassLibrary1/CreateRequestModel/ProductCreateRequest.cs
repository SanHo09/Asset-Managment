﻿using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SalesWebsite.Shared.CreateRequest
{
    public class ProductCreateRequest
    {
        public string Name { get; set; }
        public int Price { get; set; }
        public int Quantity { get; set; }
        public IFormFile image { get; set; }
        public float Rate { get; set; }
        public bool IsDeleted { get; set; }
        public int? Sold { get; set; } = 0;
        virtual public int CategoryId { get; set; }
        
    }
}
