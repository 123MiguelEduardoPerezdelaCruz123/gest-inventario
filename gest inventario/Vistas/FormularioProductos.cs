using gest_inventario.Controladores;
using gest_inventario.Modelos;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;



namespace gest_inventario.Vistas
{
    public partial class FormularioProductos : Form

    {
        private ProductoController productoController;

        public FormularioProductos()
        {
            InitializeComponent();
            productoController = new ProductoController();
            CargarProductos();
        }

        // Cargar todos los productos en el DataGridView
        private void CargarProductos()
        {
            List<Producto> productos = productoController.ObtenerProductos();
            dgvProductos.DataSource = productos;  // Asigna los productos al DataGridView
        }




        private void lblCodigo_Click(object sender, EventArgs e)
        {

        }

        private void FormularioProductos_Load(object sender, EventArgs e)
        {
            // TODO: esta línea de código carga datos en la tabla 'gestión_de_inventarioDataSet.Proveedores' Puede moverla o quitarla según sea necesario.
            this.proveedoresTableAdapter.Fill(this.gestión_de_inventarioDataSet.Proveedores);
            // TODO: esta línea de código carga datos en la tabla 'gestión_de_inventarioDataSet.Productos' Puede moverla o quitarla según sea necesario.
            this.productosTableAdapter.Fill(this.gestión_de_inventarioDataSet.Productos);
            // TODO: esta línea de código carga datos en la tabla 'gestión_de_inventarioDataSet.Categorias' Puede moverla o quitarla según sea necesario.
            this.categoriasTableAdapter.Fill(this.gestión_de_inventarioDataSet.Categorias);

        }

        private void btn_agregar_Click(object sender, EventArgs e)
        {
            Producto producto = new Producto
            {
                Nombre = txtNombre.Text,
                Codigo = txtCodigo.Text,
                Categoria = txtCategoria.Text,
                Precio = decimal.Parse(txtPrecio.Text),
                Existencia = int.Parse(txtExistencia.Text),
                Proveedor = txtProveedor.Text
            };

            productoController.AgregarProducto(producto);
            MessageBox.Show("Producto agregado exitosamente");
            LimpiarCampos();
            CargarProductos();
        }

        private void btn_Eliminar_Click(object sender, EventArgs e)
        {
            if (dgvProductos.SelectedRows.Count > 0)
            {
                int idProducto = (int)dgvProductos.SelectedRows[0].Cells["Id"].Value;

                productoController.EliminarProducto(idProducto);
                MessageBox.Show("Producto eliminado correctamente");
                CargarProductos();
            }
            else
            {
                MessageBox.Show("Seleccione un producto para eliminar");
            }
        }

        private void btn_actualizar_Click(object sender, EventArgs e)
        {
            if (dgvProductos.SelectedRows.Count > 0)
            {
                int idProducto = (int)dgvProductos.SelectedRows[0].Cells["Id"].Value;

                Producto producto = new Producto
                {
                    Id = idProducto,
                    Nombre = txtNombre.Text,
                    Codigo = txtCodigo.Text,
                    Categoria = txtCategoria.Text,
                    Precio = decimal.Parse(txtPrecio.Text),
                    Existencia = int.Parse(txtExistencia.Text),
                    Proveedor = txtProveedor.Text
                };

                productoController.ActualizarProducto(producto);
                MessageBox.Show("Producto actualizado correctamente");
                LimpiarCampos();
                CargarProductos();
            }
            else
            {
                MessageBox.Show("Seleccione un producto para actualizar");
            }
        }


        private void LimpiarCampos()
        {
            txtNombre.Clear();
            txtCodigo.Clear();
            txtCategoria.Clear();
            txtPrecio.Clear();
            txtExistencia.Clear();
            txtProveedor.Clear();
        }

        private void dgvProductos_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

                if (dgvProductos.SelectedRows.Count > 0)
                {
                    txtNombre.Text = dgvProductos.SelectedRows[0].Cells["Nombre"].Value.ToString();
                    txtCodigo.Text = dgvProductos.SelectedRows[0].Cells["Codigo"].Value.ToString();
                    txtCategoria.Text = dgvProductos.SelectedRows[0].Cells["Categoria"].Value.ToString();
                    txtPrecio.Text = dgvProductos.SelectedRows[0].Cells["Precio"].Value.ToString();
                    txtExistencia.Text = dgvProductos.SelectedRows[0].Cells["Existencia"].Value.ToString();
                    txtProveedor.Text = dgvProductos.SelectedRows[0].Cells["Proveedor"].Value.ToString();
                }
            
        }

        private void btnBuscar_Click_1(object sender, EventArgs e)
        {
            string criterio = txtNombre.Text; // O usar txtCodigo.Text
            List<Producto> productos = productoController.BuscarProductos(criterio);
            dgvProductos.DataSource = productos;
        }
    }
}
