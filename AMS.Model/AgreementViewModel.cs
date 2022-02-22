using System;
using System.Collections.Generic;

namespace AMS.Model
{
    public class AgreementViewModel
    {
        public int Id { get; set; }
        public string Username { get; set; }
        public string GroupCode { get; set; }
        public string GroupDescription { get; set; }
        public string ProductDescription { get; set; }
        public string ProductNumber { get; set; }
        public string EffectiveDate { get; set; }
        public string ExpirationDate { get; set; }
        public decimal ProductPrice { get; set; }
        public decimal NewPrice { get; set; }
    }

    public class AgreementListViewModel 
    {
        public string draw { get; set; }
        public int recordsFiltered { get; set; }
        public int recordsTotal { get; set; }
        public List<AgreementViewModel> data { get; set; } 
    }
}
