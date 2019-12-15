using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using SQLite;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Globalization;
using System.Runtime.CompilerServices;
using System.Text;
using Xamarin.Forms;

namespace AppXamarinCrud.Model
{
    public partial class Videogame : INotifyPropertyChanged
    {

        public event PropertyChangedEventHandler PropertyChanged;

        public void OnPropertyChanged([CallerMemberName]string name = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
        }

        private string id;

        [PrimaryKey]
        public string Id
        {
            get { return id; }
            set
            {
                id = value;
                OnPropertyChanged();
            }
        }

        private string name;

        public string Name
        {
            get { return name; }
            set
            {
                name = value;
                OnPropertyChanged();
            }
        }

        private DateTime releaseDate;

        public DateTime ReleaseDate
        {
            get { return releaseDate; }
            set { releaseDate = value;
                  OnPropertyChanged();
            }
        }

        private int soldUnits;

        public int SoldUnits
        {
            get { return soldUnits; }
            set { soldUnits = value;
                  OnPropertyChanged();
            }
        }

        private string userID;

        public string UserID
        {
            get { return userID; }
            set { userID = value;
                  OnPropertyChanged();
            }
        }

        private string distributorID;

        public string DistributorID
        {
            get { return distributorID; }
            set { distributorID = value;
                  OnPropertyChanged();
            }
        }

        //private Image picture;

        //public Image Picture
        //{
        //    get { return picture; }
        //    set
        //    {
        //        picture = value;
        //        OnPropertyChanged();
        //    }
        //}

        private string description;

        public string Description
        {
            get { return description; }
            set { description = value;
                  OnPropertyChanged();
            }
        }

        private bool isBusy = false;

        public bool IsBusy
        {
            get { return isBusy = false; }
            set
            {
                isBusy = value;
                OnPropertyChanged();
            }
        }

        public static Videogame[] FromJson(string json) => JsonConvert.DeserializeObject<Videogame[]>(json, AppXamarinCrud.Converter.Settings);
    }
}
