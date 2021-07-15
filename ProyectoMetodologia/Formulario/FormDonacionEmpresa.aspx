<%@ Page Language="C#" AutoEventWireup="true" CodeFile="FormDonacionEmpresa.aspx.cs" Inherits="Formulario_FormDonacionEmpresa" %>

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
            height: 30%;
            padding: 10px 5px 10px 5px;
            background-color: forestgreen;
        }

        #Table3 {
            margin: auto;
            text-align: center;
            border: solid 1px black;
            width: 50%;
            height: 30%;
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

        .filaBoton {
            text-align: center;
        }

        .columnaBoton {
            text-align: center;
            padding: 10px 5px 10px 5px;
        }

        .boton {
            border: solid 1px red;
            background-color: cornflowerblue;
            font-size: 17px;
            font: bold;
            width: 250px;
            height: 50px;
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
            margin-bottom: unset;
            width: 100%;
            height: 100%;
            padding: 10px 5px 10px 5px;
        }

        #GrillaAllComedor {
            border: solid 1px black;
            background-color:orange;
            margin: auto;
            width: 50%;
            height: 50%;
            text-align: center;
        }


        #GrillaPedidos {
            border: solid 1px black;
            background-color:dimgrey;
            margin: auto;
            width: 50%;
            height: 50%;
            text-align: center;
        }

    </style>

