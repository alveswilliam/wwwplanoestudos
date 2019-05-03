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
                    //CarregarCursos();
                    //PeriodoLetivo();
                    DadosIniciais();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void DadosIniciais()
        {
            try
            {
                Coordenador coordenador = (Coordenador)Session["coordinfo"];

                DAL dal = new DAL();
                DataTable dt = dal.InstituicaoCoordenador(coordenador);

                rblInstituicao.DataSource = dt;
                rblInstituicao.DataTextField = "INSTITUICAO";
                rblInstituicao.DataValueField = "CODCOLIGADA";
                rblInstituicao.DataBind();

                /* Nome do coordenador no menu */
                spanNome.InnerText = coordenador.Nome;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        protected void rblInstituicao_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                Campus();
            }
            catch (Exception)
            {

                throw;
            }
        }

        protected void rblCampus_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                Contexto();
            }
            catch (Exception)
            {

                throw;
            }
        }

        protected void rblContexto_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                Cursos();
                PeriodoLetivo();
            }
            catch (Exception)
            {

                throw;
            }
        }

        public void PeriodoLetivo()
        {
            try
            {
                DAL dal = new DAL();
                Periodo periodo = new Periodo();
                Coordenador coordenador = (Coordenador)Session["coordinfo"];
                coordenador.CodPerlet = periodo.CodPerlet;
                coordenador.IdPerlet = dal.IdPerlet(coordenador);
                
                Session["coordinfo"] = coordenador;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        protected void rblCurso_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                Coordenador coordenador = (Coordenador)Session["coordinfo"];

                Aluno aluno = new Aluno
                {
                    CodColigada = Convert.ToInt16(rblInstituicao.SelectedValue),
                    CodTipoCurso = coordenador.CodTipoCurso,
                    CodPerlet = coordenador.CodPerlet,
                    CodCurso = rblCurso.SelectedValue
                };

                DAL dal = new DAL();
                DataTable dt = dal.AlunosPlano(aluno);
                gvAlunos.DataSource = dt;
                gvAlunos.DataBind();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void Campus()
        {
            try
            {
                Coordenador coordenador = (Coordenador)Session["coordinfo"];
                coordenador.CodColigada = Convert.ToInt16(rblInstituicao.SelectedValue);
                Session["coordinfo"] = coordenador;

                DAL dal = new DAL();
                DataTable dt = dal.CampusCoordenador(coordenador);

                rblCampus.DataSource = dt;
                rblCampus.DataTextField = "CAMPUS";
                rblCampus.DataValueField = "CODCAMPUS";
                rblCampus.DataBind();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void Contexto()
        {
            try
            {
                Coordenador coordenador = (Coordenador)Session["coordinfo"];
                coordenador.CodCampus = rblCampus.SelectedValue;
                Session["coordinfo"] = coordenador;

                DAL dal = new DAL();
                DataTable dt = dal.Contexto(coordenador);

                rblContexto.DataSource = dt;
                rblContexto.DataTextField = "NOME";
                rblContexto.DataValueField = "CODTIPOCURSO";
                rblContexto.DataBind();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void Cursos()
        {
            try
            {
                Coordenador coordenador = (Coordenador)Session["coordinfo"];

                DAL dal = new DAL();
                DataTable dt = dal.CursoCoordenador(coordenador);

                rblCurso.DataSource = dt;
                rblCurso.DataTextField = "CURSO";
                rblCurso.DataValueField = "CODCURSO";
                rblCurso.DataBind();
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
                Coordenador coordenador = (Coordenador)Session["coordinfo"];

                Aluno aluno = new Aluno
                {
                    CodColigada = Convert.ToInt16(rblInstituicao.SelectedValue),
                    CodTipoCurso = coordenador.CodTipoCurso,
                    CodPerlet = coordenador.CodPerlet,
                    CodCurso = rblCurso.SelectedValue,
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
                Coordenador coordenador = (Coordenador)Session["coordinfo"];

                Aluno aluno = new Aluno
                {
                    CodColigada = Convert.ToInt16(rblInstituicao.SelectedValue),
                    CodTipoCurso = coordenador.CodTipoCurso,
                    CodPerlet = coordenador.CodPerlet,
                    IdPerlet = coordenador.IdPerlet,
                    CodCurso = rblCurso.SelectedValue,
                    RA = gvAlunos.SelectedDataKey.Value.ToString(),
                    UsuarioAlteracao = Session["codusuario"].ToString()
                };
            }
            catch (Exception)
            {

                throw;
            }
        }

        public bool AceitarGrade(Plano plano)
        {
            try
            {
                DAL dal = new DAL();
                dal.AtualizaStatusSMatricPl(aluno);
                dal.AtualizaStatusSMatricula(aluno);
                dal.AtualizaStatusSHabilitacaoAluno(aluno);
                dal.AtualizaStatusPlano(plano);
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

        protected void btnAcessar_Click(object sender, EventArgs e)
        {
            try
            {
                Response.Redirect("Alterar.aspx", false);
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}