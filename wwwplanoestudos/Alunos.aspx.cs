using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using wwwplanoestudos;
using wwwplanoestudos._class;

namespace wwwplanoestudos
{
    public partial class Alunos : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                if (!IsPostBack)
                    CarregarCursos();
            }
            catch (Exception)
            {

                throw;
            }
        }

        public void CarregarCursos()
        {
            try
            {
                DataTable dt = (DataTable)Session["coordinfo"];

                rblCurso.DataSource = dt;
                rblCurso.DataTextField = dt.Columns["CURSO"].ToString();
                rblCurso.DataValueField = dt.Columns["CODCURSO"].ToString();
                rblCurso.DataBind();
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}