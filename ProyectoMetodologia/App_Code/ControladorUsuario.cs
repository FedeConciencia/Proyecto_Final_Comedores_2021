using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Descripción breve de ControladorUsuario
/// </summary>
public class ControladorUsuario
{

    //METODO PARA INSERTAR DATOS INGRESADOS EN FORMULARIO DE CONTACTO:
    public static void insertarUsuario(Usuario usuario)
    {

        MySqlCommand comando = null;

        MySqlConnection conexion = null;
        Conexion con = new Conexion();

        try
        {

            conexion = con.getConnection(); //metodo getConnection, logueamos el usuario.

            if (conexion != null)
            {

                string query = "INSERT INTO usuario (nombreUsuario, contraseñaUsuario, idPersona, idEmpresa) VALUES (@nombreUsuario, @contraseñaUsuario, @idPersona, @idEmpresa)";

                conexion.Open();

                comando = new MySqlCommand(query, conexion); //Pasamos el query con el comando.

                comando.Parameters.AddWithValue("@nombreUsuario", usuario.NombreUsuario);

                comando.Parameters.AddWithValue("@contraseñaUsuario", usuario.ContraseñaUsuario);

                comando.Parameters.AddWithValue("@idPersona", usuario.IdPersona);

                comando.Parameters.AddWithValue("@idEmpresa", usuario.IdEmpresa);


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


    public static Usuario buscarOneUsuario(int dato)
    {
        Usuario usuario = null;

        MySqlDataReader reader = null;

        MySqlCommand comando = null;

        MySqlConnection conexion = null;
        Conexion con = new Conexion();

        try
        {
            conexion = con.getConnection(); //metodo getConnection, logueamos el usuario.

            if (conexion != null)
            {

                string query = "SELECT idUsuario, nombreUsuario, contraseñaUsuario, idPersona, idEmpresa FROM usuario WHERE idUsuario = @idUsuario";

                conexion.Open();


                comando = new MySqlCommand(query, conexion); //Pasamos el query con el comando.


                comando.Parameters.AddWithValue("@idUsuario", dato);


                reader = comando.ExecuteReader(); //Ejecutamos la CONSULTA de datos y guardamos los mismos en el objeto READER.

                if (reader.HasRows) //verificamos si existen filas.
                {

                    while (reader.Read())
                    {

                        int idUsuario = reader.GetInt32(0); //tambien se puede pasar como parametro el nombre de la columna ej ("idProducto")
                        string nombreUsuario = reader.GetString(1);
                        string contraseñaUsuario = reader.GetString(2);
                        int idPersona = reader.GetInt32(3);
                        int idEmpresa = reader.GetInt32(4);




                        usuario = new Usuario(idUsuario, nombreUsuario, contraseñaUsuario, idPersona, idEmpresa); //Obtenemos todos los articulos pedidos asociados al comedor


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



        return usuario;

    }



    


    public static List<Usuario> buscarAllUsuario()
    {

        Usuario usuario = null;

        List<Usuario> listaUsuario = new List<Usuario>();

        MySqlDataReader reader = null;

        MySqlCommand comando = null;

        MySqlConnection conexion = null;
        Conexion con = new Conexion();


        try
        {
            conexion = con.getConnection(); //metodo getConnection, logueamos el usuario.

            if (conexion != null)
            {

                string query = "SELECT idUsuario, nombreUsuario, contraseñaUsuario, idPersona, idEmpresa FROM usuario";

                conexion.Open();


                comando = new MySqlCommand(query, conexion); //Pasamos el query con el comando.


                reader = comando.ExecuteReader(); //Ejecutamos la CONSULTA de datos y guardamos los mismos en el objeto READER.

                if (reader.HasRows) //verificamos si existen filas.
                {

                    while (reader.Read())
                    {

                        int idUsuario = reader.GetInt32(0); //tambien se puede pasar como parametro el nombre de la columna ej ("idProducto")
                        string nombreUsuario = reader.GetString(1);
                        string contraseñaUsuario = reader.GetString(2);
                        int idPersona = reader.GetInt32(3);
                        int idEmpresa = reader.GetInt32(4);




                        usuario = new Usuario(idUsuario, nombreUsuario, contraseñaUsuario, idPersona, idEmpresa);

                        listaUsuario.Add(usuario); //Guardamos el Objeto en la lista


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



        return listaUsuario;
    }


    public static void actualizarUsuario(string nombreUsuario, string contraseñaUsuario, int idPersona, int idEmpresa, int idBusqueda)
    {


        MySqlCommand comando = null;

        MySqlConnection conexion = null;
        Conexion con = new Conexion();

        try
        {

            conexion = con.getConnection(); //metodo getConnection, logueamos el usuario.

            if (conexion != null)
            {

                string query = "UPDATE usuario SET nombreUsuario = @nombreUsuario, contraseñaUsuario = @contraseñaUsuario, idPersona = @idPersona, idEmpresa = @idEmpresa WHERE idUsuario = @idUsuario";

                conexion.Open();

                comando = new MySqlCommand(query, conexion); //Pasamos el query con el comando.

                comando.Parameters.AddWithValue("@nombreUsuario", nombreUsuario);

                comando.Parameters.AddWithValue("@contraseñaUsuario", contraseñaUsuario);

                comando.Parameters.AddWithValue("@idPersona", idPersona);

                comando.Parameters.AddWithValue("@idEmpresa", idEmpresa);

                comando.Parameters.AddWithValue("@idUsuario", idBusqueda);

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



    //Actualizar Usuario X idPersona:

    public static void actualizarUsuarioXidPersona(string nombreUsuario, string contraseñaUsuario, int idBusqueda)
    {


        MySqlCommand comando = null;

        MySqlConnection conexion = null;
        Conexion con = new Conexion();

        try
        {

            conexion = con.getConnection(); //metodo getConnection, logueamos el usuario.

            if (conexion != null)
            {

                string query = "UPDATE usuario SET nombreUsuario = @nombreUsuario, contraseñaUsuario = @contraseñaUsuario WHERE idPersona = @idPersona2";

                conexion.Open();

                comando = new MySqlCommand(query, conexion); //Pasamos el query con el comando.

                comando.Parameters.AddWithValue("@nombreUsuario", nombreUsuario);

                comando.Parameters.AddWithValue("@contraseñaUsuario", contraseñaUsuario);

                comando.Parameters.AddWithValue("@idPersona2", idBusqueda);

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

    //Buscar Usuario por ID_Persona:
    public static Usuario buscarOneUsuarioXidPersona(int dato)
    {
        Usuario usuario = null;

        MySqlDataReader reader = null;

        MySqlCommand comando = null;

        MySqlConnection conexion = null;
        Conexion con = new Conexion();

        try
        {
            conexion = con.getConnection(); //metodo getConnection, logueamos el usuario.

            if (conexion != null)
            {

                string query = "SELECT idUsuario, nombreUsuario, contraseñaUsuario, idPersona, idEmpresa FROM usuario WHERE idPersona = @idPersona2";

                conexion.Open();


                comando = new MySqlCommand(query, conexion); //Pasamos el query con el comando.


                comando.Parameters.AddWithValue("@idPersona2", dato);


                reader = comando.ExecuteReader(); //Ejecutamos la CONSULTA de datos y guardamos los mismos en el objeto READER.

                if (reader.HasRows) //verificamos si existen filas.
                {

                    while (reader.Read())
                    {

                        int idUsuario = reader.GetInt32(0); //tambien se puede pasar como parametro el nombre de la columna ej ("idProducto")
                        string nombreUsuario = reader.GetString(1);
                        string contraseñaUsuario = reader.GetString(2);
                        int idPersona = reader.GetInt32(3);
                        int idEmpresa = reader.GetInt32(4);




                        usuario = new Usuario(idUsuario, nombreUsuario, contraseñaUsuario, idPersona, idEmpresa); //Obtenemos todos los articulos pedidos asociados al comedor


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



        return usuario;

    }



    //Actualizar Usuario X idPersona:

    public static void actualizarUsuarioXidEmpresa(string nombreUsuario, string contraseñaUsuario, int idBusqueda)
    {


        MySqlCommand comando = null;

        MySqlConnection conexion = null;
        Conexion con = new Conexion();

        try
        {

            conexion = con.getConnection(); //metodo getConnection, logueamos el usuario.

            if (conexion != null)
            {

                string query = "UPDATE usuario SET nombreUsuario = @nombreUsuario, contraseñaUsuario = @contraseñaUsuario WHERE idEmpresa = @idEmpresa2";

                conexion.Open();

                comando = new MySqlCommand(query, conexion); //Pasamos el query con el comando.

                comando.Parameters.AddWithValue("@nombreUsuario", nombreUsuario);

                comando.Parameters.AddWithValue("@contraseñaUsuario", contraseñaUsuario);

                comando.Parameters.AddWithValue("@idEmpresa2", idBusqueda);

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

    //Buscar Usuario por ID_Persona:
    public static Usuario buscarOneUsuarioXidEmpresa(int dato)
    {
        Usuario usuario = null;

        MySqlDataReader reader = null;

        MySqlCommand comando = null;

        MySqlConnection conexion = null;
        Conexion con = new Conexion();

        try
        {
            conexion = con.getConnection(); //metodo getConnection, logueamos el usuario.

            if (conexion != null)
            {

                string query = "SELECT idUsuario, nombreUsuario, contraseñaUsuario, idPersona, idEmpresa FROM usuario WHERE idEmpresa = @idEmpresa2";

                conexion.Open();


                comando = new MySqlCommand(query, conexion); //Pasamos el query con el comando.


                comando.Parameters.AddWithValue("@idEmpresa2", dato);


                reader = comando.ExecuteReader(); //Ejecutamos la CONSULTA de datos y guardamos los mismos en el objeto READER.

                if (reader.HasRows) //verificamos si existen filas.
                {

                    while (reader.Read())
                    {

                        int idUsuario = reader.GetInt32(0); //tambien se puede pasar como parametro el nombre de la columna ej ("idProducto")
                        string nombreUsuario = reader.GetString(1);
                        string contraseñaUsuario = reader.GetString(2);
                        int idPersona = reader.GetInt32(3);
                        int idEmpresa = reader.GetInt32(4);




                        usuario = new Usuario(idUsuario, nombreUsuario, contraseñaUsuario, idPersona, idEmpresa); //Obtenemos todos los articulos pedidos asociados al comedor


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



        return usuario;

    }


    public static void eliminarUsuario(int nroId)
    {

        MySqlCommand comando = null;

        MySqlConnection conexion = null;
        Conexion con = new Conexion();

        try
        {

            conexion = con.getConnection(); //metodo getConnection, logueamos el usuario.

            if (conexion != null)
            {

                string query = "DELETE FROM usuario WHERE idUsuario = @idUsuario";

                conexion.Open();

                comando = new MySqlCommand(query, conexion); //Pasamos el query con el comando.

                comando.Parameters.AddWithValue("@idUsuario", nroId);

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

    //Eliminar Usuario x idPersona:

    public static void eliminarUsuarioXidPersona(int nroId)
    {

        MySqlCommand comando = null;

        MySqlConnection conexion = null;
        Conexion con = new Conexion();

        try
        {

            conexion = con.getConnection(); //metodo getConnection, logueamos el usuario.

            if (conexion != null)
            {

                string query = "DELETE FROM usuario WHERE idPersona = @idPersona";

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

    //Eliminar Usuario x idEmpresa:

    public static void eliminarUsuarioXidEmpresa(int nroId)
    {

        MySqlCommand comando = null;

        MySqlConnection conexion = null;
        Conexion con = new Conexion();

        try
        {

            conexion = con.getConnection(); //metodo getConnection, logueamos el usuario.

            if (conexion != null)
            {

                string query = "DELETE FROM usuario WHERE idEmpresa = @idEmpresa";

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