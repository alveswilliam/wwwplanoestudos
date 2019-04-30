using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace wwwplanoestudos._class
{
    public class Coordenador
    {
        public Coordenador()
        {

        }

        public string CodUsuario { get; set; }
        public string Nome { get; set; }
        public int CodColigada { get; set; }
        public int CodTipoCurso { get; set; }
        public string CodCampus { get; set; }
        public string CodPerlet { get; set; }
        public int IdPerlet { get; set; }
    }
}