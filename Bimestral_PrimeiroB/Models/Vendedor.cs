using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace Bimestral_PrimeiroB.Models
{
    public class Vendedor
    {
        public int Id_Vendedor { get; set; }
        public string Nome { get; set; }
        public string CPF { get; set; }
        public string Telefone { get; set; }

        public void Cadastrar()
        {
            SqlConnection connec = new SqlConnection("");
            SqlCommand comando = new SqlCommand("INSERT INTO Vendedor VALUES ('" + this.Nome + "', '" + this.CPF + "', '" + this.Telefone + "')", connec);
            connec.Open();
            comando.ExecuteNonQuery();
            connec.Close();
        }

        public void Alterar(Vendedor usuario)
        {
            SqlConnection connec = new SqlConnection("");
            SqlCommand comando = new SqlCommand("UPDATE Vendedor SET Nome='" + usuario.Nome + "', Senha='" + usuario.CPF + "', Tipo='" + usuario.Telefone + "' WHERE Id_Vendedor = " + usuario.Id_Vendedor + ";", connec);
            connec.Open();
            comando.ExecuteNonQuery();
            connec.Close();
        }

        public void Deletar(Vendedor usuario)
        {
            SqlConnection connec = new SqlConnection("");
            SqlCommand comando = new SqlCommand("DELETE Vendedor WHERE Id_Vendedor=" + usuario.Id_Vendedor + "", connec);
            connec.Open();
            comando.ExecuteNonQuery();
            connec.Close();
        }

        public List<Vendedor> Busca_Usuarios()
        {
            DataSet ds = new DataSet();
            SqlConnection connec = new SqlConnection("");
            SqlCommand comando = new SqlCommand("SELECT * FROM Vendedor", connec);
            SqlDataAdapter da = new SqlDataAdapter(comando);
            da.Fill(ds);

            List<Vendedor> lista = ds.Tables[0].AsEnumerable().Select(dataRow => new Vendedor { Id_Vendedor = dataRow.Field<int>("Id_Cliente"), Nome = dataRow.Field<string>("Nome"), CPF = dataRow.Field<string>("CPF"), Telefone = dataRow.Field<string>("Telefone") }).ToList();

            return lista;
        }

        public List<Vendedor> Busca_Usuarios_ID(int id)
        {
            DataSet ds = new DataSet();
            SqlConnection connec = new SqlConnection("");
            SqlCommand comando = new SqlCommand("SELECT * FROM Vendedor where Id_Vendedor=" + id, connec);
            SqlDataAdapter da = new SqlDataAdapter(comando);
            da.Fill(ds);

            List<Vendedor> lista = ds.Tables[0].AsEnumerable().Select(dataRow => new Vendedor { Id_Vendedor = dataRow.Field<int>("Id_Cliente"), Nome = dataRow.Field<string>("Nome"), CPF = dataRow.Field<string>("CPF"), Telefone = dataRow.Field<string>("Telefone") }).ToList();

            return lista;
            //return ds;
        }
    }
}