using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace AtividadeAvaliativa_PrimeiroB.Models
{
    public class Noticia
    {
        public int Id_Noticia { get; set; }

        [Required(ErrorMessage = "Este Campo é obrigatório")]
        public string Titulo { get; set; }
        public string Descricao { get; set; }
        public string Classificacao { get; set; }

        public void Cadastrar()
        {
            SqlConnection connec = new SqlConnection("Data Source=.;Initial Catalog=AtividadeAvaliativa_PrimeiroB;Integrated Security=True");
            SqlCommand comando = new SqlCommand("INSERT INTO Noticia VALUES ('"+this.Titulo+"', '"+this.Descricao+"', '"+this.Classificacao+"');", connec);
            connec.Open();
            comando.ExecuteNonQuery();
            connec.Close();
        }

        public void Alterar(Noticia noticia)
        {
            SqlConnection connec = new SqlConnection("Data Source=.;Initial Catalog=AtividadeAvaliativa_PrimeiroB;Integrated Security=True");
            SqlCommand comando = new SqlCommand("UPDATE Noticia SET Titulo = '"+noticia.Titulo+"', Descricao = '"+noticia.Descricao+"', Classificacao = '"+noticia.Classificacao+"' WHERE Id_Noticia = "+noticia.Id_Noticia+";", connec);
            connec.Open();
            comando.ExecuteNonQuery();
            connec.Close();
        }

        public void Deletar(Noticia noticia)
        {
            SqlConnection connec = new SqlConnection("Data Source=.;Initial Catalog=AtividadeAvaliativa_PrimeiroB;Integrated Security=True");
            SqlCommand comando = new SqlCommand("DELETE Noticia WHERE Id_Noticia=" + noticia.Id_Noticia + "", connec);
            connec.Open();
            comando.ExecuteNonQuery();
            connec.Close();
        }

        public List<Noticia> Busca_Noticias()
        {
            DataSet ds = new DataSet();
            SqlConnection connec = new SqlConnection("Data Source=.;Initial Catalog=AtividadeAvaliativa_PrimeiroB;Integrated Security=True");
            SqlCommand comando = new SqlCommand("SELECT * FROM Noticia", connec);
            SqlDataAdapter da = new SqlDataAdapter(comando);
            da.Fill(ds);


            List<Noticia> lista = ds.Tables[0].AsEnumerable().Select(dataRow => new Noticia { Id_Noticia = dataRow.Field<int>("Id_Noticia"), Titulo = dataRow.Field<string>("Titulo"), Descricao = dataRow.Field<string>("Descricao"), Classificacao = dataRow.Field<string>("Classificacao") }).ToList();

            return lista;
        }

        public List<Noticia> Busca_Noticias_Classificacao(string classifi)
        {
            DataSet ds = new DataSet();
            SqlConnection connec = new SqlConnection("Data Source=.;Initial Catalog=AtividadeAvaliativa_PrimeiroB;Integrated Security=True");
            SqlCommand comando = new SqlCommand("SELECT * FROM Noticia where classificacao = '"+classifi+"'", connec);
            SqlDataAdapter da = new SqlDataAdapter(comando);
            da.Fill(ds);


            List<Noticia> lista = ds.Tables[0].AsEnumerable().Select(dataRow => new Noticia { Id_Noticia = dataRow.Field<int>("Id_Noticia"), Titulo = dataRow.Field<string>("Titulo"), Descricao = dataRow.Field<string>("Descricao"), Classificacao = dataRow.Field<string>("Classificacao") }).ToList();

            return lista;
        }

        public List<Noticia> Busca_Noticias_ID(int id)
        {
            DataSet ds = new DataSet();
            SqlConnection connec = new SqlConnection("Data Source=.;Initial Catalog=AtividadeAvaliativa_PrimeiroB;Integrated Security=True");
            SqlCommand comando = new SqlCommand("SELECT * FROM Noticia where Id_Noticia=" + id, connec);
            SqlDataAdapter da = new SqlDataAdapter(comando);
            da.Fill(ds);

            List<Noticia> lista = ds.Tables[0].AsEnumerable().Select(dataRow => new Noticia { Id_Noticia = dataRow.Field<int>("Id_Noticia"), Titulo = dataRow.Field<string>("Titulo"), Descricao = dataRow.Field<string>("Descricao"), Classificacao = dataRow.Field<string>("Classificacao") }).ToList();

            return lista;
            //return ds;
        }
    }
}