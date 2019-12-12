using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Globalization;
using System.Runtime.CompilerServices;
using System.Text;
using Xamarin.Forms;

namespace AppXamarinCrud.Model
{
    public partial class Review : INotifyPropertyChanged
    {

        public event PropertyChangedEventHandler PropertyChanged;

        public void OnPropertyChanged([CallerMemberName]string name = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
        }

        private string id;

        public string Id
        {
            get { return id; }
            set
            {
                id = value;
                OnPropertyChanged();
            }
        }

        private bool played;

        public bool Played
        {
            get { return played; }
            set { played = value;
                OnPropertyChanged();
            }
        }

        private int mark;

        public int Mark
        {
            get { return mark; }
            set
            {
                mark = value;
                OnPropertyChanged();
            }
        }

        private string description;

        public string Description
        {
            get { return description; }
            set { description = value;
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

        private string videogameID;

        public string VideogameID
        {
            get { return videogameID; }
            set { videogameID = value;
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

        public static Review[] FromJson(string json) => JsonConvert.DeserializeObject<Review[]>(json, AppXamarinCrud.Converter.Settings);
    }
}

