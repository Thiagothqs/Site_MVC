using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web;
using System.Web.Script.Services;
using System.Web.Services;

namespace MVC_WebServices
{
    /// <summary>
    /// Descrição resumida de WebService
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // Para permitir que esse serviço da web seja chamado a partir do script, usando ASP.NET AJAX, remova os comentários da linha a seguir. 
    // [System.Web.Script.Services.ScriptService]
    public class WebService : System.Web.Services.WebService
    {

        [WebMethod]
        public string HelloWorld(string nome)
        {
            return "Olá, "+ nome; // "Olá, Mundo"
        }

        [ScriptMethod(ResponseFormat = ResponseFormat.Json)]
        [WebMethod]
        public string Busca_Cep(string cep)
        {
            using (HttpClient client = new HttpClient())
            {
                string url = "https://viacep.com.br/ws/" + cep + "/json/";
                var response = client.GetAsync(url).Result;
                using (HttpContent content = response.Content)
                {
                    try
                    {
                        Task<string> resultado = content.ReadAsStringAsync();
                        string JRetorno = resultado.Result;
                        cep = JRetorno;
                    }
                    catch { }
                }
            }
            return cep;
        }
    }
}
