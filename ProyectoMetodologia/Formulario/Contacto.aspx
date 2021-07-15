<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Contacto.aspx.cs" Inherits="Formulario_Contacto" %>


<%@ Register Src="~/controlesUsuario/TextBoxEmail.ascx" TagPrefix="uc1" TagName="TextBoxEmail" %>
<%@ Register Src="~/controlesUsuario/TextBoxTelefono.ascx" TagPrefix="uc1" TagName="TextBoxTelefono" %>
<%@ Register Src="~/controlesUsuario/TextBoxMultiLine.ascx" TagPrefix="uc1" TagName="TextBoxMultiLine" %>
<%@ Register Src="~/controlesUsuario/Nombre.ascx" TagPrefix="uc1" TagName="Nombre" %>






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
            width: 50%;
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

        .columnaBoton {
            text-align: center;
            padding: 10px 5px 10px 5px;
        }

        #Button1 {
            border: solid 1px red;
            background-color: darkcyan;
            font-size: 17px;
            font: bold;
            width: 90px;
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



        #Table2 {
            width: 100%;
            height: 100%;
             padding: 10px 5px 10px 5px;
        }
    </style>


</head>
<body>

    <header>

        <h1>FORMULARIO DE CONTACTO</h1>

    </header>

    <br />

    <form id="form1" runat="server">
        <div>

            <asp:Table ID="Table1" runat="server">


                <asp:TableRow CssClass="fila1" runat="server">

                    <asp:TableCell CssClass="columna1" runat="server">

                        <asp:Label ID="LabelNombre" runat="server" Text="">Nombre: </asp:Label>

                    </asp:TableCell>

                    <asp:TableCell CssClass="columna2" runat="server">

                        <asp:TextBox ID="TextBox3" runat="server"></asp:TextBox>

                        <asp:RequiredFieldValidator ID="RequiredFieldValidator3"  runat="server" ControlToValidate="TextBox3" ForeColor="Red" ErrorMessage="Nombre is Empty" Display="Dynamic" Text="*"></asp:RequiredFieldValidator>
                        <asp:RegularExpressionValidator ID="RegularExpressionValidator2" runat="server"  ControlToValidate="TextBox3" ForeColor="Red" ErrorMessage="Text Characters Only" Text="*" Display="Dynamic" ValidationExpression="^[a-zA-Z]+(([\'\,\.\- ][a-zA-Z ])?[a-zA-Z]*)*$"></asp:RegularExpressionValidator>

                    </asp:TableCell>

                </asp:TableRow>



                <asp:TableRow CssClass="fila1" runat="server">

                    <asp:TableCell CssClass="columna1" runat="server">

                        <asp:Label ID="Label1" runat="server" Text="">Apellido: </asp:Label>

                    </asp:TableCell>

                    <asp:TableCell CssClass="columna2" runat="server">

                         <asp:TextBox ID="TextBox4" runat="server"></asp:TextBox>

                        <asp:RequiredFieldValidator ID="RequiredFieldValidator4"  runat="server" ControlToValidate="TextBox4" ForeColor="Red" ErrorMessage="Apellido is Empty" Display="Dynamic" Text="*"></asp:RequiredFieldValidator>
                        <asp:RegularExpressionValidator ID="RegularExpressionValidator3" runat="server"  ControlToValidate="TextBox4" ForeColor="Red" ErrorMessage="Text Characters Only" Text="*" Display="Dynamic" ValidationExpression="^[a-zA-Z]+(([\'\,\.\- ][a-zA-Z ])?[a-zA-Z]*)*$"></asp:RegularExpressionValidator>

                    </asp:TableCell>

                </asp:TableRow>



                <asp:TableRow CssClass="fila1" runat="server">

                    <asp:TableCell CssClass="columna1" runat="server">

                        <asp:Label ID="Label3" runat="server" Text="">Email: </asp:Label>

                    </asp:TableCell>

                    <asp:TableCell CssClass="columna2" runat="server">

                        <asp:TextBox ID="TextBox2" runat="server"></asp:TextBox>

                        <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="TextBox2" ForeColor="Red" ErrorMessage="Email is Empty" Display="Dynamic" Text="*"></asp:RequiredFieldValidator>
                        <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" ControlToValidate="TextBox2" ForeColor="Red" ErrorMessage="Email format error" Text="*" Display="Dynamic" ValidationExpression="^\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*$"></asp:RegularExpressionValidator>

                    </asp:TableCell>

                </asp:TableRow>


                <asp:TableRow CssClass="fila1" runat="server">

                    <asp:TableCell CssClass="columna1" runat="server">

                        <asp:Label ID="Label4" runat="server" Text="">Confirmar Email: </asp:Label>

                    </asp:TableCell>

                    <asp:TableCell CssClass="columna2" runat="server">

                        <asp:TextBox ID="TextBox1" runat="server"></asp:TextBox>

                        <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="TextBox1" ForeColor="Red" ErrorMessage="Email is Empty" Display="Dynamic" Text="*"></asp:RequiredFieldValidator>
                        <asp:RegularExpressionValidator ID="RegularExpressionValidator7" runat="server" ControlToValidate="TextBox1" ForeColor="Red" ErrorMessage="Email format error" Text="*" Display="Dynamic" ValidationExpression="^\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*$"></asp:RegularExpressionValidator>
                        <asp:CompareValidator ID="CompareValidator1" runat="server" ControlToValidate="TextBox1" ControlToCompare="TextBox2" Type="String" Operator="Equal" ErrorMessage="Email and Email Validation are not the same" ForeColor="Red" Text="*"></asp:CompareValidator>
                    </asp:TableCell>

                </asp:TableRow>

                <asp:TableRow CssClass="fila1" runat="server">

                    <asp:TableCell CssClass="columna1" runat="server">

                        <asp:Label ID="Label5" runat="server" Text="">Telefono Movil: </asp:Label>

                    </asp:TableCell>

                    <asp:TableCell CssClass="columna2" runat="server">

                        <asp:TextBox ID="TextBox5" runat="server"></asp:TextBox>

                        <asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server" ControlToValidate="TextBox5" ForeColor="Red" ErrorMessage="Telefono is Empty" Display="Dynamic" Text="*"></asp:RequiredFieldValidator>
                        <asp:RegularExpressionValidator ID="RegularExpressionValidator4" runat="server" ControlToValidate="TextBox5"  ForeColor="Red" ErrorMessage="Wrong mobile format" Text="*" Display="Dynamic" ValidationExpression="^\D?(\d{3})\D?\D?(\d{3})\D?(\d{4})$"></asp:RegularExpressionValidator>

                    </asp:TableCell>

                </asp:TableRow>

                <asp:TableRow CssClass="fila1" runat="server">

                    <asp:TableCell CssClass="columna1" runat="server">

                        <asp:Label ID="Label6" runat="server" Text="">Consulta / Comentario: </asp:Label>

                    </asp:TableCell>

                    <asp:TableCell CssClass="columna2" runat="server">

                        <asp:TextBox ID="TextBox6" TextMode="MultiLine" MaxLength="200" runat="server"></asp:TextBox>

                        <asp:RequiredFieldValidator ID="RequiredFieldValidator6" runat="server" ControlToValidate="TextBox6" ForeColor="Red" ErrorMessage="Comentario is Empty" Display="Dynamic" Text="*"></asp:RequiredFieldValidator>

                    </asp:TableCell>

                </asp:TableRow>

                <asp:TableRow CssClass="fila1" runat="server">

                    <asp:TableCell ColumnSpan="2" CssClass="columnaBoton" runat="server">

                        <asp:Button ID="Button1" OnClick="eventoEnviar" runat="server" Text="ENVIAR" />

                    </asp:TableCell>



                </asp:TableRow>


            </asp:Table>

            <br />
            <br />


            <asp:Label ID="LabelMensaje" runat="server" Text=""></asp:Label>


            <br />
            <br />
            <asp:ValidationSummary Font-Size="Medium" ForeColor="Red" HeaderText="ERROR. NO ES POSIBLE VALIDAR LA PAGINA. LIST VALIDATION ERRORS: " runat="server" DisplayMode="List" ShowMessageBox="True"></asp:ValidationSummary>
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
