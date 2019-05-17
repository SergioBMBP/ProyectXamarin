using Autofac;
using System;
using System.Collections.Generic;
using System.Text;

namespace ProyectXamarin.Configuration
{
    public class IoCConfiguration
    {
        public IContainer Container;
        public IoCConfiguration() {
            ContainerBuilder builder = new ContainerBuilder();
            //Registrar aqui las dependencias


            //Hasta aqui
            this.Container = builder.Build();
        }
        //crear metodos por cada dependencia

    }
}
