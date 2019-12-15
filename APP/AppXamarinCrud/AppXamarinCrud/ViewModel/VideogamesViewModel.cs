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
        public List<User> Users { get; set; }

        private Task<ObservableCollection<Distributor>> DistributorsTask { get; set; }
        private ObservableCollection<Distributor> DistributorsAux { get; set; }
        public List<Distributor> Distributors { get; set; }

        Videogame model;

        VideogamesService service = new VideogamesService();

        public VideogamesViewModel()
        {
            ReleaseDate = DateTime.Now;
            Videogames = new ObservableCollection<Videogame>();
            ListView();
            ListViewAsync();
            SaveCommand = new Command(async () => await Save(), () => !IsBusy);
            ModifyCommand = new Command(async () => await Modify(), () => !IsBusy);
            DeleteCommand = new Command(async () => await Delete(), () => !IsBusy);
            CleanCommand = new Command(Clean, () => !IsBusy);
            GoCommand = new Command(Go, () => !IsBusy);
            BackCommand = new Command(Back, () => !IsBusy);
            ChangeUserIDCommand = new Command(ChangeUserID, () => !IsBusy);
            ChangeDistributorIDCommand = new Command(ChangeDistributorID, () => !IsBusy);
        }

        private void ListView()
        {

            VideogamesAux = service.ConsultLocal();
            for (int i = 0; i < VideogamesAux.Count; i++)
            {
                Videogames.Add(VideogamesAux[i]);
            }
            Users = new List<User>();
            UsersAux = service.ConsultUserLocal();
            for (int i = 0; i < UsersAux.Count; i++)
            {
                Users.Add(UsersAux[i]);
            }
            Distributors = new List<Distributor>();
            DistributorsAux = service.ConsultDistributorLocal();
            for (int i = 0; i < DistributorsAux.Count; i++)
            {
                Distributors.Add(DistributorsAux[i]);
            }
        }

        private async Task ListViewAsync()
        {
            VideogamesTask = service.Consult();
            VideogamesAux = await VideogamesTask;
            for (int i = 0; i < VideogamesAux.Count; i++)
            {
                Videogames.Add(VideogamesAux[i]);
            }
            Users = new List<User>();
            UsersTask = service.ConsultUser();
            UsersAux = await UsersTask;
            for (int i = 0; i < UsersAux.Count; i++)
            {
                Users.Add(UsersAux[i]);
            }
            DistributorsTask = service.ConsultDistributor();
            DistributorsAux = await DistributorsTask;
            for (int i = 0; i < DistributorsAux.Count; i++)
            {
                Distributors.Add(DistributorsAux[i]);
            }
        }

        public bool GoBool { get; set; }

        public Command SaveCommand { get; set; }

        public Command ModifyCommand { get; set; }

        public Command DeleteCommand { get; set; }

        public Command CleanCommand { get; set; }

        public Command GoCommand { get; set; }

        public Command BackCommand { get; set; }

        public Command ChangeUserIDCommand { get; set; }

        public Command ChangeDistributorIDCommand { get; set; }

        private int UsersID = 0;
        private int DistributorsID = 0;

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
                //Picture = Picture,
                Description = Description,
                Id = idVideogame.ToString()
            };
            if (string.IsNullOrEmpty(model.Name))
            {
                await Application.Current.MainPage.DisplayAlert("Error", "El nombre no puede ser nulo", "Aceptar");
            }
            else
            {
                service.SaveLocal(model);
                service.Save(model);
                Videogames.Add(model);
                Clean();
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
                //Picture = Picture,
                Description = Description,
                Id = Id
            };
            service.ModifyLocal(model);
            service.Modify(model);
            var item = Videogames.FirstOrDefault(i => i.Id == model.Id);
            if (item != null)
            {
                item.Name = model.Name;
                item.ReleaseDate = model.ReleaseDate;
                item.SoldUnits = model.SoldUnits;
                item.UserID = model.UserID;
                item.DistributorID = model.DistributorID;
                //item.Picture = model.Picture;
                item.Description = model.Description;
                item.Id = model.Id;
            }
            Clean();
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
                //Picture = Picture,
                Description = Description,
                Id = Id
            };
            service.DeleteLocal(model);
            service.Delete(model.Id);
            var item = Videogames.FirstOrDefault(i => i.Id == model.Id);
            Videogames.Remove(item);
            Clean();
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
            //Picture = null;
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

        private void ChangeUserID()
        {
            if (UserID == Users[UsersID].Id)
            {
                if (UsersID + 1 >= Users.Count)
                {
                    UsersID = 0;
                }
                else
                {
                    UsersID++;
                }
                UserID = Users[UsersID].Id;
            }
            else
            {
                UserID = Users[UsersID].Id;
                if (UsersID + 1 >= Users.Count)
                {
                    UsersID = 0;
                }
                else
                {
                    UsersID++;
                }
            }

        }

        private void ChangeDistributorID()
        {
            if (DistributorID == Distributors[DistributorsID].Id)
            {
                if (DistributorsID + 1 >= Distributors.Count)
                {
                    DistributorsID = 0;
                }
                else
                {
                    DistributorsID++;
                }
                DistributorID = Distributors[DistributorsID].Id;
            }
            else
            {
                DistributorID = Distributors[DistributorsID].Id;
                if (DistributorsID + 1 >= Distributors.Count)
                {
                    DistributorsID = 0;
                }
                else
                {
                    DistributorsID++;
                }
            }
        }

    }
}


