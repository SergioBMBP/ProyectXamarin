using ProyectXamarin.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace ProyectXamarin.Models
{
    public class Usuarios:IUsuarios
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public string Password { get; set; }
        public string Funcion { get; set; }
        public string Mail { get; set; }
        public int Telf { get; set; }
    }
}
