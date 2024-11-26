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
    public partial class FrmProdutos : Form
    {
        Produto p;
        Marcas m;
        Categorias c;
        public FrmProdutos()
        {
            InitializeComponent();
        }

        public void Limpar()
        {
            txtDescricao.Clear();
            txtEstoque.Clear();
            txtId.Clear();
            txtValor.Clear();
            cboCategoria.SelectedIndex = -1;
            cboMarcas.SelectedIndex = -1;
        }

        public void CarregarGrid(string pesquisa)
        {
            p = new Produto()
            {
                Descricao = pesquisa
            };

            dgvProdutos.DataSource = p.Consultar();
        }

        public void btnIncluir_Click(object sender, EventArgs e)
        {

            if (txtDescricao.Text == "") return;

            p = new Produto()
            {
                Descricao = txtDescricao.Text,
                Estoque = double.Parse(txtEstoque.Text),
                ValorVenda = double.Parse(txtValor.Text),
                IdMarca = (int)cboMarcas.SelectedValue,
                IdCategoria = (int)cboCategoria.SelectedValue
            };
            p.Incluir();

            Limpar();
            CarregarGrid("");

        }

        public void btnAlterar_Click(object sender, EventArgs e)
        {
            if (txtDescricao.Text == "") return;

            p = new Produto()
            {
                Id = int.Parse(txtId.Text),
                Descricao = txtDescricao.Text,
                Estoque = double.Parse(txtEstoque.Text),
                ValorVenda = double.Parse(txtValor.Text),
                IdMarca = (int)cboMarcas.SelectedValue,
                IdCategoria = (int)cboCategoria.SelectedValue
            };
            p.Alterar();

            Limpar();
            CarregarGrid("");
        }

        private void btnExcluir_Click(object sender, EventArgs e)
        {
            if (txtDescricao.Text == "") return;

            if (MessageBox.Show("Deseja excluir o cliente?", "Exclusão",
                MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {

                p = new Produto()
                {
                    Id = int.Parse(txtId.Text),
                };
                p.Excluir();

                Limpar();
                CarregarGrid("");
            }
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            Limpar();
            CarregarGrid("");
        }

        private void btnFechar_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void btnPesquisar_Click(object sender, EventArgs e)
        {
            CarregarGrid(txtPesquisa.Text);
            Limpar();
        }

        public void dgvProdutos_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dgvProdutos.Rows.Count > 0)
            {
                txtId.Text = dgvProdutos.CurrentRow.Cells["id"].Value.ToString();
                txtDescricao.Text = dgvProdutos.CurrentRow.Cells["descricao"].Value.ToString();
                cboMarcas.Text = dgvProdutos.CurrentRow.Cells["nome"].Value.ToString();
                cboCategoria.Text = dgvProdutos.CurrentRow.Cells["categoria"].Value.ToString();
                txtEstoque.Text = dgvProdutos.CurrentRow.Cells["estoque"].Value.ToString();
                txtValor.Text = dgvProdutos.CurrentRow.Cells["valorVenda"].Value.ToString();

            }
        }

        public void FrmProdutos_Load(object sender, EventArgs e)
        {
            c = new Categorias();
           cboCategoria.DataSource = c.Consultar();
            cboCategoria.DisplayMember = "categoria";
            cboCategoria.ValueMember = "id";

            m = new Marcas();
            cboMarcas.DataSource = m.Consultar();
            cboMarcas.DisplayMember = "nome";
            cboMarcas.ValueMember = "id";

            Limpar();
            CarregarGrid("");

            dgvProdutos.Columns["idCategoria"].Visible = false;
            dgvProdutos.Columns["idMarca"].Visible = false;
        }

        
    }
}
