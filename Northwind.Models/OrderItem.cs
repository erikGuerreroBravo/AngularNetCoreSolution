using System;
using System.Collections.Generic;
using System.Text;

namespace Northwind.Models
{
    public class OrderItem
    {
        public int Id { get; set; }
        public int OrderId { get; set; }
        public int ProuctId { get; set; }
        public decimal UnitPrice { get; set; }
        public int Quantity { get; set; }
    }
}
