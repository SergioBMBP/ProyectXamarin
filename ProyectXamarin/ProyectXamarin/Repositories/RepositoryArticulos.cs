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
            List<Articulos> articulos = await this.connect.CallApi<List<Articulos>>("api/Articulos", null);
            return articulos;
        }
        public async Task<Articulos> GetArticulo(int id)
        {
            Articulos  articulo = await this.connect.CallApi<Articulos>("api/Articulos/"+id, null);
            return articulo;
        }

        public async Task<List<Articulos>> GetArticulos(String marca)
        {
            List<Articulos> articulos = await this.connect.CallApi<List<Articulos>>("api/ArticulosMarca/"+marca, null);
            return articulos;
        }
        public async Task<List<Articulos>> GetLastArticulos()
        {
            List<Articulos> articulos = await this.connect.CallApi<List<Articulos>>("api/Articulos", null);
            int a = articulos.Count - 1;
            List<Articulos> L=new List<Articulos>();
            for (int i = 0; i < 10; i++)
            {
                L.Add(articulos[a]);
                a--;
            }
            return L;
        }

        public async Task<List<String>> GetMarcas()
        {
            List<String> marca = await this.connect.CallApi<List<String>>("api/GetMarca", null);
            
            return marca;
        }
    }
}
