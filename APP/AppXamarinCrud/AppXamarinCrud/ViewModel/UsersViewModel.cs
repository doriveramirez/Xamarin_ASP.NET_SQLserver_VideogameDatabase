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
    public class UsersViewModel : User
    {
        private Task<ObservableCollection<User>> UsersTask { get; set; }
        private ObservableCollection<User> UsersAux { get; set; }
        public ObservableCollection<User> Users { get; set; }

        private Task<ObservableCollection<Company>> CompaniesTask { get; set; }
        private ObservableCollection<Company> CompaniesAux { get; set; }
        public List<Company> Companies { get; set; }

        User model;

        UsersService servicio = new UsersService();

        public UsersViewModel()
        {
            ListViewAsync();
            SaveCommand = new Command(async () => await Save(), () => !IsBusy);
            ModifyCommand = new Command(async () => await Modify(), () => !IsBusy);
            DeleteCommand = new Command(async () => await Delete(), () => !IsBusy);
            CleanCommand = new Command(Clean, () => !IsBusy);
            GoCommand = new Command(Go, () => !IsBusy);
            BackCommand = new Command(Back, () => !IsBusy);
            ChangeCompanyIDCommand = new Command(ChangeCompanyID, () => !IsBusy);
        }

        private async Task ListViewAsync()
        {
            Users = new ObservableCollection<User>();
            UsersTask = servicio.Consult();
            UsersAux = await UsersTask;
            for (int i = 0; i < UsersAux.Count; i++)
            {
                Users.Add(UsersAux[i]);
            }
            Companies = new List<Company>();
            CompaniesTask = servicio.ConsultCompany();
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

        public Command ChangeCompanyIDCommand { get; set; }

        private int CompaniesID = 0;

        private async Task Save()
        {
            IsBusy = true;
            Guid idUser = Guid.NewGuid();
            model = new User()
            {
                Name = Name,
                Birthday = Birthday,
                Dni = Dni,
                Password = Password,
                Username = Username,
                CompanyID = CompanyID,
                Picture = Picture,
                Id = idUser.ToString()
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
                    Users.Add(model);
                    Clean();
                }
            }
            await Task.Delay(2000);
            IsBusy = false;
        }

        private async Task Modify()
        {
            IsBusy = true;
            model = new User()
            {
                Name = Name,
                Birthday = Birthday,
                Dni = Dni,
                Password = Password,
                Username = Username,
                CompanyID = CompanyID,
                Picture = Picture,
                Id = Id
            };
            var sent = await servicio.Modify(model);
            if (sent)
            {
                var item = Users.FirstOrDefault(i => i.Id == model.Id);
                if (item != null)
                {
                    item.Name = model.Name;
                    item.Birthday = model.Birthday;
                    item.Dni = model.Dni;
                    item.Password = model.Password;
                    item.Username = model.Username;
                    item.CompanyID = model.CompanyID;
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
            model = new User()
            {
                Name = Name,
                Birthday = Birthday,
                Dni = Dni,
                Password = Password,
                Username = Username,
                CompanyID = CompanyID,
                Picture = Picture,
                Id = Id
            };
            var sent = await servicio.Delete(model.Id);
            if (sent)
            {
                var item = Users.FirstOrDefault(i => i.Id == model.Id);
                Users.Remove(item);
                Clean();
            }
            await Task.Delay(2000);
            IsBusy = false;
        }

        private void Clean()
        {
            Name = "";
            Birthday = new DateTime(1900, 01, 01);
            Dni = "";
            Password = "";
            Username = "";
            CompanyID = "";
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

        private void ChangeCompanyID()
        {
            if (CompanyID == Companies[CompaniesID].Id)
            {
                if (CompaniesID + 1 >= Companies.Count)
                {
                    CompaniesID = 0;
                }
                else
                {
                    CompaniesID++;
                }
                CompanyID = Companies[CompaniesID].Id;
            }
            else
            {
                CompanyID = Companies[CompaniesID].Id;
                if (CompaniesID + 1 >= Companies.Count)
                {
                    CompaniesID = 0;
                }
                else
                {
                    CompaniesID++;
                }
            }
        }

    }
}
