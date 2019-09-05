using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace novo.Models
{
    public class Pessoa
    {
        public int Id_Pessoa { get; set; }
        public string Nome { get; set; }
        public int? Idade { get; set; }
        public string Sexo { get; set; }
        public double? Peso { get; set; }

        /*public void Cadastrar()
        {
            SqlConnection connec = new SqlConnection("Data Source=.;Initial Catalog=FACEAR_2019;User ID=ThiagoSouza;Password=12345678");
            SqlCommand comando = new SqlCommand("INSERT INTO Aluno VALUES ('" + this.Nome + "', " + this.Idade + ", '"+this.Sexo+"', "+this.Peso+")", connec);
            connec.Open();
            comando.ExecuteNonQuery();
            connec.Close();
        }

        public void Alterar(Pessoa pessoa)
        {
            SqlConnection connec = new SqlConnection("Data Source=.;Initial Catalog=FACEAR_2019;User ID=ThiagoSouza;Password=12345678");
            SqlCommand comando = new SqlCommand("UPDATE Aluno SET Nome='" + pessoa.Nome + "', Idade=" + pessoa.Idade + ", Sexo='"+pessoa.Sexo+"', Peso="+pessoa.Peso+" WHERE Id_Pessoa = " + pessoa.Id_Pessoa + "; ", connec);
            connec.Open();
            comando.ExecuteNonQuery();
            connec.Close();
        }

        public void Deletar(Pessoa pessoa)
        {
            SqlConnection connec = new SqlConnection("Data Source=.;Initial Catalog=FACEAR_2019;User ID=ThiagoSouza;Password=12345678");
            SqlCommand comando = new SqlCommand("DELETE Aluno WHERE Id_Pessoa=" + pessoa.Id_Pessoa + "", connec);
            connec.Open();
            comando.ExecuteNonQuery();
            connec.Close();
        }

        /*public DataSet Busca_Alunos()
        {
            DataSet ds = new DataSet();
            SqlConnection connec = new SqlConnection("Data Source=.;Initial Catalog=CSharpMVC;Integrated Security=True");
            SqlCommand comando = new SqlCommand("SELECT * FROM Aluno", connec);
            SqlDataAdapter da = new SqlDataAdapter(comando);
            da.Fill(ds);
            return ds;
        }
        
        public List<Professor> Busca_Alunos_ID(int id)
        {
            DataSet ds = new DataSet();
            SqlConnection connec = new SqlConnection("Data Source=.;Initial Catalog=CSharpMVC;Integrated Security=True");
            SqlCommand comando = new SqlCommand("SELECT * FROM Aluno where Id_Professor="+id, connec);
            SqlDataAdapter da = new SqlDataAdapter(comando);
            da.Fill(ds);

            List<Professor> lista = ds.Tables[0].AsEnumerable().Select(dataRow => new Professor { Nome = dataRow.Field<string>("Nome"), Idade = dataRow.Field<int>("Idade") }).ToList();

            return lista;
            //return ds;
        }*/
    }
}