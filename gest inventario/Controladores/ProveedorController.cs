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

    namespace InventarioProductos.Controladores
    {
        public class ProveedorController
        {
            private string connectionString = "Server=localhost;Database=Inventario;Trusted_Connection=True;";

            // Agregar un proveedor
            public void AgregarProveedor(Proveedor proveedor)
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();
                    string query = "INSERT INTO Proveedores (Nombre, Direccion, Telefono, Email) VALUES (@Nombre, @Direccion, @Telefono, @Email)";
                    SqlCommand cmd = new SqlCommand(query, conn);
                    cmd.Parameters.AddWithValue("@Nombre", proveedor.Nombre);
                    cmd.Parameters.AddWithValue("@Direccion", proveedor.Direccion);
                    cmd.Parameters.AddWithValue("@Telefono", proveedor.Telefono);
                    cmd.Parameters.AddWithValue("@Email", proveedor.Email);
                    cmd.ExecuteNonQuery();
                }
            }

            // Obtener lista de proveedores
            public List<Proveedor> ObtenerProveedores()
            {
                List<Proveedor> proveedores = new List<Proveedor>();

                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();
                    string query = "SELECT * FROM Proveedores";
                    SqlCommand cmd = new SqlCommand(query, conn);
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            Proveedor proveedor = new Proveedor
                            {
                                Id = (int)reader["Id"],
                                Nombre = reader["Nombre"].ToString(),
                                Direccion = reader["Direccion"].ToString(),
                                Telefono = reader["Telefono"].ToString(),
                                Email = reader["Email"].ToString()
                            };
                            proveedores.Add(proveedor);
                        }
                    }
                }

                return proveedores;
            }

            // Actualizar un proveedor
            public void ActualizarProveedor(Proveedor proveedor)
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();
                    string query = "UPDATE Proveedores SET Nombre = @Nombre, Direccion = @Direccion, Telefono = @Telefono, Email = @Email WHERE Id = @Id";
                    SqlCommand cmd = new SqlCommand(query, conn);
                    cmd.Parameters.AddWithValue("@Nombre", proveedor.Nombre);
                    cmd.Parameters.AddWithValue("@Direccion", proveedor.Direccion);
                    cmd.Parameters.AddWithValue("@Telefono", proveedor.Telefono);
                    cmd.Parameters.AddWithValue("@Email", proveedor.Email);
                    cmd.Parameters.AddWithValue("@Id", proveedor.Id);
                    cmd.ExecuteNonQuery();
                }
            }

            // Eliminar un proveedor
            public void EliminarProveedor(int id)
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();
                    string query = "DELETE FROM Proveedores WHERE Id = @Id";
                    SqlCommand cmd = new SqlCommand(query, conn);
                    cmd.Parameters.AddWithValue("@Id", id);
                    cmd.ExecuteNonQuery();
                }
            }

            // Buscar proveedores por nombre o email
            public List<Proveedor> BuscarProveedores(string criterio)
            {
                List<Proveedor> proveedores = new List<Proveedor>();

                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();
                    string query = "SELECT * FROM Proveedores WHERE Nombre LIKE @Criterio OR Email LIKE @Criterio";
                    SqlCommand cmd = new SqlCommand(query, conn);
                    cmd.Parameters.AddWithValue("@Criterio", "%" + criterio + "%");

                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            Proveedor proveedor = new Proveedor
                            {
                                Id = (int)reader["Id"],
                                Nombre = reader["Nombre"].ToString(),
                                Direccion = reader["Direccion"].ToString(),
                                Telefono = reader["Telefono"].ToString(),
                                Email = reader["Email"].ToString()
                            };
                            proveedores.Add(proveedor);
                        }
                    }
                }

                return proveedores;
            }
        }
    }

}
