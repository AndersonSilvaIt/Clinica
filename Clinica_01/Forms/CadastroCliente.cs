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
    public partial class CadastroCliente : Form
    {
        private static readonly ClienteRepositorySQLite clientRepository = new ClienteRepositorySQLite();
        private Cliente cliente;
        private IList<Cliente> ListClientes;
        private static int ClickHeaderNome, ClickHeaderFone, ClickHeaderCell, ClickHeaderEmail, ClickHeaderUF = 0;
        private static int type;
        protected ReportViewer reportViewer;
        public CadastroCliente()
        {
            InitializeComponent();
            AtualizaForm();
        }

        public CadastroCliente(int _type, string nome)
        {
            InitializeComponent();
            //AtualizaForm();
            type = 5;
            EnableFields(true);
            txtNome.Text = nome;

            btnNew.Visible = false;
            btnDelete.Visible = false;
            btnUpdate.Visible = false;
            btnSave.Visible = true;
            btnCancel.Visible = true;
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(txtNome.Text.Trim()))
                {
                    MessageBox.Show("Preencha o Nome do Paciente!", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtNome.Focus();
                    return;
                }
                GetDados();

                if (type == 5)
                {
                    ClienteRepositorySQLite.Save(cliente);
                    MessageBox.Show("Cliente salvo com sucesso!");
                    this.Close();
                    return;
                }

                if (cliente != null)
                {
                    if (cliente.Id == 0)
                    {
                        ClienteRepositorySQLite.Save(cliente);
                        MessageBox.Show("Cliente salvo com sucesso!");
                    }
                    else
                    {
                        ClienteRepositorySQLite.Update(cliente);
                        MessageBox.Show("Cliente atualizado com sucesso!");
                    }
                }

                AtualizaForm();
            }catch(ErrorMessageException eme)
            {
                MessageBox.Show(eme.Message, "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch(Exception ex) { }
        }

        private void GetDados()
        {
            if (cliente == null)
                cliente = new Cliente();

            cliente.Nome = txtNome.Text;
            cliente.CPF = txtCPF.Text;
            cliente.RG = txtRG.Text;
            if (!string.IsNullOrWhiteSpace(txtDtNascimento.Text.Replace("/", "").Trim()))
            {
                DateTime data;
                if (!DateTime.TryParse(txtDtNascimento.Text, out data))
                    throw new ErrorMessageException("Data de nascimento inválida, verifique.");
                cliente.DataNascimento = data;
            }

            if (!string.IsNullOrWhiteSpace(txtFoneResidencial.Text
                                                        .Replace("(", "")
                                                        .Replace(")", "")
                                                        .Replace("-", "").Trim()))
                cliente.FoneResidencial = txtFoneResidencial.Text;
            else
                cliente.FoneResidencial = "";

            cliente.Celular = txtCelular.Text;
            cliente.Email = txtEmail.Text;
            cliente.Rua = txtRua.Text;
            cliente.Numero = txtNumero.Text;
            cliente.Bairro = txtBairro.Text;
            cliente.Cidade = txtCidade.Text;
            cliente.UF = ddlUF.Text;
        }

        private void DirtyFields()
        {
            txtNome.Text = cliente.Nome;
            txtCPF.Text = cliente.CPF;
            txtRG.Text = cliente.RG;

            if (cliente.DataNascimento > new DateTime(1800, 1, 1))
                txtFoneResidencial.Text = cliente.DataNascimento.ToString("dd/MM/yyyy");
            txtDtNascimento.Text = cliente.FoneResidencial;
            txtCelular.Text = cliente.Celular;
            txtEmail.Text = cliente.Email;
            txtRua.Text = cliente.Rua;
            txtNumero.Text = cliente.Numero;
            txtBairro.Text = cliente.Bairro;
            txtCidade.Text = cliente.Cidade;
            ddlUF.Text = cliente.UF;
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            try
            {
                DialogResult result = MessageBox.Show("Deseja excluir esse cliente? ", "Aviso", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
                if (result == DialogResult.OK)
                {
                    ClienteRepositorySQLite.Delete(cliente);
                    MessageBox.Show("Cliente excluído com sucesso!");

                    AtualizaForm();
                }
            }
            catch (Exception ex)
            {

            }
        }

        private void ClearFields()
        {
            txtNome.Text = "";
            txtCPF.Text = "";
            txtRG.Text = "";
            txtFoneResidencial.Text = "";
            txtDtNascimento.Text = "";
            txtCelular.Text = "";
            txtEmail.Text = "";
            txtRua.Text = "";
            txtNumero.Text = "";
            txtBairro.Text = "";
            txtCidade.Text = "";
            txtNome.Focus();
        }

        private void btnNew_Click(object sender, EventArgs e)
        {
            btnDelete.Visible = false;
            btnUpdate.Visible = false;
            btnNew.Visible = false;
            btnSave.Visible = true;
            btnCancel.Visible = true;
            EnableFields(true);
            ClearFields();
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            EnableFields(true);
            btnNew.Visible = true;
            btnUpdate.Visible = false;
            btnCancel.Visible = true;
            btnDelete.Visible = false;
            btnSave.Visible = true;
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            if (type == 5)
            {
                this.Close();
                return;
            }

            AtualizaForm();
        }

        private void groupBox2_Enter(object sender, EventArgs e)
        {

        }

        private void btnPrint_Click(object sender, EventArgs e)
        {
            string path = @"Clinica_01.Reports.ClienteReport.rdlc";

            this.reportViewer = new ReportViewer();

            this.reportViewer.LocalReport.DataSources.Add(new ReportDataSource("DataSet2", ListClientes));

            FormReport frmReport = new FormReport(this.reportViewer, path, GetParametersToPrint());
            frmReport.ShowDialog();
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

        private void CadastroCliente_Load(object sender, EventArgs e)
        {
            grdClientes.DataSource = ClienteRepositorySQLite.GetAll();
            grdClientes.Refresh();

            var teste = "";
        }

        private void AtualizaForm()
        {
            ClearFields();
            btnUpdate.Visible = false;
            if (ListClientes != null)
                ListClientes.Clear();

            ListClientes = ClienteRepositorySQLite.GetAll();
            var binding = new BindingList<Cliente>(ListClientes);

            grdClientes.DataSource = binding;
            grdClientes.Refresh();

            cliente = new Cliente();
            txtNome.Focus();
            btnNew.Visible = true;
            btnUpdate.Visible = false;
            btnDelete.Visible = false;
            btnSave.Visible = false;
            btnCancel.Visible = false;
            EnableFields(false);
        }

        private void grdClientes_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex > -1 && e.RowIndex > -1)
            {
                cliente = (Cliente)grdClientes.Rows[e.RowIndex].DataBoundItem;
                DirtyFields();
                EnableFields(false);
                btnSave.Visible = true;
                btnUpdate.Visible = true;
                btnDelete.Visible = true;
                btnCancel.Visible = false;
                btnSave.Visible = false;
            }
        }

        private void grdClientes_ColumnHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (e.ColumnIndex > -1)
            {
                switch (e.ColumnIndex)
                {
                    case 0:
                        if (ClickHeaderNome == 0)
                        {
                            ListClientes = ListClientes.OrderBy(p => p.Nome).ToList();
                            ClickHeaderNome = 1;
                        }
                        else
                        {
                            ListClientes = ListClientes.OrderByDescending(p => p.Nome).ToList();
                            ClickHeaderNome = 0;
                        }
                        grdClientes.DataSource = new BindingList<Cliente>(ListClientes);
                        break;

                    case 4:
                        if (ClickHeaderFone == 0)
                        {
                            ListClientes = ListClientes.OrderBy(p => p.FoneResidencial).ToList();
                            ClickHeaderFone = 1;
                        }
                        else
                        {
                            ListClientes = ListClientes.OrderByDescending(p => p.FoneResidencial).ToList();
                            ClickHeaderFone = 0;
                        }

                        grdClientes.DataSource = new BindingList<Cliente>(ListClientes);
                        break;

                    case 5: //celular
                        if (ClickHeaderCell == 0)
                        {
                            ListClientes = ListClientes.OrderBy(p => p.Celular).ToList();
                            ClickHeaderCell = 1;
                        }
                        else
                        {
                            ListClientes = ListClientes.OrderByDescending(p => p.Celular).ToList();
                            ClickHeaderCell = 0;
                        }
                        grdClientes.DataSource = new BindingList<Cliente>(ListClientes);
                        break;

                    case 6: //email
                        if (ClickHeaderEmail == 0)
                        {
                            ListClientes = ListClientes.OrderBy(p => p.Email).ToList();
                            ClickHeaderEmail = 1;
                        }
                        else
                        {
                            ListClientes = ListClientes.OrderByDescending(p => p.Email).ToList();
                            ClickHeaderEmail = 0;
                        }
                        grdClientes.DataSource = new BindingList<Cliente>(ListClientes);
                        break;

                    case 11:// UF
                        if (ClickHeaderUF == 0)
                        {
                            ListClientes = ListClientes.OrderBy(p => p.UF).ToList();
                            ClickHeaderUF = 1;
                        }
                        else
                        {
                            ListClientes = ListClientes.OrderByDescending(p => p.UF).ToList();
                            ClickHeaderUF = 0;
                        }
                        grdClientes.DataSource = new BindingList<Cliente>(ListClientes);
                        break;
                }
            }
        }

        private void EnableFields(bool enable)
        {
            txtNome.Enabled = enable;
            txtCPF.Enabled = enable;
            txtRG.Enabled = enable;
            txtFoneResidencial.Enabled = enable;
            txtDtNascimento.Enabled = enable;
            txtCelular.Enabled = enable;
            txtEmail.Enabled = enable;
            txtRua.Enabled = enable;
            txtNumero.Enabled = enable;
            txtBairro.Enabled = enable;
            txtCidade.Enabled = enable;
            ddlUF.Enabled = enable;
        }
    }
}
