using ProyectXamarin.Models;
using ProyectXamarin.Tools;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace ProyectXamarin.Repositories
{
    public class RepositoryPedidos:IRepositoryPedidos
    {
        private ApiConnect connect;

        public RepositoryPedidos()
        {
            this.connect = new ApiConnect();

        }
        public async Task<List<Pedidos>> GetPedidos() {
            List<Pedidos> articulos = await this.connect.CallApi<List<Pedidos>>("api/Articulos");
            return articulos;
        }
    }
}
