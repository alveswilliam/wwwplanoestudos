using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace wwwplanoestudos._class
{
    public class Aluno
    {
        public Aluno()
        {

        }

        public string RA { get; set; }
        public string Nome { get; set; }
        public string CodCurso { get; set; }
        public string CodPerlet { get; set; }
        public int CodColigada { get; set; }
    }
}