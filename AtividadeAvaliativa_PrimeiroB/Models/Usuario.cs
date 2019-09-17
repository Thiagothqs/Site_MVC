using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace AtividadeAvaliativa_PrimeiroB.Models
{
    public class Usuario
    {
        public int Id_Usuario { get; set; }
        
        public string Nome { get; set; }

        public string Senha { get; set; }

        public string Tipo { get; set; }

        public void Cadastrar()
        {
            SqlConnection connec = new SqlConnection("Data Source=.;Initial Catalog=AtividadeAvaliativa_PrimeiroB;Integrated Security=True");
            SqlCommand comando = new SqlCommand("INSERT INTO Usuario VALUES ('" + this.Nome + "', '" + this.Senha + "', '" + this.Tipo + "')", connec);
            connec.Open();
            comando.ExecuteNonQuery();
            connec.Close();
        }

        public void Alterar(Usuario usuario)
        {
            SqlConnection connec = new SqlConnection("Data Source=.;Initial Catalog=AtividadeAvaliativa_PrimeiroB;Integrated Security=True");
            SqlCommand comando = new SqlCommand("UPDATE Usuario SET Nome='" + usuario.Nome + "', Senha='" + usuario.Senha + "', Tipo='" + usuario.Tipo + "' WHERE Id_Usuario = " + usuario.Id_Usuario + ";", connec);
            connec.Open();
            comando.ExecuteNonQuery();
            connec.Close();
        }

        public void Deletar(Usuario usuario)
        {
            SqlConnection connec = new SqlConnection("Data Source=.;Initial Catalog=AtividadeAvaliativa_PrimeiroB;Integrated Security=True");
            SqlCommand comando = new SqlCommand("DELETE Usuario WHERE Id_Usuario=" + usuario.Id_Usuario + "", connec);
            connec.Open();
            comando.ExecuteNonQuery();
            connec.Close();
        }

        public List<Usuario> Busca_Usuarios()
        {
            DataSet ds = new DataSet();
            SqlConnection connec = new SqlConnection("Data Source=.;Initial Catalog=AtividadeAvaliativa_PrimeiroB;Integrated Security=True");
            SqlCommand comando = new SqlCommand("SELECT * FROM Usuario", connec);
            SqlDataAdapter da = new SqlDataAdapter(comando);
            da.Fill(ds);


            List<Usuario> lista = ds.Tables[0].AsEnumerable().Select(dataRow => new Usuario { Id_Usuario = dataRow.Field<int>("Id_Usuario"), Nome = dataRow.Field<string>("Nome"), Senha = dataRow.Field<string>("Senha"), Tipo = dataRow.Field<string>("Tipo") }).ToList();

            return lista;
        }

        public List<Usuario> Busca_Usuarios_ID(int id)
        {
            DataSet ds = new DataSet();
            SqlConnection connec = new SqlConnection("Data Source=.;Initial Catalog=AtividadeAvaliativa_PrimeiroB;Integrated Security=True");
            SqlCommand comando = new SqlCommand("SELECT * FROM Usuario where Id_Usuario=" + id, connec);
            SqlDataAdapter da = new SqlDataAdapter(comando);
            da.Fill(ds);

            List<Usuario> lista = ds.Tables[0].AsEnumerable().Select(dataRow => new Usuario { Id_Usuario = dataRow.Field<int>("Id_Usuario"), Nome = dataRow.Field<string>("Nome"), Senha = dataRow.Field<string>("Senha"), Tipo = dataRow.Field<string>("Tipo") }).ToList();

            return lista;
            //return ds;
        }
    }
}