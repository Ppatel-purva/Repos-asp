using System;

namespace inventory_management_v6.Models
{
    public class ProductItems
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public int Quantity { get; set; }
        public int Price { get; set; }
        public string? Category { get; set; }
        public string? ManufacturerName { get; set; }
        public string? DistributerName { get; set; }
        public string? Address { get; set; }
        public DateTime DateTime { get; set; } = DateTime.UtcNow;
    }
}
