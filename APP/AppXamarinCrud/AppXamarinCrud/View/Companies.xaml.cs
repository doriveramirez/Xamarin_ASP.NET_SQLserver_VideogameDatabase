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
    public partial class Companies : ContentPage
    {
        CompaniesViewModel Context = new CompaniesViewModel();

        public Companies()
        {
            InitializeComponent();
            NavigationPage.SetHasNavigationBar(this, false);
            BindingContext = Context;
            LvCompanies.ItemSelected += LvCompanies_ItemSelected;
        }

        private void LvCompanies_ItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            if (e.SelectedItem != null)
            {
                Company model = (Company)e.SelectedItem;
                if (Context.GoBool)
                {
                    ((ListView)sender).SelectedItem = null;
                    //Navigation.PushAsync(new DetallePage(model));
                }
                Context.Name = model.Name;
                Context.FoundationDate = model.FoundationDate;
                Context.Picture = model.Picture;
                Context.Id = model.Id;
            }
        }
    }
}