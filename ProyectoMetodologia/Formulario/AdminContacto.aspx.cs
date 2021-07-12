using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Formulario_AdminContacto : System.Web.UI.Page
{

    string idBusqueda = "", nombre = "", apellido = "", email = "", confirmarEmail = "", movil = "", comentario = "";


    protected void Page_Load(object sender, EventArgs e)
    {

    }

    //Evento Actualizar Datos:
    protected void eventoActualizar(object sender, EventArgs e)
    {

        if (Page.IsValid == true)
        {


            List<Contacto> listaContacto = ControladorContacto.buscarAllContacto();

            obtener();

            int id = Int32.Parse(idBusqueda);

            bool validar = false;

            foreach (Contacto item in listaContacto)
            {

                if (id == item.IdContacto)
                {

                    validar = true;
                    break;

                }
                else
                {

                    validar = false;


                }


            }


            if (validar == true)
            {
                ControladorContacto.actualizarContacto(nombre, apellido, email, confirmarEmail, movil, comentario, id);

                Response.Write("<script>alert('REGISTRO ACTUALIZADO CON EXITO DE LA BASA DE DATOS.');</script>");

                limpiar();

            }
            else
            {

                Response.Write("<script>alert('ERROR. EL REGISTRO INGRESADO NO SE ENCUENTRA EN LA BASE DE DATOS.');</script>");
                limpiar();
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

            Contacto contacto = new Contacto(nombre, apellido, email, confirmarEmail, movil, comentario); //Creamos el objeto comedor

            ControladorContacto.insertarContacto(contacto); //insertamos los datos en la BD.

            Response.Write("<script>alert('DATOS INSERTADOS CON EXITO EN LA BASE DE DATOS');</script>");

            limpiar();

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

            Contacto contacto = ControladorContacto.buscarOneContacto(id);

            if (contacto != null)
            {


                TextBox2.Text = contacto.Nombre;
                TextBox7.Text = contacto.Apellido;
                TextBox5.Text = contacto.Email;
                TextBox8.Text = contacto.ConfirmarEmail;
                TextBox9.Text = contacto.Telefono;
                TextBox10.Text = contacto.Comentario;


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


        List<Contacto> listaContacto = ControladorContacto.buscarAllContacto();


        // Si la Pagina es Valida podemos Insertar los datos en la base:


        if (listaContacto.Count > 0)
        {

            GrillaComedor.DataSource = listaContacto; //Agregamos a la GridView la lista Obtenida.
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

            List<Contacto> listaContacto = ControladorContacto.buscarAllContacto();

            bool validar = false;

            foreach (Contacto item in listaContacto)
            {

                if (id == item.IdContacto)
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
                ControladorContacto.eliminarContacto(id);

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
        apellido = TextBox7.Text;
        email = TextBox5.Text;
        confirmarEmail = TextBox8.Text;
        movil = TextBox9.Text;
        comentario = TextBox10.Text;


    }


    //Metodo Limpiar el formulario:
    protected void limpiar()
    {


        TextBox1.Text = "";
        TextBox2.Text = "";
        TextBox7.Text = "";
        TextBox5.Text = "";
        TextBox8.Text = "";
        TextBox9.Text = "";
        TextBox10.Text = "";



    }


}