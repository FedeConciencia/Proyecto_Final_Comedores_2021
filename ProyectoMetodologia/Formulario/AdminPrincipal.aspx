<%@ Page Language="C#" AutoEventWireup="true" CodeFile="AdminPrincipal.aspx.cs" Inherits="Formulario_AdminPrincipal" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
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
            width: 80%;
            height: 60%;
            padding: 10px 5px 10px 5px;
            background-color: forestgreen;
        }

        .columna1 {
            text-align:center;
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

        .boton {
            border: solid 1px red;
            background-color:cornflowerblue;
            font-size: 17px;
            font: bold;
            width: 250px;
            height: 100px;
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

        <h1>FORMULARIO PRINCIPAL DE ADMINISTRACION</h1>

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

                        <asp:Button CssClass="boton" OnClick="eventoBotonComedor" ID="Button1" runat="server" Text="ADMIN.COMEDOR" />

                    </asp:TableCell>

                    <asp:TableCell CssClass="columna1" runat="server">

                        <asp:Button CssClass="boton" OnClick="eventoBotonPersona" ID="Button2" runat="server" Text="ADMIN.PERSONA" />

                    </asp:TableCell>

                </asp:TableRow>


                <asp:TableRow CssClass="fila1" runat="server">

                    <asp:TableCell CssClass="columna1" runat="server">

                        <asp:Button CssClass="boton" OnClick="eventoBotonEmpresa" ID="Button3" runat="server" Text="ADMIN.EMPRESA" />

                    </asp:TableCell>

                    <asp:TableCell CssClass="columna1" runat="server">

                        <asp:Button CssClass="boton" OnClick="eventoBotonUsuario" ID="Button4" runat="server" Text="ADMIN.USUARIO" />

                    </asp:TableCell>

                </asp:TableRow>

                 <asp:TableRow CssClass="fila1" runat="server">

                    <asp:TableCell CssClass="columna1" runat="server">

                        <asp:Button CssClass="boton" OnClick="eventoBotonArticuloPedido" ID="Button5" runat="server" Text="ADMIN.ARTICULO_PEDIDO" />

                    </asp:TableCell>

                    <asp:TableCell CssClass="columna1" runat="server">

                        <asp:Button CssClass="boton" OnClick="eventoBotonContacto" ID="Button6" runat="server" Text="ADMIN.CONTACTO" />

                    </asp:TableCell>

                </asp:TableRow>

                <asp:TableRow CssClass="fila1" runat="server">

                    <asp:TableCell  CssClass="columna1" runat="server">

                        <asp:Button CssClass="boton" OnClick="eventoBotonDonadoEmpresa" ID="Button8" runat="server" Text="ADMIN.DONADO EMPRESA" />

                    </asp:TableCell>

                    <asp:TableCell  CssClass="columna1" runat="server">

                        <asp:Button CssClass="boton" OnClick="eventoBotonDonadoPersona" ID="Button7" runat="server" Text="ADMIN.DONADO PERSONA" />

                    </asp:TableCell>

                </asp:TableRow>


        </asp:Table>


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
