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
            NavigationPage.SetHasNavigationBar(this, false);
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
                Context.Played = model.Played;
                Context.Mark = model.Mark;
                Context.Description = model.Description;
                Context.UserID = model.UserID;
                Context.VideogameID = model.VideogameID;
                Context.Id = model.Id;
            }
        }
    }
}