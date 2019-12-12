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
    public partial class Options : ContentPage
    {
        OptionsViewModel Context = new OptionsViewModel();
        public Options()
        {
            InitializeComponent();
            NavigationPage.SetHasNavigationBar(this, false);
            BindingContext = Context;
        }
    }
}