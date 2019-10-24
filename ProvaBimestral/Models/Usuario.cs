using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace ProvaBimestral.Models
{
    public class Usuario
    {
        public int Id_Usuario { get; set; }
        public string Login { get; set; }
        public string Senha { get; set; }

        public List<Usuario> Busca_Usuarios()
        {
            DataSet ds = new DataSet();
            SqlConnection connec = new SqlConnection("Data Source=.;Initial Catalog=ProvaBimestral;Integrated Security=True");
            SqlCommand comando = new SqlCommand("SELECT * FROM Usuario", connec);
            SqlDataAdapter da = new SqlDataAdapter(comando);
            da.Fill(ds);


            List<Usuario> lista = ds.Tables[0].AsEnumerable().Select(dataRow => new Usuario { Id_Usuario = dataRow.Field<int>("Id_Usuario"), Login = dataRow.Field<string>("Login"), Senha = dataRow.Field<string>("Senha") }).ToList();

            return lista;
        }

        public List<Usuario> Busca_Usuarios_ID(int id)
        {
            DataSet ds = new DataSet();
            SqlConnection connec = new SqlConnection("Data Source=.;Initial Catalog=ProvaBimestral;Integrated Security=True");
            SqlCommand comando = new SqlCommand("SELECT * FROM Usuario where Id_Usuario=" + id, connec);
            SqlDataAdapter da = new SqlDataAdapter(comando);
            da.Fill(ds);

            List<Usuario> lista = ds.Tables[0].AsEnumerable().Select(dataRow => new Usuario { Id_Usuario = dataRow.Field<int>("Id_Usuario"), Login = dataRow.Field<string>("Login"), Senha = dataRow.Field<string>("Senha") }).ToList();

            return lista;
            //return ds;
        }
    }
}