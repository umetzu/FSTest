using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using System.Web.Mvc.Ajax;
using FSTest.Services;
using FSTest.Utils;

namespace FSTest.Controllers
{

    public class HomeController : Controller
    {
        #region Controller Actions
        public ActionResult Index()
        {
            //Values used by dropzone control
            ViewBag.FileName = SessionHelper.FileName;
            ViewBag.FileSize = SessionHelper.FileSize;

            return View();
        }
        
        public ActionResult Sales()
        {
            var results = TransactionService.SalesSummary(SessionHelper.Transactions);

            return View(results);
        }

        public ActionResult Management()
        {
            var results = TransactionService.ManagementSummary(SessionHelper.Transactions);

            return View(results);
        }

        public ActionResult Break()
        {
            var results = TransactionService.BreakReport(SessionHelper.Transactions);

            return View(results);
        }

        public ActionResult Investor()
        {
            var results = TransactionService.InvestorProfit(SessionHelper.Transactions);

            return View(results);
        }
        #endregion

        /// <summary>
        /// Called from form home-dropzone in Home/Index View
        /// </summary>
        /// <param name="file">File in CSV format</param>
        /// <returns></returns>
        [HttpPost]
        public ActionResult CSVUpload(HttpPostedFileBase file)
        {
            //If file is empty clear session
            if (file != null && file.ContentLength > 0)
            {
                var fileSize = file.ContentLength + "";
                var stream = file.InputStream;

                try
                {
                    var transactions = CSVParser.Parse(stream);

                    //Store in session
                    SessionHelper.FileName = file.FileName;
                    SessionHelper.FileSize = fileSize;
                    SessionHelper.Transactions = transactions;
                }
                catch (Exception e)
                {
                    //Invalid file uploaded
                    return new HttpStatusCodeResult(HttpStatusCode.BadRequest, e.Message);
                }
            }
            else
            {
                //Clear session
                SessionHelper.FileName = "";
                SessionHelper.FileSize = "";
                SessionHelper.Transactions = null;
            }

            return new HttpStatusCodeResult(HttpStatusCode.OK);
        }
    }
}
