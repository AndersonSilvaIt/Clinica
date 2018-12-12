using Data.EF.Repositories;
using Data.Entidades;
using Data.SQLiteORM.Repository;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Clinica_01.Forms
{
    public partial class FormConfig : Form
    {
        private static Empresa empresa;
        private static EmpresaRepository empresaRepository = new EmpresaRepository();
        public FormConfig()
        {
            InitializeComponent();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                if (empresa == null)
                    empresa = new Empresa();

                if (string.IsNullOrWhiteSpace(txtRazaoSocial.Text.Trim()))
                {
                    txtRazaoSocial.Focus();
                    throw new ErrorMessageException("Razão Social precisa ser preenchido.");
                }

                if (string.IsNullOrWhiteSpace(txtCNPJ.Text.Trim()))
                {
                    txtCNPJ.Focus();
                    throw new ErrorMessageException("CNPJ precisa ser preenchido.");
                }

                empresa.RazaoSocial = txtRazaoSocial.Text;
                empresa.CNPJ = txtCNPJ.Text;
                empresa.Socio = txtSocio.Text;
                empresa.Endereco = txtEndereco.Text;
                empresa.Numero = txtNumber.Text;
                empresa.Bairro = txtBairro.Text;
                empresa.Cidade = txtCidade.Text;
                empresa.UF = ddlUF.Text;
                empresa.Fone = txtFone.Text;
                empresa.Celular = txtCelular.Text;
                empresa.Email = txtEmail.Text;
                empresa.CEP = txtCEP.Text;
                if (!string.IsNullOrWhiteSpace(openFileDialog1.FileName) && openFileDialog1.FileName != "openFileDialog1")
                    empresa.Imagem = openFileDialog1.FileName;

                if (empresa.Id > 0)
                {
                    EmpresaRepositorySQLite.Update(empresa);
                    MessageBox.Show("Cadastro atualizado", "Cadastro", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    this.Close();
                }
                else
                {
                    EmpresaRepositorySQLite.Save(empresa);
                    this.Visible = false;
                    Form1 frmDefault = new Form1();
                    frmDefault.ShowDialog();

                    this.Close();
                }
            }
            catch (ErrorMessageException eme)
            {

            }
            catch (Exception ex) { }
        }

        private void btnChooseImage_Click(object sender, EventArgs e)
        {
            openFileDialog1.Filter = "Images (*.BMP;*.JPG;*.GIF,*.PNG,*.TIFF)|*.BMP;*.JPG;*.GIF;*.PNG;*.TIFF";

            DialogResult dr = openFileDialog1.ShowDialog();

            if (dr == DialogResult.OK)
            {
                string arquivo = openFileDialog1.FileName;

                try
                {
                    string extension = System.IO.Path.GetExtension(arquivo.ToUpper());

                    if (extension != ".PNG" && extension != ".BMP" && extension != ".JPG" && extension != ".GIF" && extension != ".TIFF" && extension != ".JPEG")
                        throw new ErrorMessageException("Formato de imagem não compatível.");

                    using (FileStream fs = new FileStream(arquivo, FileMode.Open, FileAccess.Read))
                    {
                        imgLogo.Image = Image.FromStream(fs);
                    }

                    imgLogo.Enabled = true;
                    //btnImgRemove.Visible = true;
                }
                catch (ErrorMessageException eme)
                {
                    MessageBox.Show(eme.Message, "Formato Incorreto", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                catch (Exception ex)
                {
                }
            }
        }

        private void FormConfig_Load(object sender, EventArgs e)
        {
            try
            {
                var empresaAux = EmpresaRepositorySQLite.GetAll();
                if (empresaAux != null && empresaAux.Count > 0)
                {
                    empresa = empresaAux[0];
                    btnUpdate.Visible = false;
                    btnSave.Visible = true;
                    txtRazaoSocial.Text = empresa.RazaoSocial;
                    txtCNPJ.Text = empresa.CNPJ;
                    txtSocio.Text = empresa.Socio;
                    txtEndereco.Text = empresa.Endereco;
                    txtNumber.Text = empresa.Numero;
                    txtBairro.Text = empresa.Bairro;
                    txtCidade.Text = empresa.Cidade;
                    ddlUF.Text = empresa.UF;
                    txtFone.Text = empresa.Fone;
                    txtCelular.Text = empresa.Celular;
                    txtEmail.Text = empresa.Email;
                    txtCEP.Text = empresa.CEP;
                    if (!string.IsNullOrWhiteSpace(empresa.Imagem))
                    {
                        using (FileStream fs = new FileStream(empresa.Imagem, FileMode.Open, FileAccess.Read))
                        {
                            imgLogo.Image = Image.FromStream(fs);
                        }
                    }
                    btnSave.Visible = true;
                    btnUpdate.Visible = false;
                }
                else
                {
                    btnUpdate.Visible = false;
                    btnSave.Visible = true;
                }
            }
            catch { }
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            btnUpdate.Visible = false;
            btnSave.Visible = true;
        }
    }
}