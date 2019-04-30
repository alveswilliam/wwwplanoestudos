<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Teste.aspx.cs" Inherits="wwwplanoestudos.Teste" %>

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
    <form id="form1" runat="server">
        <div class="container">
            <div class="row">
                <div class="col-md-12 mb-4 text-center">
                    <h3 class="h3 mb-3">Alunos em Plano/Plano-pago</h3>
                </div>
                <div class="col-md-12 mb-4">
                    <asp:GridView ID="gvAlunos" runat="server" AutoGenerateColumns="false" CssClass="table table-responsive" GridLines="None" DataKeyNames="RA">
                        <Columns>
                            <asp:CommandField ShowSelectButton="true" SelectText="" ControlStyle-CssClass="fa fa-arrow-right" />
                            <asp:BoundField DataField="RA" HeaderText="RA"></asp:BoundField>
                            <asp:BoundField DataField="NOME" HeaderText="Nome"></asp:BoundField>
                            <asp:BoundField DataField="TELEFONE1" HeaderText="Telefone"></asp:BoundField>
                            <asp:BoundField DataField="EMAIL" HeaderText="E-mail"></asp:BoundField>
                            <asp:BoundField DataField="DESCRICAO" HeaderText="Status"></asp:BoundField>
                            <asp:BoundField DataField="STATUS" HeaderText="Situação"></asp:BoundField>
                        </Columns>
                        <HeaderStyle BackColor="#2b304e" Font-Bold="True" ForeColor="White"></HeaderStyle>
                        <RowStyle BackColor="#ffffff"></RowStyle>
                        <SelectedRowStyle BackColor="#fef4bf" Font-Bold="True" ForeColor="#333333"></SelectedRowStyle>
                    </asp:GridView>
                </div>
            </div>
        </div>
    </form>
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
