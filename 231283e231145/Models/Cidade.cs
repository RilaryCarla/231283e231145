using MySql.Data.MySqlClient;
using System;
using System.Data;
using System.Windows.Forms;


namespace _231283e231145.Models
{
    public class Cidade
    {

        public int ID { get; set; }
        public string nome { get; set; }

        public string UF { get; set; }

        public void Incluir()
        {
            try
            {
                //Abrir a conexao com o banco
                Banco.AbrirConexao();

                Banco.Comando = new MySqlCommand("INSERT INTO cidades(nome, uf)  VALUES (@nome, @uf)", Banco.Conexao);

                Banco.Comando.Parameters.AddWithValue("@nome", nome);
                Banco.Comando.Parameters.AddWithValue("@uf", UF);

                Banco.Comando.ExecuteNonQuery();

                Banco.FecharConexao();


            }
            catch (Exception e)
            {

                MessageBox.Show(e.Message, "ERRO", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        public void alterar()
        {
            try
            {
                Banco.AbrirConexao();

                Banco.Comando = new MySqlCommand("UPDATE cidades SET nome = @nome, uf = @uf WHERE id = @id", Banco.Conexao);

                Banco.Comando.Parameters.AddWithValue("@nome", nome);
                Banco.Comando.Parameters.AddWithValue("@uf", UF);
                Banco.Comando.Parameters.AddWithValue("@id", ID);

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

                Banco.Comando = new MySqlCommand("DELETE FROM cidades WHERE id = @id", Banco.Conexao);

                Banco.Comando.Parameters.AddWithValue("@id", ID);

                Banco.Comando.ExecuteNonQuery();

                Banco.FecharConexao();

            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message, "ERRO", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
        }

        public DataTable Consultar()
        {

            try
            {
                Banco.AbrirConexao();

                Banco.Comando = new MySqlCommand("SELECT * FROM cidades WHERE nome like @nome " +
                    "order by nome", Banco.Conexao);


                Banco.Comando.Parameters.AddWithValue("@nome", nome + "%");


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