﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SalesWebsite.Shared.CreateRequest
{
    public class CustomerCreateRequest
    {
        public string UserName { get; set; }
        public string Password { get; set; }
        public string FullName { get; set; }

    }
}
