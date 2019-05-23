using Autofac;
using ProyectXamarin.Services;
using ProyectXamarin.ViewModels;
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

            builder.RegisterType<SessionService>().SingleInstance();
            builder.RegisterType<MasterPageItemViewModel>();
            builder.RegisterType<UsuarioViewModel>();
            


            //Hasta aqui
            this.Container = builder.Build();
        }

        
        //crear metodos por cada dependencia
        public SessionService SessionService
        {
            get { return this.Container.Resolve<SessionService>(); }
        }

        public UsuarioViewModel UsuarioViewModel
        {
            get { return this.Container.Resolve<UsuarioViewModel>(); }
        }

        public MasterPageItemViewModel MasterPageItemViewModel
        {
            get { return this.Container.Resolve<MasterPageItemViewModel>(); }
        }


    }
}
