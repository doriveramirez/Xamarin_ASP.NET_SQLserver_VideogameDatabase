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
    public partial class Users : ContentPage
    {
        UsersViewModel Context = new UsersViewModel();

        public Users()
        {
            InitializeComponent();
            NavigationPage.SetHasNavigationBar(this, false);
            BindingContext = Context;
            LvUsers.ItemSelected += LvUsers_ItemSelected;
        }

        private void LvUsers_ItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            if (e.SelectedItem != null)
            {
                User model = (User)e.SelectedItem;
                if (Context.GoBool)
                {
                    ((ListView)sender).SelectedItem = null;
                    //Navigation.PushAsync(new DetallePage(model));
                }
                Context.Name = model.Name;
                Context.Birthday = model.Birthday;
                Context.Dni = model.Dni;
                Context.Password = model.Password;
                Context.Username = model.Username;
                Context.CompanyID = model.CompanyID;
                //Context.Picture = model.Picture;
                Context.Id = model.Id;
            }
        }
    }
}