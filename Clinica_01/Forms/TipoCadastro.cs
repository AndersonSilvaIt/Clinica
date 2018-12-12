using Data.EF.Repositories;
using Data.Entidades;
using Data.SQLiteORM.Repository;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Windows.Forms;

namespace Clinica_01.Forms
{
    public partial class TipoCadastro : Form
    {
        private static Tipo tipo;
        private static readonly TipoRepository tipoRepository = new TipoRepository();
        private static IList<Tipo> ListTipo;

        public TipoCadastro()
        {
            InitializeComponent();

            AtualizaForm();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(txtServico.Text.Trim()))
                    throw new ErrorMessageException("Serviço não informado, verifique.");

                if (tipo == null)
                    tipo = new Tipo();

                tipo.Descricao = txtServico.Text;
                tipo.Observacao = txtObs.Text;

                if (tipo.Id == 0) 
                    TipoRepositorySQLite.Save(tipo);
                else
                    TipoRepositorySQLite.Update(tipo);

                AtualizaForm();
            }
            catch (ErrorMessageException eme)
            {
                MessageBox.Show(eme.Message, "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex) { }
        }

        private void AtualizaForm()
        {
            txtServico.Text = "";
            txtObs.Text = "";

            if (ListTipo != null)
                ListTipo.Clear();

            ListTipo = TipoRepositorySQLite.GetAll();
            var bindind = new BindingList<Tipo>(ListTipo);
            grdTipo.DataSource = bindind;
            grdTipo.Refresh();
            txtServico.Focus();
            btnDelete.Visible = false;
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            try
            {
                tipoRepository.Delete(tipo);
            }
            catch (Exception ex)
            {

            }
        }

        private void grdTipo_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            Tipo tipo = (Tipo)grdTipo.Rows[e.RowIndex].DataBoundItem;
            txtServico.Text = tipo.Descricao;
            txtObs.Text = tipo.Observacao;

            btnSave.Visible = true;
            btnDelete.Visible = true;
        }

        private void TipoCadastro_Load(object sender, EventArgs e)
        {

        }
    }
}
