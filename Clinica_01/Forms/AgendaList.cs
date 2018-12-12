using Data.EF.Repositories;
using Data.Entidades;
using Data.SQLiteORM.Repository;
using Microsoft.Reporting.WinForms;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Windows.Forms;

namespace Clinica_01.Forms
{
    public partial class AgendaList : Form
    {
        //private static readonly ClienteRepository clientRepository = new ClienteRepository();
        //private static readonly AgendaRepository agendaRepository = new AgendaRepository();
        private static readonly ClienteRepositorySQLite clientRepository = new ClienteRepositorySQLite();
        private static readonly AgendaRepositorySQLite agendaRepository = new AgendaRepositorySQLite();
        private static int HeaderClickPaciente, ClickHeaderData, ClickHeaderHoras, ClickHeaderTipo = 0;
        private List<Agenda> ListAgenda;
        protected ReportViewer reportViewer;
            
        public AgendaList()
        {
            InitializeComponent();

            AtualizaForm();
        }

        private void btnNew_Click(object sender, EventArgs e)
        {
            
            AgendaCadastro frmAgenda = new AgendaCadastro();
            frmAgenda.ShowDialog();

            AtualizaForm();
        }

        private void AtualizaForm()
        {
            if (ListAgenda != null)
                ListAgenda.Clear();

            ListAgenda = AgendaRepositorySQLite.GetAll().ToList<Agenda>();
            var a = ListAgenda.OrderBy(p => p.PacienteNome).ThenBy(p => p.Data).ThenBy(p => p.Horas).ToList();
            var binding = new BindingList<Agenda>(a);

            grdAgenda.DataSource = binding;
            grdAgenda.Refresh();

            lblResults.Text = ListAgenda.Count.ToString() + " registros encontrados";

            var listaPaciente = ClienteRepositorySQLite.GetAll();
            AutoCompleteStringCollection dados = new AutoCompleteStringCollection();
            foreach (var item in listaPaciente)
            {
                dados.Add(item.Nome + " • " + item.Id);
            }

            txtPaciente.AutoCompleteCustomSource = dados;

            txtPaciente.Text = "";
            txtDataInicial.Text = "__/__/____";
            txtDataFim.Text = "__/__/____";
            txtHoraInicial.Text = "__:__";
            txtHoraInicial.Text = "__:__";

            FillDdl();
        }

