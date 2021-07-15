using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Formulario_Contacto : System.Web.UI.Page
{

    //Variables o campos de clase:

    string idContacto = "", nombre = "", apellido = "", email = "", confirmarEmail = "", telefono = "", comentario = "";

    protected void Page_Load(object sender, EventArgs e)
    {

    }


    //Metodo Evento Boton Enviar:

    protected void eventoEnviar(object sender, EventArgs e)
    {


        // Si la Pagina es Valida podemos Insertar los datos en la base:

        if (Page.IsValid)
        {

            obtenerDatos();

            Contacto contacto = new Contacto(nombre, apellido, email, confirmarEmail, telefono, comentario);

            ControladorContacto.insertarContacto(contacto); // Inserta los datos ingresados en el formulario

            enviarMail(email, comentario, telefono, nombre, apellido); //Envia el mail con todos los datos de contacto

            Response.Write("<script>alert('FORMULARIO CONTACTO ENVIADO CON EXITO.');</script>");

            limpiar();

        }
        




    }


    //Metodo para Obtener los datos ingresados en el Formulario:
    protected void obtenerDatos()
    {


        nombre = TextBox3.Text;
        apellido = TextBox4.Text;
        email = TextBox2.Text;
        confirmarEmail = TextBox1.Text;
        telefono = TextBox5.Text;
        comentario = TextBox6.Text;



    }

    //Metodo Limpiar los datos Ingresados:
    protected void limpiar()
    {

        TextBox3.Text = "";
        TextBox4.Text = "";
        TextBox2.Text = "";
        TextBox1.Text = "";
        TextBox5.Text = "";
        TextBox6.Text = "";




    }

    //Metodo para enviar mail:

    protected void enviarMail(string emailEnvio, string comentario, string telefono, string nombre, string apellido)
    {

        try
        {

            SmtpClient smtp = new SmtpClient();
            smtp.Host = "smtp.gmail.com";
            smtp.Port = 587;
            smtp.EnableSsl = true;
            smtp.DeliveryMethod = SmtpDeliveryMethod.Network;
            smtp.UseDefaultCredentials = false;
            smtp.Credentials = new NetworkCredential("martinargumedo2017@gmail.com", "yaqoorqwuwundifi");

            MailAddress frontEmail = new MailAddress("martinargumedo2017@gmail.com", "FORMULARIO CONTACTO WEB");
            MailAddress toEmail = new MailAddress("martinargumedo2017@gmail.com");
            MailMessage mail = new MailMessage();
            mail.From = frontEmail;
            mail.To.Add(toEmail);

            mail.Subject = "Mensaje del Formulario Web Comedores Solidarios";
            mail.Body += "Subject: " + nombre + " " + apellido + "\n";
            mail.Body += "Email: " + emailEnvio + "\n";
            mail.Body += "Movil: " + telefono + "\n";
            mail.Body += "Consulta: " + comentario + "\n";


            smtp.Send(mail);

        }catch(Exception ex)
        {

            Console.WriteLine("Error" + ex.Message);
            Console.WriteLine();

        }


    }


}