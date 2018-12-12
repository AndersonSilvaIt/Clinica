using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Clinica_01.Forms
{
    public partial class FormRV : Form
    {
        public FormRV()
        {
            InitializeComponent();
        }

        //public FormRV(ReportViewer rv)
        //{
        //    InitializeComponent();
        //    if (reportViewer == null)
        //        reportViewer = new ReportViewer();
        //
        //    this.reportViewer.LocalReport.DataSources.Clear();
        //    this.reportViewer = rv;
        //}

        //public FormRV(ReportViewer rv, string path, IList<ReportParameter> listParameters)
        //{
        //    InitializeComponent();

        //    //if (reportViewer == null)
        //    //    reportViewer = new ReportViewer();
        //    //
        //    //this.reportViewer.LocalReport.DataSources.Clear();
        //    //reportViewer.ProcessingMode = ProcessingMode.Local;
        //    //this.reportViewer.LocalReport.EnableExternalImages = true;
        //    //this.reportViewer.LocalReport.ReportEmbeddedResource = path;
        //    //
        //    //this.reportViewer.LocalReport.SetParameters(listParameters);
        //    //
        //    //foreach (var item in rv.LocalReport.DataSources)
        //    //{
        //    //    this.reportViewer.LocalReport.DataSources.Add(item);
        //    //}
        //}   //

        //public FormRV(ReportViewer rv, string path)
        //{
        //    //InitializeComponent();
        //    //
        //    //if (reportViewer == null)
        //    //    reportViewer = new ReportViewer();
        //    //
        //    //this.reportViewer.LocalReport.DataSources.Clear();
        //    //reportViewer.ProcessingMode = ProcessingMode.Local;
        //    //this.reportViewer.LocalReport.EnableExternalImages = true;
        //    //this.reportViewer.LocalReport.ReportEmbeddedResource = path;
        //    //
        //    //foreach (var item in rv.LocalReport.DataSources)
        //    //{
        //    //    this.reportViewer.LocalReport.DataSources.Add(item);
        //    //}
        //}

        private void FormRV_Load(object sender, EventArgs e)
        {
            //this.reportViewer.LocalReport.Refresh();
            //this.reportViewer.RefreshReport();
            //this.reportViewer1.RefreshReport();
        }
    }
}
