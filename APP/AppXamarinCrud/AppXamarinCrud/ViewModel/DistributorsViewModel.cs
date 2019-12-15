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
    public class DistributorsViewModel : Distributor
    {
        private Task<ObservableCollection<Distributor>> DistributorsTask { get; set; }
        private ObservableCollection<Distributor> DistributorsAux { get; set; }
        public ObservableCollection<Distributor> Distributors { get; set; }

        Distributor model;

        DistributorsService service = new DistributorsService();

        public DistributorsViewModel()
        {
            ListView();
            ListViewAsync();
            SaveCommand = new Command(async () => await Save(), () => !IsBusy);
            ModifyCommand = new Command(async () => await Modify(), () => !IsBusy);
            DeleteCommand = new Command(async () => await Delete(), () => !IsBusy);
            CleanCommand = new Command(Clean, () => !IsBusy);
            GoCommand = new Command(Go, () => !IsBusy);
            BackCommand = new Command(Back, () => !IsBusy);
        }

        private void ListView()
        {
            Distributors = new ObservableCollection<Distributor>();
            DistributorsAux = service.ConsultLocal();
            for (int i = 0; i < DistributorsAux.Count; i++)
            {
                Distributors.Add(DistributorsAux[i]);
            }
        }

        private async Task ListViewAsync()
        {
            DistributorsTask = service.Consult();
            DistributorsAux = await DistributorsTask;
            if (DistributorsAux.Count > 0)
            {
                Distributors.Clear();
                for (int i = 0; i < DistributorsAux.Count; i++)
                {
                    Distributors.Add(DistributorsAux[i]);
                }
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
            Guid idDistributor = Guid.NewGuid();
            model = new Distributor()
            {
                Name = Name,
                NumberOfGamesPublished = NumberOfGamesPublished,
                //Picture = Picture,
                Id = idDistributor.ToString()
            };
            if (string.IsNullOrEmpty(model.Name))
            {
                await Application.Current.MainPage.DisplayAlert("Error", "El nombre no puede ser nulo", "Aceptar");
            }
            else
            {
                service.SaveLocal(model);
                service.Save(model);
                Distributors.Add(model);
                Clean();
            }
            await Task.Delay(2000);
            IsBusy = false;
        }

        private async Task Modify()
        {
            IsBusy = true;
            model = new Distributor()
            {
                Name = Name,
                NumberOfGamesPublished = NumberOfGamesPublished,
                //Picture = Picture,
                Id = Id
            };
            service.Modify(model);
            service.ModifyLocal(model);
            var item = Distributors.FirstOrDefault(i => i.Id == model.Id);
            if (item != null)
            {
                item.Name = model.Name;
                item.NumberOfGamesPublished = model.NumberOfGamesPublished;
                //item.Picture = model.Picture;
            }
            Clean();
            await Task.Delay(2000);
            IsBusy = false;
        }

        private async Task Delete()
        {
            IsBusy = true;
            model = new Distributor()
            {
                Name = Name,
                NumberOfGamesPublished = NumberOfGamesPublished,
                //Picture = Picture,
                Id = Id
            };
            service.DeleteLocal(model);
            service.Delete(model.Id);
            var item = Distributors.FirstOrDefault(i => i.Id == model.Id);
            Distributors.Remove(item);
            Clean();
            await Task.Delay(2000);
            IsBusy = false;
        }

        private void Clean()
        {
            Name = "";
            NumberOfGamesPublished = 0;
            //Picture = null;
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

