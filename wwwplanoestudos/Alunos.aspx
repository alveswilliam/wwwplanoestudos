<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Alunos.aspx.cs" Inherits="wwwplanoestudos.Alunos" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Plano de Estudos - Alunos | UniFAJ - UniMax - FAAGROH</title>

    <meta charset="utf-8" />
    <meta name="viewport" content="width=device-width, initial-scale=1, shrink-to-fit=no" />
    <meta http-equiv="x-ua-compatible" content="ie=edge" />

    <link rel="stylesheet" href="https://use.fontawesome.com/releases/v5.7.0/css/all.css" />
    <link href="vendor/bootstrap/css/bootstrap.min.css" rel="stylesheet" />
    <link href="https://fonts.googleapis.com/css?family=Quicksand" rel="stylesheet" />
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

            <a class="navbar-brand" href="#" target="_blank">
                <img src="assets/img/logo.png" alt="Logotipo" />
                <strong>unifaj - unimax - faagroh</strong>
            </a>

            <button class="navbar-toggler" type="button" data-toggle="collapse" data-target="#navbarSupportedContent"
                aria-controls="navbarSupportedContent" aria-expanded="false" aria-label="Toggle navigation">
                <span class="navbar-toggler-icon"></span>
            </button>

            <div class="collapse navbar-collapse" id="navbarSupportedContent">

                <ul class="smooth-scroll navbar-nav mr-auto">
                    <li class="nav-item active">
                        <a class="nav-link" href="#">Início
             
                                <span class="sr-only">(current)</span>
                        </a>
                    </li>
                    <li class="nav-item">
                        <a class="nav-link" href="#login" onclick="acessoAluno()">Alterar grade</a>
                    </li>
                    <li class="nav-item">
                        <a class="nav-link" href="#" target="_blank">Gerados</a>
                    </li>
                </ul>

                <ul class="navbar-nav nav-flex-icons">
                    <li class="nav-item dropdown">
                        <a class="nav-link dropdown-toggle" href="#" id="navbarDropdown" role="button" data-toggle="dropdown" aria-haspopup="true" aria-expanded="false">Menu</a>
                        <div class="dropdown-menu" aria-labelledby="navbarDropdown">
                            <p><i class="fa fa-user-circle"></i> <span id="spanNome" runat="server"></span></p>
                            <div class="dropdown-divider"></div>
                            <a href="Login.aspx">Sair</a>
                        </div>
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
                            <h3 class="h3 mb-3">Instituição</h3>
                            <asp:RadioButtonList ID="rblInstituicao" runat="server" CssClass="radio radio-info" RepeatDirection="Horizontal" AutoPostBack="true" OnSelectedIndexChanged="rblInstituicao_SelectedIndexChanged"></asp:RadioButtonList>
                            <hr />
                        </div>
                    </div>

                    <div class="row">
                        <div class="col-md-12 mb-4">
                            <h3 class="h3 mb-3">Campus</h3>
                            <asp:RadioButtonList ID="rblCampus" runat="server" CssClass="radio radio-info" RepeatDirection="Horizontal" AutoPostBack="true" OnSelectedIndexChanged="rblCampus_SelectedIndexChanged"></asp:RadioButtonList>
                            <hr />
                        </div>
                    </div>

                    <div class="row">
                        <div class="col-md-12 mb-4">
                            <h3 class="h3 mb-3">Contexto</h3>
                            <asp:RadioButtonList ID="rblContexto" runat="server" CssClass="radio radio-info" RepeatDirection="Horizontal" AutoPostBack="true" OnSelectedIndexChanged="rblContexto_SelectedIndexChanged"></asp:RadioButtonList>
                            <hr />
                        </div>
                    </div>

                    <div class="row">
                        <div class="col-md-12 mb-4">
                            <h3 class="h3 mb-3">Curso</h3>
                            <asp:RadioButtonList ID="rblCurso" runat="server" CssClass="radio radio-info" RepeatDirection="Horizontal" AutoPostBack="true" OnSelectedIndexChanged="rblCurso_SelectedIndexChanged"></asp:RadioButtonList>
                            <hr />
                        </div>
                    </div>

                    <div class="row">
                        <div class="col-md-12 mb-4 text-center">
                            <h3 class="h3 mb-3">Alunos em Plano/Plano-pago</h3>
                        </div>
                        <div class="col-md-12 mb-4">
                            <asp:GridView ID="gvAlunos" runat="server" AutoGenerateColumns="false" CssClass="table table-responsive" GridLines="None" DataKeyNames="RA" OnSelectedIndexChanged="gvAlunos_SelectedIndexChanged">
                                <Columns>
                                    <asp:CommandField ShowSelectButton="true" SelectText="" ControlStyle-CssClass="fa fa-arrow-right" />
                                    <asp:BoundField DataField="RA" HeaderText="RA"></asp:BoundField>
                                    <asp:BoundField DataField="NOME" HeaderText="Nome"></asp:BoundField>
                                    <asp:BoundField DataField="TELEFONE1" HeaderText="Telefone"></asp:BoundField>
                                    <asp:BoundField DataField="EMAIL" HeaderText="E-mail"></asp:BoundField>
                                    <asp:BoundField DataField="DESCRICAO" HeaderText="Status"></asp:BoundField>
                                    <asp:BoundField DataField="STATUS" HeaderText="Situação"></asp:BoundField>
                                </Columns>
                                <HeaderStyle BackColor="#808080" Font-Bold="True" ForeColor="White"></HeaderStyle>
                                <RowStyle BackColor="#ffffff"></RowStyle>
                                <SelectedRowStyle BackColor="#fef4bf" Font-Bold="True" ForeColor="#333333"></SelectedRowStyle>
                            </asp:GridView>
                        </div>
                    </div>
                </section>

                <hr class="my-5" />

                <section id="disciplinas">
                    <h3 class="h3 text-center mb-5">Grade do aluno</h3>

                    <div class="row wow fadeIn">
                        <div class="col-lg-12 col-md-12 px-4">
                            <asp:GridView ID="gvGradeAluno" runat="server" AutoGenerateColumns="false" CssClass="table table-responsive" DataKeyNames="DIASEMANA, IDPERLET" ShowHeaderWhenEmpty="true" EmptyDataText="Não há disciplinas">
                                <Columns>
                                    <asp:BoundField DataField="DIASEMANA" HeaderText="DIASEMANA" Visible="false"></asp:BoundField>
                                    <asp:BoundField DataField="DIA" HeaderText="Dia"></asp:BoundField>
                                    <asp:BoundField DataField="HORAINICIAL" HeaderText="Horário"></asp:BoundField>
                                    <asp:BoundField DataField="CODDISC" HeaderText="Cód. Disc."></asp:BoundField>
                                    <asp:BoundField DataField="DISCIPLINA" HeaderText="Disciplina"></asp:BoundField>
                                    <asp:BoundField DataField="CURSO" HeaderText="Curso"></asp:BoundField>
                                    <asp:BoundField DataField="IDPERLET" HeaderText="IDPERLET" Visible="false"></asp:BoundField>
                                </Columns>
                                <HeaderStyle BackColor="#2b304e" Font-Bold="True" ForeColor="White"></HeaderStyle>
                                <RowStyle BackColor="#ffffff"></RowStyle>
                            </asp:GridView>
                        </div>
                    </div>

                    <h3 class="h3 text-center mb-5">Disciplinas em dependência</h3>

                    <div class="row wow fadeIn">
                        <div class="col-lg-6 col-md-12 px-4">
                            <asp:GridView ID="gvDependencia" runat="server" AutoGenerateColumns="false" CssClass="table table-responsive" ShowHeaderWhenEmpty="true" EmptyDataText="Não há disciplinas">
                                <Columns>
                                    <asp:BoundField DataField="CODDISC" HeaderText="Cód. Disc."></asp:BoundField>
                                    <asp:BoundField DataField="DISCIPLINA" HeaderText="Disciplina"></asp:BoundField>
                                    <asp:BoundField DataField="CODPERLET" HeaderText="Período"></asp:BoundField>
                                </Columns>
                                <HeaderStyle BackColor="#2b304e" Font-Bold="True" ForeColor="White"></HeaderStyle>
                                <RowStyle BackColor="#ffffff"></RowStyle>
                            </asp:GridView>

                        </div>
                    </div>

                    <h3 class="h3 text-center mb-5">Disciplinas cursando</h3>

                    <div class="row wow fadeIn">
                        <div class="col-lg-6 col-md-12 px-4">
                            <asp:GridView ID="gvDisciplinasCursando" runat="server" AutoGenerateColumns="false" CssClass="table table-responsive" ShowHeaderWhenEmpty="true" EmptyDataText="Não há disciplinas">
                                <Columns>
                                    <asp:BoundField DataField="CODDISC" HeaderText="Cód. Disc."></asp:BoundField>
                                    <asp:BoundField DataField="DISCIPLINA" HeaderText="Disciplina"></asp:BoundField>
                                    <asp:BoundField DataField="CODPERLET" HeaderText="Período"></asp:BoundField>
                                </Columns>
                                <HeaderStyle BackColor="#2b304e" Font-Bold="True" ForeColor="White"></HeaderStyle>
                                <RowStyle BackColor="#ffffff"></RowStyle>
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

                <hr />

                <section id="login" style="display:none">
                    <div class="container">
                        <div class="row">
                            <div class="col-xl-5 col-lg-6 col-md-10 col-sm-12 mx-auto mt-lg-5">
                                <div class="card wow fadeIn" data-wow-delay="0.3s">
                                    <div class="card-body">
                                        <div class="form-header purple-gradient">
                                            <h3>Acesso do aluno</h3>
                                        </div>

                                        <div class="md-form">
                                            <i class="fa fa-user prefix white-text"></i>
                                            <input type="text" id="txtUsuario" class="form-control" runat="server" />
                                            <label for="orangeForm-email">RA</label>
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
                </section>

            </div>
        </main>
    </form>

    <footer class="page-footer text-center font-small mt-4 wow fadeIn">
        <div class="pt-4">
        </div>

        <hr class="my-4" />

        <div class="pb-4">
        </div>

        <div class="footer-copyright py-3">
            &copy 2019 Copyright: UniFAJ
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

<script>
    function acessoAluno() {
        document.getElementById('login').style.display = 'inline';
        //document.getElementById('disciplinas').style.display = 'none';
    }
</script>

</html>
