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
    public partial class Platforms : ContentPage
    {
        PlatformsViewModel Context = new PlatformsViewModel();

        public Platforms()
        {
            InitializeComponent();
            NavigationPage.SetHasNavigationBar(this, false);
            BindingContext = Context;
            LvPlatforms.ItemSelected += LvPlatforms_ItemSelected;
        }

        private void LvPlatforms_ItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            if (e.SelectedItem != null)
            {
                Platform model = (Platform)e.SelectedItem;
                if (Context.GoBool)
                {
                    ((ListView)sender).SelectedItem = null;
                    //Navigation.PushAsync(new DetallePage(model));
                }
                Context.Name = model.Name;
                Context.ReleaseDate = model.ReleaseDate;
                Context.SoldUnits = model.SoldUnits;
                Context.Description = model.Description;
                //Context.Picture = model.Picture;
                Context.Author = model.Author;
                Context.Id = model.Id;
            }
        }
    }
}