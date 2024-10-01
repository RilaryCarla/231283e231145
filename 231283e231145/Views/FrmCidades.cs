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
    public partial class FrmCidades : Form
    {
        int count = 0;
        public FrmCidades()
        {
            InitializeComponent();
            count++;
            txtID.Text = count.ToString();
            
        }

        private void btnIncluir_Click(object sender, EventArgs e)
        {
            dgvCidades.Rows.Add(txtID.Text, txtNome.Text, txtUF.Text);
            txtID.Text = count++.ToString();
            C = new Cidade()
            {

            };
            Limpar();

        }

        public void Limpar()
        {

            txtNome.Text = "";
            txtUF.Text = "";

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
    }
}
