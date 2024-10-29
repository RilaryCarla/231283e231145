using _231283e231145.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace _231283e231145.Views
{
    public partial class FrmMarcas : Form
    {
        Marcas m;
        public FrmMarcas()
        {
            InitializeComponent();
            txtNome.Focus();
            CarregarGrid("");

        }

        public void Limpar()
        {
            txtId.Clear();
            txtNome.Clear();          
            txtPesquisa.Clear();

        }


        private void btnIncluir_Click(object sender, EventArgs e)
        {
           
                if (txtNome.Text == string.Empty) return;

                m = new Marcas()
                {
                    nome = txtNome.Text
                };

                m.Incluir();

                Limpar();
                CarregarGrid("");
           


        }

        public void CarregarGrid(string pesquisa)
        {
            m = new Marcas()
            {
                nome = pesquisa
            };

            dgvMarca.DataSource = m.Consultar();
        }

        private void btnAlterar_Click(object sender, EventArgs e)
        {
            m = new Marcas()
            {
                nome = txtNome.Text,
                id = int.Parse(txtId.Text)
              
            };

            m.Alterar();

            Limpar();
            CarregarGrid("");
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            Limpar();
            txtNome.Focus();
        }

        private void btnExcluir_Click(object sender, EventArgs e)
        {
            m = new Marcas()
            {
                id = int.Parse(txtId.Text)    
            };

            m.Excluir();

            Limpar();
            CarregarGrid("");
        }

        private void btnPesquisar_Click(object sender, EventArgs e)
        {
            CarregarGrid(txtPesquisa.Text);
        }

        private void bntSair_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void dgvMarca_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            txtNome.Text = dgvMarca.CurrentRow.Cells[1].Value.ToString();
            txtId.Text = dgvMarca.CurrentRow.Cells[0].Value.ToString();
        }
    }
}
