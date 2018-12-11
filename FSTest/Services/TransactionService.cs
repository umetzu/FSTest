using FSTest.Models;
using FSTest.ViewModels;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Util;
using static FSTest.ViewModels.BreakViewModel;

namespace FSTest.Services
{
    public static class TransactionService
    {
        /// <summary>
        /// For each Sales Rep, generate Year to Date, Month to Date, Quarter to
        /// Date, and Inception to Date summary of cash amounts sold across all funds.
        /// </summary>
        /// <param name="transactions">Transaction list value generated from CSVParser</param>
        /// <returns>IEnumerable<SalesViewModel> used as viewmodel for Sales View.</returns>
        public static IEnumerable<SalesViewModel> SalesSummary(List<TransactionModel> transactions)
        {
            var currentYear = DateTime.Today.Year;
            var currentMonth = DateTime.Today.Month;
            var currentQuarter = (currentMonth + 2) / 3;

            var result = transactions?.GroupBy(x => x.SalesRepName).Select(x => new SalesViewModel
            {
                SalesRepName = x.Key,
                YearToDate = x.Where(y => y.TransactionDate.Year == currentYear).Sum(y => y.TotalSale),
                MonthToDate = x.Where(y => y.TransactionDate.Month == currentMonth).Sum(y => y.TotalSale),
                QuarterToDate = x.Where(y => y.QuarterNumber == currentQuarter).Sum(y => y.TotalSale),
                InceptionToDate = x.Sum(y => y.TotalSale)
            });

            return result;
        }
        /// <summary>
        /// For each Sales Rep, generate a summary of the net amount held by investors across all funds.
        /// </summary>
        /// <param name="transactions">Transaction list value generated from CSVParser</param>
        /// <returns>IEnumerable<ManagementViewModel> used as viewmodel for Management View.</returns>
        public static IEnumerable<ManagementViewModel> ManagementSummary(List<TransactionModel> transactions)
        {
            var result = transactions?.GroupBy(x => x.SalesRepName).Select(x => new ManagementViewModel
            {
                SalesRepName = x.Key,
                Details = x.GroupBy(y => y.InvestorName).Select(y => new ManagementDetailViewModel
                {
                    InvestorName = y.Key,
                    TotalAmount = y.Sum(z => z.TotalSaleSigned)
                })
            });

            return result;
        }
        /// <summary>
        /// Assuming the information in the data provided is complete and accurate,
        /// generate a report that shows any errors(negative cash balances,
        /// negative share balance) by investor.
        /// </summary>
        /// <param name="transactions">Transaction list value generated from CSVParser</param>
        /// <returns>IEnumerable<BreakViewModel> used as viewmodel for Break View.</returns>
        public static IEnumerable<BreakViewModel> BreakReport(List<TransactionModel> transactions)
        {
            var result = transactions?.GroupBy(x => x.InvestorName).Select(x => new BreakViewModel
            {
                InvestorName = x.Key,
                NetCashBalance = x.Sum(y => y.TotalSaleSigned),
                NetShareBalance = x.Sum(y => y.SharesAmountSigned)
            }).Where(x => x.NetCashBalance < 0 || x.NetShareBalance < 0);

            return result;
        }
        /// <summary>
        /// For each Investor and Fund, return net profit or loss on investment.
        /// </summary>
        /// <param name="transactions">Transaction list value generated from CSVParser</param>
        /// <returns>IEnumerable<InvestorViewModel> used as viewmodel for Investor View.</returns>
        public static IEnumerable<InvestorViewModel> InvestorProfit(List<TransactionModel> transactions)
        {
            var result = transactions?.GroupBy(x => new { x.InvestorName, x.FundDescription })
                .Select(x => new InvestorViewModel
            {
                InvestorName = x.Key.InvestorName,
                FundDescription = x.Key.FundDescription,
                TotalSigned = x.Sum(y => y.TotalSaleSigned)
            });

            return result;
        }
    }
}