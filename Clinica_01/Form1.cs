using Clinica_01.Forms;
using Data.SQLiteORM;
using System;
using System.Windows.Forms;

namespace Clinica_01
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            CadastroCliente frmCad = new CadastroCliente();
            frmCad.ShowDialog();
        }

        private void btnAgenda_Click(object sender, EventArgs e)
        {
            AgendaList frmAgenda = new AgendaList();
            frmAgenda.ShowDialog();
        }

        private void agendaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AgendaList frmAgenda = new AgendaList();
            frmAgenda.ShowDialog();
        }

        private void pacientesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            CadastroCliente frmCliente = new CadastroCliente();
            frmCliente.ShowDialog();
        }

        private void tipoDeMassagensToolStripMenuItem_Click(object sender, EventArgs e)
        {
            TipoCadastro frmTipo = new TipoCadastro();
            frmTipo.ShowDialog();
        }

        private void empresaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FormConfig frmConfig = new FormConfig();
            frmConfig.ShowDialog();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            new Banco();
        }

        private void contatoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            new FormContato().ShowDialog();
        }
    }
}
