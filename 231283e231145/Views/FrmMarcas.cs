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
        public FrmMarcas()
        {
            InitializeComponent();
        }

        public void Limpar()
        {
            txtId.Text = "";
            txtNome.Text = "";
            txtPesquisa.Text = "";
        }

       
        private void btnIncluir_Click(object sender, EventArgs e)
        {

        }
    }
}
