using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace gest_inventario.Controladores
{
    using gest_inventario.Modelos;
    using System;
    using System.Collections.Generic;
    using System.Data.SqlClient;

    public class ProductoController
    {
        private string connectionString = "Server=localhost\\SQLEXPRESS;Database=nombreBaseDatos;Trusted_Connection=True;";

        // Crear un producto
        public void AgregarProducto(Producto producto)
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();
                string query = "INSERT INTO Productos (Nombre, Codigo, Categoria, Precio, Existencia, Proveedor) VALUES (@Nombre, @Codigo, @Categoria, @Precio, @Existencia, @Proveedor)";
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@Nombre", producto.Nombre);
                cmd.Parameters.AddWithValue("@Codigo", producto.Codigo);
                cmd.Parameters.AddWithValue("@Categoria", producto.Categoria);
                cmd.Parameters.AddWithValue("@Precio", producto.Precio);
                cmd.Parameters.AddWithValue("@Existencia", producto.Existencia);
                cmd.Parameters.AddWithValue("@Proveedor", producto.Proveedor);
                cmd.ExecuteNonQuery();
            }
        }

        // Leer todos los productos
        public List<Producto> ObtenerProductos()
        {
            List<Producto> productos = new List<Producto>();

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();
                string query = "SELECT * FROM Productos";
                SqlCommand cmd = new SqlCommand(query, conn);

                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        productos.Add(new Producto
                        {
                            Id = (int)reader["Id"],
                            Nombre = reader["Nombre"].ToString(),
                            Codigo = reader["Codigo"].ToString(),
                            Categoria = reader["Categoria"].ToString(),
                            Precio = (decimal)reader["Precio"],
                            Existencia = (int)reader["Existencia"],
                            Proveedor = reader["Proveedor"].ToString()
                        });
                    }
                }
            }

            return productos;
        }

        // Actualizar un producto
        public void ActualizarProducto(Producto producto)
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();
                string query = "UPDATE Productos SET Nombre=@Nombre, Codigo=@Codigo, Categoria=@Categoria, Precio=@Precio, Existencia=@Existencia, Proveedor=@Proveedor WHERE Id=@Id";
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@Nombre", producto.Nombre);
                cmd.Parameters.AddWithValue("@Codigo", producto.Codigo);
                cmd.Parameters.AddWithValue("@Categoria", producto.Categoria);
                cmd.Parameters.AddWithValue("@Precio", producto.Precio);
                cmd.Parameters.AddWithValue("@Existencia", producto.Existencia);
                cmd.Parameters.AddWithValue("@Proveedor", producto.Proveedor);
                cmd.Parameters.AddWithValue("@Id", producto.Id);
                cmd.ExecuteNonQuery();
            }
        }

        // Eliminar un producto
        public void EliminarProducto(int id)
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();
                string query = "DELETE FROM Productos WHERE Id=@Id";
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@Id", id);
                cmd.ExecuteNonQuery();
            }
        }

        internal List<Producto> BuscarProductos(string criterio)
        {
            throw new NotImplementedException();
        }
    }

}
