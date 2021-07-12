using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Descripción breve de ArticuloDonadoPersona
/// </summary>
public class ArticuloDonadoPersona
{

    private int idArticuloDonadoPersona;
    private string nombre;
    private string codigo;
    private int cantidad;
    private int idPersona;
    private int idArticuloPedido;

    public int IdArticuloDonadoPersona
    {
        get
        {
            return idArticuloDonadoPersona;
        }

        set
        {
            idArticuloDonadoPersona = value;
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

    public string Codigo
    {
        get
        {
            return codigo;
        }

        set
        {
            codigo = value;
        }
    }

    public int Cantidad
    {
        get
        {
            return cantidad;
        }

        set
        {
            cantidad = value;
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

    public int IdArticuloPedido
    {
        get
        {
            return idArticuloPedido;
        }

        set
        {
            idArticuloPedido = value;
        }
    }

    public ArticuloDonadoPersona()
    {
    }

    public ArticuloDonadoPersona(int idArticuloDonadoPersona, string nombre, string codigo, int cantidad, int idPersona, int idArticuloPedido)
    {
        this.idArticuloDonadoPersona = idArticuloDonadoPersona;
        this.nombre = nombre;
        this.codigo = codigo;
        this.cantidad = cantidad;
        this.idPersona = idPersona;
        this.idArticuloPedido = idArticuloPedido;
    }

    public ArticuloDonadoPersona(string nombre, string codigo, int cantidad, int idPersona, int idArticuloPedido)
    {
        this.nombre = nombre;
        this.codigo = codigo;
        this.cantidad = cantidad;
        this.idPersona = idPersona;
        this.idArticuloPedido = idArticuloPedido;
    }
}