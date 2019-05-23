﻿using ProyectXamarin.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace ProyectXamarin.Repositories
{
    public interface IRepositoryUsuarios
    {
       Task<Usuarios> GetUsuario(String nombre, String password);
    }
}
