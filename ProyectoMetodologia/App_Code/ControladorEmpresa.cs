using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Descripción breve de ControladorEmpresa
/// </summary>
public class ControladorEmpresa
{
    //Metodo para obtener la cantidad de registros de una Tabla:
    public static int cantidadRegistros()
    {

        int registros = 0;

        MySqlDataReader reader = null;

        MySqlCommand comando = null;

        MySqlConnection conexion = null;
        Conexion con = new Conexion();

        try
        {
            conexion = con.getConnection(); //metodo getConnection, logueamos el usuario.

            if (conexion != null)
            {

                string query = "SELECT COUNT(*) FROM empresa";

                conexion.Open();


                comando = new MySqlCommand(query, conexion); //Pasamos el query con el comando.



                reader = comando.ExecuteReader(); //Ejecutamos la CONSULTA de datos y guardamos los mismos en el objeto READER.

                if (reader.HasRows) //verificamos si existen filas.
                {

                    while (reader.Read())
                    {

                        registros = reader.GetInt32(0); //tambien se puede pasar como parametro el nombre de la columna ej ("idProducto")


                    }


                    Console.WriteLine("Registro leido con Exito de la Base de Datos.");
                    Console.WriteLine();

                }
                else
                {

                    Console.WriteLine("Error. No se encontraron Datos.");
                    Console.WriteLine();

                }

            }
            else
            {

                Console.WriteLine("Error. No fue posible leer el Registro de la Base de Datos");
                Console.WriteLine();

            }

        }
        catch (MySqlException ex)
        {

            Console.WriteLine("Error. " + ex.Message);
            Console.WriteLine();

        }
        finally
        {

            conexion.Close();

        }



        return registros;

    }

    //Metodo que permite Obtener e incremetar el ultimo valor de la taba ID:
    public static int ObtenerIdSiguienteEmpresa()
    {

        int idUltimo = 0, idSiguiente = 0;

        int numRegistros = 0;


        MySqlDataReader reader = null;

        MySqlCommand comando = null;

        MySqlConnection conexion = null;
        Conexion con = new Conexion();


        try
        {
            conexion = con.getConnection(); //metodo getConnection, logueamos el usuario.

            if (conexion != null)
            {

                numRegistros = ControladorEmpresa.cantidadRegistros(); //Obtenemos la cantidad de Registros

                string query = "SELECT MAX(idEmpresa) FROM empresa"; //Retorna el ultimo registro (Dato) de la columna seleccionada

                conexion.Open();

                comando = new MySqlCommand(query, conexion); //Pasamos el query con el comando.


                reader = comando.ExecuteReader(); //Ejecutamos la CONSULTA de datos y guardamos los mismos en el objeto READER.

                if (numRegistros > 0)
                {

                    if (reader.HasRows) //verificamos si existen filas.
                    {

                        while (reader.Read())
                        {

                            idUltimo = reader.GetInt32(0); //Guardamos en la variable el valor del ultimo idRegistrado


                        }


                        Console.WriteLine("Registro leido con Exito de la Base de Datos.");
                        Console.WriteLine();

                    }
                    else
                    {

                        Console.WriteLine("Error. No se encontraron Datos.");
                        Console.WriteLine();


                    }

                }
                else
                {

                    idUltimo = 0;
                }

            }
            else
            {

                Console.WriteLine("Error. No fue posible leer el Registro de la Base de Datos");
                Console.WriteLine();

            }





        }
        catch (MySqlException ex)
        {

            Console.WriteLine("Error. " + ex.Message);
            Console.WriteLine();

        }
        catch (Exception ex)
        {

            Console.WriteLine("Error. " + ex.Message);
            Console.WriteLine();
            idUltimo = 0;
        }
        finally
        {

            conexion.Close();

        }

        idSiguiente = idUltimo + 1; //Se incrementa en 1 el valor del ultimo idRegistrado Persona.

        return idSiguiente;

    }



