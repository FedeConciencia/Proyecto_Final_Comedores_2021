using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Descripción breve de ControladorArticuloPedido
/// </summary>
public class ControladorArticuloPedido
{

    //METODO PARA INSERTAR DATOS INGRESADOS EN FORMULARIO DE CONTACTO:
    public static void insertarArticuloPedido(ArticuloPedido articuloPedido)
    {

        MySqlCommand comando = null;

        MySqlConnection conexion = null;
        Conexion con = new Conexion();

        try
        {

            conexion = con.getConnection(); //metodo getConnection, logueamos el usuario.

            if (conexion != null)
            {

                string query = "INSERT INTO articulo_pedido (nombre, codigo, cantidad, idComedor) VALUES (@nombre, @codigo, @cantidad, @idComedor)";

                conexion.Open();

                comando = new MySqlCommand(query, conexion); //Pasamos el query con el comando.

                comando.Parameters.AddWithValue("@nombre", articuloPedido.Nombre);

                comando.Parameters.AddWithValue("@codigo", articuloPedido.Codigo);

                comando.Parameters.AddWithValue("@cantidad", articuloPedido.Cantidad);

                comando.Parameters.AddWithValue("@idComedor", articuloPedido.IdComedor);

                

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


    public static ArticuloPedido buscarOneArticuloPedido(int dato)
    {
        ArticuloPedido articuloPedido = null;

        MySqlDataReader reader = null;

        MySqlCommand comando = null;

        MySqlConnection conexion = null;
        Conexion con = new Conexion();

        try
        {
            conexion = con.getConnection(); //metodo getConnection, logueamos el usuario.

            if (conexion != null)
            {

                string query = "SELECT idArticuloPedido, nombre, codigo, cantidad, idComedor FROM articulo_pedido WHERE idArticuloPedido = @idArticuloPedido";

                conexion.Open();


                comando = new MySqlCommand(query, conexion); //Pasamos el query con el comando.


                comando.Parameters.AddWithValue("@idArticuloPedido", dato);


                reader = comando.ExecuteReader(); //Ejecutamos la CONSULTA de datos y guardamos los mismos en el objeto READER.

                if (reader.HasRows) //verificamos si existen filas.
                {

                    while (reader.Read())
                    {

                        int idArticuloPedido = reader.GetInt32(0); //tambien se puede pasar como parametro el nombre de la columna ej ("idProducto")
                        string nombre = reader.GetString(1);
                        string codigo = reader.GetString(2);
                        int cantidad = reader.GetInt32(3);
                        int idComedor = reader.GetInt32(4);
                        


                        articuloPedido = new ArticuloPedido(idArticuloPedido, nombre, codigo, cantidad, idComedor);


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



        return articuloPedido;

    }

    //Metodo para buscar todos los articulosPedidos:
    public static List<ArticuloPedido> buscarAllArticuloPedido()
    {

        ArticuloPedido articuloPedido = null;

        List<ArticuloPedido> listaArticuloPedido = new List<ArticuloPedido>();

        MySqlDataReader reader = null;

        MySqlCommand comando = null;

        MySqlConnection conexion = null;
        Conexion con = new Conexion();

        try
        {
            conexion = con.getConnection(); //metodo getConnection, logueamos el usuario.

            if (conexion != null)
            {

                string query = "SELECT idArticuloPedido, nombre, codigo, cantidad, idComedor FROM articulo_pedido";

                conexion.Open();


                comando = new MySqlCommand(query, conexion); //Pasamos el query con el comando.


                reader = comando.ExecuteReader(); //Ejecutamos la CONSULTA de datos y guardamos los mismos en el objeto READER.

                if (reader.HasRows) //verificamos si existen filas.
                {

                    while (reader.Read())
                    {
                        int idArticuloPedido = reader.GetInt32(0); //tambien se puede pasar como parametro el nombre de la columna ej ("idProducto")
                        string nombre = reader.GetString(1);
                        string codigo = reader.GetString(2);
                        int cantidad = reader.GetInt32(3);
                        int idComedor = reader.GetInt32(4);



                        articuloPedido = new ArticuloPedido(idArticuloPedido, nombre, codigo, cantidad, idComedor);

                        listaArticuloPedido.Add(articuloPedido); //Guardamos el Objeto en la lista
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



        return listaArticuloPedido;
    }

    //Filtra todos los articulos asociados a X comedor:
    public static List<ArticuloPedido> buscarAllArticuloPedidoXComedor(int idComedorBusqueda)
    {

        ArticuloPedido articuloPedido = null;

        List<ArticuloPedido> listaArticuloPedido = new List<ArticuloPedido>();

        MySqlDataReader reader = null;

        MySqlCommand comando = null;

        MySqlConnection conexion = null;
        Conexion con = new Conexion();

        try
        {
            conexion = con.getConnection(); //metodo getConnection, logueamos el usuario.

            if (conexion != null)
            {

                string query = "SELECT idArticuloPedido, nombre, codigo, cantidad, idComedor FROM articulo_pedido WHERE idComedor = @idComedor";

                conexion.Open();


                comando = new MySqlCommand(query, conexion); //Pasamos el query con el comando.

                comando.Parameters.AddWithValue("@idComedor", idComedorBusqueda);

                reader = comando.ExecuteReader(); //Ejecutamos la CONSULTA de datos y guardamos los mismos en el objeto READER.

                if (reader.HasRows) //verificamos si existen filas.
                {

                    while (reader.Read())
                    {
                        int idArticuloPedido = reader.GetInt32(0); //tambien se puede pasar como parametro el nombre de la columna ej ("idProducto")
                        string nombre = reader.GetString(1);
                        string codigo = reader.GetString(2);
                        int cantidad = reader.GetInt32(3);
                        int idComedor = reader.GetInt32(4);



                        articuloPedido = new ArticuloPedido(idArticuloPedido, nombre, codigo, cantidad, idComedor);

                        listaArticuloPedido.Add(articuloPedido); //Guardamos el Objeto en la lista
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



        return listaArticuloPedido;
    }


    public static void actualizarArticuloPedido(string nombre, string codigo, int cantidad, int idComedor, int idBusqueda)
    {


        MySqlCommand comando = null;

        MySqlConnection conexion = null;
        Conexion con = new Conexion();

        try
        {

            conexion = con.getConnection(); //metodo getConnection, logueamos el usuario.

            if (conexion != null)
            {

                string query = "UPDATE articulo_pedido SET nombre = @nombre, codigo = @codigo, cantidad = @cantidad, idComedor = @idComedor WHERE idArticuloPedido = @idArticuloPedido";

                conexion.Open();

                comando = new MySqlCommand(query, conexion); //Pasamos el query con el comando.

                comando.Parameters.AddWithValue("@nombre", nombre);

                comando.Parameters.AddWithValue("@codigo", codigo);

                comando.Parameters.AddWithValue("@cantidad", cantidad);

                comando.Parameters.AddWithValue("@idComedor", idComedor);

                comando.Parameters.AddWithValue("@idArticuloPedido", idBusqueda);

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

    public static void eliminarArticuloPedido(int nroId)
    {

        MySqlCommand comando = null;

        MySqlConnection conexion = null;
        Conexion con = new Conexion();

        try
        {

            conexion = con.getConnection(); //metodo getConnection, logueamos el usuario.

            if (conexion != null)
            {

                string query = "DELETE FROM articulo_pedido WHERE idArticuloPedido = @idArticuloPedido";

                conexion.Open();

                comando = new MySqlCommand(query, conexion); //Pasamos el query con el comando.

                comando.Parameters.AddWithValue("@idArticuloPedido", nroId);

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




    //Elimar ArticulosPedidos X Comedor:

    public static void eliminarArticuloPedidoXIdComedor(int nroId)
    {

        MySqlCommand comando = null;

        MySqlConnection conexion = null;
        Conexion con = new Conexion();

        try
        {

            conexion = con.getConnection(); //metodo getConnection, logueamos el usuario.

            if (conexion != null)
            {

                string query = "DELETE FROM articulo_pedido WHERE idComedor = @idComedor";

                conexion.Open();

                comando = new MySqlCommand(query, conexion); //Pasamos el query con el comando.

                comando.Parameters.AddWithValue("@idComedor", nroId);

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