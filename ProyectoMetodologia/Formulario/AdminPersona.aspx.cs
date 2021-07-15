using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Formulario_AdminPersona : System.Web.UI.Page
{

    string idBusqueda = "", nombre = "", apellido = "", dni = "", usuario = "", contraseña = "";


    protected void Page_Load(object sender, EventArgs e)
    {

    }

    //Evento Actualizar Datos:
    protected void eventoActualizar(object sender, EventArgs e)
    {


        if (Page.IsValid == true)
        {


            List<Persona> listaPersona = ControladorPersona.buscarAllPersona();

            List<Usuario> listaUsuario = ControladorUsuario.buscarAllUsuario();

            obtener();

            int id = Int32.Parse(idBusqueda);

            bool validar = false;

            bool validar2 = false;

            foreach (Persona item in listaPersona)
            {

                if (id == item.IdPersona)
                {

                    validar = true;
                    break;

                }
                else
                {

                    validar = false;


                }


            }

            foreach (Usuario item in listaUsuario) //Verificamos si el id se encuentra en la tabla persona asociado
            {

                if (id == item.IdPersona)
                {

                    validar2 = true;
                    break;

                }
                else
                {

                    validar2 = false;


                }


            }


            if (validar == true && validar2 == true)
            {
                ControladorPersona.actualizarPersona(nombre, apellido, dni, usuario, contraseña, id);

                ControladorUsuario.actualizarUsuarioXidPersona(usuario, contraseña, id); //Se actualizan unicamente los campos usuario y contraseña

                Response.Write("<script>alert('REGISTRO ACTUALIZADO CON EXITO DE LA BASA DE DATOS.');</script>");

                limpiar();

            }
            else if(validar == false || validar2 == false)
            {

                Response.Write("<script>alert('ERROR. EL ID_PERSONA INGRESADO NO SE ENCUENTRA EN LA BASE DE DATOS.');</script>");
                limpiar();
            }
           

        }



    }



    //Metodo Evento Boton Insertar Datos:

    protected void eventoInsertar(object sender, EventArgs e)
    {

        List<Persona> listaPersona = ControladorPersona.buscarAllPersona();

        bool validarDni = false, validarUser = false;

        // Si la Pagina es Valida podemos Insertar los datos en la base:

        if (Page.IsValid == true)
        {
            obtener();

            foreach (Persona item in listaPersona)
            {

                if (dni.Equals(item.Dni))
                {

                    validarDni = true; //Encuentra 2 cuit iguales
                    break;


                }
                else
                {

                    validarDni = false;


                }




            }



            foreach (Persona item in listaPersona)
            {

                if (usuario.Equals(item.Usuario))
                {

                    validarUser = true; //Encuentra 2 cuit iguales
                    break;


                }
                else
                {

                    validarUser = false;


                }



            }


            if (validarDni == false && validarUser == false)
            {

                Persona persona = new Persona(nombre, apellido, dni, usuario, contraseña); //Creamos el objeto comedor

                int idUsuario = ControladorPersona.ObtenerIdSiguientePersona(); //Creo el idPersona Obteniendo el ultimo idPersona + 1 para insertar en Usuario

                Usuario usuario1 = new Usuario(usuario, contraseña, idUsuario, 0);

                ControladorPersona.insertarPersona(persona); //insertamos los datos en la BD.

                ControladorUsuario.insertarUsuario(usuario1);

                Response.Write("<script>alert('DATOS INSERTADOS CON EXITO EN LA BASE DE DATOS');</script>");

                limpiar();


            }
            else if (validarDni == true && validarUser == true)
            {

                Response.Write("<script>alert('ERROR. EL USUARIO Y DNI INGRESADO YA EXISTE EN LA BASE DE DATOS.');</script>");

                limpiar();

            }
            else if (validarDni == false && validarUser == true)
            {

                Response.Write("<script>alert('ERROR. EL USUARIO INGRESADO YA EXISTE EN LA BASE DE DATOS.');</script>");

                limpiar();

            }
            else if (validarDni == true && validarUser == false)
            {


                Response.Write("<script>alert('ERROR. EL DNI INGRESADO YA EXISTE EN LA BASE DE DATOS.');</script>");

                limpiar();

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

            Persona persona = ControladorPersona.buscarOnePersona(id);

            if (persona != null)
            {

                TextBox2.Text = persona.Nombre;
                TextBox3.Text = persona.Dni;
                TextBox4.Text = persona.Usuario;
                TextBox5.Text = persona.Apellido;
                TextBox6.Text = persona.Contraseña;


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


        List<Persona> listaPersona = ControladorPersona.buscarAllPersona();


        // Si la Pagina es Valida podemos Insertar los datos en la base:


        if (listaPersona.Count > 0)
        {

            GrillaComedor.DataSource = listaPersona; //Agregamos a la GridView la lista Obtenida.
            GrillaComedor.DataBind();

            Response.Write("<script>alert('DATOS OBTENIDOS CON EXITO DE LA BASE DE DATOS.');</script>");

            limpiar();
        }
        else
        {
            GrillaComedor.DataSource = null;
            GrillaComedor.DataBind();

            Response.Write("<script>alert('ERROR NO FUE POSIBLE OBTENER LOS DATOS DE LA BASE DE DATOS.');</script>");

            limpiar();
        }



    }

    protected void eventoEliminar(object sender, EventArgs e)
    {



        if (Page.IsValid)
        {

            idBusqueda = TextBox1.Text;

            int id = Int32.Parse(idBusqueda);

            List<Persona> listaPersona = ControladorPersona.buscarAllPersona();

            bool validar = false;

            foreach (Persona item in listaPersona)
            {

                if (id == item.IdPersona)
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
                ControladorPersona.eliminarPersona(id); //Elimina la Persona

                ControladorUsuario.eliminarUsuarioXidPersona(id); //Elimina el Usuario

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
        apellido = TextBox5.Text;
        dni = TextBox3.Text;
        usuario = TextBox4.Text;
        contraseña = TextBox6.Text;



    }


    //Metodo Limpiar el formulario:
    protected void limpiar()
    {


        TextBox1.Text = "";
        TextBox2.Text = "";
        TextBox3.Text = "";
        TextBox4.Text = "";
        TextBox5.Text = "";
        TextBox6.Text = "";



    }
}