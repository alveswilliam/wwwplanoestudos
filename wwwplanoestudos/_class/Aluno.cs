﻿using System;
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
        public int IdPerlet { get; set; }
        public int CodColigada { get; set; }
        public int CodTipoCurso { get; set; }
        public int CodStatusPlano { get; set; }
        public int CodStatusPlanoPago { get; set; }
        public int CodStatusConfirmacao { get; set; }
        public string UsuarioAlteracao { get; set; }
    }
}