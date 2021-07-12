using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Formulario_DonacionesPrincipal : System.Web.UI.Page
{

    string usuario = "", contraseña = "";
    string usuarioAdmin = "admin", contraseñaAdmin = "admin123";
    bool validar = false;

    protected void Page_Load(object sender, EventArgs e)
    {

    }

    //Metodo Evento Boton Enviar:

    protected void eventoEnviar(object sender, EventArgs e)
    {

        validar = false;

        // Si la Pagina es Valida podemos Insertar los datos en la base:

        if (Page.IsValid)
        {

            validar = true;




        }
        else
        {

            validar = false;

        }


        if (validar == true)
        {
            obtener();

            List<Usuario> listaUsuario = ControladorUsuario.buscarAllUsuario(); //Obtenemos todos los Usuarios dentro de la base

            List<Persona> listaPersona = ControladorPersona.buscarAllPersona();

            List<Empresa> listaEmpresa = ControladorEmpresa.buscarAllEmpresa();

            Persona persona = null;

            Empresa empresa = null;

            bool validarEmpresa = false, validarPersona = false;



            foreach (Persona item1 in listaPersona)
            {

                if (usuario.Equals(item1.Usuario))
                {

                    validarPersona = true;
                    break;


                }
                else
                {

                    validarPersona = false;

                }




            }


            foreach (Empresa item2 in listaEmpresa)
            {

                if (usuario.Equals(item2.Usuario))
                {

                    validarEmpresa = true;
                    break;


                }
                else
                {

                    validarEmpresa = false;

                }


            }



            if (listaUsuario != null)
            {

                foreach (Usuario item in listaUsuario)
                {


                    if (usuario.Equals(usuarioAdmin) && contraseña.Equals(contraseñaAdmin))
                    {

                        Response.Redirect("AdminPrincipal.aspx"); //Direccionamos a la pagina admin
                        Response.Write("<script>alert('USUARIO ADMIN VALIDADO CON EXITO');</script>");

                    }
                    else if (usuario.Equals(item.NombreUsuario) && contraseña.Equals(item.ContraseñaUsuario) && validarPersona == true)
                    {

                        Session["usuarioPersona"] = item.NombreUsuario; //Guardamos el Usuario Persona en una Session

                        Response.Redirect("FormDonacionPersona.aspx"); //Direccionamos a la pagina de usuario
                        Response.Write("<script>alert('USUARIO VALIDADO CON EXITO.');</script>");

                    }
                    else if (usuario.Equals(item.NombreUsuario) && contraseña.Equals(item.ContraseñaUsuario) && validarEmpresa == true)
                    {


                        Session["usuarioEmpresa"] = item.NombreUsuario; //Guardamos el Usuario Empresa en una Session

                        Response.Redirect("FormDonacionEmpresa.aspx"); //Direccionamos a la pagina de usuario
                        Response.Write("<script>alert('USUARIO VALIDADO CON EXITO.');</script>");


                    }
                    else
                    {

                        LabelMensaje1.Text = "ERROR. LOGUIN INCORRECTO.";
                        LabelMensaje1.ForeColor = System.Drawing.Color.Red;

                    }
                }

            }
            else
            {

                Response.Write("<script>alert('ERROR.NO EXISTEN REGISTROS BASE DE DATOS.');</script>");

            }


            limpiar();

        }



    }




    protected void obtener()
    {

        usuario = TextBox1.Text;
        contraseña = TextBox2.Text;


    }

    protected void limpiar()
    {

        TextBox1.Text = "";
        TextBox2.Text = "";

    }



}