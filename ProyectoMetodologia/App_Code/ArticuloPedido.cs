using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Descripción breve de ArticuloPedido
/// </summary>
public class ArticuloPedido
{

    private int idArticuloPedido;
    private string nombre;
    private string codigo;
    private int cantidad;
    private int idComedor;

    public ArticuloPedido()
    {
    }

    public ArticuloPedido(int idArticuloPedido, string nombre, string codigo, int cantidad, int idComedor)
    {
        this.idArticuloPedido = idArticuloPedido;
        this.nombre = nombre;
        this.codigo = codigo;
        this.cantidad = cantidad;
        this.idComedor = idComedor;
    }

    public ArticuloPedido(string nombre, string codigo, int cantidad, int idComedor)
    {
        this.nombre = nombre;
        this.codigo = codigo;
        this.cantidad = cantidad;
        this.idComedor = idComedor;
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
}