using gest_inventario.Vistas;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace gest_inventario
{
    internal class Program
    {
                    [STAThread]

        static void Main(string[] args)
        {

    
            {
                System.Windows.Forms.Application.EnableVisualStyles();
                System.Windows.Forms.Application.SetCompatibleTextRenderingDefault(false);

                // Aquí inicia el formulario principal de productos
                System.Windows.Forms.Application.Run(new FormularioProductos());
            }
        }
    }
}
