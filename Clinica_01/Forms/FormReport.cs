using Microsoft.Reporting.WinForms;
using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace Clinica_01.Forms
{
    public partial class FormReport : Form
    {
        public FormReport()
        {
            InitializeComponent();
        }

        public FormReport(ReportViewer rv, string path)
        {
            InitializeComponent();

            if (reportViewer == null)
                reportViewer = new ReportViewer();

            this.reportViewer.LocalReport.DataSources.Clear();
            reportViewer.ProcessingMode = ProcessingMode.Local;
            this.reportViewer.LocalReport.EnableExternalImages = true;
            this.reportViewer.LocalReport.ReportEmbeddedResource = path;

            foreach (var item in rv.LocalReport.DataSources)
            {
                this.reportViewer.LocalReport.DataSources.Add(item);
            }
        }

        public FormReport(ReportViewer rv, string path, IList<ReportParameter> listParameters)
        {
            InitializeComponent();

            if (reportViewer == null)
                reportViewer = new ReportViewer();

            this.reportViewer.LocalReport.DataSources.Clear();
            reportViewer.ProcessingMode = ProcessingMode.Local;
            this.reportViewer.LocalReport.EnableExternalImages = true;
            this.reportViewer.LocalReport.ReportEmbeddedResource = path;

            this.reportViewer.LocalReport.SetParameters(listParameters);
            foreach (var item in rv.LocalReport.DataSources)
            {
                this.reportViewer.LocalReport.DataSources.Add(item);
            }
        }

        IList<ReportParameter> listParameters;

        private void FormReport_Load(object sender, EventArgs e)
        {
            //this.reportViewer.LocalReport.Refresh();
            //this.reportViewer.RefreshReport();
            //this.reportViewer1.RefreshReport();
            this.reportViewer.RefreshReport();
        }
    }
}
