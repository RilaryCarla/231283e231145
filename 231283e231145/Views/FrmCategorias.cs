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
    public partial class FrmCategorias : Form
    {
        Categorias c;

        public FrmCategorias()
        {
            InitializeComponent();
            txtCategoria.Focus();
            CarregarGrid("");
        }

        private void Limpar()
        {
           txtid.Clear();
           txtCategoria.Clear();
           txtPesquisa.Clear();    
        }

        public void CarregarGrid(string pesquisa)
        {
            c = new Categorias()
            {
                Categoria = pesquisa
            };

            dgvCategorias.DataSource = c.Consultar();

            

        }
        private void btnIncluir_Click(object sender, EventArgs e)
        {
            if (txtCategoria.Text == string.Empty) return;

            c = new Categorias()
            {
                Categoria = txtCategoria.Text
            };

            c.Incluir();

            Limpar();
            CarregarGrid("");
            

        }

        private void btnExcluir_Click(object sender, EventArgs e)
        {
            c = new Categorias()
            {
                Id = int.Parse(txtid.Text),
            };

            c.Excluir();

            Limpar();
            CarregarGrid("");
        }

        private void btnAlterar_Click(object sender, EventArgs e)
        {
            c = new Categorias()
            {

                Categoria = txtCategoria.Text,
                Id = int.Parse( txtid.Text)


            };

            c.Alterar();
            Limpar();
            CarregarGrid("");
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            Limpar();
            CarregarGrid("");

            txtCategoria.Focus();

        }

        private void btnPesquisar_Click(object sender, EventArgs e)
        {
           CarregarGrid(txtCategoria.Text); 
        }

        private void btnFechar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

       

        private void dgvCategorias_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            txtCategoria.Text = dgvCategorias.CurrentRow.Cells[1].Value.ToString();
            txtid.Text = dgvCategorias.CurrentRow.Cells[0].Value.ToString();
        }
    }
}