</head>
<body>

    <header>

        <h1>FORMULARIO DE GESTION DONACIONES EMPRESA</h1>

    </header>

    <br />
    <br />
    <br />
    <br />
    <br />
    <br />
    <br />

    <form id="form1" runat="server">

        <h2>COMEDORES:</h2>

        <br />
        <br />


         <asp:GridView ID="GrillaAllComedor" runat="server"></asp:GridView>

         <br />
         <br />

         <asp:Table ID="Table1" runat="server">

            <asp:TableRow CssClass="fila" runat="server">

                <asp:TableCell CssClass="columna1" runat="server">

                    <asp:Label ID="Label1" runat="server" Text="">ID_Comedor: </asp:Label>

                </asp:TableCell>

                 <asp:TableCell CssClass="columna1" runat="server">

                     <asp:TextBox ID="TextBox1" runat="server"></asp:TextBox>

                     <asp:RequiredFieldValidator ID="RequiredFieldValidator1" ValidationGroup="c" runat="server" ControlToValidate="TextBox1" ForeColor="Red" ErrorMessage="IdComedor is Empty" Display="Dynamic" Text="*"></asp:RequiredFieldValidator>
                     <asp:RegularExpressionValidator ID="RegularExpressionValidator1" ValidationGroup="c" runat="server" ControlToValidate="TextBox1" ForeColor="Red" ErrorMessage="Numbers Only" Text="*" Display="Dynamic" ValidationExpression="^[0-9]*$"></asp:RegularExpressionValidator>

                </asp:TableCell>


            </asp:TableRow>

             <asp:TableRow CssClass="filaBoton" runat="server">

                <asp:TableCell ColumnSpan="2" CssClass="columnaBoton" runat="server">

                    <asp:Button CssClass="boton" ValidationGroup="c" ID="Button1" OnClick="eventoseleccionarComedor" runat="server" Text="SELECCIONAR COMEDOR" />

                </asp:TableCell>


            </asp:TableRow>


        </asp:Table>

         <br />

      
        <asp:ValidationSummary Font-Size="Medium" ValidationGroup="c" ForeColor="Red" HeaderText="ERROR. NO ES POSIBLE VALIDAR LA PAGINA. LIST VALIDATION ERRORS: " runat="server" DisplayMode="List" ShowMessageBox="True"></asp:ValidationSummary>
        <br />
        

        <h2>ARTICULOS PEDIDOS POR EL COMEDOR:</h2>

        <br />
        <br />

        <asp:GridView ID="GrillaPedidos" runat="server"></asp:GridView>

        <br />
        <br />

        <h2>FORMULARIO DONACION:</h2>


         <asp:Table ID="Table3" runat="server">

           
             <asp:TableRow CssClass="fila1" runat="server">

                <asp:TableCell CssClass="columna1" runat="server">

                    <asp:Label ID="Label2" runat="server" Text="">Ingresar ID_ArticuloPedido: </asp:Label>

                </asp:TableCell>

                <asp:TableCell CssClass="columna1" runat="server">

                    <asp:TextBox ID="TextBox2" runat="server"></asp:TextBox>

                    <asp:RequiredFieldValidator ID="RequiredFieldValidator2" ValidationGroup="b" runat="server" ControlToValidate="TextBox2" ForeColor="Red" ErrorMessage="IdArticuloPedido is Empty" Display="Dynamic" Text="*"></asp:RequiredFieldValidator>
                    <asp:RegularExpressionValidator ID="RegularExpressionValidator2" ValidationGroup="b" runat="server" ControlToValidate="TextBox2" ForeColor="Red" ErrorMessage="Numbers Only" Text="*" Display="Dynamic" ValidationExpression="^[0-9]*$"></asp:RegularExpressionValidator>

                </asp:TableCell>

            </asp:TableRow>


            

            <asp:TableRow CssClass="fila1" runat="server">

                <asp:TableCell CssClass="columna1" runat="server">

                    <asp:Label ID="Label12" runat="server" Text="">Ingresar la Cantidad: </asp:Label>

                </asp:TableCell>

                <asp:TableCell CssClass="columna1" runat="server">

                    <asp:TextBox ID="TextBox3" runat="server"></asp:TextBox>

                    <asp:RequiredFieldValidator ID="RequiredFieldValidator6" ValidationGroup="b" runat="server" ControlToValidate="TextBox3" ForeColor="Red" ErrorMessage="Cantidad is Empty" Display="Dynamic" Text="*"></asp:RequiredFieldValidator>
                    <asp:RegularExpressionValidator ID="RegularExpressionValidator5" ValidationGroup="b" runat="server" ControlToValidate="TextBox3" ForeColor="Red" ErrorMessage="Numbers Only" Text="*" Display="Dynamic" ValidationExpression="^[0-9]*$"></asp:RegularExpressionValidator>
                    <asp:CustomValidator runat="server" ID="CustomValidator2" ForeColor="Red"  ValidationGroup="b" ControlToValidate="TextBox3"  OnServerValidate="validarCantidad" ErrorMessage="Cantidad > 0" Text="*" Display="Dynamic"></asp:CustomValidator>


                </asp:TableCell>

            </asp:TableRow>


            <asp:TableRow CssClass="filaBoton" runat="server">

                <asp:TableCell ColumnSpan="2" CssClass="columnaBoton" runat="server">

                    <asp:Label ID="Label5" runat="server" Text="">

                        <asp:Button CssClass="boton" ID="Button2" ValidationGroup="b" OnClick="eventoDonacion" runat="server" Text="GESTIONAR DONACION" />&nbsp;

                    </asp:Label>


                </asp:TableCell>


            </asp:TableRow>


        </asp:Table>

        <br />

      
        <asp:ValidationSummary Font-Size="Medium" ValidationGroup="b" ForeColor="Red" HeaderText="ERROR. NO ES POSIBLE VALIDAR LA PAGINA. LIST VALIDATION ERRORS: " runat="server" DisplayMode="List" ShowMessageBox="True"></asp:ValidationSummary>
        <br />



        <br />
        <br />

        
         <asp:Table ID="Table2" runat="server">

                <asp:TableRow CssClass="filaPrincipal" runat="server">

                    <asp:TableCell CssClass="columnaPrincipal" runat="server">

                        <br />
                        <br />
                        <br />

                        <asp:HyperLink ID="HyperLink1" ForeColor="White" NavigateUrl="~/Formulario/Loguin.aspx" runat="server">VOLVER PAGINA PRINCIPAL LOGUIN</asp:HyperLink>


                    </asp:TableCell>


                </asp:TableRow>


            </asp:Table>
       


        
    </form>


</body>
</html>
