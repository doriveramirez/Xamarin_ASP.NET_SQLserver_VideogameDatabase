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
        DistribuidoraViewModel contexto = new DistribuidoraViewModel();
        public DistribuidoraPage()
        {
            InitializeComponent();
            BindingContext = contexto;
            //LvDistribuidora.ItemSelected += LvDistribuidoras_ItemSelected;
        }

        private void LvDistribuidoras_ItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            if (e.SelectedItem != null)
            {
                Distribuidora modelo = (Distribuidora)e.SelectedItem;
                if (contexto.IrBool)
                {
                    Navigation.PushAsync(new DetallePage(modelo));
                }
                contexto.Nombre = modelo.Nombre;
                contexto.NumeroJuegosPublicados = modelo.NumeroJuegosPublicados;
                contexto.Imagen = modelo.Imagen;
                contexto.Id = modelo.Id;
            }
        }
    }
}