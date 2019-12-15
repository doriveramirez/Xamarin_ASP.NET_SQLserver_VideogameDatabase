using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Globalization;
using System.Runtime.CompilerServices;
using System.Text;
using Xamarin.Forms;
using SQLite;

namespace AppXamarinCrud.Model
{
    public partial class Company : INotifyPropertyChanged
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

        private DateTime foundationDate;

        public DateTime FoundationDate
        {
            get { return foundationDate; }
            set { foundationDate = value;
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

        public static Company[] FromJson(string json) => JsonConvert.DeserializeObject<Company[]>(json, AppXamarinCrud.Converter.Settings);
    }

}
