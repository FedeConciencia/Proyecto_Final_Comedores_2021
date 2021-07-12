using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Formulario_AdminPedido : System.Web.UI.Page
{

    string idBusqueda = "", nombre = "", codigo = "", cantidad = "", idComedor = "";
    protected void Page_Load(object sender, EventArgs e)
    {

    }


    //Evento Actualizar Datos:
    protected void eventoActualizar(object sender, EventArgs e)
    {

        if (Page.IsValid == true)
        {


            List<ArticuloPedido> listaArticuloPedido = ControladorArticuloPedido.buscarAllArticuloPedido();

            List<Comedor> listaComedor = ControladorComedor.buscarAllComedor();

            bool validarComedor = false;

            obtener();

            int id = Int32.Parse(idBusqueda);

            int idComedor1 = Int32.Parse(idComedor);

            bool validar = false;

            foreach (ArticuloPedido item in listaArticuloPedido)
            {

                if (id == item.IdArticuloPedido)
                {

                    validar = true;
                    break;

                }
                else
                {

                    validar = false;


                }


            }

            if (validar == false)
            {
                Response.Write("<script>alert('El ID_ARTICULO_PEDIDO INGRESADO NO SE ENCUENTRA EN LA BASE DE DATOS');</script>");
                limpiar();
            }

            foreach (Comedor item in listaComedor)
            {

                if (idComedor1 == item.IdComedor)
                {

                    validarComedor = true;
                    break;

                }
                else
                {

                    validarComedor = false;

                }

            }


            if (validarComedor == false)
            {
                Response.Write("<script>alert('El ID_COMEDOR INGRESADO NO SE ENCUENTRA EN LA BASE DE DATOS');</script>");
                limpiar();
            }


            if (validar == true && validarComedor == true)
            {
                ControladorArticuloPedido.actualizarArticuloPedido(nombre, codigo, Int32.Parse(cantidad), Int32.Parse(idComedor), id);

                Response.Write("<script>alert('REGISTRO ACTUALIZADO CON EXITO DE LA BASA DE DATOS.');</script>");

                limpiar();

            }


        }

    }

    //Metodo Evento Boton Insertar Datos:

    protected void eventoInsertar(object sender, EventArgs e)
    {

        List<Comedor> listaComedor = ControladorComedor.buscarAllComedor();

        bool validarComedor = false;

        // Si la Pagina es Valida podemos Insertar los datos en la base:

        if (Page.IsValid == true)
        {
            obtener();

            int idComedor1 = Int32.Parse(idComedor);

            foreach (Comedor item in listaComedor)
            {

                if (idComedor1 == item.IdComedor)
                {

                    validarComedor = true;
                    break;

                }
                else
                {

                    validarComedor = false;

                }

            }


            if (validarComedor == false)
            {
                Response.Write("<script>alert('El ID_COMEDOR INGRESADO NO SE ENCUENTRA EN LA BASE DE DATOS');</script>");
                limpiar();
            }
            else
            {

                ArticuloPedido articuloPedido = new ArticuloPedido(nombre, codigo, Int32.Parse(cantidad), Int32.Parse(idComedor)); //Creamos el objeto comedor

                ControladorArticuloPedido.insertarArticuloPedido(articuloPedido); //insertamos los datos en la BD.

                Response.Write("<script>alert('DATOS INSERTADOS CON EXITO EN LA BASE DE DATOS');</script>");

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


    //Evento Boton Buscar One Comedor:


    protected void eventoBuscarOne(object sender, EventArgs e)
    {


        // Si la Pagina es Valida podemos Insertar los datos en la base:

        if (Page.IsValid)
        {

            idBusqueda = TextBox1.Text;

            int id = Int32.Parse(idBusqueda);

            ArticuloPedido articuloPedido = ControladorArticuloPedido.buscarOneArticuloPedido(id);

            if (articuloPedido != null)
            {


                
                TextBox2.Text = articuloPedido.Nombre;
                TextBox3.Text = articuloPedido.Codigo;
                TextBox4.Text = (articuloPedido.Cantidad).ToString();
                TextBox6.Text = (articuloPedido.IdComedor).ToString();


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


        List<ArticuloPedido> listaArticuloPedido = ControladorArticuloPedido.buscarAllArticuloPedido();


        // Si la Pagina es Valida podemos Insertar los datos en la base:


        if (listaArticuloPedido.Count > 0)
        {

            GrillaComedor.DataSource = listaArticuloPedido; //Agregamos a la GridView la lista Obtenida.
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

            List<ArticuloPedido> listaArticuloPedido = ControladorArticuloPedido.buscarAllArticuloPedido();

            bool validar = false;

            foreach (ArticuloPedido item in listaArticuloPedido)
            {

                if (id == item.IdArticuloPedido)
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
                ControladorArticuloPedido.eliminarArticuloPedido(id);

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
        codigo = TextBox3.Text;
        cantidad = TextBox4.Text;
        idComedor = TextBox6.Text;
        


    }


    //Metodo Limpiar el formulario:
    protected void limpiar()
    {


        TextBox1.Text = "";
        TextBox2.Text = "";
        TextBox3.Text = "";
        TextBox4.Text = "";
        TextBox6.Text = "";
       



    }

}