        private void grdAgenda_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex > -1 && e.ColumnIndex > -1)
            {
                var _agenda = (Agenda)grdAgenda.Rows[e.RowIndex].DataBoundItem;

                AgendaCadastro frmAgenda = new AgendaCadastro(_agenda);
                frmAgenda.ShowDialog();
            }
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            try
            {
                DateTime dataInicial, dataFinal, horaInicial, horaFinal;
                string dataInicialString = "", dataFinalString = "";
                string paciente = "";
                string horaInicialString = "", horaFinalString = "";

                if (txtPaciente.Text.Contains("•"))
                    paciente = txtPaciente.Text.Split('•')[0].Trim();
                else
                    paciente = txtPaciente.Text.Trim();

                if (!string.IsNullOrWhiteSpace(txtDataInicial.Text.Replace("/", "").Trim()))
                {
                    if (!DateTime.TryParse(txtDataInicial.Text, out dataInicial))
                        throw new ErrorMessageException("Data Inicial inválida para a pesquisa.");

                    dataInicialString = txtDataInicial.Text;
                }

                if (!string.IsNullOrWhiteSpace(txtDataFim.Text.Replace("/", "").Trim()))
                {
                    if (!DateTime.TryParse(txtDataInicial.Text, out dataFinal))
                        throw new ErrorMessageException("Data Final inválida para a pesquisa.");

                    dataFinalString = txtDataFim.Text;
                }

                if (!string.IsNullOrWhiteSpace(txtHoraInicial.Text.Replace(":", "").Trim()))
                {
                    if (!DateTime.TryParse(txtHoraInicial.Text, out horaInicial))
                        throw new ErrorMessageException("Hora iniciaç inválida para a pesquisa.");

                    horaInicialString = txtHoraInicial.Text;
                }

                if (!string.IsNullOrWhiteSpace(txtHoraFim.Text.Replace(":", "").Trim()))
                {
                    if (!DateTime.TryParse(txtHoraFim.Text, out horaFinal))
                        throw new ErrorMessageException("Hora Final inválida para a pesquisa.");

                    horaFinalString = txtHoraFim.Text;
                }

                if (ListAgenda != null)
                    ListAgenda.Clear();

                ListAgenda = agendaRepository.SearchAgenda(paciente, dataInicialString, dataFinalString, 
                                                            horaInicialString, horaFinalString, ddlTipo.Text, ddlSituacao.Text).ToList();

                var binding = new BindingList<Agenda>(ListAgenda);

                grdAgenda.DataSource = binding;
                grdAgenda.Refresh();

                lblResults.Text = ListAgenda.Count.ToString() + " registros encontrados";

            }
            catch (ErrorMessageException eme)
            {

            }
            catch (Exception ex) { }
        }

        private void btnPrint_Click(object sender, EventArgs e)
        {
            string path = @"Clinica_01.Reports.AgendaReportList.rdlc";
            if (this.reportViewer == null)
                this.reportViewer = new ReportViewer();

            this.reportViewer.LocalReport.DataSources.Add(new ReportDataSource("DataSet2", ListAgenda));

            FormReport frmReport = new FormReport(this.reportViewer, path, GetParametersToPrint());
            frmReport.ShowDialog();
        }

        private void AgendaList_Load(object sender, EventArgs e)
        {

        }

        private void FillDdl()
        {
            TipoRepository tipoRepository = new TipoRepository();
            var listTipos = TipoRepositorySQLite.GetAll();
            var list02 = new List<Tipo>();
            list02.Add(new Tipo() { Descricao = "" });
            list02.AddRange(listTipos);

            ddlTipo.DataSource = list02;
            ddlTipo.DisplayMember = "Descricao";
        }

        private IList<ReportParameter> GetParametersToPrint()
        {
            var empresaAux = EmpresaRepositorySQLite.GetAll();
            IList<ReportParameter> listReportParameter;
            ReportParameter RazaoSocial = new ReportParameter("RazaoSocial", empresaAux[0].RazaoSocial);
            ReportParameter CNPJ = new ReportParameter("CNPJ", empresaAux[0].CNPJ);
            ReportParameter Endereco = new ReportParameter("Endereco", empresaAux[0].Endereco);
            ReportParameter Numero = new ReportParameter("Numero", empresaAux[0].Numero);
            ReportParameter Bairro = new ReportParameter("Bairro", empresaAux[0].Bairro);
            ReportParameter Cidade = new ReportParameter("Cidade", empresaAux[0].Cidade);
            ReportParameter UF = new ReportParameter("UF", empresaAux[0].UF);
            ReportParameter CEP = new ReportParameter("CEP", empresaAux[0].CEP);
            ReportParameter Telefone = new ReportParameter("Telefone", empresaAux[0].Fone);
            ReportParameter Celular = new ReportParameter("Celular", empresaAux[0].Fone);
            ReportParameter Email = new ReportParameter("Email", empresaAux[0].Email);

            if (string.IsNullOrWhiteSpace(empresaAux[0].Imagem.Trim()))
            {
                listReportParameter = new List<ReportParameter>(){ RazaoSocial, CNPJ, Endereco, Numero, Bairro,
                                                                    Cidade, CEP, Telefone, Celular, Email, UF};
            }
            else
            {
                ReportParameter Imagem = new ReportParameter("Imagem", empresaAux[0].Imagem);
                listReportParameter = new List<ReportParameter>(){ RazaoSocial, CNPJ, Endereco, Numero, Bairro,
                                                                    Cidade, CEP, Telefone, Celular, Email, Imagem, UF};
            }

            return listReportParameter;
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            status02.Text = DateTime.Now.ToString("                          dd/MM/yyyy - HH:ss");
        }

        private void btnRefresg_Click(object sender, EventArgs e)
        {
            AtualizaForm();
        }

        private void grdAgenda_ColumnHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (e.ColumnIndex > -1)
            {
                switch (e.ColumnIndex)
                {
                    case 2:
                        if (HeaderClickPaciente == 0)
                        {
                            ListAgenda = ListAgenda.OrderBy(p => p.PacienteNome).ThenBy(p => p.Data).ThenBy(p => p.Horas).ThenBy(p => p.Tipo).ToList();
                            HeaderClickPaciente = 1;
                        }
                        else
                        {
                            ListAgenda = ListAgenda.OrderByDescending(p => p.PacienteNome).ThenBy(p => p.Data).ThenBy(p => p.Horas).ThenBy(p => p.Tipo).ToList();
                            HeaderClickPaciente = 0;
                        }
                        grdAgenda.DataSource = new BindingList<Agenda>(ListAgenda);
                        break;

                    case 3:
                        if (ClickHeaderData == 0)
                        {
                            ListAgenda = ListAgenda.OrderBy(p => p.Data).ThenBy(p => p.Horas).ThenBy(p => p.PacienteNome).ThenBy(p => p.Tipo).ToList();
                            ClickHeaderData = 1;
                        }
                        else
                        {
                            ListAgenda = ListAgenda.OrderByDescending(p => p.Data).ThenBy(p => p.Horas).ThenBy(p => p.PacienteNome).ThenBy(p => p.Tipo).ToList();
                            ClickHeaderData = 0;
                        }

                        grdAgenda.DataSource = new BindingList<Agenda>(ListAgenda);
                        break;

                    case 8: //celular
                        if (ClickHeaderHoras == 0)
                        {
                            ListAgenda = ListAgenda.OrderBy(p => p.Horas).ThenBy(p => p.Data).ThenBy(p => p.PacienteNome).ThenBy(p => p.Tipo).ToList();
                            ClickHeaderHoras = 1;
                        }
                        else
                        {
                            ListAgenda = ListAgenda.OrderByDescending(p => p.Horas).ThenBy(p => p.Data).ThenBy(p => p.PacienteNome).ThenBy(p => p.Tipo).ToList();
                            ClickHeaderHoras = 0;
                        }
                        grdAgenda.DataSource = new BindingList<Agenda>(ListAgenda);
                        break;

                    case 5: //email
                        if (ClickHeaderTipo == 0)
                        {
                            ListAgenda = ListAgenda.OrderBy(p => p.Tipo).ThenBy(p => p.PacienteNome).ThenBy(p => p.Data).ThenBy(p => p.Horas).ToList();
                            ClickHeaderTipo = 1;
                        }
                        else
                        {
                            ListAgenda = ListAgenda.OrderByDescending(p => p.Tipo).ThenBy(p => p.PacienteNome).ThenBy(p => p.Data).ThenBy(p => p.Horas).ToList();
                            ClickHeaderTipo = 0;
                        }
                        grdAgenda.DataSource = new BindingList<Agenda>(ListAgenda);
                        break;
                }
            }

        }
    }
}

