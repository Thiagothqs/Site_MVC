using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace Bimestral_PrimeiroB.Models
{
    public class Produto
    {
        public int Id_Produto { get; set; }
        public string Descricao { get; set; }
        public float Valor_unitario { get; set; }
        public int QtdEstoque { get; set; }

        public void Cadastrar()
        {
            SqlConnection connec = new SqlConnection("");
            SqlCommand comando = new SqlCommand("INSERT INTO Produto VALUES ('" + this.Descricao + "', " + this.Valor_unitario + ", " + this.QtdEstoque + ")", connec);
            connec.Open();
            comando.ExecuteNonQuery();
            connec.Close();
        }

        public void Alterar(Produto usuario)
        {
            SqlConnection connec = new SqlConnection("");
            SqlCommand comando = new SqlCommand("UPDATE Produto SET Nome='" + usuario.Descricao + "', Senha='" + usuario.Valor_unitario + "', Tipo='" + usuario.QtdEstoque + "' WHERE Id_Produto = " + usuario.Id_Produto + ";", connec);
            connec.Open();
            comando.ExecuteNonQuery();
            connec.Close();
        }

        public void Deletar(Produto usuario)
        {
            SqlConnection connec = new SqlConnection("");
            SqlCommand comando = new SqlCommand("DELETE Produto WHERE Id_Produto=" + usuario.Id_Produto + "", connec);
            connec.Open();
            comando.ExecuteNonQuery();
            connec.Close();
        }

        public List<Produto> Busca_Usuarios()
        {
            DataSet ds = new DataSet();
            SqlConnection connec = new SqlConnection("");
            SqlCommand comando = new SqlCommand("SELECT * FROM Vendedor", connec);
            SqlDataAdapter da = new SqlDataAdapter(comando);
            da.Fill(ds);

            List<Produto> lista = ds.Tables[0].AsEnumerable().Select(dataRow => new Produto { Id_Produto = dataRow.Field<int>("Id_Produto"), Descricao = dataRow.Field<string>("Descricao"), Valor_unitario = dataRow.Field<float>("Valor_unitario"), QtdEstoque = dataRow.Field<int>("QtdEstoque") }).ToList();

            return lista;
        }

        public List<Produto> Busca_Usuarios_ID(int id)
        {
            DataSet ds = new DataSet();
            SqlConnection connec = new SqlConnection("");
            SqlCommand comando = new SqlCommand("SELECT * FROM Vendedor where Id_Vendedor=" + id, connec);
            SqlDataAdapter da = new SqlDataAdapter(comando);
            da.Fill(ds);

            List<Produto> lista = ds.Tables[0].AsEnumerable().Select(dataRow => new Produto { Id_Produto = dataRow.Field<int>("Id_Produto"), Descricao = dataRow.Field<string>("Descricao"), Valor_unitario = dataRow.Field<float>("Valor_unitario"), QtdEstoque = dataRow.Field<int>("QtdEstoque") }).ToList();

            return lista;
            //return ds;
        }
    }
}