using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Formulario_AdminUsuario : System.Web.UI.Page
{

    string idBusqueda = "", nombreUsuario = "", contraseñaUsuario = "", idPersona = "", idEmpresa = "";
    protected void Page_Load(object sender, EventArgs e)
    {

    }

    //Evento Actualizar Datos:
    protected void eventoActualizar(object sender, EventArgs e)
    {

        if (Page.IsValid == true)
        {


            List<Usuario> listaUsuario = ControladorUsuario.buscarAllUsuario();

            List<Persona> listaPersona = ControladorPersona.buscarAllPersona();

            List<Empresa> listaEmpresa = ControladorEmpresa.buscarAllEmpresa();

            obtener();

            int id = Int32.Parse(idBusqueda);

            bool validarIdUsuario = false, validarEmpresaId = false, validarPersonaId = false, validarUser = false;

            int idObtenidoPersona = 0, idObtenidoEmpresa = 0;

            foreach (Usuario item in listaUsuario)
            {

                if (id == item.IdUsuario)
                {

                    validarIdUsuario = true;
                    break;

                }
                else
                {

                    validarIdUsuario = false;


                }


            }

            if (validarIdUsuario == false)
            {

                Response.Write("<script>alert('El ID_USUARIO INGRESADO NO EXISTE EN LA BASE DE DATOS.');</script>");

                limpiar();

            }

            idObtenidoPersona = Int32.Parse(idPersona);


            foreach (Persona item in listaPersona)
            {

                if (idObtenidoPersona == item.IdPersona)
                {

                    validarPersonaId = true;
                    break;


                }
                else
                {

                    validarPersonaId = false;


                }

            }



            if (validarPersonaId == false)
            {

                if (idObtenidoPersona != 0)
                {

                    Response.Write("<script>alert('El ID_PERSONA INGRESADO NO EXISTE EN LA BASE DE DATOS.');</script>");

                    limpiar();

                }

            }


            idObtenidoEmpresa = Int32.Parse(idEmpresa);

            foreach (Empresa item in listaEmpresa)
            {

                if (idObtenidoEmpresa == item.IdEmpresa)
                {

                    validarEmpresaId = true;
                    break;


                }
                else
                {

                    validarEmpresaId = false;


                }


            }


            if (validarEmpresaId == false)
            {


                if (idObtenidoEmpresa != 0)
                {

                    Response.Write("<script>alert('El ID_EMPRESA INGRESADO NO EXISTE EN LA BASE DE DATOS.');</script>");

                    limpiar();

                }

            }


            if (validarIdUsuario == true && validarEmpresaId == true)
            {

                ControladorUsuario.actualizarUsuario(nombreUsuario, contraseñaUsuario, 0, idObtenidoEmpresa, id);

                ControladorEmpresa.actualizarEmpresaXUsuario(nombreUsuario, contraseñaUsuario, idObtenidoEmpresa); //Actualizamos los datos ingresados en la Empresa

                Response.Write("<script>alert('REGISTRO ACTUALIZADO CON EXITO DE LA BASA DE DATOS.');</script>");

                limpiar();


            }
            else if (validarIdUsuario == true && validarPersonaId == true)
            {

                ControladorUsuario.actualizarUsuario(nombreUsuario, contraseñaUsuario, idObtenidoPersona, 0, id);

                ControladorPersona.actualizarPersonaXUsuario(nombreUsuario, contraseñaUsuario, idObtenidoPersona); //Actualizamos los datos ingresados en la Empresa

                Response.Write("<script>alert('REGISTRO ACTUALIZADO CON EXITO DE LA BASA DE DATOS.');</script>");

                limpiar();

            }
            else
            {

                Response.Write("<script>alert('ERROR. NO ES POSIBLE GESTIONAR LA CARGA DE LOS DATOS. VERIFICAR DATOS INGRESADOS');</script>");

                limpiar();

            }



        }



    }



    //Metodo Evento Boton Insertar Datos:

    protected void eventoInsertar(object sender, EventArgs e)
    {

        List<Usuario> listaUsuario = ControladorUsuario.buscarAllUsuario();

        List<Persona> listaPersona = ControladorPersona.buscarAllPersona();

        List<Empresa> listaEmpresa = ControladorEmpresa.buscarAllEmpresa();

        bool validarUser = false, validarEmpresaId = false, validarPersonaId = false;

        int idObtenidoPersona = 0, idObtenidoEmpresa = 0;

        // Si la Pagina es Valida podemos Insertar los datos en la base:

        if (Page.IsValid == true)
        {

            obtener();


            foreach (Usuario item in listaUsuario)
            {

                if (nombreUsuario.Equals(item.NombreUsuario))
                {

                    validarUser = true; //Encuentra 2 usuario iguales
                    break;


                }
                else
                {

                    validarUser = false;


                }



            }



            if (validarUser == true)
            {

                Response.Write("<script>alert('El USUARIO INGRESADO YA EXISTE EN LA BASE DE DATOS.');</script>");

                limpiar();

            }



            idObtenidoPersona = Int32.Parse(idPersona);


            foreach (Persona item in listaPersona)
            {

                if (idObtenidoPersona == item.IdPersona)
                {

                    validarPersonaId = true;
                    break;


                }
                else
                {

                    validarPersonaId = false;


                }

            }



            if (validarPersonaId == false)
            {

                if (idObtenidoEmpresa != 0)
                {

                    Response.Write("<script>alert('El ID_PERSONA INGRESADO NO EXISTE EN LA BASE DE DATOS.');</script>");

                    limpiar();

                }

            }


            idObtenidoEmpresa = Int32.Parse(idEmpresa);

            foreach (Empresa item in listaEmpresa)
            {

                if (idObtenidoEmpresa == item.IdEmpresa)
                {

                    validarEmpresaId = true;
                    break;


                }
                else
                {

                    validarEmpresaId = false;


                }


            }


            if (validarEmpresaId == false)
            {


                if (idObtenidoEmpresa != 0)
                {

                    Response.Write("<script>alert('El ID_EMPRESA INGRESADO NO EXISTE EN LA BASE DE DATOS.');</script>");

                    limpiar();

                }

            }



            if (validarUser == false && validarEmpresaId == true)
            {

                Usuario usuario = new Usuario(nombreUsuario, contraseñaUsuario, 0, idObtenidoEmpresa); //Creamos el objeto comedor

                ControladorUsuario.insertarUsuario(usuario); //insertamos los datos en la BD.

                ControladorEmpresa.actualizarEmpresaXUsuario(nombreUsuario, contraseñaUsuario, idObtenidoEmpresa); //Actualizamos los datos ingresados en la Empresa

                Response.Write("<script>alert('DATOS INSERTADOS CON EXITO EN LA BASE DE DATOS. SE ACTUALIZA LOS ID CORRESPONDIENTES A LOS REGISTROS DE ALTAS.');</script>");

                limpiar();


            }
            else if (validarUser == false && validarPersonaId == true)
            {

                Usuario usuario = new Usuario(nombreUsuario, contraseñaUsuario, idObtenidoPersona, 0); //Creamos el objeto comedor

                ControladorUsuario.insertarUsuario(usuario); //insertamos los datos en la BD.

                ControladorPersona.actualizarPersonaXUsuario(nombreUsuario, contraseñaUsuario, idObtenidoPersona); //Actualizamos los datos ingresados en la Empresa

                Response.Write("<script>alert('DATOS INSERTADOS CON EXITO EN LA BASE DE DATOS. SE ACTUALIZA LOS ID CORRESPONDIENTES A LOS REGISTROS DE ALTAS.');</script>");

                limpiar();

            }
            else
            {

                Response.Write("<script>alert('ERROR. NO ES POSIBLE GESTIONAR LA CARGA DE LOS DATOS. VERIFICAR DATOS INGRESADOS');</script>");

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

            Usuario usuario = ControladorUsuario.buscarOneUsuario(id);

            if (usuario != null)
            {


                TextBox4.Text = usuario.NombreUsuario;
                TextBox6.Text = usuario.ContraseñaUsuario;
                TextBox2.Text = (usuario.IdPersona).ToString();
                TextBox3.Text = (usuario.IdEmpresa).ToString();



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


        List<Usuario> listaUsuario = ControladorUsuario.buscarAllUsuario();


        // Si la Pagina es Valida podemos Insertar los datos en la base:


        if (listaUsuario.Count > 0)
        {

            GrillaComedor.DataSource = listaUsuario; //Agregamos a la GridView la lista Obtenida.
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

            List<Usuario> listaUsuario = ControladorUsuario.buscarAllUsuario();

            bool validar = false;

            foreach (Usuario item in listaUsuario)
            {

                if (id == item.IdUsuario)
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
                ControladorUsuario.eliminarUsuario(id);

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
        nombreUsuario = TextBox4.Text;
        contraseñaUsuario = TextBox6.Text;
        idPersona = TextBox2.Text;
        idEmpresa = TextBox3.Text;


    }


    //Metodo Limpiar el formulario:
    protected void limpiar()
    {


        TextBox1.Text = "";
        TextBox4.Text = "";
        TextBox6.Text = "";
        TextBox2.Text = "";
        TextBox3.Text = "";




    }
}