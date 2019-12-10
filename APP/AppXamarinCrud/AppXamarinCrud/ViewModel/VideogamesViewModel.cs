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
    public class VideogamesViewModel : Videogame
    {
        private Task<ObservableCollection<Videogame>> VideogamesTask { get; set; }
        private ObservableCollection<Videogame> VideogamesAux { get; set; }
        public ObservableCollection<Videogame> Videogames { get; set; }
        private Task<ObservableCollection<User>> UsersTask { get; set; }
        private ObservableCollection<User> UsersAux { get; set; }
        public ObservableCollection<User> Users { get; set; }

        private Task<ObservableCollection<Distributor>> DistributorsTask { get; set; }
        private ObservableCollection<Distributor> DistributorsAux { get; set; }
        public ObservableCollection<Distributor> Distributors { get; set; }

        Videogame model;

        VideogamesService servicio = new VideogamesService();

        public VideogamesViewModel()
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
            Videogames = new ObservableCollection<Videogame>();
            VideogamesTask = servicio.Consult();
            VideogamesAux = await VideogamesTask;
            for (int i = 0; i < VideogamesAux.Count; i++)
            {
                Videogames.Add(VideogamesAux[i]);
            }
            Users = new ObservableCollection<User>();
            UsersTask = servicio.ConsultUser();
            UsersAux = await UsersTask;
            for (int i = 0; i < UsersAux.Count; i++)
            {
                Console.WriteLine(UsersAux[i].Dni);
                Users.Add(UsersAux[i]);
            }
            Distributors = new ObservableCollection<Distributor>();
            DistributorsTask = servicio.ConsultDistributor();
            DistributorsAux = await DistributorsTask;
            for (int i = 0; i < DistributorsAux.Count; i++)
            {
                Console.WriteLine(DistributorsAux[i].Name);
                Distributors.Add(DistributorsAux[i]);
            }
            //var Users = servicio.ConsultUser();
            //for (int i = 0; i < Users.Count; i++)
            //{
            //    Videogames.Add(VideogamesAux[i]);
            //}
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
            Guid idVideogame = Guid.NewGuid();
            model = new Videogame()
            {
                Name = Name,
                ReleaseDate = ReleaseDate,
                SoldUnits = SoldUnits,
                UserID = UserID,
                DistributorID = DistributorID,
                Picture = Picture,
                Description = Description,
                Id = idVideogame.ToString()
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
                    Videogames.Add(model);
                    Clean();
                }
            }
            await Task.Delay(2000);
            IsBusy = false;
        }

        private async Task Modify()
        {
            IsBusy = true;
            model = new Videogame()
            {
                Name = Name,
                ReleaseDate = ReleaseDate,
                SoldUnits = SoldUnits,
                UserID = UserID,
                DistributorID = DistributorID,
                Picture = Picture,
                Description = Description,
                Id = Id
            };
            var sent = await servicio.Modify(model);
            if (sent)
            {
                var item = Videogames.FirstOrDefault(i => i.Id == model.Id);
                if (item != null)
                {
                    item.Name = model.Name;
                    item.ReleaseDate = model.ReleaseDate;
                    item.SoldUnits = model.SoldUnits;
                    item.UserID = model.UserID;
                    item.DistributorID = model.DistributorID;
                    item.Picture = model.Picture;
                    item.Description = model.Description;
                    item.Picture = model.Picture;
                    item.Id = model.Id;
                }
                Clean();
            }
            await Task.Delay(2000);
            IsBusy = false;
        }

        private async Task Delete()
        {
            IsBusy = true;
            model = new Videogame()
            {
                Name = Name,
                ReleaseDate = ReleaseDate,
                SoldUnits = SoldUnits,
                UserID = UserID,
                DistributorID = DistributorID,
                Picture = Picture,
                Description = Description,
                Id = Id
            };
            var sent = await servicio.Delete(model.Id);
            if (sent)
            {
                var item = Videogames.FirstOrDefault(i => i.Id == model.Id);
                Videogames.Remove(item);
                Clean();
            }
            await Task.Delay(2000);
            IsBusy = false;
        }

        private void Clean()
        {
            Name = "";
            ReleaseDate = DateTime.Now;
            SoldUnits = 0;
            UserID = "";
            DistributorID = "";
            Picture = null;
            Description = "";
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


