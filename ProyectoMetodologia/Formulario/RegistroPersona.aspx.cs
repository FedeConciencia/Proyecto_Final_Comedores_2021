using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Formulario_RegistroPersona : System.Web.UI.Page
{

    string idBusqueda = "", nombre = "", apellido = "", dni = "", usuario = "", contraseña = "";
    protected void Page_Load(object sender, EventArgs e)
    {

    }

    //Metodo Evento Boton Insertar Datos:

    protected void eventoRegistrar(object sender, EventArgs e)
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

    //Metodo para Obtener los datos:

    protected void obtener()
    {

        
        nombre = TextBox2.Text;
        apellido = TextBox5.Text;
        dni = TextBox3.Text;
        usuario = TextBox4.Text;
        contraseña = TextBox6.Text;



    }


    //Metodo Limpiar el formulario:
    protected void limpiar()
    {


        
        TextBox2.Text = "";
        TextBox3.Text = "";
        TextBox4.Text = "";
        TextBox5.Text = "";
        TextBox6.Text = "";



    }
}