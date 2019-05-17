using System;
using System.Collections.Generic;
using System.Text;

namespace ProyectXamarin.Models
{
    public interface IUsuarios
    {
        int Id { get; set; }
        String Nombre { get; set; }
        String Password { get; set; }
        String Funcion { get; set; }
        String Mail { get; set; }
        int Telf { get; set; }
    }
}