    //METODO PARA INSERTAR DATOS INGRESADOS EN FORMULARIO DE CONTACTO:
    public static void insertarEmpresa(Empresa empresa)
    {

        MySqlCommand comando = null;

        MySqlConnection conexion = null;
        Conexion con = new Conexion();

        try
        {

            conexion = con.getConnection(); //metodo getConnection, logueamos el usuario.

            if (conexion != null)
            {

                string query = "INSERT INTO empresa (nombre, cuit, domicilio, usuario, contraseña) VALUES (@nombre, @cuit, @domicilio, @usuario, @contraseña)";

                conexion.Open();

                comando = new MySqlCommand(query, conexion); //Pasamos el query con el comando.

                comando.Parameters.AddWithValue("@nombre", empresa.Nombre);

                comando.Parameters.AddWithValue("@cuit", empresa.Cuit);

                comando.Parameters.AddWithValue("@domicilio", empresa.Domicilio);

                comando.Parameters.AddWithValue("@usuario", empresa.Usuario);

                comando.Parameters.AddWithValue("@contraseña", empresa.Contraseña);



                comando.ExecuteNonQuery(); //Ejecutamos la insercion a la base de datos.

                Console.WriteLine("Registro insertado con Exito a la Base de Datos.");
                Console.WriteLine();

            }
            else
            {

                Console.WriteLine("Error. No fue posible insertar el Registro a la Base de Datos");
                Console.WriteLine();

            }

        }
        catch (MySqlException ex)
        {

            Console.WriteLine("Error. " + ex.Message);
            Console.WriteLine();


        }
        finally
        {

            conexion.Close();


        }


    }


    public static Empresa buscarOneEmpresa(int dato)
    {
        Empresa empresa = null;

        MySqlDataReader reader = null;

        MySqlCommand comando = null;

        MySqlConnection conexion = null;
        Conexion con = new Conexion();

        try
        {
            conexion = con.getConnection(); //metodo getConnection, logueamos el usuario.

            if (conexion != null)
            {

                string query = "SELECT idEmpresa, nombre, cuit, domicilio, usuario, contraseña FROM empresa WHERE idEmpresa = @idEmpresa";

                conexion.Open();


                comando = new MySqlCommand(query, conexion); //Pasamos el query con el comando.


                comando.Parameters.AddWithValue("@idEmpresa", dato);


                reader = comando.ExecuteReader(); //Ejecutamos la CONSULTA de datos y guardamos los mismos en el objeto READER.

                if (reader.HasRows) //verificamos si existen filas.
                {

                    while (reader.Read())
                    {

                        int idEmpresa = reader.GetInt32(0); //tambien se puede pasar como parametro el nombre de la columna ej ("idProducto")
                        string nombre = reader.GetString(1);
                        string cuit = reader.GetString(2);
                        string domicilio = reader.GetString(3);
                        string usuario = reader.GetString(4);
                        string contraseña = reader.GetString(5);


                        empresa = new Empresa(idEmpresa, nombre, cuit, domicilio, usuario, contraseña); //Obtenemos todos los articulos pedidos asociados al comedor


                    }


                    Console.WriteLine("Registro leido con Exito de la Base de Datos.");
                    Console.WriteLine();

                }
                else
                {

                    Console.WriteLine("Error. No se encontraron Datos.");
                    Console.WriteLine();

                }

            }
            else
            {

                Console.WriteLine("Error. No fue posible leer el Registro de la Base de Datos");
                Console.WriteLine();

            }

        }
        catch (MySqlException ex)
        {

            Console.WriteLine("Error. " + ex.Message);
            Console.WriteLine();

        }
        finally
        {

            conexion.Close();

        }



        return empresa;

    }


    //Obtener la Empresa x el nombre del usuario:

