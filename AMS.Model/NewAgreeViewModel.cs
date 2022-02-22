using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace AMS.Model
{
    public class NewAgreeViewModel
    {
        public int Id { get; set; }
        [Required]
        public int Group { get; set; }
        [Required]
        public int Product { get; set; }
        [Required]
        [DisplayFormat(DataFormatString = "{0:MM/dd/yyyy}")]
        [DataType(DataType.Date)]
        public DateTime EffectiveDate { get; set; } = DateTime.UtcNow;
        [Required]
        [DisplayFormat(DataFormatString = "{0:MM/dd/yyyy}")]
        [DataType(DataType.Date)]
        public DateTime ExpirationDate { get; set; } = DateTime.UtcNow;
        [Required]
        [DataType(DataType.Currency)]
        public decimal ProductPrice { get; set; }
        [Required]
        [DataType(DataType.Currency)]
        public decimal NewPrice { get; set; } 
        public List<CollectionViewModel> Groups { get; set; }
        public List<CollectionViewModel> Products { get; set; }
        public string UserId { get; set; } 
        public bool Active { get; set; }
    }
}
