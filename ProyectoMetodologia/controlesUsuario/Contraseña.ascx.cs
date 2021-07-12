using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class controlesUsuario_WebUserControl : System.Web.UI.UserControl
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }

    public string getContraseña()
    {

        return TextBox1.Text;
    }

    public void setContraseña(string valor)
    {

        TextBox1.Text = valor;

    }


}