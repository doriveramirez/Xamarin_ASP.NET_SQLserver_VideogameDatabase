using MVVM.Model;
using MVVM.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace MVVM.View
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class DistribuidoraPage : ContentPage
    {
        DistribuidoraViewModel Contexto = new DistribuidoraViewModel();
        public DistribuidoraPage()
        {
            InitializeComponent();
            BindingContext = Contexto;
            LvDistribuidora.ItemSelected += LvDistribuidoras_ItemSelected;
        }

        private void LvDistribuidoras_ItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            if (e.SelectedItem != null)
            {
                Distribuidora modelo = (Distribuidora)e.SelectedItem;
                if (Contexto.IrBool)
                {
                    Navigation.PushAsync(new DetallePage(modelo));
                }
                Contexto.Nombre = modelo.Nombre;
                Contexto.NumeroJuegosPublicados = modelo.NumeroJuegosPublicados;
                Contexto.Imagen = modelo.Imagen;
                Contexto.Id = modelo.Id;
            }
        }
    }
}