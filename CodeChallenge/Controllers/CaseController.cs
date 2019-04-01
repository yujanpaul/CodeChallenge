using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using HtmlAgilityPack;
using CodeChallenge.Models;
using System.Globalization;

namespace CodeChallenge.Controllers
{
    public class CaseController : Controller
    {
        /// <summary>
        /// Returns Index View
        /// </summary>
        /// <returns></returns>
        public ActionResult Index()
        {
            return View();
        }

        /// <summary>
        /// Upload HTML file to be readed
        /// </summary>
        /// <returns></returns>
        public ActionResult UploadCases()
        {
            Session.Clear();

            List<Case> cases = new List<Case>();
            Case tempCase;
            Procedure tempProc;
            bool hasProcedures;

            var file = Request.Files[0];
            var doc = new HtmlDocument();
            doc.Load(file.InputStream);

            foreach (HtmlNode node in doc.DocumentNode.SelectNodes("//table[@id = 'ctl00_BodyContent_ContentPlaceHolder1_ucAuthResults_grvAuthResults']/tbody/*"))
            {
                tempCase = new Case();

                tempCase.AuthNum = node.SelectSingleNode(".//span[contains(@id,'lblAuthNumValue')]").InnerText;
                tempCase.CaseNumber = Int32.Parse(node.SelectSingleNode("./td/table/tbody/tr/td/table/tbody/tr[2]/td[2]").InnerText);
                tempCase.Status = node.SelectSingleNode(".//span[contains(@id,'lblStatusValue')]").InnerText;
                tempCase.ApprovalDate = DateTime.ParseExact(node.SelectSingleNode("./td/table/tbody/tr/td/table/tbody/tr[4]/td[2]").InnerText.Trim(), "M/d/yyyy h:mm:ss tt", CultureInfo.InvariantCulture);
                tempCase.ServCode = Int32.Parse(node.SelectSingleNode(".//span[contains(@id,'lblService') and not (contains(@id,'Label'))]").InnerText);
                tempCase.ServDescription = node.SelectSingleNode(".//span[contains(@id,'lblservicedescription') and not (contains(@id,'label'))]").InnerText;
                tempCase.SiteName = node.SelectSingleNode("./td/table/tbody/tr/td/table/tbody/tr[7]/td[2]").InnerText.Trim();
                tempCase.ExpDate = DateTime.ParseExact(node.SelectSingleNode("./td/table/tbody/tr/td/table/tbody/tr[8]/td[2]").InnerText.Trim(), "M/d/yyyy", CultureInfo.InvariantCulture);
                tempCase.LastUpdate = DateTime.ParseExact(node.SelectSingleNode("./td/table/tbody/tr/td/table/tbody/tr[9]/td[2]").InnerText.Trim(), "M/d/yyyy h:mm:ss tt", CultureInfo.InvariantCulture);


                hasProcedures = node.SelectSingleNode(".//table[contains(@id,'gvProcedureBasket')]/tbody").ChildNodes.Count > 2;

                if (hasProcedures)
                {
                    foreach (HtmlNode item in node.SelectNodes(".//table[contains(@id,'gvProcedureBasket')]/tbody/tr[position()>1]"))
                    {
                        tempProc = new Procedure();
                        tempProc.Id = Int32.Parse(node.SelectSingleNode(".//span[contains(@id,'lblProcedureCode')]").InnerText.Trim());
                        tempProc.Desc = node.SelectSingleNode(".//span[contains(@id,'lblDescription')]").InnerText.Trim();
                        tempProc.QtyRequested = Int32.Parse(node.SelectSingleNode(".//span[contains(@id,'lblAmtRequested')]").InnerText.Trim());
                        tempProc.QtyApproved = Int32.Parse(node.SelectSingleNode(".//span[contains(@id,'lblAmtApproved')]").InnerText.Trim());
                        tempProc.Modifiers = node.SelectSingleNode(".//span[contains(@id,'lblModifiers')]").InnerText.Trim();

                        tempCase.Procedures.Add(tempProc);
                    }
                }

                Session[tempCase.CaseNumber.ToString()] = tempCase;
                cases.Add(tempCase);
            }
            return PartialView("_MainCases", cases);
        }

        /// <summary>
        /// Extract Case Detail
        /// </summary>
        /// <param name="caseNumber"></param>
        /// <returns></returns>
        public ActionResult GetDetails(int caseNumber)
        {
            Case caseModel = (Case)Session[caseNumber.ToString()];
            return View("_CaseDetail", caseModel);
        }
    }
}