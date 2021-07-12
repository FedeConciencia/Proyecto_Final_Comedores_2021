using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Formulario_AdminEmpresa : System.Web.UI.Page
{

    string idBusqueda = "", nombre = "", cuit = "", domicilio = "", usuario = "", contraseña = "";


    protected void Page_Load(object sender, EventArgs e)
    {

    }


    //Validacion Personalizada de CUIT unico:

    protected void validarCuitUnico(object source, ServerValidateEventArgs args)
    {

        //Validamos si el dato string ingresado contiene caracteres numericos:

        bool validar = false;

        obtener();

        List<Empresa> listaEmpresa = ControladorEmpresa.buscarAllEmpresa();

        foreach (Empresa item in listaEmpresa)
        {

            if (cuit.Equals(item.Cuit))
            {

                validar = true; //Encuentra 2 cuit iguales
                break;


            }
            else
            {

                validar = false; //el cuit ingresado no se encuentra disponible.


            }



        }

        if (validar == false)
        {

            args.IsValid = true; //El evento personalizado es valido (Cuit unico)

        }
        else
        {

            args.IsValid = false; //El evento personalizado no cumple validacion (cuit repetido)

        }


    }

    //Validacion Personalizada de USUARIO unico:

    protected void validarUsuarioUnico(object source, ServerValidateEventArgs args)
    {

        //Validamos si el dato string ingresado contiene caracteres numericos:

        bool validar = false;

        obtener();

        List<Usuario> listaUsuario = ControladorUsuario.buscarAllUsuario();

        foreach (Usuario item in listaUsuario)
        {

            if (usuario.Equals(item.NombreUsuario))
            {

                validar = true; //Encuentra 2 usuarios iguales
                break;


            }
            else
            {

                validar = false; //el usuario ingresado no se encuentra disponible.


            }



        }

        if (validar == false)
        {

            args.IsValid = true; //El evento personalizado es valido (Cuit unico)

        }
        else
        {

            args.IsValid = false; //El evento personalizado no cumple validacion (cuit repetido)

        }


    }


    //Evento Actualizar Datos:
    protected void eventoActualizar(object sender, EventArgs e)
    {

        if (Page.IsValid == true)
        {


            List<Empresa> listaEmpresa = ControladorEmpresa.buscarAllEmpresa();

            List<Usuario> listaUsuario = ControladorUsuario.buscarAllUsuario();


            obtener();

            int id = Int32.Parse(idBusqueda);

            bool validar = false;

            bool validar2 = false;

            foreach (Empresa item in listaEmpresa)
            {

                if (id == item.IdEmpresa)
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

                if (id == item.IdEmpresa)
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
                ControladorEmpresa.actualizarEmpresa(nombre, cuit, domicilio, usuario, contraseña, id);

                ControladorUsuario.actualizarUsuarioXidEmpresa(usuario, contraseña, id);

                Response.Write("<script>alert('REGISTRO ACTUALIZADO CON EXITO DE LA BASA DE DATOS.');</script>");

                limpiar();

            }
            else if (validar == false || validar2 == false)
            {

                Response.Write("<script>alert('ERROR. EL ID_PERSONA INGRESADO NO SE ENCUENTRA EN LA BASE DE DATOS.');</script>");
                limpiar();
            }


        }



    }



    //Metodo Evento Boton Insertar Datos:

    protected void eventoInsertar(object sender, EventArgs e)
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


            }else if (validarCuit == true && validarUser == true)
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


    //Evento Boton Buscar One Comedor:


    protected void eventoBuscarOne(object sender, EventArgs e)
    {


        // Si la Pagina es Valida podemos Insertar los datos en la base:

        if (Page.IsValid)
        {

            idBusqueda = TextBox1.Text;

            int id = Int32.Parse(idBusqueda);

            Empresa empresa = ControladorEmpresa.buscarOneEmpresa(id);

            if (empresa != null)
            {


                TextBox2.Text = empresa.Nombre;
                TextBox3.Text = empresa.Domicilio;
                TextBox4.Text = empresa.Usuario;
                TextBox5.Text = empresa.Cuit;
                TextBox6.Text = empresa.Contraseña;


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


        List<Empresa> listaEmpresa = ControladorEmpresa.buscarAllEmpresa();


        // Si la Pagina es Valida podemos Insertar los datos en la base:


        if (listaEmpresa.Count > 0)
        {

            GrillaComedor.DataSource = listaEmpresa; //Agregamos a la GridView la lista Obtenida.
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

            List<Empresa> listaEmpresa = ControladorEmpresa.buscarAllEmpresa();

            bool validar = false;

            foreach (Empresa item in listaEmpresa)
            {

                if (id == item.IdEmpresa)
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
                ControladorEmpresa.eliminarEmpresa(id);

                ControladorUsuario.eliminarUsuarioXidEmpresa(id);

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
        cuit = TextBox5.Text;
        domicilio = TextBox3.Text;
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