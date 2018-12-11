using System;
using System.ComponentModel.DataAnnotations;

namespace FSTest.ViewModels
{
    public class SalesViewModel
    {
        [Display(Name="Sales Rep")]
        public string SalesRepName { get; internal set; }
        [Display(Name="Year to date")]
        public decimal YearToDate { get; internal set; }
        [Display(Name="Month to date")]
        public decimal MonthToDate { get; internal set; }
        [Display(Name="Quarter to date")]
        public decimal QuarterToDate { get; internal set; }
        [Display(Name="Inception to date")]
        public decimal InceptionToDate { get; internal set; }
    }
}
