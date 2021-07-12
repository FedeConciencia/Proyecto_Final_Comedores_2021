<%@ Page Language="C#" AutoEventWireup="true" CodeFile="RegistroPrincipal.aspx.cs" Inherits="Formulario_CrearUsuario" %>

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
            width: 50%;
            height: 300px;
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
            width: 200px;
            height: 150px;
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

            margin-bottom:unset;
            width: 100%;
            height: 100%;
            padding: 10px 5px 10px 5px;
        }

        #GrillaComedor{

            border: solid 1px black;
            background-color:darkgoldenrod;
            margin:auto;
            width: 50%;
            height: 50%;
            text-align:center;

        }

    </style>

</head>
<body>

     <header>

        <h1>PAGINA PRINCIPAL DE REGISTRO DE USUARIOS</h1>

    </header>

    <br />
    <br />
    <br />
    <br />
    <br />
    

    <form id="form1" runat="server">


         <asp:Table ID="Table1" runat="server">

                <asp:TableRow CssClass="fila1" runat="server">

                    <asp:TableCell CssClass="columna1" runat="server">

                        <asp:Label ID="Label5" runat="server" Text="">

                        <asp:Button CssClass="boton" ID="Button1"  OnClick="eventoRegistrarPersona" runat="server" Text="REGISTRAR PERSONA" />

                        </asp:Label>

                    </asp:TableCell>

                    <asp:TableCell CssClass="columna1" runat="server">

                        <asp:Label ID="Label3" runat="server" Text="">

                        <asp:Button CssClass="boton" ID="Button4"  OnClick="eventoRegistrarEmpresa" runat="server" Text="REGISTRAR EMPRESA" />

                        </asp:Label>

                    </asp:TableCell>

                </asp:TableRow>

             </asp:Table>


            <br />
            <br />
            <br />
            <br />
            <br />
            <br />
            <br />
            <br />
            <br />
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

       
    </form>


</body>
</html>
