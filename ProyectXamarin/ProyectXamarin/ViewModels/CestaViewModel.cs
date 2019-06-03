using ProyectXamarin.Base;
using ProyectXamarin.Models;
using ProyectXamarin.Repositories;
using ProyectXamarin.Services;
using ProyectXamarin.Views;
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

            this.CargarCesta();
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


        private int _PrecioTotal;
        public int PrecioTotal
        {
            get { return this._PrecioTotal; }
            set
            {
                this._PrecioTotal = value; OnPropertyChanged("PrecioTotal");
            }
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
                    
                    if (articulos.Count <= 0)
                    {
                        this.PrecioTotal = 0;
                        this.buttonEnable = false;
                    } else
                    {
                        SumarPrecio();
                    }
                });
            }
        }

        public Command MostrarDetalles
        {
            get
            {
                return new Command(async (articulo) =>
                {
                    DetallesArticulosView view = new DetallesArticulosView();
                    ArticuloViewModel viewmodel = new ArticuloViewModel();
                    Articulos art = articulo as Articulos;

                    viewmodel.Articulo = art;
               
                    view.BindingContext = viewmodel;
                    await Application.Current.MainPage.Navigation.PushModalAsync(view);
                    MessagingCenter.Subscribe<CestaViewModel>(this, "UPDATE", async (sender) => {
                        this.CargarCesta();
                    });

            });
            }
        }

        private void CargarCesta()
        {
            if (App.Locator.SessionService.Cesta.Count > 0)
            {
                List<Articulos> lista = App.Locator.SessionService.Cesta;
                this.Cesta = new ObservableCollection<Articulos>(lista);
                this.buttonEnable = true;
                SumarPrecio();
            }
            else
            {
                this.buttonEnable = false;
            }
        }


        private void SumarPrecio()
        {
            int multiplicacion = 0;
            this.PrecioTotal = 0;
            foreach (Articulos articulo in this.Cesta)
            {
                multiplicacion = articulo.CantidadCesta * articulo.Precio;
                this.PrecioTotal += multiplicacion;
            }
        }
    }
}
