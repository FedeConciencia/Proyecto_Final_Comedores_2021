<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Loguin.aspx.cs" Inherits="Formulario_DonacionesPrincipal" %>





<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title></title>

    <style>
        body {
            text-align: center;
            margin: auto;
            background-color: royalblue;
        }

        #Table1 {
            margin: auto;
            text-align: center;
            border: solid 1px black;
            width: 40%;
            height: 50%;
            padding: 10px 5px 10px 5px;
            background-color: forestgreen;
        }

        .columna1 {
            text-align: left;
            padding: 10px 5px 10px 5px;
        }

        .columna2 {
            text-align: left;
            padding: 10px 5px 10px 5px;
        }

        .filaBoton{

            text-align: center;

        }

        .columnaBoton {
            text-align: center;
            padding: 10px 5px 10px 5px;
        }

        #Button1 {
            border: solid 1px red;
            background-color: darkcyan;
            font-size: 17px;
            font: bold;
            width: 100px;
            height: 40px;
        }

        #TextBoxMultiLine {
            width: 600px;
            height: 600px;
        }

        .columnaPrincipal {
            text-align: right;
            padding: 10px 5px 10px 5px;
        }

        .filaPrincipal {
            text-align: right;
            padding: 10px 5px 10px 5px;
        }

        .filaCrear {
            text-align: right;
            padding: 10px 5px 10px 5px;
        }



        #Table2 {
            width: 100%;
            height: 100%;
            padding: 10px 5px 10px 5px;
        }
    </style>


</head>
<body>

    <header>

        <h1>FORMULARIO DE LOGUIN</h1>

    </header>

    <br />
    <br />
    <br />
    <br />
    <br />
    <br />
    <br />

    <form id="form1" runat="server">
        <div>

            <asp:Table ID="Table1" runat="server">

                <asp:TableRow CssClass="fila1" runat="server">

                    <asp:TableCell CssClass="columna1" runat="server">

                        <asp:Label ID="Label1" runat="server" Text="">Usuario: </asp:Label>

                    </asp:TableCell>

                    <asp:TableCell CssClass="columna1" runat="server">

                        <asp:TextBox ID="TextBox1" runat="server"></asp:TextBox>

                        <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="TextBox1" ForeColor="Red" ErrorMessage="Usuario is Empty" Display="Dynamic" Text="*"></asp:RequiredFieldValidator>

                    </asp:TableCell>

                </asp:TableRow>

                <asp:TableRow CssClass="fila1" runat="server">

                    <asp:TableCell CssClass="columna1" runat="server">

                        <asp:Label ID="Label2" runat="server" Text="">Contraseña: </asp:Label>

                    </asp:TableCell>

                    <asp:TableCell CssClass="columna1" runat="server">

                        <asp:TextBox ID="TextBox2" TextMode="Password" runat="server"></asp:TextBox>

                        <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="TextBox2" ForeColor="Red" ErrorMessage="Contraseña is Empty" Display="Dynamic" Text="*"></asp:RequiredFieldValidator>
                        <asp:RegularExpressionValidator ID="RegularExpressionValidator6" runat="server" ControlToValidate="TextBox2" ForeColor="Red" ErrorMessage="Password Format Invalid" Text="*" Display="Dynamic" ValidationExpression="^([a-zA-Z0-9@*#]{8,15})$"></asp:RegularExpressionValidator>

                    </asp:TableCell>

                </asp:TableRow>

                <asp:TableRow CssClass="filaBoton" runat="server">

                    <asp:TableCell ColumnSpan="2" CssClass="columnaBoton" runat="server">

                        <asp:Button ID="Button1" OnClick="eventoEnviar" runat="server" Text="INGRESAR" />

                    </asp:TableCell>
    
               </asp:TableRow>

                 <asp:TableRow CssClass="filaCrear" runat="server">

                    <asp:TableCell ColumnSpan="2" CssClass="columnaCrear" runat="server">

                        <asp:HyperLink ID="HyperLink2" ForeColor="White" NavigateUrl="~/Formulario/RegistroPrincipal.aspx" runat="server">REGISTRAR USUARIO</asp:HyperLink>

                    </asp:TableCell>
    
               </asp:TableRow>


            </asp:Table>
            
            <br />


            <asp:Label ID="LabelMensaje" runat="server" Text=""></asp:Label>
            <br />
            <asp:Label ID="LabelMensaje1" runat="server" Text=""></asp:Label>


            <br />
            <br />
            <asp:ValidationSummary Font-Size="Medium" ForeColor="Red" HeaderText="ERROR. NO ES POSIBLE VALIDAR LA PAGINA. LIST VALIDATION ERRORS: " runat="server" DisplayMode="List" ShowMessageBox="True"></asp:ValidationSummary>
            <br />
            <br />
            <br />
            <br />
            <br />
            <br />


            <asp:Table ID="Table2" runat="server">

                <asp:TableRow CssClass="filaPrincipal" runat="server">

                    <asp:TableCell CssClass="columnaPrincipal" runat="server">

                        <br />
                        <br />
                        <br />

                        <asp:HyperLink ID="HyperLink1" ForeColor="White" NavigateUrl="~/Formulario/Principal.aspx" runat="server">VOLVER PAGINA PRINCIPAL</asp:HyperLink>


                    </asp:TableCell>


                </asp:TableRow>


            </asp:Table>



        </div>
    </form>
</body>
</html>
