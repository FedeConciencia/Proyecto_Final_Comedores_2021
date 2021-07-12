using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Descripción breve de Usuario
/// </summary>
public class Usuario
{

    private int idUsuario;
    private string nombreUsuario;
    private string contraseñaUsuario;
    private int idPersona;
    private int idEmpresa;

    public Usuario()
    {
    }

    public Usuario(int idUsuario, string nombreUsuario, string contraseñaUsuario, int idPersona, int idEmpresa)
    {
        this.idUsuario = idUsuario;
        this.nombreUsuario = nombreUsuario;
        this.contraseñaUsuario = contraseñaUsuario;
        this.idPersona = idPersona;
        this.idEmpresa = idEmpresa;
    }

    public Usuario(string nombreUsuario, string contraseñaUsuario, int idPersona, int idEmpresa)
    {
        this.nombreUsuario = nombreUsuario;
        this.contraseñaUsuario = contraseñaUsuario;
        this.idPersona = idPersona;
        this.idEmpresa = idEmpresa;
    }

    public int IdUsuario
    {
        get
        {
            return idUsuario;
        }

        set
        {
            idUsuario = value;
        }
    }

    public string NombreUsuario
    {
        get
        {
            return nombreUsuario;
        }

        set
        {
            nombreUsuario = value;
        }
    }

    public string ContraseñaUsuario
    {
        get
        {
            return contraseñaUsuario;
        }

        set
        {
            contraseñaUsuario = value;
        }
    }

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

    public int IdEmpresa
    {
        get
        {
            return idEmpresa;
        }

        set
        {
            idEmpresa = value;
        }
    }
}