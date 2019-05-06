using CPConnect;
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

                Plano plano = new Plano
                {
                    CodColigada = Convert.ToInt16(rblInstituicao.SelectedValue),
                    CodTipoCurso = coordenador.CodTipoCurso,
                    CodPerlet = coordenador.CodPerlet,
                    IdPerlet = coordenador.IdPerlet,
                    CodCurso = rblCurso.SelectedValue,
                    RA = gvAlunos.SelectedDataKey.Value.ToString(),
                    Usuario = coordenador.CodUsuario,
                    Status = "Grade aceita"
                };

                AceitarGrade(plano);
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
                dal.AtualizaStatusSMatricPl(plano);
                dal.AtualizaStatusSMatricula(plano);
                dal.AtualizaStatusSHabilitacaoAluno(plano);

                if (dal.TemPlano(plano))
                    dal.AtualizaStatusPlano(plano);
                else
                    dal.InsereNovoPlano(plano);
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
                Coordenador coordenador = (Coordenador)Session["coordinfo"];

                Plano plano = new Plano
                {
                    CodColigada = Convert.ToInt16(rblInstituicao.SelectedValue),
                    CodTipoCurso = coordenador.CodTipoCurso,
                    CodPerlet = coordenador.CodPerlet,
                    IdPerlet = coordenador.IdPerlet,
                    CodCurso = rblCurso.SelectedValue,
                    RA = gvAlunos.SelectedDataKey.Value.ToString(),
                    Usuario = coordenador.CodUsuario,
                    Status = "Grade rejeitada"
                };

                DAL dal = new DAL();

                if (dal.TemPlano(plano))
                    dal.AtualizaStatusPlano(plano);
                else
                    dal.InsereNovoPlano(plano);
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
                //LoginClass login = new LoginClass();
                //object a, b, c;
                //int erro_i = 0;
                //string erro_s = null;

                //b = login.ErrorCode;
                //c = login.ErrorMessage;
                //a = null;

                ////método utilizado para conexão com RM através de ADO
                //login.GetConnectionParams(true, "CORPORERM", txtRA.Value.ToString(), txtSenha.Value.ToString(), "F", ref a, ref erro_i, ref erro_s);
                ////método utilizado para verificação do usuário dentro do RM
                //login.GetAccessParams(true, "CORPORERM", txtRA.Value.ToString(), txtSenha.Value.ToString(), "F", ref a, ref b, ref c);
                ////O código '0' indica que a conexão foi efetuada com sucesso.

                //if (b.ToString() == "10" || b.ToString() == "11" || b.ToString() == "12" || b.ToString() == "0")
                //{
                    //Usuário existe e senha OK, mas sem permissão de acesso ao corpore.net

                    Coordenador coordenador = (Coordenador)Session["coordinfo"];

                    Aluno aluno = new Aluno
                    {
                        CodColigada = Convert.ToInt16(rblInstituicao.SelectedValue),
                        CodTipoCurso = coordenador.CodTipoCurso,
                        RA = txtRA.Value,
                        CodPerlet = coordenador.CodPerlet,
                        CodCurso = rblCurso.SelectedValue
                    };

                    DAL dal = new DAL();

                    if (dal.AlunoMatriculadoCurso(aluno))
                    {
                        Response.Redirect("Alterar.aspx", false);
                    }
                    else
                        throw new Exception("O aluno não está regularmente matriculado no curso selecionado.");
                //}
                //else
                //{
                //    //divMsg.Visible = true;
                //    //spanMsg.InnerText = "Usuário ou senha incorretos.";
                //}
            }
            catch (Exception ex)
            {
                //divMsg.Visible = true;
                //spanMsg.InnerText = "Houve um erro ao realizar o login: " + ex.Message;
            }
        }
    }
}