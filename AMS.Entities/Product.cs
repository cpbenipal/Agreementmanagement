using System;
using System.ComponentModel.DataAnnotations;

namespace AMS.Entities
{
    public class Product
    {
        [Key]
        public int Id { get; set; }
        public virtual ProductGroup ProductGroup { get; set; }
        public string ProductDescription { get; set; }
        public string ProductNumber { get; set; }
        [DataType(DataType.Currency)]
        public decimal Price { get; set; }
        public bool Active { get; set; }
    }
}
