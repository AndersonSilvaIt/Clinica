using Data.EF.Repositories;
using Data.Entidades;
using Data.SQLiteORM.Repository;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Windows.Forms;

namespace Clinica_01.Forms
{
    public partial class FormContato : Form
    {
        private static Tipo tipo;
        private static readonly TipoRepository tipoRepository = new TipoRepository();
        private static IList<Tipo> ListTipo;

        public FormContato()
        {
            InitializeComponent();

            //AtualizaForm();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
           
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

        private void TipoCadastro_Load(object sender, EventArgs e)
        {

        }
    }
}