    public static Empresa buscarOneEmpresaXusuario(string usuario1)
    {
        Empresa empresa = null;

        MySqlDataReader reader = null;

        MySqlCommand comando = null;

        MySqlConnection conexion = null;
        Conexion con = new Conexion();

        try
        {
            conexion = con.getConnection(); //metodo getConnection, logueamos el usuario.

            if (conexion != null)
            {

                string query = "SELECT idEmpresa, nombre, cuit, domicilio, usuario, contraseña FROM empresa WHERE usuario = @usuario";

                conexion.Open();


                comando = new MySqlCommand(query, conexion); //Pasamos el query con el comando.


                comando.Parameters.AddWithValue("@usuario", usuario1);


                reader = comando.ExecuteReader(); //Ejecutamos la CONSULTA de datos y guardamos los mismos en el objeto READER.

                if (reader.HasRows) //verificamos si existen filas.
                {

                    while (reader.Read())
                    {

                        int idEmpresa = reader.GetInt32(0); //tambien se puede pasar como parametro el nombre de la columna ej ("idProducto")
                        string nombre = reader.GetString(1);
                        string cuit = reader.GetString(2);
                        string domicilio = reader.GetString(3);
                        string usuario = reader.GetString(4);
                        string contraseña = reader.GetString(5);


                        empresa = new Empresa(idEmpresa, nombre, cuit, domicilio, usuario, contraseña); //Obtenemos todos los articulos pedidos asociados al comedor


                    }


                    Console.WriteLine("Registro leido con Exito de la Base de Datos.");
                    Console.WriteLine();

                }
                else
                {

                    Console.WriteLine("Error. No se encontraron Datos.");
                    Console.WriteLine();

                }

            }
            else
            {

                Console.WriteLine("Error. No fue posible leer el Registro de la Base de Datos");
                Console.WriteLine();

            }

        }
        catch (MySqlException ex)
        {

            Console.WriteLine("Error. " + ex.Message);
            Console.WriteLine();

        }
        finally
        {

            conexion.Close();

        }



        return empresa;

    }


    public static List<Empresa> buscarAllEmpresa()
    {

        Empresa empresa = null;

        List<Empresa> listaEmpresa = new List<Empresa>();

        MySqlDataReader reader = null;

        MySqlCommand comando = null;

        MySqlConnection conexion = null;
        Conexion con = new Conexion();


        try
        {
            conexion = con.getConnection(); //metodo getConnection, logueamos el usuario.

            if (conexion != null)
            {

                string query = "SELECT idEmpresa, nombre, cuit, domicilio, usuario, contraseña FROM empresa";

                conexion.Open();


                comando = new MySqlCommand(query, conexion); //Pasamos el query con el comando.


                reader = comando.ExecuteReader(); //Ejecutamos la CONSULTA de datos y guardamos los mismos en el objeto READER.

                if (reader.HasRows) //verificamos si existen filas.
                {

                    while (reader.Read())
                    {
                        int idEmpresa = reader.GetInt32(0); //tambien se puede pasar como parametro el nombre de la columna ej ("idProducto")
                        string nombre = reader.GetString(1);
                        string cuit = reader.GetString(2);
                        string domicilio = reader.GetString(3);
                        string usuario = reader.GetString(4);
                        string contraseña = reader.GetString(5);


                        empresa = new Empresa(idEmpresa, nombre, cuit, domicilio, usuario, contraseña); //Obtenemos todos los articulos pedidos asociados al comedor

                        listaEmpresa.Add(empresa); //Guardamos el Objeto en la lista

                       
                    }


                    Console.WriteLine("Registro leido con Exito de la Base de Datos.");
                    Console.WriteLine();

                }
                else
                {

                    Console.WriteLine("Error. No se encontraron Datos.");
                    Console.WriteLine();

                }

            }
            else
            {

                Console.WriteLine("Error. No fue posible leer el Registro de la Base de Datos");
                Console.WriteLine();

            }

        }
        catch (MySqlException ex)
        {

            Console.WriteLine("Error. " + ex.Message);
            Console.WriteLine();

        }
        finally
        {

            conexion.Close();

        }



        return listaEmpresa;
    }


