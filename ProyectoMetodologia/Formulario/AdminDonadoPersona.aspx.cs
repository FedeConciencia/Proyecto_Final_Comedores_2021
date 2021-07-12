using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Formulario_AdminDonadoPersona : System.Web.UI.Page
{

    string idBusqueda = "", nombre = "", codigo = "", cantidad = "", idPersona = "", idArticuloPedido = "";
    protected void Page_Load(object sender, EventArgs e)
    {

    }


    //Evento Actualizar Datos:
    protected void eventoActualizar(object sender, EventArgs e)
    {

        // Si la Pagina es Valida podemos Insertar los datos en la base:

        if (Page.IsValid == true)
        {


            obtener();

            //Buscar todos los ArticulosPedidos:

            List<ArticuloDonadoPersona> listaArticuloDonadoPersona = ControladorDonadoPersona.buscarAllArticuloDonadoPersona();

            List<ArticuloPedido> listaPedido = ControladorArticuloPedido.buscarAllArticuloPedido();

            List<Persona> listaPersona = ControladorPersona.buscarAllPersona();

            int idArtPedido = Int32.Parse(idArticuloPedido);

            int cant = Int32.Parse(cantidad);

            bool validarIdArticuloPedido = false, validarCantidad = false, validarIdPersona = false, validarNombrePedido = false, validarCodigoPedido = false, validarIdArticuloDonado = false;

            string nombreArticuloSeleccionado = "", codigoSeleccionado = "";

            int cantidadSeleccionado = 0, idComedorSeleccionado = 0, idArtSeleccionado = 0;

            string nombrePersona = "", apellidoPersona = "", dniPersona = "", usuarioEmpresa = "", contraseñaEmpresa = "";

            int idPersona1 = 0, idDonado = 0;


            idDonado = Int32.Parse(idBusqueda);


            foreach (ArticuloDonadoPersona item in listaArticuloDonadoPersona)
            {


                if (idDonado == item.IdArticuloDonadoPersona)
                {

                    validarIdArticuloDonado = true;


                    break;


                }
                else
                {

                    validarIdArticuloDonado = false;

                }

            }


            if (validarIdArticuloDonado == false)
            {

                Response.Write("<script>alert('ERROR. EL ID_ARTICULO_DONADO INGRESADO NO SE ENCUENTRA EN LA BASE DE DATOS.');</script>");
                limpiar();

            }



            foreach (ArticuloPedido item in listaPedido)
            {

                //Verificamos si el idArticuloPedido seleccionado por el usuario se encuentra en la lista

                if (idArtPedido == item.IdArticuloPedido)
                {

                    validarIdArticuloPedido = true;

                    nombreArticuloSeleccionado = item.Nombre;
                    codigoSeleccionado = item.Codigo;
                    cantidadSeleccionado = item.Cantidad;
                    idComedorSeleccionado = item.IdComedor;
                    idArtSeleccionado = item.IdArticuloPedido;

                    break;


                }
                else
                {

                    validarIdArticuloPedido = false;

                }


            }


            if (validarIdArticuloPedido == false)
            {

                Response.Write("<script>alert('ERROR. EL ID_ARTICULO_PEDIDO INGRESADO NO SE ENCUENTRA EN LA BASE DE DATOS.');</script>");
                limpiar();

            }


            //Verificamos si la cantidad ingresada es > que la cantidad correspondiente al id seleccionado.


            if (cant > cantidadSeleccionado)
            {

                validarCantidad = false;


            }
            else
            {

                validarCantidad = true;

            }




            if (validarCantidad == false && validarIdArticuloPedido == true)
            {

                Response.Write("<script>alert('LA CANTIDAD INGRESADA ES MAYOR A LA CANTIDAD SOLICITADA EN ARTICULO PEDIDO SELECCIONADO.');</script>");
                limpiar();

            }


            idPersona1 = Int32.Parse(idPersona);


            foreach (Persona item in listaPersona)
            {


                if (idPersona1 == item.IdPersona)
                {

                    validarIdPersona = true;


                    break;


                }
                else
                {

                    validarIdPersona = false;

                }

            }


            if (validarIdPersona == false)
            {

                Response.Write("<script>alert('ERROR. EL ID_PERSONA INGRESADO NO SE ENCUENTRA EN LA BASE DE DATOS.');</script>");
                limpiar();

            }


            if (nombreArticuloSeleccionado.Equals(nombre))
            {

                validarNombrePedido = true;

            }
            else
            {

                validarNombrePedido = false;

            }

            if (validarNombrePedido == false)
            {

                Response.Write("<script>alert('ERROR. EL NOMBRE INGRESADO NO CONCUERDA CON EL NOMBRE ARTICULO PEDIDO (ID_INGRESADO).');</script>");
                limpiar();

            }


            if (codigoSeleccionado.Equals(codigo))
            {

                validarCodigoPedido = true;

            }
            else
            {

                validarCodigoPedido = false;

            }

            if (validarCodigoPedido == false)
            {

                Response.Write("<script>alert('ERROR. EL CODIGO INGRESADO NO CONCUERDA CON EL CODIGO ARTICULO PEDIDO (ID_INGRESADO).');</script>");
                limpiar();

            }



            if (validarIdArticuloDonado == true && validarIdArticuloPedido == true && validarCantidad == true && validarIdPersona == true && validarNombrePedido == true && validarCodigoPedido == true)
            {

                if (cant == cantidadSeleccionado)  // si la donacion se efectuo por el total.
                {

                    ControladorDonadoPersona.actualizarArticuloDonadoPersona(nombreArticuloSeleccionado, codigoSeleccionado, cant, idPersona1, idArtSeleccionado, idDonado); //insertamos los datos en la BD.

                    ControladorArticuloPedido.eliminarArticuloPedido(idArtSeleccionado); //Se elimina el registro ya que se cubrio la totalida del mismo

                    Response.Write("<script>alert('DATOS ACTUALIZADOS CON EXITO EN LA BASE DE DATOS.');</script>");

                    limpiar();
                }
                else if (cant < cantidadSeleccionado) // Si la cantidad ingresada es menor se gestiona un UPDATE
                {

                    ControladorDonadoPersona.actualizarArticuloDonadoPersona(nombreArticuloSeleccionado, codigoSeleccionado, cant, idPersona1, idArtSeleccionado, idDonado); //insertamos los datos en la BD.

                    int cantFinal = cantidadSeleccionado - cant;  //Siendo la cantidad donada menor a la totalidad restamos la misma

                    ControladorArticuloPedido.actualizarArticuloPedido(nombreArticuloSeleccionado, codigoSeleccionado, cantFinal, idComedorSeleccionado, idArtSeleccionado); //Actualizamos el articuloDonado

                    Response.Write("<script>alert('DATOS ACTUALIZADOS CON EXITO EN LA BASE DE DATOS.');</script>");

                    limpiar();

                }



            }



        }



    }

    

    //Metodo para validar ingreso de numero > 0:

    public void validarCantidad(object source, ServerValidateEventArgs args)
    {

        obtener();

        int cant = Int32.Parse(cantidad);

        if (cant <= 0)
        {


            args.IsValid = false;


        }
        else
        {

            args.IsValid = true;

        }


    }

    public void validarCodigo(object source, ServerValidateEventArgs args)
    {

        obtener();

        int cant = Int32.Parse(codigo);

        if (cant <= 0)
        {


            args.IsValid = false;


        }
        else
        {

            args.IsValid = true;

        }


    }



    //Metodo Evento Boton Insertar Datos:

    protected void eventoInsertar(object sender, EventArgs e)
    {


        // Si la Pagina es Valida podemos Insertar los datos en la base:

        if (Page.IsValid == true)
        {


            obtener();

            //Buscar todos los ArticulosPedidos:

            List<ArticuloPedido> listaPedido = ControladorArticuloPedido.buscarAllArticuloPedido();

            List<Persona> listaPersona = ControladorPersona.buscarAllPersona();

            int idArtPedido = Int32.Parse(idArticuloPedido);

            int cant = Int32.Parse(cantidad);

            bool validarIdArticuloPedido = false, validarCantidad = false, validarIdPersona = false, validarNombrePedido = false, validarCodigoPedido = false;

            string nombreArticuloSeleccionado = "", codigoSeleccionado = "";

            int cantidadSeleccionado = 0, idComedorSeleccionado = 0, idArtSeleccionado = 0;

            string nombrePersona = "", apellidoPersona = "", dniPersona = "", usuarioPersona = "", contraseñaPersona = "";

            int idPersona1 = 0;


            foreach (ArticuloPedido item in listaPedido)
            {

                //Verificamos si el idArticuloPedido seleccionado por el usuario se encuentra en la lista

                if (idArtPedido == item.IdArticuloPedido)
                {

                    validarIdArticuloPedido = true;

                    nombreArticuloSeleccionado = item.Nombre;
                    codigoSeleccionado = item.Codigo;
                    cantidadSeleccionado = item.Cantidad;
                    idComedorSeleccionado = item.IdComedor;
                    idArtSeleccionado = item.IdArticuloPedido;

                    break;


                }
                else
                {

                    validarIdArticuloPedido = false;

                }


            }


            if (validarIdArticuloPedido == false)
            {

                Response.Write("<script>alert('ERROR. EL ID_ARTICULO_PEDIDO INGRESADO NO SE ENCUENTRA EN LA BASE DE DATOS.');</script>");
                limpiar();

            }


            //Verificamos si la cantidad ingresada es > que la cantidad correspondiente al id seleccionado.


            if (cant > cantidadSeleccionado)
            {

                validarCantidad = false;


            }
            else
            {

                validarCantidad = true;

            }




            if (validarCantidad == false && validarIdArticuloPedido == true)
            {


                Response.Write("<script>alert('LA CANTIDAD INGRESADA ES MAYOR A LA CANTIDAD SOLICITADA EN ARTICULO PEDIDO SELECCIONADO.');</script>");
                limpiar();

            }


            idPersona1 = Int32.Parse(idPersona);


            foreach (Persona item in listaPersona)
            {


                if (idPersona1 == item.IdPersona)
                {

                    validarIdPersona = true;


                    break;


                }
                else
                {

                    validarIdPersona = false;

                }

            }


            if (validarIdPersona == false)
            {

                Response.Write("<script>alert('ERROR. EL ID_PERSONA INGRESADO NO SE ENCUENTRA EN LA BASE DE DATOS.');</script>");
                limpiar();

            }


            if (nombreArticuloSeleccionado.Equals(nombre))
            {

                validarNombrePedido = true;

            }
            else
            {

                validarNombrePedido = false;

            }

            if (validarNombrePedido == false)
            {

                Response.Write("<script>alert('ERROR. EL NOMBRE INGRESADO NO CONCUERDA CON EL NOMBRE ARTICULO PEDIDO (ID_INGRESADO).');</script>");
                limpiar();

            }


            if (codigoSeleccionado.Equals(codigo))
            {

                validarCodigoPedido = true;

            }
            else
            {

                validarCodigoPedido = false;

            }

            if (validarCodigoPedido == false)
            {

                Response.Write("<script>alert('ERROR. EL CODIGO INGRESADO NO CONCUERDA CON EL CODIGO ARTICULO PEDIDO (ID_INGRESADO).');</script>");
                limpiar();

            }



            if (validarIdArticuloPedido == true && validarCantidad == true && validarIdPersona == true && validarNombrePedido == true && validarCodigoPedido == true)
            {

                if (cant == cantidadSeleccionado)  // si la donacion se efectuo por el total.
                {

                    ArticuloDonadoPersona articuloDonadoPersona = new ArticuloDonadoPersona(nombreArticuloSeleccionado, codigoSeleccionado, cant, idPersona1, idArtSeleccionado); //Creamos el objeto comedor

                    ControladorDonadoPersona.insertarArticuloDonadoPersona(articuloDonadoPersona); //insertamos los datos en la BD.

                    ControladorArticuloPedido.eliminarArticuloPedido(idArtSeleccionado); //Se elimina el registro ya que se cubrio la totalida del mismo

                    Response.Write("<script>alert('DATOS INSERTADOS CON EXITO EN LA BASE DE DATOS.');</script>");

                    limpiar();
                }
                else if (cant < cantidadSeleccionado) // Si la cantidad ingresada es menor se gestiona un UPDATE
                {

                    ArticuloDonadoPersona articuloDonadoPersona = new ArticuloDonadoPersona(nombreArticuloSeleccionado, codigoSeleccionado, cant, idPersona1, idArtSeleccionado); //Creamos el objeto comedor

                    ControladorDonadoPersona.insertarArticuloDonadoPersona(articuloDonadoPersona); //insertamos los datos en la BD.

                    int cantFinal = cantidadSeleccionado - cant;  //Siendo la cantidad donada menor a la totalidad restamos la misma

                    ControladorArticuloPedido.actualizarArticuloPedido(nombreArticuloSeleccionado, codigoSeleccionado, cantFinal, idComedorSeleccionado, idArtSeleccionado); //Actualizamos el articuloDonado

                    Response.Write("<script>alert('DATOS INSERTADOS CON EXITO EN LA BASE DE DATOS.');</script>");

                    limpiar();

                }



            }

        }

    }



    


    //Evento Boton Buscar One Comedor:


    protected void eventoBuscarOne(object sender, EventArgs e)
    {




        // Si la Pagina es Valida podemos Insertar los datos en la base:

        if (Page.IsValid)
        {

            idBusqueda = TextBox1.Text;

            int id = Int32.Parse(idBusqueda);

            ArticuloDonadoPersona articuloDonadoPersona = ControladorDonadoPersona.buscarOneArticuloDonadoPersona(id);

            if (articuloDonadoPersona != null)
            {


                TextBox2.Text = articuloDonadoPersona.Nombre;
                TextBox5.Text = articuloDonadoPersona.Codigo;
                TextBox6.Text = (articuloDonadoPersona.Cantidad).ToString();
                TextBox7.Text = (articuloDonadoPersona.IdPersona).ToString();
                TextBox8.Text = (articuloDonadoPersona.IdArticuloPedido).ToString();




                Response.Write("<script>alert('DATOS OBTENIDOS CON EXITO DE LA BASE DE DATOS.');</script>");

            }
            else
            {
                Response.Write("<script>alert('NO HAY DIPONIBLE REGISTROS CON EL ID INGRESADO.');</script>");
                limpiar();
            }

        }



    }

    protected void eventoBuscarAll(object sender, EventArgs e)
    {


        List<ArticuloDonadoPersona> listaDonadoPersona = ControladorDonadoPersona.buscarAllArticuloDonadoPersona();


        // Si la Pagina es Valida podemos Insertar los datos en la base:


        if (listaDonadoPersona.Count > 0)
        {

            GrillaComedor.DataSource = listaDonadoPersona; //Agregamos a la GridView la lista Obtenida.
            GrillaComedor.DataBind();

            Response.Write("<script>alert('DATOS OBTENIDOS CON EXITO DE LA BASE DE DATOS.');</script>");

            limpiar();
        }
        else
        {
            GrillaComedor.DataSource = null;
            GrillaComedor.DataBind();

            Response.Write("<script>alert('ERROR NO FUE POSIBLE OBTENER LOS DATOS DE LA BASE DE DATOS.');</script>");
        }



    }

    protected void eventoEliminar(object sender, EventArgs e)
    {


        if (Page.IsValid)
        {

            idBusqueda = TextBox1.Text;

            int id = Int32.Parse(idBusqueda);

            List<ArticuloDonadoPersona> listaDonadoPersona = ControladorDonadoPersona.buscarAllArticuloDonadoPersona();

            bool validar = false;

            foreach (ArticuloDonadoPersona item in listaDonadoPersona)
            {

                if (id == item.IdArticuloDonadoPersona)
                {

                    validar = true;

                }
                else
                {

                    validar = false;


                }


            }

            if (validar == true)
            {
                ControladorDonadoPersona.eliminarArticuloDonadoPersona(id);

                Response.Write("<script>alert('REGISTRO ELIMINADO CON EXITO DE LA BASA DE DATOS.');</script>");

                limpiar();

            }
            else
            {

                Response.Write("<script>alert('ERROR. EL REGISTRO INGRESADO NO SE ENCUENTRA EN LA BASE DE DATOS.');</script>");
                limpiar();
            }


        }



    }



    protected void eventoLimpiar(object sender, EventArgs e)
    {


        limpiar();



    }


    //Metodo para Obtener los datos:

    protected void obtener()
    {

        idBusqueda = TextBox1.Text;
        nombre = TextBox2.Text;
        codigo = TextBox5.Text;
        cantidad = TextBox6.Text;
        idPersona = TextBox7.Text;
        idArticuloPedido = TextBox8.Text;



    }


    //Metodo Limpiar el formulario:
    protected void limpiar()
    {


        TextBox1.Text = "";
        TextBox2.Text = "";
        TextBox5.Text = "";
        TextBox6.Text = "";
        TextBox7.Text = "";
        TextBox8.Text = "";


    }
}