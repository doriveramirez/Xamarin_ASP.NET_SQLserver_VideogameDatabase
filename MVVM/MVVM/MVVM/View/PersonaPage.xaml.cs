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
    public partial class PersonaPage : ContentPage
    {
        PersonaViewModel contexto = new PersonaViewModel();
        public PersonaPage()
        {
            InitializeComponent();
            BindingContext = contexto;
            //LvPersonas.ItemSelected += LvPersonas_ItemSelected;
        }

        //private void LvPersonas_ItemSelected(object sender, SelectedItemChangedEventArgs e)
        //{
        //    if (e.SelectedItem != null)
        //    {
        //        Distribuidora distribuidora = (Distribuidora)e.SelectedItem;
        //        if (contexto.IrBool)
        //        {
        //            Navigation.PushAsync(new DetallePage(distribuidora));
        //        }
        //        contexto.Nombre = distribuidora.Nombre;
        //        contexto.NumeroJuegosPublicados = distribuidora.NumeroJuegosPublicados;
        //        contexto.Id = distribuidora.Id;
        //    }
        //}
    }
}