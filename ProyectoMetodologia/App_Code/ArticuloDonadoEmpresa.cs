using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Descripción breve de ArticuloDonadoEmpresa
/// </summary>
public class ArticuloDonadoEmpresa
{

    private int idArticuloDonadoEmpresa;
    private string nombre;
    private string codigo;
    private int cantidad;
    private int idEmpresa;
    private int idArticuloPedido;

    public int IdArticuloDonadoEmpresa
    {
        get
        {
            return idArticuloDonadoEmpresa;
        }

        set
        {
            idArticuloDonadoEmpresa = value;
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

    public ArticuloDonadoEmpresa()
    {
    }

    public ArticuloDonadoEmpresa(int idArticuloDonadoEmpresa, string nombre, string codigo, int cantidad, int idEmpresa, int idArticuloPedido)
    {
        this.idArticuloDonadoEmpresa = idArticuloDonadoEmpresa;
        this.nombre = nombre;
        this.codigo = codigo;
        this.cantidad = cantidad;
        this.idEmpresa = idEmpresa;
        this.idArticuloPedido = idArticuloPedido;
    }

    public ArticuloDonadoEmpresa(string nombre, string codigo, int cantidad, int idEmpresa, int idArticuloPedido)
    {
        this.nombre = nombre;
        this.codigo = codigo;
        this.cantidad = cantidad;
        this.idEmpresa = idEmpresa;
        this.idArticuloPedido = idArticuloPedido;
    }


}
