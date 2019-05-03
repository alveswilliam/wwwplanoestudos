<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Alterar.aspx.cs" Inherits="wwwplanoestudos.Alterar" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Plano de Ensino - Alterar Grade | UniFAJ - UniMax - FAAGROH</title>

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
                        <a class="nav-link" href="Alunos.aspx">Início
             
                                <span class="sr-only">(current)</span>
                        </a>
                    </li>
                    <li class="nav-item">
                        <a class="nav-link" href="#login">Alterar grade</a>
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
                        <div class="col-md-6 mb-4">
                            <h3 class="h3 mb-3">Turmas</h3>
                            <asp:RadioButtonList ID="rblTurmas" runat="server" CssClass="radio radio-info" RepeatDirection="Horizontal" AutoPostBack="true"></asp:RadioButtonList>
                        </div>
                        <div class="col-md-6 mb-4">
                            <h3 class="h3 mb-3">Disciplinas da matriz</h3>
                            <asp:CheckBoxList ID="cblDisciplinaMatriz" runat="server" CssClass="checkbox checkbox-info" RepeatDirection="Vertical" AutoPostBack="true"></asp:CheckBoxList>
                            <asp:Button ID="btnAdicionarDisciplinaMatriz" runat="server" Text="Adicionar" CssClass="btn btn-primary btn-rounded btn-sm" />
                        </div>
                    </div>

                    <hr />

                    <div class="row">
                        <div class="col-md-4 mb-4">
                            <h3 class="h3 mb-3">Disciplinas de outro curso</h3>
                            <asp:DropDownList ID="ddlOutroCurso" runat="server" CssClass="form-control" AutoPostBack="true"></asp:DropDownList>
                            <asp:DropDownList ID="ddlTurmaOutroCurso" runat="server" CssClass="form-control" AutoPostBack="true"></asp:DropDownList>
                            <asp:DropDownList ID="ddlDisciplinaOutroCurso" runat="server" CssClass="form-control" AutoPostBack="true"></asp:DropDownList>
                            <asp:DropDownList ID="ddlDisciplinaEquivalenteOutroCurso" runat="server" CssClass="form-control" AutoPostBack="true"></asp:DropDownList>
                            <asp:Button ID="btnAdicionarDisciplinaOutroCurso" runat="server" Text="Adicionar" CssClass="btn btn-primary btn-rounded btn-sm" />
                            
                        </div>
                        <div class="col-md-4 mb-4">
                            <h3 class="h3 mb-3">Disciplinas EaD</h3>
                            <asp:DropDownList ID="ddlDisciplinaEad" runat="server" CssClass="form-control" AutoPostBack="true"></asp:DropDownList>
                            <asp:DropDownList ID="ddlAproveitamentoEad" runat="server" CssClass="form-control" AutoPostBack="true"></asp:DropDownList>
                            <asp:Button ID="btnAdicionarDisciplinaEad" runat="server" Text="Adicionar" CssClass="btn btn-primary btn-rounded btn-sm" />
                            
                        </div>
                        <div class="col-md-4 mb-4">
                            <h3 class="h3 mb-3">Disciplinas de outra matriz</h3>
                            <asp:DropDownList ID="ddlTurmaOutraMatriz" runat="server" CssClass="form-control" AutoPostBack="true"></asp:DropDownList>
                            <asp:DropDownList ID="ddlDisciplinaOutraMatriz" runat="server" CssClass="form-control" AutoPostBack="true"></asp:DropDownList>
                            <asp:DropDownList ID="ddlEquivalenteOutraMatriz" runat="server" CssClass="form-control" AutoPostBack="true"></asp:DropDownList>
                            <asp:Button ID="btnAdicionarDisciplinaOutraMatriz" runat="server" Text="Adicionar" CssClass="btn btn-primary btn-rounded btn-sm" />
                            
                        </div>
                    </div>

                    <div class="row">
                        <div class="col-md-12 mb-4 text-center">
                            <h3 class="h3 mb-3">Grade do aluno</h3>
                        </div>
                        <div class="col-md-12 mb-4">
                            <asp:GridView ID="gvGrade" runat="server" AutoGenerateColumns="false" CssClass="table table-responsive" GridLines="None">
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

                <div class="row wow fadeIn">
                        <div class="col-lg-12 col-md-12 px-4 text-center">
                            <asp:Button ID="btnConfirmar" runat="server" Text="Confirmar o plano" CssClass="btn btn-outline-primary waves-effect" />
                        </div>
                    </div>

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
</html>
