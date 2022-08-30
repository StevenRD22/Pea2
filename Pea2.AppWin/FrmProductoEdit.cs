using Pea2.Dominio;
using Pea2.Logic;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Pea2.AppWin
{
    public partial class FrmProductoEdit : Form
    {
        Producto producto;
        public FrmProductoEdit(Producto producto)
        {
            InitializeComponent();
            this.producto = producto;
        }

        private void IniciarFormulario(object sender, EventArgs e)
        {
            cargarDatos();
            if (producto.IdProducto > 0)
            {
                asignarControles();
            }
        }
        private void cargarDatos()
        {
            // Listar los tipo de categoria
            cboCategoria.DataSource = CategoriaBL.Listar();
            cboCategoria.DisplayMember = "Nombre";
            cboCategoria.ValueMember = "IdCategoria";
        }

        private void GrabarDatos(object sender, EventArgs e)
        {
            asignarObjeto();
            this.DialogResult = DialogResult.OK;
        }
        private void asignarObjeto()
        {
            producto.Nombre = txtNombre.Text;
            producto.Marca = txtMarca.Text;
            producto.Precio = int.Parse(txtPrecio.Text);
            producto.IdCategoria = int.Parse(cboCategoria.SelectedValue.ToString());
            producto.Stock =int.Parse(txtStock.Text);
        }
        private void asignarControles()
        {
            txtNombre.Text = producto.Nombre;
            txtMarca.Text = producto.Marca;
            txtPrecio.Text = producto.Precio.ToString() ;
            cboCategoria.SelectedValue = producto.IdCategoria;
            txtStock.Text = producto.Stock.ToString();


        }
    }
}
