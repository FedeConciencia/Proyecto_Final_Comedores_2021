<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Principal.aspx.cs" Inherits="Formulario_Principal" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>

    <style>

        body{

            text-align:center;
            margin:auto;
            background-color:royalblue;


        }

        #Table1{

            margin:auto;
            text-align:center;
            width:100%;
            height:100%;
            padding:10px 5px 10px 5px;



        }

        .columnaNav{

            text-align:center;
            padding:10px 5px 10px 5px;
            width:100px;

        }

        .filaNav{


            background-color:slateblue;
            padding:10px 5px 10px 5px;
            width:80%;

        }

        .columnaCentro{

            text-align:center;
            padding:10px 5px 10px 5px;

        }

        .filaCentro{


            background-color:seagreen;
            padding:10px 5px 10px 5px;

        }

        .columnaFinal{

            text-align:center;
            padding:10px 5px 10px 5px;

        }

        .filaFinal {

            background-color:saddlebrown;
            padding:10px 5px 10px 5px;

        }

        #LabelFinal{

            text-decoration-color:aliceblue;
            font-family:Verdana, Arial;
            font-size:17px;

        }

    </style>


</head>
<body>

    <header>

    <h1>RED COMEDORES MENDOZA</h1>
   
    </header>

    <br />

    <form id="form1" runat="server">
        <div>

            <asp:Table ID="Table1" runat="server">

                <asp:TableRow CssClass="filaNav" runat="server">

                    <asp:TableCell CssClass="columnaNav" runat="server">

                        <asp:HyperLink ID="Link1" ForeColor="White" NavigateUrl="~/Formulario/QuienesSomos.aspx" runat="server">QUIENES SOMOS</asp:HyperLink>

                    </asp:TableCell>

                    <asp:TableCell CssClass="columnaNav" runat="server">

                        <asp:HyperLink ID="Link2" ForeColor="White" NavigateUrl="~/Formulario/Loguin.aspx" runat="server">DONACIONES</asp:HyperLink>


                    </asp:TableCell>

                     <asp:TableCell CssClass="columnaNav" runat="server">

                         <asp:HyperLink ID="Link3" ForeColor="White" NavigateUrl="~/Formulario/Contacto.aspx" runat="server">CONTACTO</asp:HyperLink>


                    </asp:TableCell>

                </asp:TableRow>

                <asp:TableRow CssClass="filaCentro" runat="server">

                    
                     <asp:TableCell ColumnSpan="3" CssClass="columnaCentro" runat="server">

                         <br />
                         <br />
                         <br />
                         <asp:Image ID="imgImagen" runat="server" ImageUrl="/Imagen/ImagenPrincipal.png" Width="700px" Height="300px"  AlternateText="Error. No se encuentra la imagen." />
                         <br />
                         <br />
                         <br />

                    </asp:TableCell>



                </asp:TableRow>


                 <asp:TableRow CssClass="filaFinal" runat="server">

                    
                     <asp:TableCell ColumnSpan="3" CssClass="columnaFinal" runat="server">

                         
                         <asp:Label ID="LabelFinal" runat="server" Text="">Red Solidaria Mendoza 2021 - Todos Los Derechos Reservados</asp:Label>


                    </asp:TableCell>



                </asp:TableRow>




        </asp:Table>


        </div>
    </form>
</body>
</html>
