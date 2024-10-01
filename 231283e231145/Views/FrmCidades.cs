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
using _231283e231145.Models;

namespace _231283e231145.Views
{
    public partial class FrmCidades : Form
    {
        Cidade c;
        
        public FrmCidades()
        {
            InitializeComponent();
            
          

        }

        private void btnIncluir_Click(object sender, EventArgs e)
        {
            if (txtNome.Text == string.Empty) return;

            
           
            c = new Cidade()
            {
                nome = txtNome.Text,
                UF = txtUF.Text,

            };

            c.Incluir();


            Limpar();
            CarregarGrid("");

        }

        private void FrmCidades_Load(object sender, EventArgs e)
        {
          
        }

        public void Limpar()
        {
            txtID.Clear();
            txtNome.Clear();
            txtUF.Clear();

            txtPesquisa.Clear();


        }

        public void CarregarGrid(string pesquisa)
        {
            c = new Cidade()
            {
                nome = pesquisa
            };

            dgvCidades.DataSource = c.Consultar();
        }

        private void dgvCidades_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dgvCidades.RowCount != 0)
            {
                txtID.Text = dgvCidades.CurrentRow.Cells[0].Value.ToString();
                txtNome.Text = dgvCidades.CurrentRow.Cells[1].Value.ToString();
                txtUF.Text = dgvCidades.CurrentRow.Cells[2].Value.ToString();

            }


        }

        private void btnAlterar_Click(object sender, EventArgs e)
        {
            if (txtID.Text == string.Empty) return;

            c = new Cidade()
            {
                ID = int.Parse(txtID.Text),
                nome = txtNome.Text,
                UF = txtUF.Text,

            };

            c.alterar();

            Limpar();
            CarregarGrid("");
        }

        private void btnExcluir_Click(object sender, EventArgs e)
        {
            if (txtID.Text == "") return;

            if (MessageBox.Show("Deseja excluir a cidade?", "Exclusão", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                c = new Cidade()
                {
                    ID = int.Parse(txtID.Text)
                };

                c.Excluir();

                Limpar();
                CarregarGrid("");


            }
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            Limpar();
            CarregarGrid("");
        }

        private void btnProcurar_Click(object sender, EventArgs e)
        {
            CarregarGrid(txtPesquisa.Text);

            

        }

        private void btnFechar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void FrmCidades_Load_1(object sender, EventArgs e)
        {
            Limpar();
            CarregarGrid("");
        }
    }
}
