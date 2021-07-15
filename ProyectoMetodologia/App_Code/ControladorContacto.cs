using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Descripción breve de Controlador
/// </summary>
public class ControladorContacto
{
    
    //METODO PARA INSERTAR DATOS INGRESADOS EN FORMULARIO DE CONTACTO:
    public static void insertarContacto(Contacto contacto)
    {

        MySqlCommand comando = null;

        MySqlConnection conexion = null;
        Conexion con = new Conexion();

        try
        {

            conexion = con.getConnection(); //metodo getConnection, logueamos el usuario.

            if (conexion != null)
            {

                string query = "INSERT INTO contacto (nombre, apellido, email, confirmarEmail, telefono, comentario) VALUES (@nombre, @apellido, @email, @confirmarEmail, @telefono, @comentario)";

                conexion.Open();

                comando = new MySqlCommand(query, conexion); //Pasamos el query con el comando.

                comando.Parameters.AddWithValue("@nombre", contacto.Nombre);

                comando.Parameters.AddWithValue("@apellido", contacto.Apellido);

                comando.Parameters.AddWithValue("@email", contacto.Email);

                comando.Parameters.AddWithValue("@confirmarEmail", contacto.ConfirmarEmail);

                comando.Parameters.AddWithValue("@telefono", contacto.Telefono);

                comando.Parameters.AddWithValue("@comentario", contacto.Comentario);

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


    public static Contacto buscarOneContacto(int dato)
    {
        Contacto contacto = null;

        MySqlDataReader reader = null;

        MySqlCommand comando = null;

        MySqlConnection conexion = null;
        Conexion con = new Conexion();

        try
        {
            conexion = con.getConnection(); //metodo getConnection, logueamos el usuario.

            if (conexion != null)
            {

                string query = "SELECT idContacto, nombre, apellido, email, confirmarEmail, telefono, comentario FROM contacto WHERE idContacto = @idContacto";

                conexion.Open();


                comando = new MySqlCommand(query, conexion); //Pasamos el query con el comando.


                comando.Parameters.AddWithValue("@idContacto", dato);


                reader = comando.ExecuteReader(); //Ejecutamos la CONSULTA de datos y guardamos los mismos en el objeto READER.

                if (reader.HasRows) //verificamos si existen filas.
                {

                    while (reader.Read())
                    {

                        int idContacto = reader.GetInt32(0); //tambien se puede pasar como parametro el nombre de la columna ej ("idProducto")
                        string nombre = reader.GetString(1);
                        string apellido = reader.GetString(2);
                        string email = reader.GetString(3);
                        string confirmarEmail = reader.GetString(4);
                        string telefono = reader.GetString(5);
                        string comentario = reader.GetString(6);


                        contacto = new Contacto(idContacto, nombre, apellido, email, confirmarEmail, telefono, comentario);


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



        return contacto;

    }


    public static List<Contacto> buscarAllContacto()
    {

        Contacto contacto = null;

        List<Contacto> listaContacto = new List<Contacto>();

        MySqlDataReader reader = null;

        MySqlCommand comando = null;

        MySqlConnection conexion = null;
        Conexion con = new Conexion();

        try
        {
            conexion = con.getConnection(); //metodo getConnection, logueamos el usuario.

            if (conexion != null)
            {

                string query = "SELECT idContacto, nombre, apellido, email, confirmarEmail, telefono, comentario FROM contacto";

                conexion.Open();


                comando = new MySqlCommand(query, conexion); //Pasamos el query con el comando.


                reader = comando.ExecuteReader(); //Ejecutamos la CONSULTA de datos y guardamos los mismos en el objeto READER.

                if (reader.HasRows) //verificamos si existen filas.
                {

                    while (reader.Read())
                    {

                        int idContacto = reader.GetInt32(0); //tambien se puede pasar como parametro el nombre de la columna ej ("idProducto")
                        string nombre = reader.GetString(1);
                        string apellido = reader.GetString(2);
                        string email = reader.GetString(3);
                        string confirmarEmail = reader.GetString(4);
                        string telefono = reader.GetString(5);
                        string comentario = reader.GetString(6);


                        contacto = new Contacto(idContacto, nombre, apellido, email, confirmarEmail, telefono, comentario);

                        listaContacto.Add(contacto); //Guardamos el Objeto en la lista
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



        return listaContacto;
    }


    public static void actualizarContacto(string nombre, string apellido, string email, string confirmarEmail, string telefono, string comentario, int nroId)
    {


        MySqlCommand comando = null;

        MySqlConnection conexion = null;
        Conexion con = new Conexion();

        try
        {

            conexion = con.getConnection(); //metodo getConnection, logueamos el usuario.

            if (conexion != null)
            {

                string query = "UPDATE contacto SET nombre = @nombre, apellido = @apellido, email = @email, confirmarEmail = @confirmarEmail, telefono = @telefono, comentario = @comentario WHERE idContacto = @idContacto";

                conexion.Open();

                comando = new MySqlCommand(query, conexion); //Pasamos el query con el comando.

                comando.Parameters.AddWithValue("@nombre", nombre);

                comando.Parameters.AddWithValue("@apellido", apellido);

                comando.Parameters.AddWithValue("@email", email);

                comando.Parameters.AddWithValue("@confirmarEmail", confirmarEmail);

                comando.Parameters.AddWithValue("@telefono", telefono);

                comando.Parameters.AddWithValue("@comentario", comentario);

                comando.Parameters.AddWithValue("@idContacto", nroId);

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

    public static void eliminarContacto(int nroId)
    {

        MySqlCommand comando = null;

        MySqlConnection conexion = null;
        Conexion con = new Conexion();

        try
        {

            conexion = con.getConnection(); //metodo getConnection, logueamos el usuario.

            if (conexion != null)
            {

                string query = "DELETE FROM contacto WHERE idContacto = @idContacto";

                conexion.Open();

                comando = new MySqlCommand(query, conexion); //Pasamos el query con el comando.

                comando.Parameters.AddWithValue("@idContacto", nroId);

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



