using Pea2.Data;
using Pea2.Dominio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pea2.Logic
{
    public static class CategoriaBL
    {
        public static List<Categoria> Listar()
        {
            var categoriaData = new CategoriaData();
            return categoriaData.Listar();
        }
    }
}
