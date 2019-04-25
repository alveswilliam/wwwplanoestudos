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


    <link rel="stylesheet" href="https://maxcdn.bootstrapcdn.com/font-awesome/4.7.0/css/font-awesome.min.css" />
    <link href="vendor/bootstrap/css/bootstrap.min.css" rel="stylesheet" />
    <%--<link href="https://fonts.googleapis.com/css?family=Muli" rel="stylesheet" />--%>
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
            /*background: url("http://mdbootstrap.com/img/Photos/Horizontal/Nature/full page/img%20(11).jpg")no-repeat center center;*/
            background-color: #fff; /*#2b304e*/
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
            color: #ffffff;
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
            border-bottom: 1px solid #8EDEF8;
            box-shadow: 0 1px 0 0 #8EDEF8;
        }

            .md-form input[type=text]:focus:not([readonly]) + label,
            .md-form input[type=password]:focus:not([readonly]) + label {
                color: #8EDEF8;
            }

        .md-form .form-control {
            color: #fff;
        }
    </style>

</head>
<body>
    <form id="form1" runat="server">
        

            <!--Main Navigation-->
            <header>

                <%--<nav class="navbar navbar-expand-lg navbar-dark fixed-top scrolling-navbar">
                    <div class="container">
                        <a class="navbar-brand" href="#"><strong>MDB</strong></a>
                        <button class="navbar-toggler" type="button" data-toggle="collapse" data-target="#navbarSupportedContent-7" aria-controls="navbarSupportedContent-7" aria-expanded="false" aria-label="Toggle navigation">
                            <span class="navbar-toggler-icon"></span>
                        </button>
                        <div class="collapse navbar-collapse" id="navbarSupportedContent-7">
                            <ul class="navbar-nav mr-auto">
                                <li class="nav-item active">
                                    <a class="nav-link" href="#">Home <span class="sr-only">(current)</span></a>
                                </li>
                                <li class="nav-item">
                                    <a class="nav-link" href="#">Link</a>
                                </li>
                                <li class="nav-item">
                                    <a class="nav-link" href="#">Profile</a>
                                </li>
                            </ul>
                            <form class="form-inline">
                                <div class="md-form my-0">
                                    <input class="form-control mr-sm-2" type="text" placeholder="Search" aria-label="Search">
                                </div>
                            </form>
                        </div>
                    </div>
                </nav>--%>

                <!--Intro Section-->
                <section class="view intro-2">
                    <div class="mask rgba-stylish-strong h-100 d-flex justify-content-center align-items-center">
                        <div class="container">
                            <div class="row">
                                <div class="col-xl-5 col-lg-6 col-md-10 col-sm-12 mx-auto mt-lg-5">

                                    <!--Form with header-->
                                    <div class="card wow fadeIn" data-wow-delay="0.3s">
                                        <div class="card-body">

                                            <!--Header-->
                                            <div class="form-header purple-gradient">
                                                <h3>Plano de Estudos</h3>
                                            </div>

                                            <!--Body-->
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
                                                <%--<button class="btn purple-gradient btn-lg">Acessar</button>--%>
                                                <asp:Button ID="btnAcessar" runat="server" Text="Acessar" CssClass="btn purple-gradient btn-lg" OnClick="btnAcessar_Click" />
                                                <hr />
                                                <div class="inline-ul text-center d-flex justify-content-center">
                                                    <a class="p-2 m-2">Esqueceu a senha?</a>
                                                    <%--<a class="p-2 m-2 fa-lg li-ic"><i class="fa fa-linkedin white-text"></i></a>
                                                    <a class="p-2 m-2 fa-lg ins-ic"><i class="fa fa-instagram white-text"></i></a>--%>
                                                </div>
                                            </div>

                                        </div>
                                    </div>
                                    <!--/Form with header-->

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
