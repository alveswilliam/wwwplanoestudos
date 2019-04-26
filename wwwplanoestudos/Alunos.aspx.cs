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
                {
                    CarregarCursos();
                    PeriodoLetivo();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void PeriodoLetivo()
        {
            try
            {
                Periodo periodo = new Periodo();
                Session["codperlet"] = periodo.CodPerlet;
            }
            catch (Exception ex)
            {
                throw ex;
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

        protected void rblCurso_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                DataTable dt = (DataTable)Session["coordinfo"];
                

                Aluno aluno = new Aluno
                {
                    CodColigada = Convert.ToInt16(dt.Rows[0]["CODCOLIGADA"]),
                    CodPerlet = Session["codperlet"].ToString(),
                    CodCurso = rblCurso.SelectedValue
                };

                DAL dal = new DAL();
                DataTable dtAlunos = dal.AlunosPlano(aluno);
                gvAlunos.DataSource = dtAlunos;
                gvAlunos.DataBind();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}