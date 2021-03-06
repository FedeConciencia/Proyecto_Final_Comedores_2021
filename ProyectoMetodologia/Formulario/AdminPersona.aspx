<%@ Page Language="C#" AutoEventWireup="true" CodeFile="AdminPersona.aspx.cs" Inherits="Formulario_AdminPersona" %>

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
            width: 70%;
            height: 50%;
            padding: 10px 5px 10px 5px;
            background-color: forestgreen;
        }

        .columna1 {
            text-align:left;
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
            width: 130px;
            height: 30px;
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
            width: 70%;
            height: 50%;
            text-align:center;

        }

    </style>

</head>
<body>

      <header>

        <h1>FORMULARIO DE ADMINISTRACION PERSONA</h1>

    </header>

    <br />
    <br />
    <br />
    <br />
    <br />
    <br />
    <br />

    <form id="form1" runat="server">

        
            <asp:Table ID="Table1" runat="server">

                <asp:TableRow CssClass="fila1" runat="server">

                    <asp:TableCell CssClass="columna1" runat="server">

                        <asp:Label ID="Label1" runat="server" Text="">Busqueda ID_Persona: </asp:Label>

                    </asp:TableCell>

                    <asp:TableCell CssClass="columna1" runat="server">

                        <asp:TextBox ID="TextBox1" runat="server"></asp:TextBox>

                        <asp:RequiredFieldValidator ID="RequiredFieldValidator1" ValidationGroup="a" runat="server" ControlToValidate="TextBox1" ForeColor="Red" ErrorMessage="IdPersona is Empty" Display="Dynamic" Text="*"></asp:RequiredFieldValidator>
                        <asp:RegularExpressionValidator ID="RegularExpressionValidator1" ValidationGroup="a" runat="server" ControlToValidate="TextBox1" ForeColor="Red" ErrorMessage="Numbers Only" Text="*" Display="Dynamic" ValidationExpression="^[0-9]*$"></asp:RegularExpressionValidator>

                    </asp:TableCell>

                </asp:TableRow>


                <asp:TableRow CssClass="fila1" runat="server">

                    <asp:TableCell CssClass="columna1" runat="server">

                        <asp:Label ID="Label2" runat="server" Text="">Nombre: </asp:Label>

                    </asp:TableCell>

                    <asp:TableCell CssClass="columna1" runat="server">

                        <asp:TextBox ID="TextBox2" runat="server"></asp:TextBox>

                        <asp:RequiredFieldValidator ID="RequiredFieldValidator2" ValidationGroup="b" runat="server" ControlToValidate="TextBox2" ForeColor="Red" ErrorMessage="Nombre is Empty" Display="Dynamic" Text="*"></asp:RequiredFieldValidator>
                        <asp:RegularExpressionValidator ID="RegularExpressionValidator2" runat="server" ValidationGroup="b" ControlToValidate="TextBox2" ForeColor="Red" ErrorMessage="Text Characters Only" Text="*" Display="Dynamic" ValidationExpression="^[a-zA-Z]+(([\'\,\.\- ][a-zA-Z ])?[a-zA-Z]*)*$"></asp:RegularExpressionValidator>

                    </asp:TableCell>

                </asp:TableRow>

                 <asp:TableRow CssClass="fila1" runat="server">

                    <asp:TableCell CssClass="columna1" runat="server">

                        <asp:Label ID="Label11" runat="server" Text="">Apellido: </asp:Label>

                    </asp:TableCell>

                    <asp:TableCell CssClass="columna1" runat="server">

                        <asp:TextBox ID="TextBox5" runat="server"></asp:TextBox>

                        <asp:RequiredFieldValidator ID="RequiredFieldValidator5" ValidationGroup="b" runat="server" ControlToValidate="TextBox5" ForeColor="Red" ErrorMessage="Apellido is Empty" Display="Dynamic" Text="*"></asp:RequiredFieldValidator>
                        <asp:RegularExpressionValidator ID="RegularExpressionValidator4" runat="server" ValidationGroup="b" ControlToValidate="TextBox5" ForeColor="Red" ErrorMessage="Text Characters Only" Text="*" Display="Dynamic" ValidationExpression="^[a-zA-Z]+(([\'\,\.\- ][a-zA-Z ])?[a-zA-Z]*)*$"></asp:RegularExpressionValidator>

                    </asp:TableCell>

                </asp:TableRow>

                 <asp:TableRow CssClass="fila1" runat="server">

                    <asp:TableCell CssClass="columna1" runat="server">

                        <asp:Label ID="Label3" runat="server" Text="">Dni: </asp:Label>

                    </asp:TableCell>

                    <asp:TableCell CssClass="columna1" runat="server">

                        <asp:TextBox ID="TextBox3" runat="server"></asp:TextBox>

                        <asp:RequiredFieldValidator ID="RequiredFieldValidator3" ValidationGroup="b" runat="server" ControlToValidate="TextBox3" ForeColor="Red" ErrorMessage="Dni is Empty" Display="Dynamic" Text="*"></asp:RequiredFieldValidator>
                        <asp:RegularExpressionValidator ID="RegularExpressionValidator3" ValidationGroup="b" runat="server" ControlToValidate="TextBox3" ForeColor="Red" ErrorMessage="Numbers Only" Text="*" Display="Dynamic" ValidationExpression="^[0-9]*$"></asp:RegularExpressionValidator>

                    </asp:TableCell>

                </asp:TableRow>

                <asp:TableRow CssClass="fila1" runat="server">

                    <asp:TableCell  CssClass="columna1" runat="server">

                        <asp:Label ID="Label4" runat="server" Text="">Usuario: </asp:Label>

                    </asp:TableCell>

                    <asp:TableCell  CssClass="columna1" runat="server">

                        <asp:TextBox ID="TextBox4" runat="server"></asp:TextBox>

                        <asp:RequiredFieldValidator ID="RequiredFieldValidator4" ValidationGroup="b" runat="server" ControlToValidate="TextBox4" ForeColor="Red" ErrorMessage="Usuario is Empty" Display="Dynamic" Text="*"></asp:RequiredFieldValidator>

                    </asp:TableCell>

                </asp:TableRow>

                 <asp:TableRow CssClass="fila1" runat="server">

                    <asp:TableCell  CssClass="columna1" runat="server">

                        <asp:Label ID="Label12" runat="server" Text="">Contraseña: </asp:Label>

                    </asp:TableCell>

                    <asp:TableCell  CssClass="columna1" runat="server">

                       <asp:TextBox ID="TextBox6" TextMode="Password" runat="server"></asp:TextBox>

                        <asp:RequiredFieldValidator ID="RequiredFieldValidator6" ValidationGroup="b" runat="server" ControlToValidate="TextBox6" ForeColor="Red" ErrorMessage="Contraseña is Empty" Display="Dynamic" Text="*"></asp:RequiredFieldValidator>
                        <asp:RegularExpressionValidator ID="RegularExpressionValidator6" ValidationGroup="b" runat="server" ControlToValidate="TextBox6" ForeColor="Red" ErrorMessage="Password Format Invalid" Text="*" Display="Dynamic" ValidationExpression="^([a-zA-Z0-9@*#]{8,15})$"></asp:RegularExpressionValidator>

                    </asp:TableCell>

                </asp:TableRow>

                 <asp:TableRow CssClass="filaBoton" runat="server">

                    <asp:TableCell ColumnSpan="2" CssClass="columnaBoton" runat="server">

                        <asp:Label ID="Label5" runat="server" Text="">

                        <asp:Button CssClass="boton" ID="Button1" ValidationGroup="b" OnClick="eventoInsertar" runat="server" Text="INSERTAR" />&nbsp;

                        </asp:Label>

                         <asp:Label ID="Label6" runat="server" Text="">

                        <asp:Button CssClass="boton" ValidationGroup="a" OnClick="eventoBuscarOne" ID="Button2" runat="server" Text="BUSCAR ONE" />&nbsp;

                        </asp:Label>

                         <asp:Label ID="Label7" runat="server" Text="">

                        <asp:Button CssClass="boton" CausesValidation="false" OnClick="eventoBuscarAll"  ID="Button3" runat="server" Text="BUSCAR ALL" />&nbsp;

                        </asp:Label>

                         <asp:Label ID="Label8" runat="server" Text="">

                        <asp:Button CssClass="boton" ValidationGroup="b" OnClick="eventoActualizar" ID="Button4" runat="server" Text="ACTUALIZAR" />&nbsp;

                        </asp:Label>

                         <asp:Label ID="Label9" runat="server" Text="">

                        <asp:Button CssClass="boton" ValidationGroup="a" ID="Button5" OnClick="eventoEliminar" runat="server" Text="ELIMINAR" />&nbsp;

                        </asp:Label>

                         <asp:Label ID="Label10" runat="server" Text="">

                        <asp:Button CssClass="boton" OnClick="eventoLimpiar" CausesValidation="false" ID="Button6" runat="server" Text="LIMPIAR" />&nbsp;

                        </asp:Label>

                    </asp:TableCell>


                </asp:TableRow>


        </asp:Table>

            <br />
            <br />
            <br />

            <asp:Label ID="LabelMensaje" runat="server" Text=""></asp:Label>
           


            <br />
            <br />
            <asp:ValidationSummary Font-Size="Medium" ForeColor="Red" HeaderText="ERROR. NO ES POSIBLE VALIDAR LA PAGINA. LIST VALIDATION ERRORS: " runat="server" DisplayMode="List" ShowMessageBox="True"></asp:ValidationSummary>
            <br />
            <asp:ValidationSummary Font-Size="Medium" ValidationGroup="a" ForeColor="Red" HeaderText="ERROR. NO ES POSIBLE VALIDAR LA PAGINA. LIST VALIDATION ERRORS: " runat="server" DisplayMode="List" ShowMessageBox="True"></asp:ValidationSummary>
            <br />
            <asp:ValidationSummary Font-Size="Medium" ValidationGroup="b" ForeColor="Red" HeaderText="ERROR. NO ES POSIBLE VALIDAR LA PAGINA. LIST VALIDATION ERRORS: " runat="server" DisplayMode="List" ShowMessageBox="True"></asp:ValidationSummary>
            <br />

            <asp:GridView ID="GrillaComedor" runat="server"></asp:GridView>

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

                        <asp:HyperLink ID="HyperLink1" ForeColor="White" NavigateUrl="~/Formulario/AdminPrincipal.aspx" runat="server">VOLVER PAGINA PRINCIPAL ADMIN</asp:HyperLink>


                    </asp:TableCell>


                </asp:TableRow>


            </asp:Table>


        


    </form>
</body>
</html>
