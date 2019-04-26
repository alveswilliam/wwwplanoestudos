<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Alunos.aspx.cs" Inherits="wwwplanoestudos.Alunos" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>

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

    <!-- Navbar -->
    <nav class="navbar fixed-top navbar-expand-lg navbar-dark scrolling-navbar">
        <div class="container">

            <!-- Brand -->
            <a class="navbar-brand" href="https://mdbootstrap.com/docs/jquery/" target="_blank">
                <strong>MDB</strong>
            </a>

            <!-- Collapse -->
            <button class="navbar-toggler" type="button" data-toggle="collapse" data-target="#navbarSupportedContent"
                aria-controls="navbarSupportedContent" aria-expanded="false" aria-label="Toggle navigation">
                <span class="navbar-toggler-icon"></span>
            </button>

            <!-- Links -->
            <div class="collapse navbar-collapse" id="navbarSupportedContent">

                <!-- Left -->
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

                <!-- Right -->
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
    <!-- Navbar -->

    <!-- Full Page Intro -->
    <div class="view" style="background-image: url('https://mdbootstrap.com/img/Photos/Others/images/93.jpg'); background-repeat: no-repeat; background-size: cover;">

        <!-- Mask & flexbox options-->
        <div class="mask rgba-black-light d-flex justify-content-center align-items-center">

            <!-- Content -->
            <div class="text-center white-text mx-5 wow fadeIn">
                <h1 class="mb-4">
                    <strong>Plano de Estudos</strong>
                </h1>
            </div>
            <!-- Content -->

        </div>
        <!-- Mask & flexbox options-->

    </div>
    <!-- Full Page Intro -->
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
                            <asp:GridView ID="gvAlunos" runat="server" AutoGenerateColumns="false" CssClass="table table-hover">
                                <Columns>
                                    <asp:CommandField ShowSelectButton="true" SelectText="Selecionar" ButtonType="Button" />
                                    <asp:BoundField DataField="RA" HeaderText="RA"></asp:BoundField>
                                    <asp:BoundField DataField="NOME" HeaderText="Nome"></asp:BoundField>
                                    <asp:BoundField DataField="TELEFONE1" HeaderText="Telefone"></asp:BoundField>
                                    <asp:BoundField DataField="EMAIL" HeaderText="E-mail"></asp:BoundField>
                                    <%--<asp:BoundField DataField="DESCRICAO" HeaderText="DESCRIÇÃO"></asp:BoundField>--%>
                                    <asp:BoundField DataField="STATUS" HeaderText="Situação"></asp:BoundField>
                                </Columns>
                            </asp:GridView>
                        </div>
                    </div>

                    <!--Grid row-->

                </section>
                <!--Section: Main info-->

                <hr class="my-5" />

                <!--Section: Main features & Quick Start-->
                <section id="disciplinas">

                    <h3 class="h3 text-center mb-5">Grade do aluno</h3>

                    <div class="row wow fadeIn">
                        <div class="col-lg-6 col-md-12 px-4">
                            <asp:GridView ID="gvGradeAluno" runat="server" AutoGenerateColumns="false" CssClass="table table-hover">
                                <Columns>
                                    <asp:BoundField DataField="DIA" HeaderText="RA"></asp:BoundField>
                                    <asp:BoundField DataField="HORARIO" HeaderText="Nome"></asp:BoundField>
                                    <asp:BoundField DataField="TELEFONE1" HeaderText="Telefone"></asp:BoundField>
                                    <asp:BoundField DataField="EMAIL" HeaderText="E-mail"></asp:BoundField>
                                    <%--<asp:BoundField DataField="DESCRICAO" HeaderText="DESCRIÇÃO"></asp:BoundField>--%>
                                    <asp:BoundField DataField="STATUS" HeaderText="Situação"></asp:BoundField>
                                </Columns>
                            </asp:GridView>

                        </div>
                    </div>

                    <h3 class="h3 text-center mb-5">Disciplinas em dependência</h3>

                    <div class="row wow fadeIn">
                        <div class="col-lg-6 col-md-12 px-4">
                            <asp:GridView ID="gvDependencia" runat="server" AutoGenerateColumns="false" CssClass="table table-hover">
                                <Columns>
                                    <asp:CommandField ShowSelectButton="true" SelectText="Selecionar" ButtonType="Button" />
                                    <asp:BoundField DataField="RA" HeaderText="RA"></asp:BoundField>
                                    <asp:BoundField DataField="NOME" HeaderText="Nome"></asp:BoundField>
                                    <asp:BoundField DataField="TELEFONE1" HeaderText="Telefone"></asp:BoundField>
                                    <asp:BoundField DataField="EMAIL" HeaderText="E-mail"></asp:BoundField>
                                    <%--<asp:BoundField DataField="DESCRICAO" HeaderText="DESCRIÇÃO"></asp:BoundField>--%>
                                    <asp:BoundField DataField="STATUS" HeaderText="Situação"></asp:BoundField>
                                </Columns>
                            </asp:GridView>

                        </div>
                    </div>

                    <h3 class="h3 text-center mb-5">Disciplinas cursando</h3>

                    <div class="row wow fadeIn">
                        <div class="col-lg-6 col-md-12 px-4">
                            <asp:GridView ID="gvDisciplinasCursando" runat="server" AutoGenerateColumns="false" CssClass="table table-hover">
                                <Columns>
                                    <asp:CommandField ShowSelectButton="true" SelectText="Selecionar" ButtonType="Button" />
                                    <asp:BoundField DataField="RA" HeaderText="RA"></asp:BoundField>
                                    <asp:BoundField DataField="NOME" HeaderText="Nome"></asp:BoundField>
                                    <asp:BoundField DataField="TELEFONE1" HeaderText="Telefone"></asp:BoundField>
                                    <asp:BoundField DataField="EMAIL" HeaderText="E-mail"></asp:BoundField>
                                    <%--<asp:BoundField DataField="DESCRICAO" HeaderText="DESCRIÇÃO"></asp:BoundField>--%>
                                    <asp:BoundField DataField="STATUS" HeaderText="Situação"></asp:BoundField>
                                </Columns>
                            </asp:GridView>
                        </div>
                    </div>
                    

                </section>
                <!--Section: Main features & Quick Start-->

                <hr class="my-5" />

                <!--Section: Not enough-->
                <section>

                    <h2 class="my-5 h3 text-center">Not enough?</h2>

                    <!--First row-->
                    <div class="row features-small mb-5 mt-3 wow fadeIn">

                        <!--First column-->
                        <div class="col-md-4">
                            <!--First row-->
                            <div class="row">
                                <div class="col-2">
                                    <i class="fas fa-check-circle fa-2x indigo-text"></i>
                                </div>
                                <div class="col-10">
                                    <h6 class="feature-title">Free for personal and commercial use</h6>
                                    <p class="grey-text">
                                        Our license is user-friendly. Feel free to use MDB for both private as well as
                  commercial projects.
               
                                    </p>
                                    <div style="height: 15px"></div>
                                </div>
                            </div>
                            <!--/First row-->

                            <!--Second row-->
                            <div class="row">
                                <div class="col-2">
                                    <i class="fas fa-check-circle fa-2x indigo-text"></i>
                                </div>
                                <div class="col-10">
                                    <h6 class="feature-title">400+ UI elements</h6>
                                    <p class="grey-text">
                                        An impressive collection of flexible components allows you to develop any project.
               
                                    </p>
                                    <div style="height: 15px"></div>
                                </div>
                            </div>
                            <!--/Second row-->

                            <!--Third row-->
                            <div class="row">
                                <div class="col-2">
                                    <i class="fas fa-check-circle fa-2x indigo-text"></i>
                                </div>
                                <div class="col-10">
                                    <h6 class="feature-title">600+ icons</h6>
                                    <p class="grey-text">Hundreds of useful, scalable, vector icons at your disposal.</p>
                                    <div style="height: 15px"></div>
                                </div>
                            </div>
                            <!--/Third row-->

                            <!--Fourth row-->
                            <div class="row">
                                <div class="col-2">
                                    <i class="fas fa-check-circle fa-2x indigo-text"></i>
                                </div>
                                <div class="col-10">
                                    <h6 class="feature-title">Fully responsive</h6>
                                    <p class="grey-text">
                                        It doesn't matter whether your project will be displayed on desktop, laptop,
                  tablet or mobile phone. MDB
                  looks great on each screen.
                                    </p>
                                    <div style="height: 15px"></div>
                                </div>
                            </div>
                            <!--/Fourth row-->
                        </div>
                        <!--/First column-->

                        <!--Second column-->
                        <div class="col-md-4 flex-center">
                            <img src="https://mdbootstrap.com/img/Others/screens.png" alt="MDB Magazine Template displayed on iPhone"
                                class="z-depth-0 img-fluid">
                        </div>
                        <!--/Second column-->

                        <!--Third column-->
                        <div class="col-md-4 mt-2">
                            <!--First row-->
                            <div class="row">
                                <div class="col-2">
                                    <i class="fas fa-check-circle fa-2x indigo-text"></i>
                                </div>
                                <div class="col-10">
                                    <h6 class="feature-title">70+ CSS animations</h6>
                                    <p class="grey-text">
                                        Neat and easy to use animations, which will increase the interactivity of your
                  project and delight your visitors.
               
                                    </p>
                                    <div style="height: 15px"></div>
                                </div>
                            </div>
                            <!--/First row-->

                            <!--Second row-->
                            <div class="row">
                                <div class="col-2">
                                    <i class="fas fa-check-circle fa-2x indigo-text"></i>
                                </div>
                                <div class="col-10">
                                    <h6 class="feature-title">Plenty of useful templates</h6>
                                    <p class="grey-text">Need inspiration? Use one of our predefined templates for free.</p>
                                    <div style="height: 15px"></div>
                                </div>
                            </div>
                            <!--/Second row-->

                            <!--Third row-->
                            <div class="row">
                                <div class="col-2">
                                    <i class="fas fa-check-circle fa-2x indigo-text"></i>
                                </div>
                                <div class="col-10">
                                    <h6 class="feature-title">Easy installation</h6>
                                    <p class="grey-text">
                                        5 minutes, a few clicks and... done. You will be surprised at how easy it is.
               
                                    </p>
                                    <div style="height: 15px"></div>
                                </div>
                            </div>
                            <!--/Third row-->

                            <!--Fourth row-->
                            <div class="row">
                                <div class="col-2">
                                    <i class="fas fa-check-circle fa-2x indigo-text"></i>
                                </div>
                                <div class="col-10">
                                    <h6 class="feature-title">Easy to use and customize</h6>
                                    <p class="grey-text">
                                        Using MDB is straightforward and pleasant. Components flexibility allows you deep
                  customization. You will
                  easily adjust each component to suit your needs.
                                    </p>
                                    <div style="height: 15px"></div>
                                </div>
                            </div>
                            <!--/Fourth row-->
                        </div>
                        <!--/Third column-->

                    </div>
                    <!--/First row-->

                </section>
                <!--Section: Not enough-->

                <hr class="mb-5">

                <!--Section: More-->
                <section>

                    <h2 class="my-5 h3 text-center">...and even more</h2>

                    <!--First row-->
                    <div class="row features-small mt-5 wow fadeIn">

                        <!--Grid column-->
                        <div class="col-xl-3 col-lg-6">
                            <!--Grid row-->
                            <div class="row">
                                <div class="col-2">
                                    <i class="fab fa-firefox fa-2x mb-1 indigo-text" aria-hidden="true"></i>
                                </div>
                                <div class="col-10 mb-2 pl-3">
                                    <h5 class="feature-title font-bold mb-1">Cross-browser compatibility</h5>
                                    <p class="grey-text mt-2">
                                        Chrome, Firefox, IE, Safari, Opera, Microsoft Edge - MDB loves all browsers;
                  all browsers love MDB.
               
                                    </p>
                                </div>
                            </div>
                            <!--/Grid row-->
                        </div>
                        <!--/Grid column-->

                        <!--Grid column-->
                        <div class="col-xl-3 col-lg-6">
                            <!--Grid row-->
                            <div class="row">
                                <div class="col-2">
                                    <i class="fas fa-level-up-alt fa-2x mb-1 indigo-text" aria-hidden="true"></i>
                                </div>
                                <div class="col-10 mb-2">
                                    <h5 class="feature-title font-bold mb-1">Frequent updates</h5>
                                    <p class="grey-text mt-2">
                                        MDB becomes better every month. We love the project and enhance as much as
                  possible.
               
                                    </p>
                                </div>
                            </div>
                            <!--/Grid row-->
                        </div>
                        <!--/Grid column-->

                        <!--Grid column-->
                        <div class="col-xl-3 col-lg-6">
                            <!--Grid row-->
                            <div class="row">
                                <div class="col-2">
                                    <i class="fas fa-comments fa-2x mb-1 indigo-text" aria-hidden="true"></i>
                                </div>
                                <div class="col-10 mb-2">
                                    <h5 class="feature-title font-bold mb-1">Active community</h5>
                                    <p class="grey-text mt-2">
                                        Our society grows day by day. Visit our forum and check how it is to be a
                  part of our family.
               
                                    </p>
                                </div>
                            </div>
                            <!--/Grid row-->
                        </div>
                        <!--/Grid column-->

                        <!--Grid column-->
                        <div class="col-xl-3 col-lg-6">
                            <!--Grid row-->
                            <div class="row">
                                <div class="col-2">
                                    <i class="fas fa-code fa-2x mb-1 indigo-text" aria-hidden="true"></i>
                                </div>
                                <div class="col-10 mb-2">
                                    <h5 class="feature-title font-bold mb-1">jQuery 3.x</h5>
                                    <p class="grey-text mt-2">
                                        MDB is integrated with newest jQuery. Therefore you can use all the latest
                  features which come along with
                  it.
               
                                    </p>
                                </div>
                            </div>
                            <!--/Grid row-->
                        </div>
                        <!--/Grid column-->

                    </div>
                    <!--/First row-->

                    <!--Second row-->
                    <div class="row features-small mt-4 wow fadeIn">

                        <!--Grid column-->
                        <div class="col-xl-3 col-lg-6">
                            <!--Grid row-->
                            <div class="row">
                                <div class="col-2">
                                    <i class="fas fa-cubes fa-2x mb-1 indigo-text" aria-hidden="true"></i>
                                </div>
                                <div class="col-10 mb-2">
                                    <h5 class="feature-title font-bold mb-1">Modularity</h5>
                                    <p class="grey-text mt-2">
                                        Material Design for Bootstrap comes with both, compiled, ready to use
                  libraries including all features as
                  well as modules for CSS (SASS files) and JS.
                                    </p>
                                </div>
                            </div>
                            <!--/Grid row-->
                        </div>
                        <!--/Grid column-->

                        <!--Grid column-->
                        <div class="col-xl-3 col-lg-6">
                            <!--Grid row-->
                            <div class="row">
                                <div class="col-2">
                                    <i class="fas fa-question fa-2x mb-1 indigo-text" aria-hidden="true"></i>
                                </div>
                                <div class="col-10 mb-2">
                                    <h5 class="feature-title font-bold mb-1">Technical support</h5>
                                    <p class="grey-text mt-2">
                                        We care about reliability. If you have any questions - do not hesitate to
                  contact us.
               
                                    </p>
                                </div>
                            </div>
                            <!--/Grid row-->
                        </div>
                        <!--/Grid column-->

                        <!--Grid column-->
                        <div class="col-xl-3 col-lg-6">
                            <!--Grid row-->
                            <div class="row">
                                <div class="col-2">
                                    <i class="fas fa-th fa-2x mb-1 indigo-text" aria-hidden="true"></i>
                                </div>
                                <div class="col-10 mb-2">
                                    <h5 class="feature-title font-bold mb-1">Flexbox</h5>
                                    <p class="grey-text mt-2">MDB fully supports Flex Box. You can forget about alignment issues.</p>
                                </div>
                            </div>
                            <!--/Grid row-->
                        </div>
                        <!--/Grid column-->

                        <!--Grid column-->
                        <div class="col-xl-3 col-lg-6">
                            <!--Grid row-->
                            <div class="row">
                                <div class="col-2">
                                    <i class="far fa-file-code fa-2x mb-1 indigo-text" aria-hidden="true"></i>
                                </div>
                                <div class="col-10 mb-2">
                                    <h5 class="feature-title font-bold mb-1">SASS files</h5>
                                    <p class="grey-text mt-2">Arranged and well documented .scss files can't wait until you compile them.</p>
                                </div>
                            </div>
                            <!--/Grid row-->
                        </div>
                        <!--/Grid column-->

                    </div>
                    <!--/Second row-->

                </section>
                <!--Section: More-->

            </div>
        </main>
        <!--Main layout-->
    </form>

    <!--Footer-->
    <footer class="page-footer text-center font-small mt-4 wow fadeIn">

        <!--Call to action-->
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
        <!--/.Call to action-->

        <hr class="my-4">

        <!-- Social icons -->
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
        <!-- Social icons -->

        <!--Copyright-->
        <div class="footer-copyright py-3">
            © 2019 Copyright:
     
                <a href="https://mdbootstrap.com/education/bootstrap/" target="_blank">MDBootstrap.com </a>
        </div>
        <!--/.Copyright-->

    </footer>


    <script type="text/javascript">
        // Animations initialization
        new WOW().init();

    </script>
</body>

<script type="text/javascript" src="vendor/jquery-3.3.1.min.js"></script>
<script type="text/javascript" src="vendor/bootstrap/js/popper.min.js"></script>
<script type="text/javascript" src="vendor/bootstrap/js/bootstrap.min.js"></script>
<script type="text/javascript" src="assets/js/mdb.min.js"></script>

</html>
