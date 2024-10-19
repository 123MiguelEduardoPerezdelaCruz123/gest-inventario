using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace gest_inventario.Modelos
{


        public class Producto
        {
            public int Id { get; set; }
            public string Nombre { get; set; }
            public string Codigo { get; set; }
            public string Categoria { get; set; }
            public decimal Precio { get; set; }
            public int Existencia { get; set; }
            public string Proveedor { get; set; }
        }

    
}
