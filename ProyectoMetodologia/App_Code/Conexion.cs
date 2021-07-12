using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Descripción breve de Conexion
/// </summary>
public class Conexion
{

    public String cadenaConexion = "server = localhost" + "; port = 3306" + "; user id = root" + "; password = 12345" + "; database = proyecto_comedores";

    //Metodo para gestionar conexion con la Base de Datos, Importante agregar Referencia Libreria MySql.data:
    public MySqlConnection getConnection()
    {

        MySqlConnection conexion = null;


        try
        {

            conexion = new MySqlConnection(cadenaConexion);

            Console.WriteLine("Conexion Exitosa con la Base de Datos.");

            return conexion;

        }
        catch (MySqlException ex)
        {

            Console.WriteLine("Error. " + ex.Message);

            return null;

        }


    }



}