using ProyectXamarin.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace ProyectXamarin.Repositories
{
    public interface IRepositoryPedidos
    {
        Task<List<Pedidos>> GetPedidos();
        Task RealizarPedido(List<Articulos> articulos, int idPedido);
       Task<int> GetMaximoPedido();
        Task<List<Pedidos>> GetPedidosUsuario(int id,String token);
    }
}
