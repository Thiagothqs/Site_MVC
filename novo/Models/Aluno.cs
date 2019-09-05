using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace novo.Models
{
    public class Aluno : Pessoa
    {
        public void Cadastrar()
        {
            SqlConnection connec = new SqlConnection("Data Source=.;Initial Catalog=CSharpMVC;Integrated Security=True");
            SqlCommand comando = new SqlCommand("INSERT INTO Aluno VALUES ('" + this.Nome + "', " + this.Idade + ", '" + this.Sexo + "', " + this.Peso + ")", connec);
            connec.Open();
            comando.ExecuteNonQuery();
            connec.Close();
        }

        public void Alterar(Aluno pessoa)
        {
            SqlConnection connec = new SqlConnection("Data Source=.;Initial Catalog=CSharpMVC;Integrated Security=True");
            SqlCommand comando = new SqlCommand("UPDATE Aluno SET Nome='" + pessoa.Nome + "', Idade=" + pessoa.Idade + ", Sexo='" + pessoa.Sexo + "', Peso=" + pessoa.Peso + " WHERE Id_Pessoa = " + pessoa.Id_Pessoa + "; ", connec);
            connec.Open();
            comando.ExecuteNonQuery();
            connec.Close();
        }

        public void Deletar(Aluno pessoa)
        {
            SqlConnection connec = new SqlConnection("Data Source=.;Initial Catalog=CSharpMVC;Integrated Security=True");
            SqlCommand comando = new SqlCommand("DELETE Aluno WHERE Id_Pessoa=" + pessoa.Id_Pessoa + "", connec);
            connec.Open();
            comando.ExecuteNonQuery();
            connec.Close();
        }

        public List<Aluno> Busca_Alunos()
        {
            DataSet ds = new DataSet();
            SqlConnection connec = new SqlConnection("Data Source=.;Initial Catalog=CSharpMVC;Integrated Security=True");
            SqlCommand comando = new SqlCommand("SELECT * FROM Aluno", connec);
            SqlDataAdapter da = new SqlDataAdapter(comando);
            da.Fill(ds);


            List<Aluno> lista = ds.Tables[0].AsEnumerable().Select(dataRow => new Aluno { Id_Pessoa = dataRow.Field<int>("Id_Pessoa"), Nome = dataRow.Field<string>("Nome"), Idade = dataRow.Field<int>("Idade"), Sexo = dataRow.Field<string>("Sexo"), Peso = dataRow.Field<double>("Peso") }).ToList();

            return lista;
        }
        
        public List<Aluno> Busca_Alunos_ID(int id)
        {
            DataSet ds = new DataSet();
            SqlConnection connec = new SqlConnection("Data Source=.;Initial Catalog=CSharpMVC;Integrated Security=True");
            SqlCommand comando = new SqlCommand("SELECT * FROM Aluno where Id_Pessoa="+id, connec);
            SqlDataAdapter da = new SqlDataAdapter(comando);
            da.Fill(ds);

            List<Aluno> lista = ds.Tables[0].AsEnumerable().Select(dataRow => new Aluno { Id_Pessoa = dataRow.Field<int>("Id_Pessoa"), Nome = dataRow.Field<string>("Nome"), Idade = dataRow.Field<int>("Idade"), Sexo = dataRow.Field<string>("Sexo"), Peso = dataRow.Field<double>("Peso") }).ToList();

            return lista;
            //return ds;
        }
    }
}