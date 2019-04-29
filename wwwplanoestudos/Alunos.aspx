<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Alunos.aspx.cs" Inherits="wwwplanoestudos.Alunos" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Plano de Ensino - Alunos | UniFAJ - UniMax - FAAGROH</title>

    <meta charset="utf-8" />
    <meta name="viewport" content="width=device-width, initial-scale=1, shrink-to-fit=no" />
    <meta http-equiv="x-ua-compatible" content="ie=edge" />

    <link rel="stylesheet" href="https://use.fontawesome.com/releases/v5.7.0/css/all.css" />
    <link href="vendor/bootstrap/css/bootstrap.min.css" rel="stylesheet" />
    <link href="assets/css/mdb.min.css" rel="stylesheet" type="text/css" />
    <link href="assets/css/style.min.css" rel="stylesheet" />
    <link href="assets/css/radio-check.css" rel="stylesheet" />
    <link rel="shortcut icon" href="assets/img/favicon-unifaj.png" />

    <style type="text/css">
        @media (min-width: 800px) and (max-width: 850px) {
            .navbar:not(.top-nav-collapse) {
                background: #1C2331 !important;
            }
        }
    </style>

</head>
<body>
    <nav class="navbar fixed-top navbar-expand-lg navbar-dark scrolling-navbar">
        <div class="container">

            <a class="navbar-brand" href="https://mdbootstrap.com/docs/jquery/" target="_blank">
                <strong>MDB</strong>
            </a>

            <button class="navbar-toggler" type="button" data-toggle="collapse" data-target="#navbarSupportedContent"
                aria-controls="navbarSupportedContent" aria-expanded="false" aria-label="Toggle navigation">
                <span class="navbar-toggler-icon"></span>
            </button>

            <div class="collapse navbar-collapse" id="navbarSupportedContent">

                <ul class="navbar-nav mr-auto">
                    <li class="nav-item active">
                        <a class="nav-link" href="#">Home
             
                                <span class="sr-only">(current)</span>
                        </a>
                    </li>
                    <li class="nav-item">
                        <a class="nav-link" href="https://mdbootstrap.com/docs/jquery/" target="_blank">About MDB</a>
                    </li>
                    <li class="nav-item">
                        <a class="nav-link" href="https://mdbootstrap.com/docs/jquery/getting-started/download/" target="_blank">Free
              download</a>
                    </li>
                    <li class="nav-item">
                        <a class="nav-link" href="https://mdbootstrap.com/education/bootstrap/" target="_blank">Free tutorials</a>
                    </li>
                </ul>

                <ul class="navbar-nav nav-flex-icons">
                    <li class="nav-item">
                        <a href="https://www.facebook.com/mdbootstrap" class="nav-link" target="_blank">
                            <i class="fab fa-facebook-f"></i>
                        </a>
                    </li>
                    <li class="nav-item">
                        <a href="https://twitter.com/MDBootstrap" class="nav-link" target="_blank">
                            <i class="fab fa-twitter"></i>
                        </a>
                    </li>
                    <li class="nav-item">
                        <a href="https://github.com/mdbootstrap/bootstrap-material-design" class="nav-link border border-light rounded"
                            target="_blank">
                            <i class="fab fa-github mr-2"></i>MDB GitHub
                        </a>
                    </li>
                </ul>

            </div>

        </div>
    </nav>

    <div class="view" style="background-image: url('https://mdbootstrap.com/img/Photos/Others/images/93.jpg'); background-repeat: no-repeat; background-size: cover;">
        <div class="mask rgba-black-light d-flex justify-content-center align-items-center">
            <div class="text-center white-text mx-5 wow fadeIn">
                <h1 class="mb-4">
                    <strong>Plano de Estudos</strong>
                </h1>
            </div>
        </div>
    </div>
    
    <form id="form1" runat="server">
        <main>
            <div class="container">

                <section class="mt-5 wow fadeIn">
                    <div class="row">
                        <div class="col-md-12 mb-4">
                            <h3 class="h3 mb-3">Curso</h3>
                            <asp:RadioButtonList ID="rblCurso" runat="server" CssClass="radio radio-info" RepeatDirection="Horizontal" AutoPostBack="true" OnSelectedIndexChanged="rblCurso_SelectedIndexChanged"></asp:RadioButtonList>
                            <hr />
                        </div>
                    </div>

                    <div class="row">
                        <div class="col-md-12 mb-4">
                            <asp:GridView ID="gvAlunos" runat="server" AutoGenerateColumns="false" CssClass="table table-hover" DataKeyNames="RA" OnSelectedIndexChanged="gvAlunos_SelectedIndexChanged">
                                <Columns>
                                    <asp:CommandField ShowSelectButton="true" SelectText="Selecionar" ButtonType="Button" />
                                    <asp:BoundField DataField="RA" HeaderText="RA"></asp:BoundField>
                                    <asp:BoundField DataField="NOME" HeaderText="Nome"></asp:BoundField>
                                    <asp:BoundField DataField="TELEFONE1" HeaderText="Telefone"></asp:BoundField>
                                    <asp:BoundField DataField="EMAIL" HeaderText="E-mail"></asp:BoundField>
                                    <asp:BoundField DataField="STATUS" HeaderText="Situação"></asp:BoundField>
                                </Columns>
                            </asp:GridView>
                        </div>
                    </div>
                </section>

                <hr class="my-5" />

                <section id="disciplinas">
                    <h3 class="h3 text-center mb-5">Grade do aluno</h3>

                    <div class="row wow fadeIn">
                        <div class="col-lg-12 col-md-12 px-4">
                            <asp:GridView ID="gvGradeAluno" runat="server" AutoGenerateColumns="false" CssClass="table table-hover" ShowHeaderWhenEmpty="true" EmptyDataText="Não há disciplinas">
                                <Columns>
                                    <asp:BoundField DataField="DIASEMANA" HeaderText="DIASEMANA" Visible="false"></asp:BoundField>
                                    <asp:BoundField DataField="DIA" HeaderText="Dia"></asp:BoundField>
                                    <asp:BoundField DataField="HORAINICIAL" HeaderText="Horário"></asp:BoundField>
                                    <asp:BoundField DataField="CODDISC" HeaderText="Cód. Disc."></asp:BoundField>
                                    <asp:BoundField DataField="DISCIPLINA" HeaderText="Disciplina"></asp:BoundField>
                                    <asp:BoundField DataField="CURSO" HeaderText="Curso"></asp:BoundField>
                                    <asp:BoundField DataField="IDPERLET" HeaderText="IDPERLET" Visible="false"></asp:BoundField>
                                </Columns>
                            </asp:GridView>
                        </div>
                    </div>

                    <h3 class="h3 text-center mb-5">Disciplinas em dependência</h3>

                    <div class="row wow fadeIn">
                        <div class="col-lg-6 col-md-12 px-4">
                            <asp:GridView ID="gvDependencia" runat="server" AutoGenerateColumns="false" CssClass="table table-hover" ShowHeaderWhenEmpty="true" EmptyDataText="Não há disciplinas">
                                <Columns>
                                    <asp:BoundField DataField="CODDISC" HeaderText="Cód. Disc."></asp:BoundField>
                                    <asp:BoundField DataField="DISCIPLINA" HeaderText="Disciplina"></asp:BoundField>
                                    <asp:BoundField DataField="CODPERLET" HeaderText="Período"></asp:BoundField>
                                </Columns>
                            </asp:GridView>

                        </div>
                    </div>

                    <h3 class="h3 text-center mb-5">Disciplinas cursando</h3>

                    <div class="row wow fadeIn">
                        <div class="col-lg-6 col-md-12 px-4">
                            <asp:GridView ID="gvDisciplinasCursando" runat="server" AutoGenerateColumns="false" CssClass="table table-hover" ShowHeaderWhenEmpty="true" EmptyDataText="Não há disciplinas">
                                <Columns>
                                    <asp:BoundField DataField="CODDISC" HeaderText="Cód. Disc."></asp:BoundField>
                                    <asp:BoundField DataField="DISCIPLINA" HeaderText="Disciplina"></asp:BoundField>
                                    <asp:BoundField DataField="CODPERLET" HeaderText="Período"></asp:BoundField>
                                </Columns>
                            </asp:GridView>
                        </div>
                    </div>

                    <div class="row wow fadeIn">
                        <div class="col-lg-6 col-md-12 px-4 text-right">
                            <asp:Button ID="btnAceitar" runat="server" Text="Aceitar grade" CssClass="btn btn-outline-primary waves-effect" OnClick="btnAceitar_Click" />
                        </div>
                        <div class="col-lg-6 col-md-12 px-4 text-left">
                            <asp:Button ID="btnRejeitar" runat="server" Text="Rejeitar grade" CssClass="btn btn-outline-danger waves-effect" OnClick="btnRejeitar_Click" />
                        </div>
                    </div>

                </section>
                
            </div>
        </main>
    </form>

    <footer class="page-footer text-center font-small mt-4 wow fadeIn">
        <div class="pt-4">
            <a class="btn btn-outline-white" href="https://mdbootstrap.com/docs/jquery/getting-started/download/" target="_blank"
                role="button">Download MDB
       
                    <i class="fas fa-download ml-2"></i>
            </a>
            <a class="btn btn-outline-white" href="https://mdbootstrap.com/education/bootstrap/" target="_blank" role="button">Start
        free tutorial
       
                    <i class="fas fa-graduation-cap ml-2"></i>
            </a>
        </div>

        <hr class="my-4" />

        <div class="pb-4">
            <a href="https://www.facebook.com/mdbootstrap" target="_blank">
                <i class="fab fa-facebook-f mr-3"></i>
            </a>

            <a href="https://twitter.com/MDBootstrap" target="_blank">
                <i class="fab fa-twitter mr-3"></i>
            </a>

            <a href="https://www.youtube.com/watch?v=7MUISDJ5ZZ4" target="_blank">
                <i class="fab fa-youtube mr-3"></i>
            </a>

            <a href="https://plus.google.com/u/0/b/107863090883699620484" target="_blank">
                <i class="fab fa-google-plus-g mr-3"></i>
            </a>

            <a href="https://dribbble.com/mdbootstrap" target="_blank">
                <i class="fab fa-dribbble mr-3"></i>
            </a>

            <a href="https://pinterest.com/mdbootstrap" target="_blank">
                <i class="fab fa-pinterest mr-3"></i>
            </a>

            <a href="https://github.com/mdbootstrap/bootstrap-material-design" target="_blank">
                <i class="fab fa-github mr-3"></i>
            </a>

            <a href="http://codepen.io/mdbootstrap/" target="_blank">
                <i class="fab fa-codepen mr-3"></i>
            </a>
        </div>
        
        <div class="footer-copyright py-3">
            © 2019 Copyright:
     
                <a href="https://mdbootstrap.com/education/bootstrap/" target="_blank">MDBootstrap.com </a>
        </div>

    </footer>

</body>

<script type="text/javascript" src="vendor/jquery-3.3.1.min.js"></script>
<script type="text/javascript" src="vendor/bootstrap/js/popper.min.js"></script>
<script type="text/javascript" src="vendor/bootstrap/js/bootstrap.min.js"></script>
<script type="text/javascript" src="assets/js/mdb.min.js"></script>

<script type="text/javascript">
    // Animations initialization
    new WOW().init();

</script>

</html>
