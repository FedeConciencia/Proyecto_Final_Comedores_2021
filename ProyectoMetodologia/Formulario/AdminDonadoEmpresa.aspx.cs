using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Formulario_AdminDonadoEmpresa : System.Web.UI.Page
{

    string idBusqueda = "", nombre = "", codigo = "", cantidad = "", idEmpresa = "", idArticuloPedido = "";

  
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

            List<ArticuloDonadoEmpresa> listaArticuloDonadoEmpresa = ControladorDonadoEmpresa.buscarAllArticuloDonadoEmpresa();

            List<ArticuloPedido> listaPedido = ControladorArticuloPedido.buscarAllArticuloPedido();

            List<Empresa> listaEmpresa = ControladorEmpresa.buscarAllEmpresa();

            int idArtPedido = Int32.Parse(idArticuloPedido);

            int cant = Int32.Parse(cantidad);

            bool validarIdArticuloPedido = false, validarCantidad = false, validarIdEmpresa = false, validarNombrePedido = false, validarCodigoPedido = false, validarIdArticuloDonado = false;

            string nombreArticuloSeleccionado = "", codigoSeleccionado = "";

            int cantidadSeleccionado = 0, idComedorSeleccionado = 0, idArtSeleccionado = 0;

            string nombreEmpresa = "", cuitEmpresa = "", domicilioEmpresa = "", usuarioEmpresa = "", contraseñaEmpresa = "";

            int idEmpresa1 = 0, idDonado = 0;


            idDonado = Int32.Parse(idBusqueda);


            foreach (ArticuloDonadoEmpresa item in listaArticuloDonadoEmpresa)
            {


                if (idDonado == item.IdArticuloDonadoEmpresa)
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


            idEmpresa1 = Int32.Parse(idEmpresa);


            foreach (Empresa item in listaEmpresa)
            {


                if (idEmpresa1 == item.IdEmpresa)
                {

                    validarIdEmpresa = true;


                    break;


                }
                else
                {

                    validarIdEmpresa = false;

                }

            }


            if (validarIdEmpresa == false)
            {

                Response.Write("<script>alert('ERROR. EL ID_EMPRESA INGRESADO NO SE ENCUENTRA EN LA BASE DE DATOS.');</script>");
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



            if (validarIdArticuloDonado == true && validarIdArticuloPedido == true && validarCantidad == true && validarIdEmpresa == true && validarNombrePedido == true && validarCodigoPedido == true)
            {

                if (cant == cantidadSeleccionado)  // si la donacion se efectuo por el total.
                {

                    ControladorDonadoEmpresa.actualizarArticuloDonadoEmpresa(nombreArticuloSeleccionado, codigoSeleccionado, cant, idEmpresa1, idArtSeleccionado, idDonado); //insertamos los datos en la BD.

                    ControladorArticuloPedido.eliminarArticuloPedido(idArtSeleccionado); //Se elimina el registro ya que se cubrio la totalida del mismo

                    Response.Write("<script>alert('DATOS ACTUALIZADOS CON EXITO EN LA BASE DE DATOS.');</script>");

                    limpiar();
                }
                else if (cant < cantidadSeleccionado) // Si la cantidad ingresada es menor se gestiona un UPDATE
                {

                    ControladorDonadoEmpresa.actualizarArticuloDonadoEmpresa(nombreArticuloSeleccionado, codigoSeleccionado, cant, idEmpresa1, idArtSeleccionado, idDonado); //insertamos los datos en la BD.

                    int cantFinal = cantidadSeleccionado - cant;  //Siendo la cantidad donada menor a la totalidad restamos la misma

                    ControladorArticuloPedido.actualizarArticuloPedido(nombreArticuloSeleccionado, codigoSeleccionado, cantFinal, idComedorSeleccionado, idArtSeleccionado); //Actualizamos el articuloDonado

                    Response.Write("<script>alert('DATOS ACTUALIZADOS CON EXITO EN LA BASE DE DATOS.');</script>");

                    limpiar();

                }



            }



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

            List<Empresa> listaEmpresa = ControladorEmpresa.buscarAllEmpresa();

            int idArtPedido = Int32.Parse(idArticuloPedido);

            int cant = Int32.Parse(cantidad);

            bool validarIdArticuloPedido = false, validarCantidad = false, validarIdEmpresa = false, validarNombrePedido = false, validarCodigoPedido = false;

            string nombreArticuloSeleccionado = "", codigoSeleccionado = "";

            int cantidadSeleccionado = 0, idComedorSeleccionado = 0, idArtSeleccionado = 0;

            string nombreEmpresa = "", cuitEmpresa = "", domicilioEmpresa = "", usuarioEmpresa = "", contraseñaEmpresa = "";

            int idEmpresa1 = 0;


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


            idEmpresa1 = Int32.Parse(idEmpresa);


            foreach (Empresa item in listaEmpresa)
            {


                if (idEmpresa1 == item.IdEmpresa)
                {

                    validarIdEmpresa = true;


                    break;


                }
                else
                {

                    validarIdEmpresa = false;

                }

            }


            if (validarIdEmpresa == false)
            {

                Response.Write("<script>alert('ERROR. EL ID_EMPRESA INGRESADO NO SE ENCUENTRA EN LA BASE DE DATOS.');</script>");
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



            if (validarIdArticuloPedido == true && validarCantidad == true && validarIdEmpresa == true && validarNombrePedido == true && validarCodigoPedido == true)
            {

                if (cant == cantidadSeleccionado)  // si la donacion se efectuo por el total.
                {

                    ArticuloDonadoEmpresa articuloDonadoEmpresa = new ArticuloDonadoEmpresa(nombreArticuloSeleccionado, codigoSeleccionado, cant, idEmpresa1, idArtSeleccionado); //Creamos el objeto comedor

                    ControladorDonadoEmpresa.insertarArticuloDonadoEmpresa(articuloDonadoEmpresa); //insertamos los datos en la BD.

                    ControladorArticuloPedido.eliminarArticuloPedido(idArtSeleccionado); //Se elimina el registro ya que se cubrio la totalida del mismo

                    Response.Write("<script>alert('DATOS INSERTADOS CON EXITO EN LA BASE DE DATOS.');</script>");

                    limpiar();
                }
                else if (cant < cantidadSeleccionado) // Si la cantidad ingresada es menor se gestiona un UPDATE
                {

                    ArticuloDonadoEmpresa articuloDonadoEmpresa = new ArticuloDonadoEmpresa(nombreArticuloSeleccionado, codigoSeleccionado, cant, idEmpresa1, idArtSeleccionado); //Creamos el objeto comedor

                    ControladorDonadoEmpresa.insertarArticuloDonadoEmpresa(articuloDonadoEmpresa); //insertamos los datos en la BD.

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

            ArticuloDonadoEmpresa articuloDonadoEmpresa = ControladorDonadoEmpresa.buscarOneArticuloDonadoEmpresa(id);

            if (articuloDonadoEmpresa != null)
            {


                TextBox2.Text = articuloDonadoEmpresa.Nombre;
                TextBox5.Text = articuloDonadoEmpresa.Codigo;
                TextBox6.Text = (articuloDonadoEmpresa.Cantidad).ToString();
                TextBox7.Text = (articuloDonadoEmpresa.IdEmpresa).ToString();
                TextBox8.Text = (articuloDonadoEmpresa.IdArticuloPedido).ToString();




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


        List<ArticuloDonadoEmpresa> listaDonadoEmpresa = ControladorDonadoEmpresa.buscarAllArticuloDonadoEmpresa();


        // Si la Pagina es Valida podemos Insertar los datos en la base:


        if (listaDonadoEmpresa.Count > 0)
        {

            GrillaComedor.DataSource = listaDonadoEmpresa; //Agregamos a la GridView la lista Obtenida.
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

            List<ArticuloDonadoEmpresa> listaDonadoEmpresa = ControladorDonadoEmpresa.buscarAllArticuloDonadoEmpresa();

            bool validar = false;

            foreach (ArticuloDonadoEmpresa item in listaDonadoEmpresa)
            {

                if (id == item.IdArticuloDonadoEmpresa)
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
                ControladorDonadoEmpresa.eliminarArticuloDonadoEmpresa(id);

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

    //Metodo personalizado para validar ingreso de Cantidad:

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
        idEmpresa = TextBox7.Text;
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
