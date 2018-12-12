using Data.EF.Repositories;
using Data.Entidades;
using Data.SQLiteORM.Repository;
using Microsoft.Reporting.WinForms;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace Clinica_01.Forms
{
    public partial class AgendaCadastro : Form
    {
        private static readonly ClienteRepository clientRepository = new ClienteRepository();
        private static readonly AgendaRepository agendaRepository = new AgendaRepository();
        private static Agenda agenda;
        protected ReportViewer reportViewer;
        public AgendaCadastro()
        {
            InitializeComponent();

            var listaPaciente = ClienteRepositorySQLite.GetAll();
            AutoCompleteStringCollection dados = new AutoCompleteStringCollection();
            foreach (var item in listaPaciente)
            {
                dados.Add(item.Nome + " • " + item.Id);
            }
            txtPaciente.AutoCompleteCustomSource = dados;
            FillDdl();


            btnUpdate.Visible = false;
            btnDelete.Visible = false;
            btnSaveUpdate.Visible = false;
            txtPaciente.Focus();
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

        public AgendaCadastro(Agenda _agenda)
        {
            InitializeComponent();
            agenda = _agenda;
            var listaPaciente = ClienteRepositorySQLite.GetAll();
            AutoCompleteStringCollection dados = new AutoCompleteStringCollection();
            foreach (var item in listaPaciente)
            {
                dados.Add(item.Nome + " • " + item.Id);
            }
            txtPaciente.AutoCompleteCustomSource = dados;

            FillDdl();

            btnUpdate.Visible = false;
            btnDelete.Visible = false;
            btnSaveUpdate.Visible = false;
            DirtyFields();
            txtPaciente.Focus();
        }


        private void btnAgendar_Click(object sender, EventArgs e)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(txtPaciente.Text.Trim()))
                {
                    txtPaciente.Focus();
                    throw new ErrorMessageException("Informe um paciente.");
                }

                GetFields();

                AgendaRepositorySQLite.Save(agenda);

                string message = string.Format(@"                                     === AGENDA ===
                                                 Paciente: {0} 
                                                 Data: {1} {2}Hrs
                                                 Tipo: {3}
                                               CRIADA COM SUCESSO!", agenda.PacienteNome, agenda.Data.ToString("dd/MM/yyyy"), agenda.Horas, agenda.Tipo);

                MessageBox.Show(message, "Agenda", MessageBoxButtons.OK, MessageBoxIcon.None);
                this.Close();
            }
            catch (ErrorMessageException eme)
            {
                MessageBox.Show(eme.Message, "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex) { }
        }

        private void GetFields()
        {
            if (agenda == null)
                agenda = new Agenda();

            var hora = txtHora.Text.Replace(":", "").Trim();
            if (string.IsNullOrWhiteSpace(hora))
            {
                txtHora.Focus();
                throw new ErrorMessageException("Por gentileza, informe a Hora da consulta.");
            }
            DateTime hora02 = DateTime.Now;
            if (!DateTime.TryParse(txtHora.Text, out hora02))
            {
                txtHora.Focus();
                throw new ErrorMessageException("Hora da consulta inválida, verifique!");
            }

            if (txtPaciente.Text.Contains("•"))
            {
                agenda.PacienteNome = txtPaciente.Text.Split('•')[0];
                var idPaciente = 0;
                int.TryParse(txtPaciente.Text.Split('•')[1], out idPaciente);
                agenda.IdPaciente = idPaciente;
            }
            else
            {
                DialogResult result = MessageBox.Show("Paciente não cadastrado, deseja cadastrar? ", "Paciente não cadastrado", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (result == DialogResult.Yes)
                {
                    var clienteOldLast = clientRepository.LastId();

                    CadastroCliente frmCadastroCliente = new CadastroCliente(5, txtPaciente.Text);
                    frmCadastroCliente.ShowDialog();
                    var clienteOldLastOrDefault = clientRepository.LastId();

                    if (clienteOldLast.Id != clienteOldLastOrDefault.Id)
                    {
                        var listaPaciente = clientRepository.GetAll();
                        AutoCompleteStringCollection dados = new AutoCompleteStringCollection();
                        foreach (var item in listaPaciente)
                        {
                            dados.Add(item.Nome + " • " + item.Id);
                        }
                        txtPaciente.AutoCompleteCustomSource = dados;

                        txtPaciente.Text = clienteOldLastOrDefault.Nome + " • " + clienteOldLastOrDefault.Id;
                    }
                }
            }

            agenda.Data = Convert.ToDateTime(dateTimePicker1.Text);
            agenda.Horas = txtHora.Text.Trim();
            agenda.Tipo = ddlTipo.Text;
            agenda.Observacao = txtObs.Text;
            if (!string.IsNullOrWhiteSpace(txtValor.Text.Trim()))
            {
                decimal valor = 0;

                if (!decimal.TryParse(txtValor.Text.Trim(), out valor))
                {
                    txtValor.Focus();
                    throw new ErrorMessageException("Valor da consulta inválido, verifique.");
                }

                agenda.Valor = valor;
            }

            if (string.IsNullOrWhiteSpace(ddlSituacao.SelectedText))
                agenda.Situation = "Agendado";
            else
                agenda.Situation = ddlSituacao.SelectedText;

            Agenda agendaOld = new Agenda();
            agendaOld = AgendaRepositorySQLite.GetAgenda(agenda.Data, agenda.Horas, agenda.Id);

            if (agendaOld != null)
            {
                if (string.IsNullOrWhiteSpace(agendaOld.Situation.Trim()) || agendaOld.Situation == "Agendado")
                {
                    throw new ErrorMessageException(string.Format("Já existe uma agenda para a data {0} - {1}", agenda.Data.ToString("dd/MM/yyyy"),
                    agenda.Horas));
                }

            }

        }


        private void btnTipo_Click(object sender, EventArgs e)
        {
            //colocar uma imagem de lupa neste botão e no botão do Paciente
            TipoCadastro frmTipo = new TipoCadastro();
            frmTipo.ShowDialog();

            FillDdl();
        }

        private void btnPaciente_Click(object sender, EventArgs e)
        {
            //colocar uma imagem de lupa neste botão e no botão do Paciente
        }

        private void btnSaveUpdate_Click(object sender, EventArgs e)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(txtPaciente.Text.Trim()))
                    throw new ErrorMessageException("Informe um paciente.");

                GetFields();
                AgendaRepositorySQLite.Update(agenda);

                MessageBox.Show("Atualização", "Agenda Atualizada.", MessageBoxButtons.OK, MessageBoxIcon.Hand);
                this.Close();
            }
            catch (Exception ex) { }
        }

        private void EnableFields(bool enable)
        {
            txtPaciente.Enabled = enable;
            dateTimePicker1.Enabled = enable;
            txtHora.Enabled = enable;
            ddlTipo.Enabled = enable;
            btnPaciente.Enabled = enable;
            btnTipo.Enabled = enable;
            txtObs.Enabled = enable;
            txtValor.Enabled = enable;
        }

        private void DirtyFields()
        {
            if (agenda.IdPaciente > 0)
                txtPaciente.Text = agenda.PacienteNome + " • " + agenda.Id;
            else
                txtPaciente.Text = agenda.PacienteNome;

            dateTimePicker1.Text = agenda.Data.ToString("dd/MM/yyyy");

            txtHora.Text = agenda.Horas;
            ddlTipo.Text = agenda.Tipo;
            txtObs.Text = agenda.Observacao;
            if (agenda.Valor > 0)
                txtValor.Text = agenda.Valor.ToString("#,0.00");

            ddlSituacao.SelectedText = agenda.Situation;
            btnAgendar.Visible = false;
            btnSaveUpdate.Visible = true;
            btnPrint.Visible = true;
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            EnableFields(true);
            btnUpdate.Visible = false;
            btnSaveUpdate.Visible = true;
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            agendaRepository.Delete(agenda);

        }

        private void btnPrint_Click(object sender, EventArgs e)
        {
            string path = @"Clinica_01.Reports.AgendaReport.rdlc";
            if (this.reportViewer == null)
                this.reportViewer = new ReportViewer();

            var ListAgenda = AgendaRepositorySQLite.GetAll().ToList<Agenda>();

            this.reportViewer.LocalReport.DataSources.Add(new ReportDataSource("DataSet2", ListAgenda));

            FormReport frmReport = new FormReport(this.reportViewer, path, GetParametersToPrint());
            frmReport.ShowDialog();
        }

        private IList<ReportParameter> GetParametersToPrint()
        {
            var paciente = txtPaciente.Text;
            if (txtPaciente.Text.Contains("•"))
                paciente = txtPaciente.Text.Split('•')[0].Trim();

            EmpresaRepository empresaRepository = new EmpresaRepository();
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


            ReportParameter Nome = new ReportParameter("Nome", agenda.PacienteNome);
            ReportParameter Data = new ReportParameter("Data", agenda.Data.ToString("dd/MM/yyyy"));
            ReportParameter Horas = new ReportParameter("Horas", agenda.Horas);
            ReportParameter Servico = new ReportParameter("Servico", agenda.Tipo);
            ReportParameter Obs = new ReportParameter("Obs", agenda.Observacao);
            ReportParameter Valor = new ReportParameter("Valor", agenda.Valor.ToString());



            if (string.IsNullOrWhiteSpace(empresaAux[0].Imagem.Trim()))
            {
                listReportParameter = new List<ReportParameter>(){ Nome,Data,Horas,Servico, Obs, Valor,
                RazaoSocial, CNPJ, Endereco, Numero, Bairro, Cidade, CEP, Telefone, Celular, Email, UF};
            }
            else
            {
                ReportParameter Imagem = new ReportParameter("Imagem", empresaAux[0].Imagem);
                listReportParameter = new List<ReportParameter>(){ Nome,Data,Horas,Servico, Obs, Valor,
                RazaoSocial, CNPJ, Endereco, Numero, Bairro, Cidade, CEP, Telefone, Celular, Email, Imagem, UF};
            }


            return listReportParameter;
        }

        private void AgendaCadastro_Load(object sender, EventArgs e)
        {

        }
    }
}
