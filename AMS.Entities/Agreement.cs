using Microsoft.AspNetCore.Identity;
using System;
using System.ComponentModel.DataAnnotations;  

namespace AMS.Entities
{
    public class Agreement
    {
        [Key]
        public int AgreementId { get; set; }
        public int ProductId { get; set; }
        public virtual Product Product { get; set; }
        public int ProductGroupId { get; set; }

        public virtual ProductGroup ProductGroup { get; set; }
        [DisplayFormat(DataFormatString = "{0:MM/dd/yyyy}")]
        [DataType(DataType.Date)]
        public DateTime EffectiveDate { get; set; } = DateTime.UtcNow;
        [DisplayFormat(DataFormatString = "{0:MM/dd/yyyy}")]
        [DataType(DataType.Date)]
        public DateTime ExpirationDate { get; set; } = DateTime.UtcNow;
        [DataType(DataType.Currency)]
        public decimal ProductPrice { get; set; }
        [DataType(DataType.Currency)]
        public decimal NewPrice { get; set; }
        public virtual IdentityUser User { get; set; }
    }
}
