<%@ Page Language="C#" AutoEventWireup="true" CodeFile="QuienesSomos.aspx.cs" Inherits="Formulario_QuienesSomos" %>

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

        }

        .filaNav{

            padding:10px 5px 10px 5px;

        }

         .columnaCentro{

            text-align:left;
            padding:10px 5px 10px 5px;
            width:50%;

        }

        .filaCentro{

            padding:10px 5px 10px 5px;

        }

        #LabelTexto1{

            text-align:left;
            font-size: 17px;
            font-family:Verdana, Arial;

        }

        h3{

            color:black;

        }

        .columnaFinal{

            text-align:left;
            padding:10px 5px 10px 5px;

        }

        .filaFinal {

           
            padding:10px 5px 10px 5px;

        }

         #LabelTexto2{

            text-align:left;
            font-size: 17px;
            font-family:Verdana, Arial;

        }

         .columnaVolver{


             text-align:right;

         }


    </style>

</head>
<body>


    <header>

    <h1>¿QUIENES SOMOS?</h1>
   
    </header>

    <br />

    <form id="form1" runat="server">
        <div>


             <asp:Table ID="Table1" runat="server">

                <asp:TableRow CssClass="filaNav" runat="server">

                    <asp:TableCell CssClass="columnaNav" runat="server">

                         
                         <br />
                         <asp:Image ID="Image1" runat="server" ImageUrl="/Imagen/solidaridad.jpg" Width="100%" Height="300px"  AlternateText="Error. No se encuentra la imagen." />
                         <br />
                         


                    </asp:TableCell>

                   

                </asp:TableRow>

                <asp:TableRow CssClass="filaCentro" runat="server">

                    
                     <asp:TableCell ColumnSpan="3" CssClass="columnaCentro" runat="server">

                         <br />

                         <asp:Label ID="LabelTexto1" ForeColor="White" runat="server" Text="">

                             Hace unos años el activista estadounidense Martin Luther King, viendo la indiferencia de mucha gente por los asuntos sociales, dijo: “habíamos aprendido a volar como los pájaros, a nadar como los peces, pero lo que no habíamos aprendido era el arte de vivir juntos, como hermanos”. Tuvo que aparecer un maléfico virus para reventar la burbuja en la que vivíamos y darnos cuenta de que hay personas más allá de nuestro selecto círculo social, hay un mundo real fuera de la computadora o los juegos de video, hay seres de carne y hueso salidos de las frías estadísticas.
                             <br />
                             <br />
                             Hoy debido a este virus estamos llevando una vida de aislamiento, pero no significa que estamos solos. Y lo podemos ver cuando un grupo de madres que vive entre las rocas de un asentamiento humano prepara una olla común con lo poco que tienen para alimentar a sus familias y a los que el hambre agobia. Lo vemos cuando un padre que trabaja de taxista lleva platos de comida a unos caminantes, quienes con hijos en brazos han dejado la ciudad que les negó todo para encontrar en su terruño el socorro de la familia. Hoy la solidaridad se está haciendo cada vez más fuerte.
                             <br />
                             <br />
                             <h3>La solidaridad en tiempos de crisis</h3>
                             <br />
                             ¿Cuál es la esencia de la vida? Servir a otros y hacer el bien, así describió el filósofo Aristóteles el valor de la solidaridad, el cual está emparentado con la compasión y con la generosidad. La solidaridad, uno de los valores que identifica a la RED SOLIDARIA, tiene que ver con el ánimo que nos inspira a cooperar y brindar nuestro apoyo a una o más personas en un momento de vulnerabilidad. Y lo más importante, la ayuda es desinteresada, o sea no esperamos recibir una retribución o ganancia a cambio.
                             <br />
                             <br />
                             La crisis mundial ha puesto todo de cabeza y entre otras muchas cosas nos ha revelado lo frágiles que podemos llegar a ser ante determinados acontecimientos globales. Sin embargo, también se ha demostrado la solidaridad en tiempos de crisis. Hoy tú también tienes la oportunidad de ser solidario.
                             <br />
                             <br />
                             <h3>Estamos para ayudar a otros</h3>
                             <br />
                             Ante la emergencia sanitaria desatada por la pandemia del COVID-19, RED SOLIDARIA MENDOZA, y UNIVERSIDAD UTN MENDOZA han unido sus esfuerzos y lanzado la campaña “Estamos Juntos” para canalizar la ayuda de todos los Mendocinos a las familias de escasos recursos económicos y que no han recibido ningún tipo de asistencia de las autoridades. Esperamos que tú también puedas unirte para ayudar a las personas que tanto lo necesitan.


                         </asp:Label>

                         <br />


                    </asp:TableCell>



                </asp:TableRow>


                 <asp:TableRow CssClass="filaFinal" runat="server">

                    
                     <asp:TableCell ColumnSpan="3" CssClass="columnaFinal" runat="server">

                        
                         <asp:Label ID="LabelTexto2" ForeColor="Black" runat="server" Text="">

                             <br />
                             <br />

                             ¿Quieres saber en qué consiste la ayuda y cómo puedes ser solidario con estas familias?, te invitamos a seguir este enlace:

                         </asp:Label>

                          <asp:HyperLink ID="Link2" ForeColor="Red" NavigateUrl="~/Formulario/Loguin.aspx" runat="server">DONACIONES</asp:HyperLink>


                    </asp:TableCell>



                </asp:TableRow>


                  <asp:TableRow CssClass="filaVolver" ForeColor="Gray" runat="server">

                    
                     <asp:TableCell ColumnSpan="3"  CssClass="columnaVolver" runat="server">

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
