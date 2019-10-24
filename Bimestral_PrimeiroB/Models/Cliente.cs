using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace Bimestral_PrimeiroB.Models
{
    public class Cliente
    {
        public int Id_Cliente { get; set; }
        public string Nome { get; set; }
        public string CPF { get; set; }
        public string Telefone { get; set; }

        public void Cadastrar()
        {
            SqlConnection connec = new SqlConnection("");
            SqlCommand comando = new SqlCommand("INSERT INTO Cliente VALUES ('" + this.Nome + "', '" + this.CPF + "', '" + this .Telefone+ "')", connec);
            connec.Open();
            comando.ExecuteNonQuery();
            connec.Close();
        }

        public void Alterar(Cliente usuario)
        {
            SqlConnection connec = new SqlConnection("");
            SqlCommand comando = new SqlCommand("UPDATE Cliente SET Nome='" + usuario.Nome + "', Senha='" + usuario.CPF + "', Tipo='" + usuario.Telefone + "' WHERE Id_Cliente = " + usuario.Id_Cliente + ";", connec);
            connec.Open();
            comando.ExecuteNonQuery();
            connec.Close();
        }

        public void Deletar(Cliente usuario)
        {
            SqlConnection connec = new SqlConnection("");
            SqlCommand comando = new SqlCommand("DELETE Cliente WHERE Id_Cliente=" + usuario.Id_Cliente + "", connec);
            connec.Open();
            comando.ExecuteNonQuery();
            connec.Close();
        }

        public List<Cliente> Busca_Usuarios()
        {
            DataSet ds = new DataSet();
            SqlConnection connec = new SqlConnection("");
            SqlCommand comando = new SqlCommand("SELECT * FROM ???", connec);
            SqlDataAdapter da = new SqlDataAdapter(comando);
            da.Fill(ds);


            List<Cliente> lista = ds.Tables[0].AsEnumerable().Select(dataRow => new Cliente { Id_Cliente = dataRow.Field<int>("Id_Cliente"), Nome = dataRow.Field<string>("Nome"), CPF = dataRow.Field<string>("CPF"), Telefone = dataRow.Field<string>("Telefone") }).ToList();

            return lista;
        }

        public List<Cliente> Busca_Usuarios_ID(int id)
        {
            DataSet ds = new DataSet();
            SqlConnection connec = new SqlConnection("");
            SqlCommand comando = new SqlCommand("SELECT * FROM Cliente where Id_Cliente=" + id, connec);
            SqlDataAdapter da = new SqlDataAdapter(comando);
            da.Fill(ds);

            List<Cliente> lista = ds.Tables[0].AsEnumerable().Select(dataRow => new Cliente { Id_Cliente = dataRow.Field<int>("Id_Cliente"), Nome = dataRow.Field<string>("Nome"), CPF = dataRow.Field<string>("CPF"), Telefone = dataRow.Field<string>("Telefone") }).ToList();

            return lista;
            //return ds;
        }
    }
}