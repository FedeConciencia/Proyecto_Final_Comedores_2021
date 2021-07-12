using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Descripción breve de Persona
/// </summary>
public class Persona
{

    private int idPersona;
    private string nombre;
    private string apellido;
    private string dni;
    private string usuario;
    private string contraseña;

    private List<ArticuloDonadoPersona> listaArticuloDonado;

    public int IdPersona
    {
        get
        {
            return idPersona;
        }

        set
        {
            idPersona = value;
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

    public string Dni
    {
        get
        {
            return dni;
        }

        set
        {
            dni = value;
        }
    }

    public string Usuario
    {
        get
        {
            return usuario;
        }

        set
        {
            usuario = value;
        }
    }

    public string Contraseña
    {
        get
        {
            return contraseña;
        }

        set
        {
            contraseña = value;
        }
    }

    public List<ArticuloDonadoPersona> ListaArticuloDonado
    {
        get
        {
            return listaArticuloDonado;
        }

        set
        {
            listaArticuloDonado = value;
        }
    }

    public Persona()
    {
    }

    public Persona(int idPersona, string nombre, string apellido, string dni, string usuario, string contraseña)
    {
        this.idPersona = idPersona;
        this.nombre = nombre;
        this.apellido = apellido;
        this.dni = dni;
        this.usuario = usuario;
        this.contraseña = contraseña;
    }

    public Persona(string nombre, string apellido, string dni, string usuario, string contraseña)
    {
        this.nombre = nombre;
        this.apellido = apellido;
        this.dni = dni;
        this.usuario = usuario;
        this.contraseña = contraseña;
    }

    public Persona(int idPersona, string nombre, string apellido, string dni, string usuario, string contraseña, List<ArticuloDonadoPersona> listaArticuloDonado) : this(idPersona, nombre, apellido, dni, usuario, contraseña)
    {
        this.listaArticuloDonado = listaArticuloDonado;
    }

    public Persona(string nombre, string apellido, string dni)
    {
        this.nombre = nombre;
        this.apellido = apellido;
        this.dni = dni;
    }
}