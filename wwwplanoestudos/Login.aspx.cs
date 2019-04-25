using CPConnect;
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
    public partial class Login : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
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
                //LoginClass login = new LoginClass();
                //object a, b, c;
                //int erro_i = 0;
                //string erro_s = null;

                //b = login.ErrorCode;
                //c = login.ErrorMessage;
                //a = null;

                ////método utilizado para conexão com RM através de ADO
                //login.GetConnectionParams(true, "CORPORERM", txtUsuario.Value.ToString(), txtSenha.Value.ToString(), "F", ref a, ref erro_i, ref erro_s);
                ////método utilizado para verificação do usuário dentro do RM
                //login.GetAccessParams(true, "CORPORERM", txtUsuario.Value.ToString(), txtSenha.Value.ToString(), "F", ref a, ref b, ref c);
                ////O código '0' indica que a conexão foi efetuada com sucesso.

                //if (b.ToString() == "10" || b.ToString() == "11" || b.ToString() == "12" || b.ToString() == "0")
                //{
                    //Usuário existe e senha OK, mas sem permissão de acesso ao corpore.net

                    Coordenador coordenador = new Coordenador
                    {
                        CodUsuario = txtUsuario.Value
                    };

                    DAL dal = new DAL();
                    DataTable dt = dal.ValidaCoordenador(coordenador);

                    if (dt.Rows.Count > 0)
                    {
                        Session["coordinfo"] = dt;
                        Response.Redirect("Alunos.aspx", false);
                    }
                    else
                        throw new Exception("Você não tem permissão de acesso ao sistema. Favor entrar em contato com o suporte.");

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