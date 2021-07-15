using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Descripción breve de ControladorDonadoPersona
/// </summary>
public class ControladorDonadoPersona
{

    //METODO PARA INSERTAR DATOS INGRESADOS EN FORMULARIO DE CONTACTO:
    public static void insertarArticuloDonadoPersona(ArticuloDonadoPersona articuloDonado)
    {

        MySqlCommand comando = null;

        MySqlConnection conexion = null;
        Conexion con = new Conexion();

        try
        {

            conexion = con.getConnection(); //metodo getConnection, logueamos el usuario.

            if (conexion != null)
            {

                string query = "INSERT INTO articulo_donado_persona (nombre, codigo, cantidad, idPersona, idArticuloPedido) VALUES (@nombre, @codigo, @cantidad, @idPersona, @idArticuloPedido)";

                conexion.Open();

                comando = new MySqlCommand(query, conexion); //Pasamos el query con el comando.

                comando.Parameters.AddWithValue("@nombre", articuloDonado.Nombre);

                comando.Parameters.AddWithValue("@codigo", articuloDonado.Codigo);

                comando.Parameters.AddWithValue("@cantidad", articuloDonado.Cantidad);

                comando.Parameters.AddWithValue("@idPersona", articuloDonado.IdPersona);

                comando.Parameters.AddWithValue("@idArticuloPedido", articuloDonado.IdArticuloPedido);

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


    public static ArticuloDonadoPersona buscarOneArticuloDonadoPersona(int dato)
    {
        ArticuloDonadoPersona articuloDonado = null;

        MySqlDataReader reader = null;

        MySqlCommand comando = null;

        MySqlConnection conexion = null;
        Conexion con = new Conexion();

        try
        {
            conexion = con.getConnection(); //metodo getConnection, logueamos el usuario.

            if (conexion != null)
            {

                string query = "SELECT idArticulo_persona, nombre, codigo, cantidad, idPersona, idArticuloPedido FROM articulo_donado_persona WHERE idArticulo_persona = @idArticulo_persona";

                conexion.Open();


                comando = new MySqlCommand(query, conexion); //Pasamos el query con el comando.


                comando.Parameters.AddWithValue("@idArticulo_persona", dato);


                reader = comando.ExecuteReader(); //Ejecutamos la CONSULTA de datos y guardamos los mismos en el objeto READER.

                if (reader.HasRows) //verificamos si existen filas.
                {

                    while (reader.Read())
                    {

                        int idArticuloDonado = reader.GetInt32(0); //tambien se puede pasar como parametro el nombre de la columna ej ("idProducto")
                        string nombre = reader.GetString(1);
                        string codigo = reader.GetString(2);
                        int cantidad = reader.GetInt32(3);
                        int idPersona = reader.GetInt32(4);
                        int idArticuloPedido = reader.GetInt32(5);


                        articuloDonado = new ArticuloDonadoPersona(idArticuloDonado, nombre, codigo, cantidad, idPersona, idArticuloPedido);


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



        return articuloDonado;

    }

    //Metodo para buscar todos los articulos donados:
    public static List<ArticuloDonadoPersona> buscarAllArticuloDonadoPersona()
    {

        ArticuloDonadoPersona articuloDonado = null;

        List<ArticuloDonadoPersona> listaArticuloDonado = new List<ArticuloDonadoPersona>();

        MySqlDataReader reader = null;

        MySqlCommand comando = null;

        MySqlConnection conexion = null;
        Conexion con = new Conexion();

        try
        {
            conexion = con.getConnection(); //metodo getConnection, logueamos el usuario.

            if (conexion != null)
            {

                string query = "SELECT idArticulo_persona, nombre, codigo, cantidad, idPersona, idArticuloPedido FROM articulo_donado_persona";

                conexion.Open();


                comando = new MySqlCommand(query, conexion); //Pasamos el query con el comando.


                reader = comando.ExecuteReader(); //Ejecutamos la CONSULTA de datos y guardamos los mismos en el objeto READER.

                if (reader.HasRows) //verificamos si existen filas.
                {

                    while (reader.Read())
                    {

                        int idArticuloDonado = reader.GetInt32(0); //tambien se puede pasar como parametro el nombre de la columna ej ("idProducto")
                        string nombre = reader.GetString(1);
                        string codigo = reader.GetString(2);
                        int cantidad = reader.GetInt32(3);
                        int idPersona = reader.GetInt32(4);
                        int idArticuloPedido = reader.GetInt32(5);


                        articuloDonado = new ArticuloDonadoPersona(idArticuloDonado, nombre, codigo, cantidad, idPersona, idArticuloPedido);

                        listaArticuloDonado.Add(articuloDonado); //Guardamos el Objeto en la lista
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



        return listaArticuloDonado;
    }

    //Metodo para buscar solo los articulos donados por X idPersona
    public static List<ArticuloDonadoPersona> buscarAllArticuloDonadoXPersona(int idPersonaBusqueda)
    {

        ArticuloDonadoPersona articuloDonado = null;

        List<ArticuloDonadoPersona> listaArticuloDonado = new List<ArticuloDonadoPersona>();

        MySqlDataReader reader = null;

        MySqlCommand comando = null;

        MySqlConnection conexion = null;
        Conexion con = new Conexion();

        try
        {
            conexion = con.getConnection(); //metodo getConnection, logueamos el usuario.

            if (conexion != null)
            {

                string query = "SELECT idArticulo_persona, nombre, codigo, cantidad, idPersona, idArticuloPedido FROM articulo_donado_persona WHERE idPersona = @idPersona";

                conexion.Open();


                comando = new MySqlCommand(query, conexion); //Pasamos el query con el comando.

                comando.Parameters.AddWithValue("@idPersona", idPersonaBusqueda);

                reader = comando.ExecuteReader(); //Ejecutamos la CONSULTA de datos y guardamos los mismos en el objeto READER.

                if (reader.HasRows) //verificamos si existen filas.
                {

                    while (reader.Read())
                    {

                        int idArticuloDonado = reader.GetInt32(0); //tambien se puede pasar como parametro el nombre de la columna ej ("idProducto")
                        string nombre = reader.GetString(1);
                        string codigo = reader.GetString(2);
                        int cantidad = reader.GetInt32(3);
                        int idPersona = reader.GetInt32(4);
                        int idArticuloPedido = reader.GetInt32(5);


                        articuloDonado = new ArticuloDonadoPersona(idArticuloDonado, nombre, codigo, cantidad, idPersona, idArticuloPedido);

                        listaArticuloDonado.Add(articuloDonado); //Guardamos el Objeto en la lista
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



        return listaArticuloDonado;
    }




    //Metodo para buscar solo los articulos donados por X idArticuloPedido
    public static List<ArticuloDonadoPersona> buscarAllArticuloDonadoXArticuloPedido(int idArticuloPedidoBusqueda)
    {

        ArticuloDonadoPersona articuloDonado = null;

        List<ArticuloDonadoPersona> listaArticuloDonado = new List<ArticuloDonadoPersona>();

        MySqlDataReader reader = null;

        MySqlCommand comando = null;

        MySqlConnection conexion = null;
        Conexion con = new Conexion();

        try
        {
            conexion = con.getConnection(); //metodo getConnection, logueamos el usuario.

            if (conexion != null)
            {

                string query = "SELECT idArticulo_persona, nombre, codigo, cantidad, idPersona, idArticuloPedido FROM articulo_donado_persona WHERE idArticuloPedido = @idArticuloPedido";

                conexion.Open();


                comando = new MySqlCommand(query, conexion); //Pasamos el query con el comando.

                comando.Parameters.AddWithValue("@idArticuloPedido", idArticuloPedidoBusqueda);

                reader = comando.ExecuteReader(); //Ejecutamos la CONSULTA de datos y guardamos los mismos en el objeto READER.

                if (reader.HasRows) //verificamos si existen filas.
                {

                    while (reader.Read())
                    {

                        int idArticuloDonado = reader.GetInt32(0); //tambien se puede pasar como parametro el nombre de la columna ej ("idProducto")
                        string nombre = reader.GetString(1);
                        string codigo = reader.GetString(2);
                        int cantidad = reader.GetInt32(3);
                        int idPersona = reader.GetInt32(4);
                        int idArticuloPedido = reader.GetInt32(5);


                        articuloDonado = new ArticuloDonadoPersona(idArticuloDonado, nombre, codigo, cantidad, idPersona, idArticuloPedido);

                        listaArticuloDonado.Add(articuloDonado); //Guardamos el Objeto en la lista
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



        return listaArticuloDonado;
    }


    public static void actualizarArticuloDonadoPersona(string nombre, string codigo, int cantidad, int idPersona, int idArticuloPedido, int idBusqueda)
    {


        MySqlCommand comando = null;

        MySqlConnection conexion = null;
        Conexion con = new Conexion();

        try
        {

            conexion = con.getConnection(); //metodo getConnection, logueamos el usuario.

            if (conexion != null)
            {

                string query = "UPDATE articulo_donado_persona SET nombre = @nombre, codigo = @codigo, cantidad = @cantidad, idPersona = @idPersona, idArticuloPedido = @idArticuloPedido WHERE idArticulo_persona = @idArticulo_persona";

                conexion.Open();

                comando = new MySqlCommand(query, conexion); //Pasamos el query con el comando.

                comando.Parameters.AddWithValue("@nombre", nombre);

                comando.Parameters.AddWithValue("@codigo", codigo);

                comando.Parameters.AddWithValue("@cantidad", cantidad);

                comando.Parameters.AddWithValue("@idPersona", idPersona);

                comando.Parameters.AddWithValue("@idArticuloPedido", idArticuloPedido);

                comando.Parameters.AddWithValue("@idArticulo_persona", idBusqueda);

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

    public static void eliminarArticuloDonadoPersona(int nroId)
    {

        MySqlCommand comando = null;

        MySqlConnection conexion = null;
        Conexion con = new Conexion();

        try
        {

            conexion = con.getConnection(); //metodo getConnection, logueamos el usuario.

            if (conexion != null)
            {

                string query = "DELETE FROM articulo_donado_persona WHERE idArticulo_persona = @idArticulo_persona";

                conexion.Open();

                comando = new MySqlCommand(query, conexion); //Pasamos el query con el comando.

                comando.Parameters.AddWithValue("@idArticulo_persona", nroId);

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