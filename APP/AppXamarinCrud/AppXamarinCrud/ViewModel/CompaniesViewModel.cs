using AppXamarinCrud.Model;
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
    public class CompaniesViewModel : Company
    {
        private Task<ObservableCollection<Company>> CompaniesTask { get; set; }
        private ObservableCollection<Company> CompaniesAux { get; set; }
        public ObservableCollection<Company> Companies { get; set; }

        Company model;

        CompaniesService servicio = new CompaniesService();

        public CompaniesViewModel()
        {
            ListViewAsync();
            SaveCommand = new Command(async () => await Save(), () => !IsBusy);
            ModifyCommand = new Command(async () => await Modify(), () => !IsBusy);
            DeleteCommand = new Command(async () => await Delete(), () => !IsBusy);
            CleanCommand = new Command(Clean, () => !IsBusy);
            GoCommand = new Command(Go, () => !IsBusy);
            BackCommand = new Command(Back, () => !IsBusy);
        }

        private async Task ListViewAsync()
        {
            Companies = new ObservableCollection<Company>();
            CompaniesTask = servicio.Consult();
            CompaniesAux = await CompaniesTask;
            for (int i = 0; i < CompaniesAux.Count; i++)
            {
                Companies.Add(CompaniesAux[i]);
            }
        }

        public bool GoBool { get; set; }

        public Command SaveCommand { get; set; }

        public Command ModifyCommand { get; set; }

        public Command DeleteCommand { get; set; }

        public Command CleanCommand { get; set; }

        public Command GoCommand { get; set; }

        public Command BackCommand { get; set; }

        private async Task Save()
        {
            IsBusy = true;
            Guid idCompany = Guid.NewGuid();
            model = new Company()
            {
                Name = Name,
                FoundationDate = FoundationDate,
                Picture = Picture,
                Id = idCompany.ToString()
            };
            if (string.IsNullOrEmpty(model.Name))
            {
                await Application.Current.MainPage.DisplayAlert("Error", "El nombre no puede ser nulo", "Aceptar");
            }
            else
            {
                var sent = await servicio.Save(model);
                if (sent)
                {
                    Companies.Add(model);
                    Clean();
                }
            }
            await Task.Delay(2000);
            IsBusy = false;
        }

        private async Task Modify()
        {
            IsBusy = true;
            model = new Company()
            {
                Name = Name,
                FoundationDate = FoundationDate,
                Picture = Picture,
                Id = Id
            };
            var sent = await servicio.Modify(model);
            if (sent)
            {
                var item = Companies.FirstOrDefault(i => i.Id == model.Id);
                if (item != null)
                {
                    item.Name = model.Name;
                    item.FoundationDate = model.FoundationDate;
                    item.Picture = model.Picture;
                }
                Clean();
            }
            await Task.Delay(2000);
            IsBusy = false;
        }

        private async Task Delete()
        {
            IsBusy = true;
            model = new Company()
            {
                Name = Name,
                FoundationDate = FoundationDate,
                Picture = Picture,
                Id = Id
            };
            var sent = await servicio.Delete(model.Id);
            if (sent)
            {
                var item = Companies.FirstOrDefault(i => i.Id == model.Id);
                Companies.Remove(item);
                Clean();
            }
            await Task.Delay(2000);
            IsBusy = false;
        }

        private void Clean()
        {
            Name = "";
            FoundationDate = new DateTime(0000,00,00);
            Picture = null;
            Id = "";
        }

        private void Go()
        {
            if (GoBool == false)
            {
                GoBool = true;
            }
            else
            {
                GoBool = false;
            }
        }

        private void Back()
        {
            Application.Current.MainPage = new NavigationPage(new Main());
        }

    }
}

