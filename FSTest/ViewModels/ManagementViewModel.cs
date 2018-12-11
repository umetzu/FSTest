using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace FSTest.ViewModels
{
    public class ManagementViewModel
    {
        [Display(Name = "Sales Rep")]
        public string SalesRepName { get; set; }
        public IEnumerable<ManagementDetailViewModel> Details { get; set; }
    }
    public class ManagementDetailViewModel
    {
        [Display(Name = "Investor")]
        public string InvestorName { get; set; }
        [Display(Name = "Total Amount")]
        public decimal TotalAmount { get; set; }
    }
}
