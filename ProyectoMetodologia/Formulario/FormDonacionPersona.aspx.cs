using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Formulario_FormUsuarioPrincipal : System.Web.UI.Page
{

    string idComedor = "", nombre = "", cantidad = "", codigo = "", idEmpresa = "", idArticuloPedido = "";

    static int id = 0; //Variable global static

    protected void Page_Load(object sender, EventArgs e)
    {

        

        //Buscar todos los comedores mostrar al cargar la pagina:

        List<Comedor> listaComedor = ControladorComedor.buscarAllComedor();


        if (listaComedor.Count > 0)
        {

            GrillaAllComedor.DataSource = listaComedor; //Agregamos a la GridView la lista Obtenida.
            GrillaAllComedor.DataBind();

            //Response.Write("<script>alert('DATOS OBTENIDOS CON EXITO DE LA BASE DE DATOS.');</script>");


        }
        else
        {
            GrillaAllComedor.DataSource = null;
            GrillaAllComedor.DataBind();

            Response.Write("<script>alert('ERROR NO EXISTEN REGISTROS DE COMEDORES EN LA ACTUALIDAD.');</script>");
        }


    }


    //Metodo seleccionar comedor y mostrar articulos Pedidos:

    protected void eventoseleccionarComedor(object sender, EventArgs e)
    {


        // Si la Pagina es Valida podemos Insertar los datos en la base:

        if (Page.IsValid)
        {

            obtener();

            id = Int32.Parse(idComedor); //Lo Guardamos en una variable Global Statica

            //Buscar todos los Comedores mostrar al cargar la pagina:

            List<Comedor> listaComedor = ControladorComedor.buscarAllComedor();

            bool validarIdComedor = false;

            foreach (Comedor item in listaComedor)
            {

                if (id == item.IdComedor)
                {


                    validarIdComedor = true;
                    break;



                }
                else
                {

                    validarIdComedor = false;


                }



            }


            if (validarIdComedor == false)
            {

                Response.Write("<script>alert('ERROR. EL ID_COMEDOR INGRESADO NO SE ENCUENTRA EN LA BASE DE DATOS.');</script>");
                limpiar1();

            }
            else
            {

                //Buscar todos los ArticulosPedidosXComedor mostrar al cargar la pagina:

                List<ArticuloPedido> listaPedido = ControladorArticuloPedido.buscarAllArticuloPedidoXComedor(id);


                if (listaPedido.Count > 0)
                {

                    GrillaPedidos.DataSource = listaPedido; //Agregamos a la GridView la lista Obtenida.
                    GrillaPedidos.DataBind();

                    Response.Write("<script>alert('DATOS OBTENIDOS CON EXITO DE LA BASE DE DATOS.');</script>");


                }
                else
                {
                    GrillaPedidos.DataSource = null;
                    GrillaPedidos.DataBind();

                    Response.Write("<script>alert('ERROR NO FUE POSIBLE OBTENER LOS DATOS DE LA BASE DE DATOS.');</script>");
                }



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



    //Metodo Gestionar Donacion:

    protected void eventoDonacion(object sender, EventArgs e)
    {

        // Si la Pagina es Valida podemos Insertar los datos en la base:

        if (Page.IsValid)
        {


            obtener();

            //Buscar todos los ArticulosPedidosXComedor mostrar al cargar la pagina:

            List<ArticuloPedido> listaPedido = ControladorArticuloPedido.buscarAllArticuloPedidoXComedor(id);

            int idArtPedido = Int32.Parse(idArticuloPedido);

            int cant = Int32.Parse(cantidad);

            bool validarIdArticuloPedido = false, validarCantidad = false;

            string nombreArticuloSeleccionado = "", codigoSeleccionado = "";

            int cantidadSeleccionado = 0, idComedorSeleccionado = 0, idArtSeleccionado = 0;

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
                limpiar2();

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
                limpiar2();

            }


            if (validarIdArticuloPedido == true && validarCantidad == true)
            {

                string usuarioLogin = (string)Session["usuarioPersona"]; //Obtenemos el usuario logueado en el Login

                List<Persona> listaPersona = ControladorPersona.buscarAllPersona();

                bool validarUsuarioPersona = false;

                string nombrePersona = "", apellidoPersona = "", dniPersona = "", usuarioPersona = "", contraseñaPersona = "";
                int idPersona = 0;

                foreach (Persona item in listaPersona)
                {

                    if (usuarioLogin.Equals(item.Usuario))  //Gestionamos Busqueda del Usuario que es Unico.
                    {

                        validarUsuarioPersona = true;

                        idPersona = item.IdPersona;
                        nombrePersona = item.Nombre;
                        apellidoPersona = item.Apellido;
                        dniPersona = item.Dni;
                        usuarioPersona = item.Usuario;
                        contraseñaPersona = item.Contraseña;


                        break;


                    }
                    else
                    {

                        validarUsuarioPersona = false;

                    }


                }


               


                    if (cant == cantidadSeleccionado)  // si la donacion se efectuo por el total.
                    {


                        ArticuloDonadoPersona articuloDonadoPersona = new ArticuloDonadoPersona(nombreArticuloSeleccionado, codigoSeleccionado, cant, idPersona, idArtSeleccionado);  //Creo el Objeto ArticuloDonado

                        ControladorDonadoPersona.insertarArticuloDonadoPersona(articuloDonadoPersona); //Inserto el objeto en la tabla

                        ControladorArticuloPedido.eliminarArticuloPedido(idArtSeleccionado); //Se elimina el registro ya que se cubrio la totalida del mismo

                        Response.Write("<script>alert('DONACION EFECTUADA CON EXITO. AGRADECEMOS SU VOLUNTAD. NOS PONDREMOS EN CONTACTO A LA BREVEDAD PARA COORDINAR LA MISMA.');</script>");
                        limpiar2();
                    }
                    else if (cant < cantidadSeleccionado) // Si la cantidad ingresada es menor se gestiona un UPDATE
                    {

                        ArticuloDonadoPersona articuloDonadoPersona = new ArticuloDonadoPersona(nombreArticuloSeleccionado, codigoSeleccionado, cant, idPersona, idArtSeleccionado);  //Creo el Objeto ArticuloDonado

                        ControladorDonadoPersona.insertarArticuloDonadoPersona(articuloDonadoPersona); //Inserto el objeto en la tabla

                        int cantFinal = cantidadSeleccionado - cant;  //Siendo la cantidad donada menor a la totalidad restamos la misma

                        ControladorArticuloPedido.actualizarArticuloPedido(nombreArticuloSeleccionado, codigoSeleccionado, cantFinal, idComedorSeleccionado, idArtSeleccionado); //Actualizamos el articuloDonado

                        Response.Write("<script>alert('DONACION EFECTUADA CON EXITO. AGRADECEMOS SU VOLUNTAD. NOS PONDREMOS EN CONTACTO A LA BREVEDAD PARA COORDINAR LA MISMA.');</script>");
                        limpiar2();

                    }


                

            }

        }
    }


    //Metodo Obtener Datos:
    protected void obtener()
    {

        idComedor = TextBox1.Text;
        idArticuloPedido = TextBox2.Text;
        cantidad = TextBox3.Text;

    }



    //Metodo Obtener Limpiar:
    protected void limpiar1()
    {

        TextBox1.Text = "";


    }

    //Metodo Obtener Limpiar:
    protected void limpiar2()
    {

        TextBox2.Text = "";
        TextBox3.Text = "";


    }


}