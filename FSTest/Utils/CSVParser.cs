using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using FSTest.Models;
using Microsoft.VisualBasic.FileIO;

namespace FSTest.Utils
{

    public static class CSVParser
    {
        /// <summary>
        /// Parse the stream using TextFieldParser
        /// Validations omitted... file must be correctly formatted.
        /// </summary>
        /// <param name="stream">
        /// Input stream containing list of transactions
        /// TXN_DATE, TXN_TYPE, TXN_SHARES, TXN_PRICE, FUND, INVESTOR, SALES_REP
        /// </param>
        /// <returns>List of TransactionModel from stream, can return nulls</returns>
        public static List<TransactionModel> Parse(Stream stream)
        {
            var result = new List<TransactionModel>();

            using (var parser = new TextFieldParser(stream))
            {
                parser.SetDelimiters(",");
                parser.TrimWhiteSpace = true;

                // Skip header
                if (!parser.EndOfData)
                {
                    parser.ReadLine();
                }

                while (!parser.EndOfData)
                {
                    string[] fields = parser.ReadFields();

                    try
                    {
                        
                        var transactionModel = new TransactionModel();

                        //Parsing fields, no validations.
                        transactionModel.TransactionDate = DateTime.Parse(fields[0]);
                        transactionModel.TransactionType = (TransactionType)Enum.Parse(typeof(TransactionType), fields[1], true);
                        transactionModel.SharesAmount = decimal.Parse(fields[2]);
                        transactionModel.TransactionPrice = decimal.Parse(fields[3], NumberStyles.Currency);
                        transactionModel.FundDescription = fields[4];
                        transactionModel.InvestorName = fields[5];
                        transactionModel.SalesRepName = fields[6];

                        result.Add(transactionModel);
                    }
                    catch (Exception)
                    {
                        return null;
                    }
                }

                return result;
            }
        }
    }
}
