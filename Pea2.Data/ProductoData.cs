using Pea2.Dominio;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pea2.Data
{
    public class ProductoData
    {
        string cadenaConexion = "server=localhost; database=Parcial; Integrated security=true";
        public List<Producto> Listar()
        {
            var listado = new List<Producto>();
            using (var conexion = new SqlConnection(cadenaConexion))
            {
                conexion.Open();
                using (var comando = new SqlCommand("Select * From Producto", conexion))
                {
                    using (var lector = comando.ExecuteReader())
                    {
                        //lector diferente de null y lector tiene filas
                        if (lector != null && lector.HasRows)
                        {
                            Producto producto;
                            while (lector.Read())
                            {
                                producto = new Producto();
                                producto.IdProducto = int.Parse(lector[0].ToString());
                                producto.Nombre = lector[1].ToString();
                                producto.Marca = lector[2].ToString();
                                producto.Precio = Convert.ToDecimal(lector[3].ToString());
                                producto.Stock = int.Parse(lector[4].ToString());
                                producto.IdCategoria = int.Parse(lector[7].ToString());
                                
                                listado.Add(producto);
                            }
                        }
                    }
                }
            }
            return listado;
        }
        public Producto BuscarPorId(int id)
        {
            Producto producto = new Producto();
            using (var conexion = new SqlConnection(cadenaConexion))
            {
                conexion.Open();
                using (var comando = new SqlCommand("SELECT * FROM Producto WHERE IdProducto=@id", conexion))
                {
                    comando.Parameters.AddWithValue("@id", id);
                    using (var lector = comando.ExecuteReader())
                    {
                        if (lector != null && lector.HasRows)
                        {
                            lector.Read();
                            producto = new Producto();
                            producto.IdProducto = int.Parse(lector[0].ToString());
                            producto.Nombre = lector[1].ToString();
                            producto.Marca = lector[2].ToString();
                            producto.Precio = Convert.ToDecimal(lector[3].ToString());
                            producto.Stock = int.Parse(lector[4].ToString());
                            producto.IdCategoria = int.Parse(lector[7].ToString());
                        }
                    }
                }
            }
            return producto;
        }
        public bool Insertar(Producto producto)
        {
            int filasInsertadas = 0;
            using (var conexion = new SqlConnection(cadenaConexion))
            {
                conexion.Open();
                var sql = "INSERT INTO Producto (Nombre, Marca, " +
                                "Precio, Stock, IdCategoria)" +
                            "VALUES(@Nombre, @Marca, @Precio, @Stock, " +
                                "@IdCategoria)";
                using (var comando = new SqlCommand(sql, conexion))
                {
                    comando.Parameters.AddWithValue("@Nombre", producto.Nombre);
                    comando.Parameters.AddWithValue("@Marca", producto.Marca);
                    comando.Parameters.AddWithValue("@Precio", producto.Precio);
                    comando.Parameters.AddWithValue("@Stock", producto.Stock);
                    comando.Parameters.AddWithValue("@IdCategoria", producto.IdCategoria);
                    filasInsertadas = comando.ExecuteNonQuery();
                }
            }
            return filasInsertadas > 0;

        }
        public bool Actualizar(Producto producto)
        {
            int filasActualizadas = 0;
            using (var conexion = new SqlConnection(cadenaConexion))
            {
                conexion.Open();
                var sql = "UPDATE Producto SET Nombre = @Nombre, Marca = @Marca, " +
                    "Precio = @Precio, Stock = @Stock, " +
                    "IdCategoria = @IdCategoria WHERE IdProducto=@id";
                using (var comando = new SqlCommand(sql, conexion))
                {
                    comando.Parameters.AddWithValue("@Nombre", producto.Nombre);
                    comando.Parameters.AddWithValue("@Marca", producto.Marca);
                    comando.Parameters.AddWithValue("@Precio", producto.Precio);
                    comando.Parameters.AddWithValue("@Stock", producto.Stock);
                    comando.Parameters.AddWithValue("@IdCategoria", producto.IdCategoria);
                    comando.Parameters.AddWithValue("@id", producto.IdProducto);
                    filasActualizadas = comando.ExecuteNonQuery();
                }
            }
            return filasActualizadas > 0;
        }
        public bool Eliminar(int id)
        {
            int filasEiminadas = 0;
            using (var conexion = new SqlConnection(cadenaConexion))
            {
                conexion.Open();
                var sql = "DELETE FROM Producto WHERE IdProducto=@id";
                using (var comando = new SqlCommand(sql, conexion))
                {
                    comando.Parameters.AddWithValue("@id", id);
                    filasEiminadas = comando.ExecuteNonQuery();
                }
            }
            return filasEiminadas > 0;
        }
    }

}

