using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Formulario_CrearUsuario : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }


    protected void eventoRegistrarPersona(object sender, EventArgs e)
    {

        Response.Redirect("RegistroPersona.aspx");

    }

    protected void eventoRegistrarEmpresa(object sender, EventArgs e)
    {

        Response.Redirect("RegistroEmpresa.aspx");

    }
}