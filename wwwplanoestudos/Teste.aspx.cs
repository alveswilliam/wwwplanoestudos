using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using wwwplanoestudos._class;

namespace wwwplanoestudos
{
    public partial class Teste : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            Aluno aluno = new Aluno
            {
                CodColigada = 1,
                CodTipoCurso = 1,
                CodPerlet = "2019-01",
                CodCurso = "1018"
            };

            DAL dal = new DAL();
            DataTable dt = dal.AlunosPlano(aluno);
            gvAlunos.DataSource = dt;
            gvAlunos.DataBind();
        }
    }
}