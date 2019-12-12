using AppXamarinCrud.Model;
using AppXamarinCrud.Service;
using AppXamarinCrud.View;
using MVVM.Model;
using MVVM.Service;
using MVVM.View;
using Newtonsoft.Json;
//using OfficeOpenXml.FormulaParsing.Excel.Functions.Text;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace MVVM.ViewModel
{
    public class OptionsViewModel
    {

        OptionsService servicio = new OptionsService();

        public OptionsViewModel()
        {
            BackCommand = new Command(Back);
        }

        public Command BackCommand { get; set; }

        private void Back()
        {
            Application.Current.MainPage = new NavigationPage(new Main());
        }

    }
}


