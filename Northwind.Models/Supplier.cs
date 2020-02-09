﻿using System;
using System.Collections.Generic;
using System.Text;

namespace Northwind.Models
{
    public class Supplier
    {
        public int Id { get; set; }
        public string  CompanyName { get; set; }
        public string ContactName { get; set; }
        public string ContactTitle { get; set; }
        public string City { get; set; }
        public string Phone { get; set; }
        public string Fax { get; set; }
    }
}
