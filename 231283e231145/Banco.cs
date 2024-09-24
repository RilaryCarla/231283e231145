﻿using System;
using System.Data;
using System.Windows.Forms;
using MySql.Data.MySqlClient;


namespace _231283e231145
{
    public class Banco
    {
        //criando variaveis responsáveis pela conexão e consulta que serão usados em todo o projeto
        //Connection responsável pela conexão com o MySql
        public static MySqlConnection Conexao;
        //Comand responsável pelas instrução MySql a serem executadas
        public static MySqlCommand Comando;
        //Adapter responsável por inserir dados em uma database
        public static MySqlDataAdapter Adaptador;
        //DataTable responsável por ligar o banco em controles com a propriedade datasource
        public static DataTable datTabela;

        public static void AbrirConexao()
        {

            try
            {
                Conexao = new MySqlConnection("server=localhost;port = 3307;uid=root;pwd=etecjau");


                Conexao.Open();
            }
            catch (Exception e)
            {

                MessageBox.Show(e.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                FecharConexao();

            }
        }

        public static void FecharConexao()
        {
            try
            {
                Conexao.Close();
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        public static void CriarBanco()
        {

            try
            {
                AbrirConexao();

                Comando = new MySqlCommand("CREATE DATABASE IF NOT EXISTS vendas; USE vendas", Conexao);

                Comando.ExecuteNonQuery();

                FecharConexao();
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                FecharConexao();
            }
        }
    }

   
}