using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace FSTest.ViewModels
{
    public class BreakViewModel
    {
        [Display(Name="Investor Name")]
        public string InvestorName { get; set; }
        [Display(Name="Net Cash Balance")]
        public decimal NetCashBalance { get; set; }
        [Display(Name="Net Share Balance")]
        public decimal NetShareBalance { get; set; }
    }
}
