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
    public partial class Videogames : ContentPage
    {
        VideogamesViewModel Context = new VideogamesViewModel();

        public Videogames()
        {
            InitializeComponent();
            NavigationPage.SetHasNavigationBar(this, false);
            BindingContext = Context;
            LvVideogames.ItemSelected += LvVideogames_ItemSelected;
        }

        private void LvVideogames_ItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            if (e.SelectedItem != null)
            {
                Videogame model = (Videogame)e.SelectedItem;
                if (Context.GoBool)
                {
                    ((ListView)sender).SelectedItem = null;
                    //Navigation.PushAsync(new DetallePage(model));
                }
                Context.Name = model.Name;
                Context.ReleaseDate = model.ReleaseDate;
                Context.SoldUnits = model.SoldUnits;
                Context.UserID = model.UserID;
                Context.DistributorID = model.DistributorID;
                Context.Picture = model.Picture;
                Context.Description = model.Description;
                Context.Id = model.Id;
            }
        }
    }
}