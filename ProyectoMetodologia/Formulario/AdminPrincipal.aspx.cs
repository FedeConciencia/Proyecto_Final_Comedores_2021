using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Formulario_AdminPrincipal : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }

    protected void eventoBotonComedor(object sender, EventArgs e)
    {


        // Si la Pagina es Valida podemos Insertar los datos en la base:

        if (Page.IsValid)
        {


            Response.Redirect("AdminComedor.aspx");  //Al presionar el Boton direcciona a la pagina de administrador de Comedores
            

        }
        else
        {

            
        }




    }


    protected void eventoBotonPersona(object sender, EventArgs e)
    {


        // Si la Pagina es Valida podemos Insertar los datos en la base:

        if (Page.IsValid)
        {


            Response.Redirect("AdminPersona.aspx");  //Al presionar el Boton direcciona a la pagina de administrador de Comedores


        }
        else
        {


        }




    }

    protected void eventoBotonEmpresa(object sender, EventArgs e)
    {


        // Si la Pagina es Valida podemos Insertar los datos en la base:

        if (Page.IsValid)
        {


            Response.Redirect("AdminEmpresa.aspx");  //Al presionar el Boton direcciona a la pagina de administrador de Comedores


        }
        else
        {


        }




    }

    protected void eventoBotonUsuario(object sender, EventArgs e)
    {


        // Si la Pagina es Valida podemos Insertar los datos en la base:

        if (Page.IsValid)
        {


            Response.Redirect("AdminUsuario.aspx");  //Al presionar el Boton direcciona a la pagina de administrador de Comedores


        }
        else
        {


        }




    }


    protected void eventoBotonArticuloPedido(object sender, EventArgs e)
    {


        // Si la Pagina es Valida podemos Insertar los datos en la base:

        if (Page.IsValid)
        {


            Response.Redirect("AdminPedido.aspx");  //Al presionar el Boton direcciona a la pagina de administrador de Comedores


        }
        else
        {


        }




    }



    protected void eventoBotonDonadoEmpresa(object sender, EventArgs e)
    {


        // Si la Pagina es Valida podemos Insertar los datos en la base:

        if (Page.IsValid)
        {


            Response.Redirect("AdminDonadoEmpresa.aspx");  //Al presionar el Boton direcciona a la pagina de administrador de Comedores


        }
        else
        {


        }




    }


    protected void eventoBotonDonadoPersona(object sender, EventArgs e)
    {


        // Si la Pagina es Valida podemos Insertar los datos en la base:

        if (Page.IsValid)
        {


            Response.Redirect("AdminDonadoPersona.aspx");  //Al presionar el Boton direcciona a la pagina de administrador de Comedores


        }
        else
        {


        }




    }



    protected void eventoBotonContacto(object sender, EventArgs e)
    {


        // Si la Pagina es Valida podemos Insertar los datos en la base:

        if (Page.IsValid)
        {


            Response.Redirect("AdminContacto.aspx");  //Al presionar el Boton direcciona a la pagina de administrador de Comedores


        }
        else
        {


        }




    }





}