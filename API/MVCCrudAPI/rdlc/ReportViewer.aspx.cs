using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Configuration;
using System.Data;
using System.Web.Razor.Tokenizer;

namespace RDLCREPORTMVC.Reporting
{
    public partial class ReportViewer : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!(IsPostBack))
            {
                string sConnString = "", sProviderName = "";
                sConnString = ConfigurationManager.ConnectionStrings["EmployeesConnectionString"].ConnectionString;
                sProviderName = ConfigurationManager.ConnectionStrings["EmployeesConnectionString"].ProviderName;

                ///iNSTANTIATING DB HELPER CLASS
                //VBHelpers _DBHelper = new DBHelper(sConnString, sProviderName);

                ///FETCHING DATA FROM DB
                //DataTable dtReportData = _DBHelper.ExecuteDataTable("SELECT * FROM EMPLOYEES");

                //Show Report
                //ShowReport(dtReportData);
            }
        }
        void ShowReport(DataTable dt)
        {
            //rptViewer.Reset();

            //rptViewer.ProcessingMode = Microsoft.Reporting.WebForms.ProcessingMode.Local;

            //rptViewer.LocalReport.ReportPath = Server.MapPath("~/Reporting/EmployeeReport.rdlc");

            //To SHow images in report (external/dynamically)
            //rptViewer.LocalReport.EnableExternalImages = true;

            //To Add Parameter to report enable this section
            //Don't forget to declare while designing
            //rptViewer.LocalReport.SetParameters(new Microsoft.Reporting.WebForms.ReportParameter("prmName","santokh"));


            //rptViewer.LocalReport.DataSources.Add(new Microsoft.Reporting.WebForms.ReportDataSource("DataSet1", dt));


            //rptViewer.LocalReport.Refresh();
        }
    }
}