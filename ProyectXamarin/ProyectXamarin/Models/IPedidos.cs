using System;
using System.Collections.Generic;
using System.Text;

namespace ProyectXamarin.Models
{
    public interface IPedidos
    {
        int Id_Pedido { get; set; }
        String Producto { get; set; }
        int Cantidad_Pedida { get; set; }
        DateTime Fecha { get; set; }
        int Id { get; set; }
        int Id_Articulos { get; set; }
    }
}
