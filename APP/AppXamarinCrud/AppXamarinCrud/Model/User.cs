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
    public partial class User : INotifyPropertyChanged
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

        private DateTime birthday;

        public DateTime Birthday
        {
            get { return birthday; }
            set { birthday = value;
                OnPropertyChanged();
            }
        }

        private string dni;

        public string Dni
        {
            get { return dni; }
            set { dni = value;
                OnPropertyChanged();
            }
        }

        private string password;

        public string Password
        {
            get { return password; }
            set { password = value;
                OnPropertyChanged();
            }
        }

        private string username;

        public string Username
        {
            get { return username; }
            set { username = value;
                OnPropertyChanged();
            }
        }

        private string companyID;

        public string CompanyID
        {
            get { return companyID; }
            set { companyID = value;
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

        public static User[] FromJson(string json) => JsonConvert.DeserializeObject<User[]>(json, AppXamarinCrud.Converter.Settings);
    }
}
