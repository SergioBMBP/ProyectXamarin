using ProyectXamarin.Base;
using ProyectXamarin.Models;
using ProyectXamarin.Repositories;
using ProyectXamarin.Services;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using Xamarin.Forms;

namespace ProyectXamarin.ViewModels
{
    public class CestaViewModel: ViewModelBase
    {
        IRepositoryPedidos repo;
        
        public CestaViewModel()
        {
            if(App.Locator.SessionService.Cesta.Count > 0)
            {
                List<Articulos> lista = App.Locator.SessionService.Cesta;
                this.Cesta = new ObservableCollection<Articulos>(lista);
                this.buttonEnable = true;
            } else
            {
                this.buttonEnable = false;
            }
            
            this.repo = new RepositoryPedidos();
        }

        private ObservableCollection<Articulos> _Cesta;
        public ObservableCollection<Articulos> Cesta
        {
            get { return this._Cesta; }
            set { this._Cesta = value; OnPropertyChanged("Cesta"); }
        }

        private bool _buttonEnable;
        public bool buttonEnable
        {
            get { return this._buttonEnable; }
            set { this._buttonEnable = value; OnPropertyChanged("buttonEnable"); }
        }



        public Command RealizarPedido
        {
            get
            {
                return new Command(async () =>
                {

                    int idPedido = await this.repo.GetMaximoPedido();
                    
                    List<Articulos> lista = new List<Articulos>(Cesta);
                    await this.repo.RealizarPedido(lista, idPedido);

                });
            }
        }

        public Command EliminarArticuloCesta {
            get
            {
                return new Command((sender) =>
                {
                    Articulos articulo = sender as Articulos;
                    int index = App.Locator.SessionService.Cesta.IndexOf(articulo);
                    App.Locator.SessionService.Cesta.RemoveAt(index);
                    List<Articulos> articulos = App.Locator.SessionService.Cesta;
                    this.Cesta = new ObservableCollection<Articulos>(articulos);
                    if(articulos.Count <= 0)
                    {
                        this.buttonEnable = false;
                    }
                });
            }
        }
    }
}
