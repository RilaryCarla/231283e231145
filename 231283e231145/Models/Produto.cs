using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data;
using MySql.Data.MySqlClient;

namespace _231283e231145.Models
{
    public class Produto
    {
        public int Id { get; set; }
        public string Descricao { get; set; }
        public int IdCategoria { get; set; }
        public int IdMarca { get; set; }
        public double Estoque { get; set; }
        public double ValorVenda { get; set; }


        public void Incluir()
        {
            try
            {
                Banco.AbrirConexao();

                Banco.Comando = new MySqlCommand("INSERT INTO produtos (descricao, idCategoria, idMarca, estoque, valorVenda) " +
                    "Values (@descricao, @idCategoria, @idMarca, @estoque, @valorVenda)", Banco.Conexao);

                Banco.Comando.Parameters.AddWithValue("@descricao", Descricao);
                Banco.Comando.Parameters.AddWithValue("@idCategoria", IdCategoria);
                Banco.Comando.Parameters.AddWithValue("@idMarca", IdMarca);
                Banco.Comando.Parameters.AddWithValue("@estoque", Estoque);
                Banco.Comando.Parameters.AddWithValue("@valorVenda", ValorVenda);

                Banco.Comando.ExecuteNonQuery();

                Banco.FecharConexao();
            }catch(Exception e)
            {
                MessageBox.Show(e.Message, "ERRO", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        public void Alterar()
        {
            try
            {
                Banco.AbrirConexao();

                Banco.Comando = new MySqlCommand("UPDATE produtos " +
                    "SET descricao = @descricao, idCategoria = @idCategoria, idMarca = @idMarca, estoque = @estoque, valorVenda = @valorVenda " +
                    "WHERE id = @id", Banco.Conexao);

                Banco.Comando.Parameters.AddWithValue("@id", Id);
                Banco.Comando.Parameters.AddWithValue("@descricao", Descricao);
                Banco.Comando.Parameters.AddWithValue("@idCategoria", IdCategoria);
                Banco.Comando.Parameters.AddWithValue("@idMarca", IdMarca);
                Banco.Comando.Parameters.AddWithValue("@estoque", Estoque);
                Banco.Comando.Parameters.AddWithValue("@valorVenda", ValorVenda);

                Banco.Comando.ExecuteNonQuery();

                Banco.FecharConexao();
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message, "ERRO", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        public void Excluir()
        {
            try
            {
                Banco.AbrirConexao();

                Banco.Comando = new MySqlCommand("DELETE FROM produtos " +                   
                    "WHERE id = @id", Banco.Conexao);

                Banco.Comando.Parameters.AddWithValue("@id", Id);
                Banco.Comando.ExecuteNonQuery();

                Banco.FecharConexao();
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message, "ERRO", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        public DataTable Consultar ()
        {
            try
            {
                Banco.AbrirConexao();

                Banco.Comando = new MySqlCommand("Select p.*, c.categoria, m.nome FROM produtos p INNER JOIN categorias c ON c.id = idCategoria INNER JOIN marcas m ON m.id = idMarca WHERE descricao LIKE @descricao order by id ", Banco.Conexao);
                Banco.Comando.Parameters.AddWithValue("@descricao", Descricao + "%");

                Banco.Adaptador = new MySqlDataAdapter(Banco.Comando);
                Banco.datTabela = new DataTable();
                Banco.Adaptador.Fill(Banco.datTabela);

                Banco.FecharConexao();

                return Banco.datTabela;
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message, "ERRO", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return null;
            }
        }

    }

}
