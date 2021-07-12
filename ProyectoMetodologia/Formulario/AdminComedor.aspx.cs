using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Formulario_AdminComedor : System.Web.UI.Page
{

    string idBusqueda = "", nombre = "", cuit = "", domicilio = "";


    protected void Page_Load(object sender, EventArgs e)
    {






    }

    //Validacion Personalizada ingreso de CUIT unico:

    protected void validarCuitUnico(object source, ServerValidateEventArgs args)
    {

        //Validamos si el dato string ingresado contiene caracteres numericos:

        bool validar = false;

        obtener();

        List<Comedor> listaComedor = ControladorComedor.buscarAllComedor();

        foreach(Comedor item in listaComedor)
        {

            if(cuit.Equals(item.Cuit))
            {

                validar = true; //Encuentra 2 cuit iguales
                break;


            }
            else
            {

                validar = false;
                

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

        // Si la Pagina es Valida podemos Actualizar los datos en la base:

        if (Page.IsValid == true)
        {


            List<Comedor> listaComedor = ControladorComedor.buscarAllComedor();

            obtener();

            int id = Int32.Parse(idBusqueda);

            bool validar = false;

            foreach (Comedor item in listaComedor)
            {

                if (id == item.IdComedor)
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
                ControladorComedor.actualizarComedor(nombre, cuit, domicilio, id);

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

        List<Comedor> listaComedor = ControladorComedor.buscarAllComedor();

        bool validar = false;

        // Si la Pagina es Valida podemos Insertar los datos en la base:

        if (Page.IsValid == true)
        {
            obtener();

            foreach (Comedor item in listaComedor)
            {

                if (cuit.Equals(item.Cuit))
                {

                    validar = true; //Encuentra 2 cuit iguales
                    break;


                }
                else
                {

                    validar = false;


                }



            }

            if (validar == false)
            {

                Comedor comedor = new Comedor(nombre, cuit, domicilio); //Creamos el objeto comedor

                ControladorComedor.insertarComedor(comedor); //insertamos los datos en la BD.

                Response.Write("<script>alert('DATOS INSERTADOS CON EXITO EN LA BASE DE DATOS');</script>");


                limpiar();

            }
            else
            {

                Response.Write("<script>alert('ERROR. CUIT INGRESADO YA SE ENCUENTRA EN LA BASE DE DATOS.');</script>");


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

            Comedor comedor = ControladorComedor.buscarOneComedor(id);

            if (comedor != null)
            {

                TextBox2.Text = comedor.Nombre;
                TextBox3.Text = comedor.Cuit;
                TextBox4.Text = comedor.Domicilio;



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


        List<Comedor> listaComedor = ControladorComedor.buscarAllComedor();


        // Si la Pagina es Valida podemos Insertar los datos en la base:


        if (listaComedor.Count > 0)
        {

            GrillaComedor.DataSource = listaComedor; //Agregamos a la GridView la lista Obtenida.
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

            List<Comedor> listaComedor = ControladorComedor.buscarAllComedor();

            bool validar = false;

            foreach (Comedor item in listaComedor)
            {

                if (id == item.IdComedor)
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
                ControladorComedor.eliminarComedor(id);

                ControladorArticuloPedido.eliminarArticuloPedidoXIdComedor(id); //Eliminamos Todos los Articulos Asociados al Comedor.

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
        cuit = TextBox3.Text;
        domicilio = TextBox4.Text;



    }


    //Metodo Limpiar el formulario:
    protected void limpiar()
    {


        TextBox1.Text = "";
        TextBox2.Text = "";
        TextBox3.Text = "";
        TextBox4.Text = "";



    }






}


