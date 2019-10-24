using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace ProvaBimestral.Models
{
    public class Produto
    {
        public int Id_Produto { get; set; }

        [Required(ErrorMessage = "Este Campo é obrigatório")]
        public string Nome { get; set; }

        public string Descricao { get; set; }

        public string Marca { get; set; }

        public string Modelo { get; set; }

        [Range(1, 5000, ErrorMessage = "Preço deve ser entre 1 e 5000 reais")]
        public string Preco { get; set; }

        [System.Web.Mvc.Remote("validacao", "Produto", ErrorMessage = "Somente Celular, Tablet, Notebook e Carregadores são aceitos")]
        public string Categoria { get; set; }

        public void Cadastrar()
        {
            SqlConnection connec = new SqlConnection("Data Source=.;Initial Catalog=ProvaBimestral;Integrated Security=True");
            SqlCommand comando = new SqlCommand("INSERT INTO PRODUTO VALUES ('" + this.Nome + "', '" + this.Descricao + "', '" + this.Marca + "', '"+this.Modelo+"', "+this.Preco+", '"+this.Categoria+"');", connec);
            connec.Open();
            comando.ExecuteNonQuery();
            connec.Close();
        }

        public void Alterar(Produto produto)
        {
            SqlConnection connec = new SqlConnection("Data Source=.;Initial Catalog=ProvaBimestral;Integrated Security=True");
            SqlCommand comando = new SqlCommand("UPDATE Produto SET Nome='" + produto.Nome + "', Descricao='" + produto.Descricao + "', Marca='" + produto.Marca + "', Modelo='"+produto.Modelo+"', Preco='"+produto.Preco+"', Categoria='"+produto.Categoria+"' WHERE Id_Produto = " + produto.Id_Produto + ";", connec);
            connec.Open();
            comando.ExecuteNonQuery();
            connec.Close();
        }

        public void Deletar(Produto usuario)
        {
            SqlConnection connec = new SqlConnection("Data Source=.;Initial Catalog=ProvaBimestral;Integrated Security=True");
            SqlCommand comando = new SqlCommand("DELETE Produto WHERE Id_Produto=" + usuario.Id_Produto + "", connec);
            connec.Open();
            comando.ExecuteNonQuery();
            connec.Close();
        }

        public List<Produto> Busca_Produtos()
        {
            DataSet ds = new DataSet();
            SqlConnection connec = new SqlConnection("Data Source=.;Initial Catalog=ProvaBimestral;Integrated Security=True");
            SqlCommand comando = new SqlCommand("SELECT * FROM Produto", connec);
            SqlDataAdapter da = new SqlDataAdapter(comando);
            da.Fill(ds);

            List<Produto> lista = ds.Tables[0].AsEnumerable().Select(dataRow => new Produto { Id_Produto = dataRow.Field<int>("Id_Produto"), Nome = dataRow.Field<string>("Nome"), Descricao = dataRow.Field<string>("Descricao"), Marca = dataRow.Field<string>("Marca"), Modelo = dataRow.Field<string>("Modelo"), Categoria = dataRow.Field<string>("Categoria"), Preco = dataRow.Field<string>("Preco") }).ToList();

            return lista;
        }

        public List<Produto> Busca_Produtos_ID(int id)
        {
            DataSet ds = new DataSet();
            SqlConnection connec = new SqlConnection("Data Source=.;Initial Catalog=ProvaBimestral;Integrated Security=True");
            SqlCommand comando = new SqlCommand("SELECT * FROM Produto where Id_Produto=" + id, connec);
            SqlDataAdapter da = new SqlDataAdapter(comando);
            da.Fill(ds);

            List<Produto> lista = ds.Tables[0].AsEnumerable().Select(dataRow => new Produto { Id_Produto = dataRow.Field<int>("Id_Produto"), Nome = dataRow.Field<string>("Nome"), Descricao = dataRow.Field<string>("Descricao"), Marca = dataRow.Field<string>("Marca"), Modelo = dataRow.Field<string>("Modelo"), Categoria = dataRow.Field<string>("Categoria"), Preco = dataRow.Field<string>("Preco") }).ToList();

            return lista;
            //return ds;
        }

        public List<Produto> Busca_Produto_Categoria(string classifi)
        {
            DataSet ds = new DataSet();
            SqlConnection connec = new SqlConnection("Data Source=.;Initial Catalog=ProvaBimestral;Integrated Security=True");
            SqlCommand comando = new SqlCommand("SELECT * FROM Produto where categoria = '" + classifi + "'", connec);
            SqlDataAdapter da = new SqlDataAdapter(comando);
            da.Fill(ds);


            List<Produto> lista = ds.Tables[0].AsEnumerable().Select(dataRow => new Produto { Id_Produto = dataRow.Field<int>("Id_Produto"), Nome = dataRow.Field<string>("Nome"), Descricao = dataRow.Field<string>("Descricao"), Marca = dataRow.Field<string>("Marca"), Modelo = dataRow.Field<string>("Modelo"), Categoria = dataRow.Field<string>("Categoria"), Preco = dataRow.Field<string>("Preco") }).ToList();

            return lista;
        }
    }
}