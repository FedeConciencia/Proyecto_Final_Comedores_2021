using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Descripción breve de Contacto
/// </summary>
public class Contacto
{

    private int idContacto;
    private string nombre;
    private string apellido;
    private string email;
    private string confirmarEmail;
    private string telefono;
    private string comentario;

    public Contacto()
    {
    }

    public Contacto(int idContacto, string nombre, string apellido, string email, string confirmarEmail, string telefono, string comentario)
    {
        this.idContacto = idContacto;
        this.nombre = nombre;
        this.apellido = apellido;
        this.email = email;
        this.confirmarEmail = confirmarEmail;
        this.telefono = telefono;
        this.comentario = comentario;
    }

    public Contacto(string nombre, string apellido, string email, string confirmarEmail, string telefono, string comentario)
    {
        this.nombre = nombre;
        this.apellido = apellido;
        this.email = email;
        this.confirmarEmail = confirmarEmail;
        this.telefono = telefono;
        this.comentario = comentario;
    }

    public int IdContacto
    {
        get
        {
            return idContacto;
        }

        set
        {
            idContacto = value;
        }
    }

    public string Nombre
    {
        get
        {
            return nombre;
        }

        set
        {
            nombre = value;
        }
    }

    public string Apellido
    {
        get
        {
            return apellido;
        }

        set
        {
            apellido = value;
        }
    }

    public string Email
    {
        get
        {
            return email;
        }

        set
        {
            email = value;
        }
    }

    public string ConfirmarEmail
    {
        get
        {
            return confirmarEmail;
        }

        set
        {
            confirmarEmail = value;
        }
    }

    public string Telefono
    {
        get
        {
            return telefono;
        }

        set
        {
            telefono = value;
        }
    }

    public string Comentario
    {
        get
        {
            return comentario;
        }

        set
        {
            comentario = value;
        }
    }
}