    public static void actualizarEmpresa(string nombre, string cuit, string domicilio, string usuario, string contraseña, int idBusqueda)
    {


        MySqlCommand comando = null;

        MySqlConnection conexion = null;
        Conexion con = new Conexion();

        try
        {

            conexion = con.getConnection(); //metodo getConnection, logueamos el usuario.

            if (conexion != null)
            {

                string query = "UPDATE empresa SET nombre = @nombre, cuit = @cuit, domicilio = @domicilio, usuario = @usuario, contraseña = @contraseña WHERE idEmpresa = @idEmpresa";

                conexion.Open();

                comando = new MySqlCommand(query, conexion); //Pasamos el query con el comando.

                comando.Parameters.AddWithValue("@nombre", nombre);

                comando.Parameters.AddWithValue("@cuit", cuit);

                comando.Parameters.AddWithValue("@domicilio", domicilio);

                comando.Parameters.AddWithValue("@usuario", usuario);

                comando.Parameters.AddWithValue("@contraseña", contraseña);

                comando.Parameters.AddWithValue("@idEmpresa", idBusqueda);

                comando.ExecuteNonQuery(); //Ejecutamos la insercion a la base de datos.

                Console.WriteLine("Registro actualizado con Exito a la Base de Datos.");
                Console.WriteLine();

            }
            else
            {

                Console.WriteLine("Error. No fue posible actualizar el Registro a la Base de Datos");
                Console.WriteLine();

            }

        }
        catch (MySqlException ex)
        {

            Console.WriteLine("Error. " + ex.Message);
            Console.WriteLine();


        }
        finally
        {

            conexion.Close();


        }



    }


    public static void actualizarEmpresaXUsuario(string usuario, string contraseña, int idBusqueda)
    {


        MySqlCommand comando = null;

        MySqlConnection conexion = null;
        Conexion con = new Conexion();

        try
        {

            conexion = con.getConnection(); //metodo getConnection, logueamos el usuario.

            if (conexion != null)
            {

                string query = "UPDATE empresa SET usuario = @usuario, contraseña = @contraseña WHERE idEmpresa = @idEmpresa";

                conexion.Open();

                comando = new MySqlCommand(query, conexion); //Pasamos el query con el comando.


                comando.Parameters.AddWithValue("@usuario", usuario);

                comando.Parameters.AddWithValue("@contraseña", contraseña);

                comando.Parameters.AddWithValue("@idEmpresa", idBusqueda);

                comando.ExecuteNonQuery(); //Ejecutamos la insercion a la base de datos.

                Console.WriteLine("Registro actualizado con Exito a la Base de Datos.");
                Console.WriteLine();

            }
            else
            {

                Console.WriteLine("Error. No fue posible actualizar el Registro a la Base de Datos");
                Console.WriteLine();

            }

        }
        catch (MySqlException ex)
        {

            Console.WriteLine("Error. " + ex.Message);
            Console.WriteLine();


        }
        finally
        {

            conexion.Close();


        }



    }

    public static void eliminarEmpresa(int nroId)
    {

        MySqlCommand comando = null;

        MySqlConnection conexion = null;
        Conexion con = new Conexion();

        try
        {

            conexion = con.getConnection(); //metodo getConnection, logueamos el usuario.

            if (conexion != null)
            {

                string query = "DELETE FROM empresa WHERE idEmpresa = @idEmpresa";

                conexion.Open();

                comando = new MySqlCommand(query, conexion); //Pasamos el query con el comando.

                comando.Parameters.AddWithValue("@idEmpresa", nroId);

                comando.ExecuteNonQuery(); //Ejecutamos la insercion a la base de datos.

                Console.WriteLine("Registro eliminado con Exito a la Base de Datos.");
                Console.WriteLine();

            }
            else
            {

                Console.WriteLine("Error. No fue posible eliminar el Registro a la Base de Datos");
                Console.WriteLine();

            }

        }
        catch (MySqlException ex)
        {

            Console.WriteLine("Error. " + ex.Message);
            Console.WriteLine();


        }
        finally
        {

            conexion.Close();


        }

    }

}