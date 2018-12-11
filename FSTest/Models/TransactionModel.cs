using System;
namespace FSTest.Models
{
    public enum TransactionType { Buy, Sell }

    public class TransactionModel
    {
        /// <summary>The TransactionDate property stores the「TXN_DATE」from CSV file ~ Date transaction took place.</summary>
        public DateTime TransactionDate { get; set; }
        /// <summary>The TransactionType property stores the「TXN_TYPE」from CSV file ~ Type of transaction (BUY/SELL).</summary>
        public TransactionType TransactionType { get; set; }
        /// <summary>The SharesAmount property stores the「TXN_SHARES」from CSV file ~ Number of shares affected by transaction.</summary>
        public decimal SharesAmount { get; set; }
        /// <summary>The TransactionPrice property stores the「TXN_PRICE」from CSV file ~ Price per share.</summary>
        public decimal TransactionPrice { get; set; }
        /// <summary>The FundDescription property stores the「FUND」from CSV file ~ Name of fund in which shares are transacted.</summary>
        public string FundDescription { get; set; }
        /// <summary>The InvestorName property stores the「INVESTOR」from CSV file ~ Name of the owner of the shares being transacted.</summary>
        public string InvestorName { get; set; }
        /// <summary>The SalesRepName property stores the「SALES_REP」from CSV file ~ Name of the sales rep advising the investor.</summary>
        public string SalesRepName { get; set; }

        #region Calculated properties

        /// <summary>The SharesAmountSigned property returns SharesAmount property oppostie value if the transaction type is Sell.</summary>
        public decimal SharesAmountSigned
        {
            get
            {
                if (TransactionType == TransactionType.Sell)
                {
                    return SharesAmount * -1;
                }

                return SharesAmount;
            }
        }
        /// <summary>The TotalSaleSigned property uses SharesAmountSigned to calculate the total sale.</summary>
        public decimal TotalSaleSigned {get { return SharesAmountSigned * TransactionPrice; } }
        /// <summary>The TotalSale property is the operation value of SharesAmount * TransactionPrice.</summary>
        public decimal TotalSale { get { return SharesAmount * TransactionPrice; } }
        /// <summary>The QuarterNumber property is the year's quarter of the TransactionDate property.</summary>
        public int QuarterNumber { get { return (TransactionDate.Month + 2) / 3; } }

        #endregion
    }
}
