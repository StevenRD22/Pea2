using Pea2.Dominio;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pea2.Data
{
    public class CategoriaData
    {
        string cadenaConexion = "server=localhost; database=Parcial; Integrated security=true";
        public List<Categoria> Listar()
        {
            var listado = new List<Categoria>();
            using (var conexion = new SqlConnection(cadenaConexion))
            {
                conexion.Open();
                using (var comando = new SqlCommand("Select * From Categoria", conexion))
                {
                    using (var lector = comando.ExecuteReader())
                    {
                        //lector diferente de null y lector tiene filas
                        if (lector != null && lector.HasRows)
                        {
                            Categoria cat;
                            while (lector.Read())
                            {
                                cat = new Categoria();
                                cat.IdCategoria = int.Parse(lector[0].ToString());
                                cat.Nombre = lector[2].ToString();
                                listado.Add(cat);
                            }
                        }
                    }
                }
            }
            return listado;
        }
        public Categoria BuscarPorId(int id)
        {
            var categoria = new Categoria();
            return categoria;
        }
    }
}
