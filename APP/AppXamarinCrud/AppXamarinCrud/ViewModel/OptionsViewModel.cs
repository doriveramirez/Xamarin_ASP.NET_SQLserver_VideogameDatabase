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
using VideogameDatabase.Model;
using Xamarin.Forms;

namespace MVVM.ViewModel
{
    public class OptionsViewModel: Connection
    {

        OptionsService service = new OptionsService();

        public Connection Con { get; set; }

        public string Url { get; set; }

        public OptionsViewModel()
        {
            Update();
            SaveCommand = new Command(async () => await Save(), () => !IsBusy);
            BackCommand = new Command(Back, () => !IsBusy);
        }

        public Command BackCommand { get; set; }
        public Command SaveCommand { get; set; }

        private void Update()
        {
            Url = service.ConsultLocal().Url;
        }

        private async Task Save()
        {
            bool successful;
            IsBusy = true;
            Con = new Connection()
            {
               Url  = Url
            };
            if (string.IsNullOrEmpty(Con.Url))
            {
                await Application.Current.MainPage.DisplayAlert("Error", "La dirección no puede ser nula", "Aceptar");
            }
            else
            {
                successful = await service.SaveLocalAsync(Con);
                if (successful)
                {
                    await Application.Current.MainPage.DisplayAlert("Felicidades", "Se ha conectado satisfactoriamente a la url: " + Con.Url, "Aceptar");
                }
                else
                {
                    await Application.Current.MainPage.DisplayAlert("Error", "No se ha podido conectar a la url: " + Con.Url, "Aceptar");
                }
            }
            await Task.Delay(2000);
            IsBusy = false;
        }

        private void Back()
        {
            Application.Current.MainPage = new NavigationPage(new Main());
        }

    }
}


