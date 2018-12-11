using System;
using System.Collections.Generic;
using System.Web;
using System.Web.SessionState;
using FSTest.Models;

namespace FSTest.Utils
{
    /// <summary>
    /// Class Helper that wraps HttpSessionState and contains dictionary key values
    /// </summary>
    public class SessionHelper
    {
        #region dictionary key values

        const string TransactionsKey = "Transactions";
        const string FileNameKey = "FileName";
        const string FileSizeKey = "FileSize";

        #endregion
        /// <summary> Add/Update/Remove Transacion list from session. </summary>
        public static List<TransactionModel> Transactions
        {
            get { return HttpContext.Current.Session[TransactionsKey] != null ? (List<TransactionModel>)HttpContext.Current.Session[TransactionsKey] : null; }
            set { HttpContext.Current.Session[TransactionsKey] = value; }
        }
        /// <summary> Add/Update/Remove the file name from the used CSVFile to generate the Transactions property. </summary>

        public static string FileName
        {
            get { return HttpContext.Current.Session[FileNameKey] + ""; }
            set { HttpContext.Current.Session[FileNameKey] = value; }
        }
        /// <summary> Add/Update/Remove the file size from the used CSVFile to generate the Transactions property. </summary>
        public static string FileSize
        {
            get { return HttpContext.Current.Session[FileSizeKey] + ""; }
            set { HttpContext.Current.Session[FileSizeKey] = value; }
        }
    }
}
