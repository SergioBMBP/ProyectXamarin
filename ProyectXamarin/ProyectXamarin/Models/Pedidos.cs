using ProyectXamarin.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace ProyectXamarin.Models
{
    public class Pedidos :IPedidos
    {
        public int Id_Pedido { get; set; }
        public string Producto { get; set; }
        public int Cantidad_Pedida { get; set; }
        public DateTime Fecha { get; set; }
        public int Id { get; set; }
        public int Id_Articulos { get; set; }
    }
}
