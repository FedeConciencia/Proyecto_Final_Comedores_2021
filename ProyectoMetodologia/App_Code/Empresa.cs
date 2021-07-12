using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Descripción breve de Empresa
/// </summary>
public class Empresa
{


    private int idEmpresa;
    private string nombre;
    private string cuit;
    private string domicilio;
    private string usuario;
    private string contraseña;


    private List<ArticuloDonadoEmpresa> listaArticuloDonado;

    public Empresa()
    {
    }

    public Empresa(string nombre, string cuit, string domicilio, string usuario, string contraseña)
    {
        this.nombre = nombre;
        this.cuit = cuit;
        this.domicilio = domicilio;
        this.usuario = usuario;
        this.contraseña = contraseña;
    }

    public Empresa(int idEmpresa, string nombre, string cuit, string domicilio, string usuario, string contraseña, List<ArticuloDonadoEmpresa> listaArticuloDonado)
    {
        this.idEmpresa = idEmpresa;
        this.nombre = nombre;
        this.cuit = cuit;
        this.domicilio = domicilio;
        this.usuario = usuario;
        this.contraseña = contraseña;
        this.listaArticuloDonado = listaArticuloDonado;
    }

    public Empresa(string nombre, string cuit, string domicilio, string usuario, string contraseña, List<ArticuloDonadoEmpresa> listaArticuloDonado)
    {
        this.nombre = nombre;
        this.cuit = cuit;
        this.domicilio = domicilio;
        this.usuario = usuario;
        this.contraseña = contraseña;
        this.listaArticuloDonado = listaArticuloDonado;
    }

    public Empresa(int idEmpresa, string nombre, string cuit, string domicilio, string usuario, string contraseña)
    {
        this.idEmpresa = idEmpresa;
        this.nombre = nombre;
        this.cuit = cuit;
        this.domicilio = domicilio;
        this.usuario = usuario;
        this.contraseña = contraseña;
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

    public string Cuit
    {
        get
        {
            return cuit;
        }

        set
        {
            cuit = value;
        }
    }

    public string Domicilio
    {
        get
        {
            return domicilio;
        }

        set
        {
            domicilio = value;
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

    public List<ArticuloDonadoEmpresa> ListaArticuloDonado
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



}