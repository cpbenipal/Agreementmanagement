using System;
using System.ComponentModel.DataAnnotations;

namespace AMS.Entities
{
    public class ProductGroup
    {
        [Key]
        public int Id { get; set; }
        public string GroupDescription { get; set; }
        public string GroupCode { get; set; }
        public bool Active { get; set; }
    }
}
