using AppXamarinCrud.Model;
using AppXamarinCrud.ViewModel;
using MVVM.View;
using MVVM.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace AppXamarinCrud.View
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Reviews : ContentPage
    {
        ReviewsViewModel Context = new ReviewsViewModel();

        public Reviews()
        {
            InitializeComponent();
            BindingContext = Context;
            LvReviews.ItemSelected += LvReviews_ItemSelected;
        }

        private void LvReviews_ItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            if (e.SelectedItem != null)
            {
                Review model = (Review)e.SelectedItem;
                if (Context.GoBool)
                {
                    ((ListView)sender).SelectedItem = null;
                    //Navigation.PushAsync(new DetallePage(model));
                }
                Context.Nombre = model.Name;
                Context.NumeroJuegosPublicados = model.NumeroJuegosPublicados;
                Context.Imagen = model.Imagen;
                Context.Id = model.Id;
            }
        }
    }
}