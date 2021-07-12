using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Descripción breve de ControladorPersona
/// </summary>
public class ControladorPersona
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

                string query = "SELECT COUNT(*) FROM persona";

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
    public static int ObtenerIdSiguientePersona()
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

                numRegistros = ControladorPersona.cantidadRegistros(); //Obtenemos la cantidad de Registros

                string query = "SELECT MAX(idPersona) FROM persona"; //Retorna el ultimo registro (Dato) de la columna seleccionada

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
    public static void insertarPersona(Persona persona)
    {

        MySqlCommand comando = null;

        MySqlConnection conexion = null;
        Conexion con = new Conexion();

        try
        {

            conexion = con.getConnection(); //metodo getConnection, logueamos el usuario.

            if (conexion != null)
            {

                string query = "INSERT INTO persona (nombre, apellido, dni, usuario, contraseña) VALUES (@nombre, @apellido, @dni, @usuario, @contraseña)";

                conexion.Open();

                comando = new MySqlCommand(query, conexion); //Pasamos el query con el comando.

                comando.Parameters.AddWithValue("@nombre", persona.Nombre);

                comando.Parameters.AddWithValue("@apellido", persona.Apellido);

                comando.Parameters.AddWithValue("@dni", persona.Dni);

                comando.Parameters.AddWithValue("@usuario", persona.Usuario);

                comando.Parameters.AddWithValue("@contraseña", persona.Contraseña);



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


    public static Persona buscarOnePersona(int dato)
    {
        Persona persona = null;

        MySqlDataReader reader = null;

        MySqlCommand comando = null;

        MySqlConnection conexion = null;
        Conexion con = new Conexion();

        try
        {
            conexion = con.getConnection(); //metodo getConnection, logueamos el usuario.

            if (conexion != null)
            {

                string query = "SELECT idPersona, nombre, apellido, dni, usuario, contraseña FROM persona WHERE idPersona = @idPersona";

                conexion.Open();


                comando = new MySqlCommand(query, conexion); //Pasamos el query con el comando.


                comando.Parameters.AddWithValue("@idPersona", dato);


                reader = comando.ExecuteReader(); //Ejecutamos la CONSULTA de datos y guardamos los mismos en el objeto READER.

                if (reader.HasRows) //verificamos si existen filas.
                {

                    while (reader.Read())
                    {

                        int idPersona = reader.GetInt32(0); //tambien se puede pasar como parametro el nombre de la columna ej ("idProducto")
                        string nombre = reader.GetString(1);
                        string apellido = reader.GetString(2);
                        string dni = reader.GetString(3);
                        string usuario = reader.GetString(4);
                        string contraseña = reader.GetString(5);


                        persona = new Persona(idPersona, nombre, apellido, dni, usuario, contraseña); //Obtenemos todos los articulos pedidos asociados al comedor


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



        return persona;

    }



    //Buscar una Persona X el numero del Usuario:

    public static Persona buscarOnePersonaXUsuario(string usuario1)
    {
        Persona persona = null;

        MySqlDataReader reader = null;

        MySqlCommand comando = null;

        MySqlConnection conexion = null;
        Conexion con = new Conexion();

        try
        {
            conexion = con.getConnection(); //metodo getConnection, logueamos el usuario.

            if (conexion != null)
            {

                string query = "SELECT idPersona, nombre, apellido, dni, usuario, contraseña FROM persona WHERE usuario = @usuario";

                conexion.Open();


                comando = new MySqlCommand(query, conexion); //Pasamos el query con el comando.


                comando.Parameters.AddWithValue("@usuario", usuario1);


                reader = comando.ExecuteReader(); //Ejecutamos la CONSULTA de datos y guardamos los mismos en el objeto READER.

                if (reader.HasRows) //verificamos si existen filas.
                {

                    while (reader.Read())
                    {

                        int idPersona = reader.GetInt32(0); //tambien se puede pasar como parametro el nombre de la columna ej ("idProducto")
                        string nombre = reader.GetString(1);
                        string apellido = reader.GetString(2);
                        string dni = reader.GetString(3);
                        string usuario = reader.GetString(4);
                        string contraseña = reader.GetString(5);


                        persona = new Persona(idPersona, nombre, apellido, dni, usuario, contraseña); //Obtenemos todos los articulos pedidos asociados al comedor


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



        return persona;

    }


    public static List<Persona> buscarAllPersona()
    {

        Persona persona = null;

        List<Persona> listaPersona = new List<Persona>();

        MySqlDataReader reader = null;

        MySqlCommand comando = null;

        MySqlConnection conexion = null;
        Conexion con = new Conexion();


        try
        {
            conexion = con.getConnection(); //metodo getConnection, logueamos el usuario.

            if (conexion != null)
            {

                string query = "SELECT idPersona, nombre, apellido, dni, usuario, contraseña FROM persona";

                conexion.Open();


                comando = new MySqlCommand(query, conexion); //Pasamos el query con el comando.


                reader = comando.ExecuteReader(); //Ejecutamos la CONSULTA de datos y guardamos los mismos en el objeto READER.

                if (reader.HasRows) //verificamos si existen filas.
                {

                    while (reader.Read())
                    {
                        int idPersona = reader.GetInt32(0); //tambien se puede pasar como parametro el nombre de la columna ej ("idProducto")
                        string nombre = reader.GetString(1);
                        string apellido = reader.GetString(2);
                        string dni = reader.GetString(3);
                        string usuario = reader.GetString(4);
                        string contraseña = reader.GetString(5);


                        persona = new Persona(idPersona, nombre, apellido, dni, usuario, contraseña); //Obtenemos todos los articulos pedidos asociados al comedor

                        listaPersona.Add(persona); //Guardamos el Objeto en la lista


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



        return listaPersona;
    }


    public static void actualizarPersona(string nombre, string apellido, string dni, string usuario, string contraseña, int idBusqueda)
    {


        MySqlCommand comando = null;

        MySqlConnection conexion = null;
        Conexion con = new Conexion();

        try
        {

            conexion = con.getConnection(); //metodo getConnection, logueamos el usuario.

            if (conexion != null)
            {

                string query = "UPDATE persona SET nombre = @nombre, apellido = @apellido, dni = @dni, usuario = @usuario, contraseña = @contraseña WHERE idPersona = @idPersona";

                conexion.Open();

                comando = new MySqlCommand(query, conexion); //Pasamos el query con el comando.

                comando.Parameters.AddWithValue("@nombre", nombre);

                comando.Parameters.AddWithValue("@apellido", apellido);

                comando.Parameters.AddWithValue("@dni", dni);

                comando.Parameters.AddWithValue("@usuario", usuario);

                comando.Parameters.AddWithValue("@contraseña", contraseña);

                comando.Parameters.AddWithValue("@idPersona", idBusqueda);

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



    //Actualizar Persona x idUsuario:

    public static void actualizarPersonaXUsuario(string usuario, string contraseña, int idBusqueda)
    {


        MySqlCommand comando = null;

        MySqlConnection conexion = null;
        Conexion con = new Conexion();

        try
        {

            conexion = con.getConnection(); //metodo getConnection, logueamos el usuario.

            if (conexion != null)
            {

                string query = "UPDATE persona SET usuario = @usuario, contraseña = @contraseña WHERE idPersona = @idPersona";

                conexion.Open();

                comando = new MySqlCommand(query, conexion); //Pasamos el query con el comando.

                comando.Parameters.AddWithValue("@usuario", usuario);

                comando.Parameters.AddWithValue("@contraseña", contraseña);

                comando.Parameters.AddWithValue("@idPersona", idBusqueda);

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

    public static void eliminarPersona(int nroId)
    {

        MySqlCommand comando = null;

        MySqlConnection conexion = null;
        Conexion con = new Conexion();

        try
        {

            conexion = con.getConnection(); //metodo getConnection, logueamos el usuario.

            if (conexion != null)
            {

                string query = "DELETE FROM persona WHERE idPersona = @idPersona";

                conexion.Open();

                comando = new MySqlCommand(query, conexion); //Pasamos el query con el comando.

                comando.Parameters.AddWithValue("@idPersona", nroId);

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