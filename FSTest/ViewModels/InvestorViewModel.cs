using System;
using System.ComponentModel.DataAnnotations;

namespace FSTest.ViewModels
{
    public class InvestorViewModel
    {
        [Display(Name="Investor")]
        public string InvestorName { get; set; }
        [Display(Name = "Fund")]
        public string FundDescription { get; set; }
        [Display(Name = "Total")]
        public decimal TotalSigned { get; set; }
    }
}
