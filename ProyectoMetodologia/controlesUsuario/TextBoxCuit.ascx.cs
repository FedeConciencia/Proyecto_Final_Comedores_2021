using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class controlesUsuario_TextBoxCuit : System.Web.UI.UserControl
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }


    //Metodo Getters para acceder al valor del componente de usuario (Control de Usuario):

    public string getCuit()
    {

        return TextBox1.Text;

    }


    //Metodo Setters para modificar el valor del componente de usuario (Control de Usuario):

    public void setCuit(string valor)
    {

        TextBox1.Text = valor;

    }
}