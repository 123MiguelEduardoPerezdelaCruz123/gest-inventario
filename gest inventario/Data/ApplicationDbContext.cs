using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
using gest_inventario.Modelos;

namespace gest_inventario.Data
{

        public class ApplicationDbContext : DbContext
        {
            // Constructor que llama a la cadena de conexión definida en app.config
            public ApplicationDbContext() : base("DefaultConnection")
            {
            }

            // Define tus tablas como DbSet
            public DbSet<Producto> Productos { get; set; }
            public DbSet<Categoria> Categorias { get; set; }
        }
}
