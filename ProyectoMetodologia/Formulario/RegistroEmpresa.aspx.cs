using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Formulario_RegistroEmpresa : System.Web.UI.Page
{

    string idBusqueda = "", nombre = "", cuit = "", domicilio = "", usuario = "", contraseña = "";
    protected void Page_Load(object sender, EventArgs e)
    {

    }

    protected void eventoRegistrar(object sender, EventArgs e)
    {

        List<Empresa> listaEmpresa = ControladorEmpresa.buscarAllEmpresa();

        bool validarCuit = false, validarUser = false;

        // Si la Pagina es Valida podemos Insertar los datos en la base:

        if (Page.IsValid == true)
        {
            obtener();

            foreach (Empresa item in listaEmpresa)
            {

                if (cuit.Equals(item.Cuit))
                {

                    validarCuit = true; //Encuentra 2 cuit iguales
                    break;


                }
                else
                {

                    validarCuit = false;


                }




            }



            foreach (Empresa item in listaEmpresa)
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


            if (validarCuit == false && validarUser == false)
            {

                Empresa empresa = new Empresa(nombre, cuit, domicilio, usuario, contraseña); //Creamos el objeto comedor

                int idUsuario = ControladorEmpresa.ObtenerIdSiguienteEmpresa(); //Creo el idPersona Obteniendo el ultimo idPersona + 1 para insertar en Usuario

                Usuario usuario1 = new Usuario(usuario, contraseña, 0, idUsuario);

                ControladorEmpresa.insertarEmpresa(empresa); //insertamos los datos en la BD.

                ControladorUsuario.insertarUsuario(usuario1);

                Response.Write("<script>alert('DATOS INSERTADOS CON EXITO EN LA BASE DE DATOS');</script>");

                limpiar();


            }
            else if (validarCuit == true && validarUser == true)
            {

                Response.Write("<script>alert('ERROR. EL USUARIO Y CUIT INGRESADO YA EXISTE EN LA BASE DE DATOS.');</script>");

                limpiar();

            }
            else if (validarCuit == false && validarUser == true)
            {

                Response.Write("<script>alert('ERROR. EL USUARIO INGRESADO YA EXISTE EN LA BASE DE DATOS.');</script>");

                limpiar();

            }
            else if (validarCuit == true && validarUser == false)
            {


                Response.Write("<script>alert('ERROR. EL CUIT INGRESADO YA EXISTE EN LA BASE DE DATOS.');</script>");

                limpiar();

            }




        }

    }

    //Metodo para Obtener los datos:

    protected void obtener()
    {


        nombre = TextBox2.Text;
        cuit = TextBox5.Text;
        domicilio = TextBox3.Text;
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