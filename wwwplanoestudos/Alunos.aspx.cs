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
                rblCurso.DataValueField = dt.Columns["VALOR"].ToString();
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
                Aluno aluno = new Aluno
                {
                    CodColigada = Convert.ToInt16(rblCurso.SelectedValue.Split('|')[1]),
                    CodTipoCurso = Convert.ToInt16(rblCurso.SelectedValue.Split('|')[2]),
                    CodPerlet = Session["codperlet"].ToString(),
                    CodCurso = rblCurso.SelectedValue.Split('|')[0]
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

        protected void gvAlunos_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                Aluno aluno = new Aluno
                {
                    CodColigada = Convert.ToInt16(rblCurso.SelectedValue.Split('|')[1]),
                    CodTipoCurso = Convert.ToInt16(rblCurso.SelectedValue.Split('|')[2]),
                    CodPerlet = Session["codperlet"].ToString(),
                    CodCurso = rblCurso.SelectedValue.Split('|')[0],
                    RA = gvAlunos.SelectedDataKey.Value.ToString()
                };

                DAL dal = new DAL();

                DataTable dt = dal.DisciplinasGrade(aluno);
                gvGradeAluno.DataSource = dt;
                gvGradeAluno.DataBind();

                dt.Clear();
                dt = dal.DisciplinasDependencia(aluno);
                gvDependencia.DataSource = dt;
                gvDependencia.DataBind();

                dt.Clear();
                dt = dal.DisciplinasCursando(aluno);
                gvDisciplinasCursando.DataSource = dt;
                gvDisciplinasCursando.DataBind();
            }
            catch (Exception)
            {

                throw;
            }
        }

        protected void btnAceitar_Click(object sender, EventArgs e)
        {
            try
            {
                Aluno aluno = new Aluno
                {
                    CodColigada = Convert.ToInt16(rblCurso.SelectedValue.Split('|')[1]),
                    CodTipoCurso = Convert.ToInt16(rblCurso.SelectedValue.Split('|')[2]),
                    CodPerlet = Session["codperlet"].ToString(),
                    CodCurso = rblCurso.SelectedValue.Split('|')[0],
                    RA = gvAlunos.SelectedDataKey.Value.ToString()
                };
            }
            catch (Exception)
            {

                throw;
            }
        }

        public bool AceitarGrade(Aluno aluno)
        {
            try
            {
                DAL dal = new DAL();
                dal.AtualizaStatusSMatricPl(aluno);
            }
            catch (Exception ex)
            {
                throw ex;
            }

            return true;
        }

        protected void btnRejeitar_Click(object sender, EventArgs e)
        {
            try
            {

            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}