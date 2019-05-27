using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace ProyectXamarin.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class DetallesArticulosView : ContentPage
    {
        public DetallesArticulosView()
        {
            InitializeComponent();
            controlstepper1.ValueChanged += OnValueChanged1;
        }
        private void OnValueChanged1(object sender, ValueChangedEventArgs e)
        {

            this.lblvalor1.Text = e.NewValue.ToString();
        }
    }
}