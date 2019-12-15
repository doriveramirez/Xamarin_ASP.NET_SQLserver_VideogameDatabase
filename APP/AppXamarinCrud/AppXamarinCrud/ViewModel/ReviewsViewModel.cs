﻿using AppXamarinCrud.Model;
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
    public class ReviewsViewModel : Review
    {
        private Task<ObservableCollection<Review>> ReviewsTask { get; set; }
        private ObservableCollection<Review> ReviewsAux { get; set; }
        public ObservableCollection<Review> Reviews { get; set; }

        private Task<ObservableCollection<User>> UsersTask { get; set; }
        private ObservableCollection<User> UsersAux { get; set; }
        public ObservableCollection<User> Users { get; set; }

        private Task<ObservableCollection<Videogame>> VideogamesTask { get; set; }
        private ObservableCollection<Videogame> VideogamesAux { get; set; }
        public ObservableCollection<Videogame> Videogames { get; set; }

        Review model;

        ReviewsService servicio = new ReviewsService();

        public ReviewsViewModel()
        {
            ListViewAsync();
            SaveCommand = new Command(async () => await Save(), () => !IsBusy);
            ModifyCommand = new Command(async () => await Modify(), () => !IsBusy);
            DeleteCommand = new Command(async () => await Delete(), () => !IsBusy);
            CleanCommand = new Command(Clean, () => !IsBusy);
            GoCommand = new Command(Go, () => !IsBusy);
            BackCommand = new Command(Back, () => !IsBusy);
            ChangeVideogameIDCommand = new Command(ChangeVideogameID, () => !IsBusy);
            ChangeUserIDCommand = new Command(ChangeUserID, () => !IsBusy);
        }

        private async Task ListViewAsync()
        {
            Reviews = new ObservableCollection<Review>();
            ReviewsTask = servicio.Consult();
            ReviewsAux = await ReviewsTask;
            for (int i = 0; i < ReviewsAux.Count; i++)
            {
                Reviews.Add(ReviewsAux[i]);
            }
            Videogames = new ObservableCollection<Videogame>();
            VideogamesTask = servicio.ConsultVideogame();
            VideogamesAux = await VideogamesTask;
            for (int i = 0; i < VideogamesAux.Count; i++)
            {
                Console.WriteLine("hola" + VideogamesAux[i].Name);
                Videogames.Add(VideogamesAux[i]);
            }
            Users = new ObservableCollection<User>();
            UsersTask = servicio.ConsultUser();
            UsersAux = await UsersTask;
            for (int i = 0; i < UsersAux.Count; i++)
            {
                Console.WriteLine("hola" + UsersAux[i].Dni);
                Users.Add(UsersAux[i]);
            }
            Console.WriteLine("adios");
        }

        public bool GoBool { get; set; }

        public Command SaveCommand { get; set; }

        public Command ModifyCommand { get; set; }

        public Command DeleteCommand { get; set; }

        public Command CleanCommand { get; set; }

        public Command GoCommand { get; set; }

        public Command BackCommand { get; set; }

        public Command ChangeUserIDCommand { get; set; }

        public Command ChangeVideogameIDCommand { get; set; }

        private int UsersID = 0;

        private int VideogamesID = 0;

        private async Task Save()
        {
            IsBusy = true;
            Guid idReview = Guid.NewGuid();
            model = new Review()
            {
                Played = Played,
                Mark = Mark,
                Description = Description,
                UserID = UserID,
                VideogameID = VideogameID,
                Id = idReview.ToString()
            };
            var sent = await servicio.Save(model);
            if (sent)
            {
                Reviews.Add(model);
                Clean();
            }
            await Task.Delay(2000);
            IsBusy = false;
        }

        private async Task Modify()
        {
            IsBusy = true;
            model = new Review()
            {
                Played = Played,
                Mark = Mark,
                Description = Description,
                UserID = UserID,
                VideogameID = VideogameID,
                Id = Id
            };
            var sent = await servicio.Modify(model);
            if (sent)
            {
                var item = Reviews.FirstOrDefault(i => i.Id == model.Id);
                if (item != null)
                {

                    item.Played = model.Played;
                    item.Mark = model.Mark;
                    item.Description = model.Description;
                    item.UserID = model.UserID;
                    item.VideogameID = model.VideogameID;
                }
                Clean();
            }
            await Task.Delay(2000);
            IsBusy = false;
        }

        private async Task Delete()
        {
            IsBusy = true;
            model = new Review()
            {
                Played = Played,
                Mark = Mark,
                Description = Description,
                UserID = UserID,
                VideogameID = VideogameID,
                Id = Id
            };
            var sent = await servicio.Delete(model.Id);
            if (sent)
            {
                var item = Reviews.FirstOrDefault(i => i.Id == model.Id);
                Reviews.Remove(item);
                Clean();
            }
            await Task.Delay(2000);
            IsBusy = false;
        }

        private void Clean()
        {
            Played = false;
            Mark = 0;
            Description = "";
            UserID = "";
            VideogameID = "";
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
        private void ChangeVideogameID()
        {
            if (VideogameID == Videogames[VideogamesID].Id)
            {
                if (VideogamesID + 1 >= Videogames.Count)
                {
                    VideogamesID = 0;
                }
                else
                {
                    VideogamesID++;
                }
                VideogameID = Videogames[VideogamesID].Id;
            }
            else
            {
                VideogameID = Videogames[VideogamesID].Id;
                if (VideogamesID + 1 >= Videogames.Count)
                {
                    VideogamesID = 0;
                }
                else
                {
                    VideogamesID++;
                }
            }
        }

    }
}