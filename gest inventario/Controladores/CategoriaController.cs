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

    public class CategoriaController
    {
        private string connectionString = "Server=localhost;Database=NombreBaseDatos;Trusted_Connection=True;";

        // Crear una categoría
        public void AgregarCategoria(Categoria categoria)
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();
                string query = "INSERT INTO Categorias (Nombre) VALUES (@Nombre)";
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@Nombre", categoria.Nombre);
                cmd.ExecuteNonQuery();
            }
        }

        // Leer todas las categorías
        public List<Categoria> ObtenerCategorias()
        {
            List<Categoria> categorias = new List<Categoria>();

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();
                string query = "SELECT * FROM Categorias";
                SqlCommand cmd = new SqlCommand(query, conn);

                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        categorias.Add(new Categoria
                        {
                            Id = (int)reader["Id"],
                            Nombre = reader["Nombre"].ToString()
                        });
                    }
                }
            }

            return categorias;
        }

        // Actualizar una categoría
        public void ActualizarCategoria(Categoria categoria)
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();
                string query = "UPDATE Categorias SET Nombre=@Nombre WHERE Id=@Id";
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@Nombre", categoria.Nombre);
                cmd.Parameters.AddWithValue("@Id", categoria.Id);
                cmd.ExecuteNonQuery();
            }
        }

        // Eliminar una categoría
        public void EliminarCategoria(int id)
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();
                string query = "DELETE FROM Categorias WHERE Id=@Id";
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@Id", id);
                cmd.ExecuteNonQuery();
            }
        }
    }

}
