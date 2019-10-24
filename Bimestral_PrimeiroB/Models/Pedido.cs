using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace Bimestral_PrimeiroB.Models
{
    public class Pedido
    {
        public int Id_Pedido { get; set; }
        public int Id_Cliente { get; set; }
        public int Id_Vendedor { get; set; }
        public string Data_Pedido { get; set; }

        public void Cadastrar()
        {
            SqlConnection connec = new SqlConnection("");
            SqlCommand comando = new SqlCommand("INSERT INTO Pedido VALUES (" + this.Id_Cliente + ", " + this.Id_Vendedor + ", '" + this.Data_Pedido + "')", connec);
            connec.Open();
            comando.ExecuteNonQuery();
            connec.Close();
        }

        public void Alterar(Pedido usuario)
        {
            SqlConnection connec = new SqlConnection("");
            SqlCommand comando = new SqlCommand("UPDATE Pedido SET Nome='" + usuario.Id_Cliente + "', Senha='" + usuario.Id_Vendedor + "', Tipo='" + usuario.Data_Pedido + "' WHERE Id_Produto = " + usuario.Id_Pedido + ";", connec);
            connec.Open();
            comando.ExecuteNonQuery();
            connec.Close();
        }

        public void Deletar(Pedido usuario)
        {
            SqlConnection connec = new SqlConnection("");
            SqlCommand comando = new SqlCommand("DELETE Pedido WHERE Id_Pedido=" + usuario.Id_Pedido + "", connec);
            connec.Open();
            comando.ExecuteNonQuery();
            connec.Close();
        }

        public List<Pedido> Busca_Usuarios()
        {
            DataSet ds = new DataSet();
            SqlConnection connec = new SqlConnection("");
            SqlCommand comando = new SqlCommand("SELECT * FROM Vendedor", connec);
            SqlDataAdapter da = new SqlDataAdapter(comando);
            da.Fill(ds);

            List<Pedido> lista = ds.Tables[0].AsEnumerable().Select(dataRow => new Pedido { Id_Pedido = dataRow.Field<int>("Id_Pedido"), Id_Cliente = dataRow.Field<int>("Id_Cliente"), Id_Vendedor = dataRow.Field<int>("Id_Pedido"), Data_Pedido = dataRow.Field<string>("Data_Pedido") }).ToList();

            return lista;
        }

        public List<Pedido> Busca_Usuarios_ID(int id)
        {
            DataSet ds = new DataSet();
            SqlConnection connec = new SqlConnection("");
            SqlCommand comando = new SqlCommand("SELECT * FROM Pedido where Id_Pedido=" + id, connec);
            SqlDataAdapter da = new SqlDataAdapter(comando);
            da.Fill(ds);

            List<Pedido> lista = ds.Tables[0].AsEnumerable().Select(dataRow => new Pedido { Id_Pedido = dataRow.Field<int>("Id_Pedido"), Id_Cliente = dataRow.Field<int>("Id_Cliente"), Id_Vendedor = dataRow.Field<int>("Id_Pedido"), Data_Pedido = dataRow.Field<string>("Data_Pedido") }).ToList();

            return lista;
            //return ds;
        }
    }
}