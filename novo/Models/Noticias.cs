using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace novo.Models
{
    public class Noticias
    {
        public int ID { get; set; }
        public int ID_Topico { get; set; }
        public string Titulo { get; set; }
        public string Descricao { get; set; }
    }
}