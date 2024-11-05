using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace _231283e231145.Models
{
    public class Cliente
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public int IdCidade { get; set; }
        public DateTime DataNasc {  get; set; }
        public double Renda { get; set; }
        public string cpf { get; set; }
        public string Foto { get; set; }
        public bool Venda { get; set; }

        public void Incluir()
        {
            try
            {
                Banco.AbrirConexao();
                Banco.Comando = new MySqlCommand("INSERT INTO clientes(nome,idCidade,dataNasc, renda, cpf, foto, venda)" +
                    "VALUES(@nome, @idCidade, @dataNasc, @renda, @cpf, @foto, @venda)", Banco.Conexao);

                Banco.Comando.Parameters.AddWithValue("@nome", Nome);
                Banco.Comando.Parameters.AddWithValue("@idCidade", IdCidade);
                Banco.Comando.Parameters.AddWithValue("@dataNasc", DataNasc);
                Banco.Comando.Parameters.AddWithValue("@renda", Renda);
                Banco.Comando.Parameters.AddWithValue("@cpf", cpf);
                Banco.Comando.Parameters.AddWithValue("@foto", Foto);
                Banco.Comando.Parameters.AddWithValue("@venda", Venda);
                Banco.Comando.ExecuteNonQuery();

                Banco.FecharConexao();
            }
            catch(Exception e)
            {
                MessageBox.Show(e.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        public void Excluir()
        {
            try
            {
                Banco.AbrirConexao();

                Banco.Comando = new MySqlCommand("DELETE FROM clientes WHERE id = @id", Banco.Conexao);
                Banco.Comando.Parameters.AddWithValue("@id", Id);
                Banco.Comando.ExecuteNonQuery();

                Banco.FecharConexao();
            }catch(Exception e)
            {
                MessageBox.Show(e.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        public DataTable Consultar()
        {
            try
            {
                Banco.AbrirConexao();

                Banco.Comando = new MySqlCommand("SELECT cl.*, ci.nome cidade, ci.uf FROM clientes cl" +
                    "inner join cidades ci ON cl.idCidade = ci.id WHERE cl.nome LIKE ?nome ORDER BY cl.nome", Banco.Conexao);
                Banco.Comando.Parameters.AddWithValue("@nome", Nome + "%");
                Banco.Adaptador = new MySqlDataAdapter(Banco.Comando);
                Banco.datTabela = new DataTable();
                Banco.Adaptador.Fill(Banco.datTabela);

                return Banco.datTabela;


            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return null;
            }
                
               
        }

        public void Alterar()
        {
            try
            {
                Banco.AbrirConexao();

                Banco.AbrirConexao();
                Banco.Comando = new MySqlCommand("UPDATE clientes SET nome = @nome, idCidade = @idCidade, dataNasc = @datanasc," +
                    "renda = @renda, cpf = @cpf, foto = @foto, venda = @venda WHERE id = @id ", Banco.Conexao);

                Banco.Comando.Parameters.AddWithValue("@nome", Nome);
                Banco.Comando.Parameters.AddWithValue("@idCidade", IdCidade);
                Banco.Comando.Parameters.AddWithValue("@dataNasc", DataNasc);
                Banco.Comando.Parameters.AddWithValue("@renda", Renda);
                Banco.Comando.Parameters.AddWithValue("@cpf", cpf);
                Banco.Comando.Parameters.AddWithValue("@foto", Foto);
                Banco.Comando.Parameters.AddWithValue("@venda", Venda);
                Banco.Comando.Parameters.AddWithValue("@id", Id);
                Banco.Comando.ExecuteNonQuery();

                Banco.FecharConexao();
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        }

     }

     

