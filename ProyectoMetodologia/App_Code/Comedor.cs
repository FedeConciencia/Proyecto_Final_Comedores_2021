using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Descripción breve de Comedor
/// </summary>
public class Comedor
{

    private int idComedor;
    private string nombre;
    private string cuit;
    private string domicilio;
 

    private List<ArticuloPedido> listaArticuloPedido;

    public Comedor()
    {


    }

    public Comedor(int idComedor, string nombre, string cuit, string domicilio)
    {
        this.idComedor = idComedor;
        this.nombre = nombre;
        this.cuit = cuit;
        this.domicilio = domicilio;
    }

    public Comedor(int idComedor, string nombre, string cuit, string domicilio, List<ArticuloPedido> listaArticuloPedido)
    {
        this.idComedor = idComedor;
        this.nombre = nombre;
        this.cuit = cuit;
        this.domicilio = domicilio;
        this.listaArticuloPedido = listaArticuloPedido;
    }

    public Comedor(string nombre, string cuit, string domicilio)
    {
        this.nombre = nombre;
        this.cuit = cuit;
        this.domicilio = domicilio;
    }

    public int IdComedor
    {
        get
        {
            return idComedor;
        }

        set
        {
            idComedor = value;
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


    public List<ArticuloPedido> ListaArticuloPedido
    {
        get
        {
            return listaArticuloPedido;
        }

        set
        {
            listaArticuloPedido = value;
        }
    }
}