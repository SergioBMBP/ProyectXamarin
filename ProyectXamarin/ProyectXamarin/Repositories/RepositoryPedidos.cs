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
        private StorageSession session;
        public RepositoryPedidos()
        {
            this.connect = new ApiConnect();
            this.session = new StorageSession();

        }
        public async Task<List<Pedidos>> GetPedidos() {
            List<Pedidos> articulos = await this.connect.CallApi<List<Pedidos>>("api/Articulos");
            return articulos;
        }

        public async Task RealizarPedido(List<Articulos> articulos, int idPedido)
        {
            Usuarios usuario = await this.session.GetStorageUser();
            String token = await this.session.GetStorageToken();
            foreach (Articulos articulo in articulos)
            {
                Pedidos pedido = new Pedidos();
                pedido.Id = usuario.Id;
                pedido.Id_Articulos = articulo.Id_Articulos;
                pedido.Producto = articulo.Nombre;
                pedido.Fecha = DateTime.Now;
                pedido.Cantidad_Pedida = articulo.Cantidad;
                pedido.Id_Pedido = idPedido;


                await this.connect.CallApiPost(pedido, "api/InsertarPedido", token);
            }
        }
    }
}
