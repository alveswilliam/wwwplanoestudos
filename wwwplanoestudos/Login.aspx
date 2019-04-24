<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="wwwplanoestudos.Login" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>

    <meta charset="utf-8" />
    <meta http-equiv="X-UA-Compatible" content="IE=edge" />
    <meta name="viewport" content="width=device-width, initial-scale=1, shrink-to-fit=no" />
    <meta name="description" content="" />
    <meta name="author" content="" />

    <%--<link rel="stylesheet" href="https://stackpath.bootstrapcdn.com/bootstrap/4.3.1/css/bootstrap.min.css" />--%>
    <%--<link rel="stylesheet" href="https://stackpath.bootstrapcdn.com/bootstrap/4.1.3/css/bootstrap.min.css" />--%>
    <link href="vendor/bootstrap/css/bootstrap.min.css" rel="stylesheet" />
    <link rel="stylesheet" href="https://use.fontawesome.com/releases/v5.8.1/css/all.css" />
    <link type="text/css" href="assets/css/login.css" rel="stylesheet" />
    <link href="https://fonts.googleapis.com/css?family=Muli" rel="stylesheet" />
    <link rel="shortcut icon" href="assets/img/favicon-unifaj.png" />
</head>
<body>
    <form id="form1" runat="server">
        <div class="container">
            <div class="row">
                <div class="col-12">
                    <img src="assets/img/cabecalho-color.png" alt="cabecalho" class="img-fluid mx-auto d-block" />
                </div>
            </div>
            <div class="card card-login mx-auto mt-5">
                <div class="card-header">Plano de Estudos | Acesso</div>
                <div class="card-body">
                    <div class="form-group">
                        <div class="form-label-group">
                            <input type="text" id="txtUsuario" runat="server" class="form-control" placeholder="Usuário" required="required" autofocus="autofocus" />
                            <label for="txtUsuario">Usuário</label>
                        </div>
                    </div>
                    <div class="form-group">
                        <div class="form-label-group">
                            <input type="password" id="txtSenha" runat="server" class="form-control" placeholder="Senha" required="required" />
                            <label for="txtSenha">Senha</label>
                        </div>
                    </div>
                    <asp:Button ID="btnAcessar" runat="server" Text="Acessar" CssClass="btn btn-primary btn-block" />
                    <div class="text-center">
                        <a class="d-block small" href="https://portal.poliseducacional.com.br/Corpore.Net/SharedServices/LibPages/RecoverPassConfirmation.aspx?UserCaption=5LK%5c9F%5c3D%5c023%5c5B&ConfirmationCaption=%5c7B%5cFAbP%5c06%5c11Q%5c7C&RecoverContainerClassName=ASP.login_aspx,%20App_Web_vudjekzp,%20Version=0.0.0.0,%20Culture=neutral,%20PublicKeyToken=null&RecoverInitializeMethodName=GetRecoverPassServer&ServiceAlias=CorporeRM" target="_blank">Esqueceu sua senha?</a>
                    </div>
                </div>
            </div>

            <br />
            <div class="row">
                <div class="col-xs-12 col-md-12">
                    <div class="alert alert-danger" role="alert" runat="server" id="divMsgErro" visible="false">
                        <span class="fa fa-exclamation-triangle" aria-hidden="true"></span>
                        <strong>Atenção! </strong><span id="spanMsgErro" runat="server"></span>
                    </div>
                </div>
            </div>
        </div>
    </form>
</body>

<script src="https://code.jquery.com/jquery-3.3.1.slim.min.js"></script>
<script src="https://cdnjs.cloudflare.com/ajax/libs/popper.js/1.14.7/umd/popper.min.js"></script>
<script src="vendor/bootstrap/js/bootstrap.bundle.min.js"></script>
<script src="vendor/jquery/jquery.easing.min.js"></script>

</html>
