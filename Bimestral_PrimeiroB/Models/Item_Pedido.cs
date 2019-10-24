using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace Bimestral_PrimeiroB.Models
{
    public class Item_Pedido
    {
        public int Id_Pedido { get; set; }
        public int Id_Produto { get; set; }
        public int Quantidade { get; set; }

        public void Cadastrar()
        {
            SqlConnection connec = new SqlConnection("");
            SqlCommand comando = new SqlCommand("INSERT INTO Item_Pedido VALUES (" + this.Id_Pedido + ", " + this.Id_Produto + ", " + this.Quantidade + ")", connec);
            connec.Open();
            comando.ExecuteNonQuery();
            connec.Close();
        }

        public void Alterar(Item_Pedido usuario)
        {
            SqlConnection connec = new SqlConnection("");
            SqlCommand comando = new SqlCommand("UPDATE Item_Pedido SET Nome='" + usuario.Id_Pedido + "', Senha='" + usuario.Id_Produto + "', Tipo='" + usuario.Quantidade + "' WHERE Id_Produto = " + usuario.Id_Produto + " & Id_Pedido=" + usuario.Id_Pedido + ";", connec);
            connec.Open();
            comando.ExecuteNonQuery();
            connec.Close();
        }

        public void Deletar(Item_Pedido usuario)
        {
            SqlConnection connec = new SqlConnection("");
            SqlCommand comando = new SqlCommand("DELETE Item_Pedido WHERE Id_Pedido=" + usuario.Id_Pedido + " & Id_Produto=" + usuario.Id_Produto, connec);
            connec.Open();
            comando.ExecuteNonQuery();
            connec.Close();
        }

        public List<Item_Pedido> Busca_Usuarios()
        {
            DataSet ds = new DataSet();
            SqlConnection connec = new SqlConnection("");
            SqlCommand comando = new SqlCommand("SELECT * FROM Item_Pedido", connec);
            SqlDataAdapter da = new SqlDataAdapter(comando);
            da.Fill(ds);

            List<Item_Pedido> lista = ds.Tables[0].AsEnumerable().Select(dataRow => new Item_Pedido { Id_Pedido = dataRow.Field<int>("Id_Pedido"), Id_Produto = dataRow.Field<int>("Id_Produto"), Quantidade = dataRow.Field<int>("Quantidade") }).ToList();

            return lista;
        }

        public List<Item_Pedido> Busca_Usuarios_ID(int id)
        {
            DataSet ds = new DataSet();
            SqlConnection connec = new SqlConnection("");
            SqlCommand comando = new SqlCommand("SELECT * FROM Item_Pedido where Id_Pedido=" + id, connec);
            SqlDataAdapter da = new SqlDataAdapter(comando);
            da.Fill(ds);

            List<Item_Pedido> lista = ds.Tables[0].AsEnumerable().Select(dataRow => new Item_Pedido { Id_Pedido = dataRow.Field<int>("Id_Pedido"), Id_Produto = dataRow.Field<int>("Id_Produto"), Quantidade = dataRow.Field<int>("Quantidade") }).ToList();

            return lista;
            //return ds;
        }
    }
}