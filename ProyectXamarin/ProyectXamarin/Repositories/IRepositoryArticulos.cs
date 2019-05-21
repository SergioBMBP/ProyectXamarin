using ProyectXamarin.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace ProyectXamarin.Repositories
{
    public interface IRepositoryArticulos
    {
        Task<List<Articulos>> GetArticulos();
        Task<List<Articulos>> GetArticulos(String marca);
        Task<Articulos> GetArticulo(int id);
    }
}
