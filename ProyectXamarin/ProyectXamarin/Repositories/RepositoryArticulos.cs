using ProyectXamarin.Models;
using ProyectXamarin.Tools;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace ProyectXamarin.Repositories
{
    public class RepositoryArticulos:IRepositoryArticulos
    {
        private ApiConnect connect;

        public RepositoryArticulos() {
            this.connect = new ApiConnect();

        }

        public async Task<List<Articulos>> GetArticulos()
        {
            List<Articulos> articulos = await this.connect.CallApi<List<Articulos>>("api/Articulos");
            return articulos;
        }
        public async Task<Articulos> GetArticulo(int id)
        {
            Articulos  articulo = await this.connect.CallApi<Articulos>("api/Articulos/"+id);
            return articulo;
        }

        public async Task<List<Articulos>> GetArticulos(String marca)
        {
            List<Articulos> articulos = await this.connect.CallApi<List<Articulos>>("api/ArticulosMarca/"+marca);
            return articulos;
        }
    }
}
