using ProyectXamarin.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace ProyectXamarin.Services
{
    public class SessionService
    {
        public String SesionToken { get; set; }
        public Usuarios User { get; set; }
        public SessionService()
        {            
            this.User = new Usuarios();
        }

       
    }
}
