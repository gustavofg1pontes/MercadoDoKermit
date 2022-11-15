using System;
using System.Collections.Generic;
using System.Linq;
using System.Data.SqlClient;
using System.Text;
using System.Threading.Tasks;
using System.Drawing.Printing;

namespace MercadinhoDaSacanagem
{
    public class ComandosBanco
    {
        SqlConnection con = new SqlConnection();
        SqlCommand cmd = new SqlCommand();

        public ComandosBanco()
        {
            //adicionar banco
            con.ConnectionString = "Data Source=DESKTOP-QQOLUS3\\SQLEXPRESS;Initial Catalog=TrabalhoLP1;Integrated Security=True";
        }

        public void Conectar()
        {
            con.Open();
            cmd.Connection = con;
        }
        public void Desconectar()
        {
            con.Close();
        }

        public void Adicionar(Produto produto)
        {
            cmd.Parameters.Clear();
            cmd.CommandText = "INSERT INTO produtos(numero, nome, preco, validade, quantidade) VALUES (@numero, @nome, @preco, @validade, @quant)";
            cmd.Parameters.AddWithValue("@numero", produto.Numero);
            cmd.Parameters.AddWithValue("@nome", produto.Nome);
            cmd.Parameters.AddWithValue("@preco", produto.Preco);
            cmd.Parameters.AddWithValue("@validade", produto.Validade);
            cmd.Parameters.AddWithValue("@quant", produto.Quantidade);
            this.Conectar();
            cmd.ExecuteNonQuery();
            this.Desconectar();
        }

        public Produto Consultar(int numero)
        {
            Produto produto = new Produto();
            cmd.Parameters.Clear();
            cmd.CommandText = "SELECT * FROM produtos WHERE numero = @numero";
            cmd.Parameters.AddWithValue("@numero", numero);
            this.Conectar();
            SqlDataReader rdr = cmd.ExecuteReader();
            while (rdr.Read())
            {
                produto.Numero = rdr.GetInt32(0);
                produto.Nome = rdr.GetString(1);
                produto.Preco = rdr.GetDouble(2);
                produto.Validade = rdr.GetString(3);
                produto.Quantidade = rdr.GetInt32(4);
            }
            rdr.Close();
            this.Desconectar();
            return produto;
        }

        public void Alterar(Produto produto)
        {
            cmd.Parameters.Clear();
            cmd.CommandText = "UPDATE produtos " +
                "SET nome = @nome, preco = @preco, validade = @validade, quantidade = @quantidade WHERE numero = @numero";
            cmd.Parameters.AddWithValue("@numero", produto.Numero);
            cmd.Parameters.AddWithValue("@nome", produto.Nome);
            cmd.Parameters.AddWithValue("@preco", produto.Preco);
            cmd.Parameters.AddWithValue("@validade", produto.Validade);
            cmd.Parameters.AddWithValue("@quantidade", produto.Quantidade);
            this.Conectar();
            cmd.ExecuteNonQuery();
            this.Desconectar();
        }

        public void Excluir(int numero)
        {
            cmd.Parameters.Clear();
            cmd.CommandText = "DELETE FROM produtos WHERE numero = @numero";
            cmd.Parameters.AddWithValue("@numero", numero);
            this.Conectar();
            cmd.ExecuteNonQuery();
            this.Desconectar();
        }

        public bool TemNoBanco(int numero)
        {
            bool temNoBanco = false;
            cmd.Parameters.Clear();
            cmd.CommandText = "SELECT * FROM produtos WHERE numero = @numero";
            cmd.Parameters.AddWithValue("@numero", numero);
            this.Conectar();
            SqlDataReader rdr = cmd.ExecuteReader();
            temNoBanco = rdr.Read();
            this.Desconectar();
            return temNoBanco;
        }
    }
}