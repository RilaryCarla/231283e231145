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
    public partial class FrmClientes : Form
    {
        Cidade c;
        Cliente cc;
        public FrmClientes()
        {
            InitializeComponent();
            CarregarGrid("");
        }

        void CarregarGrid(string pesquisa)
        {
            cc = new Cliente()
            {
                Nome = pesquisa,
            };

         dgvClientes.DataSource = cc.Consultar();
        }
        void Limpar()
        {
            txtID.Clear();
            txtNome.Clear();
            txtUF.Clear();
            txtRenda.Clear();
            cboCidades.SelectedIndex = -1;
            mskCPF.Clear();
            dtpDataNasc.Value = DateTime.Now;          
            chkVenda.Checked = false;
        }

        public void FrmClientes_Load(object sender, EventArgs e)
        {
            //Cria um objeto do tipo cidade 
            //e alimenta o combobox

            c = new Cidade();
            cboCidades.DataSource = c.Consultar();
            cboCidades.DisplayMember = "nome";
            cboCidades.ValueMember = "id";

            Limpar();
            CarregarGrid("");

            dgvClientes.Columns["idCidade"].Visible = false;

           
        }

        public void cboCidades_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cboCidades.SelectedIndex != -1)
            {
                DataRowView reg = (DataRowView)cboCidades.SelectedItem;
                txtUF.Text = reg["uf"].ToString();
            }
        }

        public void picFoto_Click(object sender, EventArgs e)
        {
            ofdArquivo.InitialDirectory = "D:/fotos/clientes/";
            ofdArquivo.FileName = "";
            ofdArquivo.ShowDialog();
            picFoto.ImageLocation = ofdArquivo.FileName;
        }

        public void btnIncluir_Click(object sender, EventArgs e)
        {
            if (txtNome.Text == "") return;

            cc = new Cliente()
            {
                Nome = txtNome.Text,
                IdCidade = (int)cboCidades.SelectedValue,
                DataNasc = dtpDataNasc.Value,
                Renda = double.Parse(txtRenda.Text),
                cpf = mskCPF.Text,              
                Venda = chkVenda.Checked
            };
            cc.Incluir();

            Limpar();
            CarregarGrid("");
        }

        public void dgvClientes_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dgvClientes.Rows.Count > 0)
            {
                txtID.Text = dgvClientes.CurrentRow.Cells["id"].Value.ToString();
                txtNome.Text = dgvClientes.CurrentRow.Cells["Nome"].Value.ToString();
                cboCidades.Text = dgvClientes.CurrentRow.Cells["cidade"].Value.ToString();
                txtUF.Text = dgvClientes.CurrentRow.Cells["uf"].Value.ToString();
                chkVenda.Checked = (bool)dgvClientes.CurrentRow.Cells["venda"].Value;
                mskCPF.Text = dgvClientes.CurrentRow.Cells["cpf"].Value.ToString();
                dtpDataNasc.Text = dgvClientes.CurrentRow.Cells["dataNasc"].Value.ToString();
                txtRenda.Text = dgvClientes.CurrentRow.Cells["renda"].Value.ToString();
                
            }

        }

        public void btnAlterar_Click(object sender, EventArgs e)
        {
            if (txtID.Text == "") return;

            cc = new Cliente()
            {
                Id = int.Parse(txtID.Text),
                Nome = txtNome.Text,
                IdCidade = (int)cboCidades.SelectedValue,
                DataNasc = dtpDataNasc.Value,
                Renda = double.Parse(txtRenda.Text),
                cpf = mskCPF.Text,
               
                Venda = chkVenda.Checked,
            };
            cc.Alterar();

            Limpar();
            CarregarGrid("");
        }

        public void btnExcluir_Click(object sender, EventArgs e)
        {
            if (txtID.Text == "") return;

            if (MessageBox.Show("Deseja excluir o cliente?", "Exclusão",
                MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                cc = new Cliente()
                {
                    Id = int.Parse(txtID.Text)
                };
                cc.Excluir();

                Limpar();
                CarregarGrid("");
            }
        }

        public void btnCancelar_Click(object sender, EventArgs e)
        {
            Limpar();
            CarregarGrid("");
        }

        public void btnConsultar_Click(object sender, EventArgs e)
        {
            CarregarGrid(txtPesquisa.Text);
        }

        public void btnFechar_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
