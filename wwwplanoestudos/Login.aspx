<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="wwwplanoestudos.Login" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Plano de Estudos - Acesso | UniFAJ - UniMax - FAAGROH</title>

    <meta charset="utf-8" />
    <meta http-equiv="X-UA-Compatible" content="IE=edge" />
    <meta name="viewport" content="width=device-width, initial-scale=1, shrink-to-fit=no" />
    <meta name="description" content="" />
    <meta name="author" content="" />


    <link rel="stylesheet" href="https://maxcdn.bootstrapcdn.com/font-awesome/4.7.0/css/font-awesome.min.css" />
    <link href="vendor/bootstrap/css/bootstrap.min.css" rel="stylesheet" />
    <link href="https://fonts.googleapis.com/css?family=Quicksand" rel="stylesheet" />
    <link href="assets/css/mdbpro.min.css" rel="stylesheet" type="text/css" />
    <link rel="shortcut icon" href="assets/img/favicon-unifaj.png" />

    <style>
        html,
        body,
        header,
        .view {
            height: 100vh;
        }

        @media (max-width: 740px) {
            html,
            body,
            header,
            .view {
                height: 815px;
            }
        }

        @media (min-width: 800px) and (max-width: 850px) {
            html,
            body,
            header,
            .view {
                height: 650px;
            }
        }

        .intro-2 {
            background: url("../assets/img/background.png") center center;
            /*background-color: #fff; /*#2b304e*/
            background-size: cover;
        }

        .top-nav-collapse {
            background-color: #3f51b5 !important;
        }

        .navbar:not(.top-nav-collapse) {
            background: transparent !important;
        }

        @media (max-width: 768px) {
            .navbar:not(.top-nav-collapse) {
                background: #3f51b5 !important;
            }
        }

        @media (min-width: 800px) and (max-width: 850px) {
            .navbar:not(.top-nav-collapse) {
                background: #3f51b5 !important;
            }
        }

        .card {
            background-color: rgba(229, 228, 255, 0.2);
        }

        .md-form label {
            color: #2b304e;
        }

        h6 {
            line-height: 1.7;
        }


        .card {
            margin-top: 30px;
            /*margin-bottom: -45px;*/
        }

        .md-form input[type=text]:focus:not([readonly]),
        .md-form input[type=password]:focus:not([readonly]) {
            border-bottom: 1px solid #2b304e;
            box-shadow: 0 1px 0 0 #2b304e;
        }

            .md-form input[type=text]:focus:not([readonly]) + label,
            .md-form input[type=password]:focus:not([readonly]) + label {
                color: #2b304e;
            }

        .md-form .form-control {
            color: #5e5e5e;
        }
    </style>

</head>
<body>
    <form id="form1" runat="server">

        <header>
            <section class="view intro-2">
                <div class="mask rgba-stylish-strong h-100 d-flex justify-content-center align-items-center">
                    <div class="container">

                        <div class="row">
                            <div class="col-xl-5 col-lg-6 col-md-10 col-sm-12 mx-auto mt-lg-5">
                                <img src="assets/img/cabecalho-color.png" alt="Logo das instituições" class="img-fluid centro" />
                            </div>
                        </div>

                        <div class="row">
                            <div class="col-xl-5 col-lg-6 col-md-10 col-sm-12 mx-auto mt-lg-5">
                                <div class="card wow fadeIn" data-wow-delay="0.3s">
                                    <div class="card-body">
                                        <div class="form-header purple-gradient">
                                            <h3>Plano de Estudos</h3>
                                        </div>

                                        <div class="md-form">
                                            <i class="fa fa-user prefix white-text"></i>
                                            <input type="text" id="txtUsuario" class="form-control" runat="server" />
                                            <label for="orangeForm-email">Usuário</label>
                                        </div>

                                        <div class="md-form">
                                            <i class="fa fa-lock prefix white-text"></i>
                                            <input type="password" id="txtSenha" class="form-control" runat="server" />
                                            <label for="orangeForm-pass">Senha</label>
                                        </div>

                                        <div class="text-center">
                                            <asp:Button ID="btnAcessar" runat="server" Text="Acessar" CssClass="btn purple-gradient btn-lg" OnClick="btnAcessar_Click" />
                                            <hr />
                                            <div class="inline-ul text-center d-flex justify-content-center">
                                                <a class="p-2 m-2">Esqueceu a senha?</a>
                                            </div>
                                        </div>

                                    </div>
                                </div>
                            </div>
                        </div>
                    </div>
                </div>
            </section>
        </header>

        <%--<div class="row">
                <div class="col-xs-12 col-md-12">
                    <div class="alert alert-danger" role="alert" runat="server" id="divMsgErro" visible="false">
                        <span class="fa fa-exclamation-triangle" aria-hidden="true"></span>
                        <strong>Atenção! </strong><span id="spanMsgErro" runat="server"></span>
                    </div>
                </div>
            </div>--%>
    </form>
</body>

<script type="text/javascript" src="vendor/jquery-3.3.1.min.js"></script>
<script type="text/javascript" src="vendor/bootstrap/js/popper.min.js"></script>
<script type="text/javascript" src="vendor/bootstrap/js/bootstrap.min.js"></script>
<script type="text/javascript" src="assets/js/mdb.min.js"></script>
<script>
    new WOW().init();
</script>

</html>
