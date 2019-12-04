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
    public partial class Platform : INotifyPropertyChanged
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
            set { releaseDate = value; }
        }

        private int soldUnits;

        public int SoldUnits
        {
            get { return soldUnits; }
            set { soldUnits = value; }
        }

        private string description;

        public string Description
        {
            get { return description; }
            set { description = value; }
        }


        private Image picture;

        public Image Picture
        {
            get { return picture; }
            set
            {
                picture = value;
                OnPropertyChanged();
            }
        }

        private string author;

        public string Author
        {
            get { return author; }
            set { author = value; }
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

        public static Platform[] FromJson(string json) => JsonConvert.DeserializeObject<Platform[]>(json, AppXamarinCrud.Converter.Settings);
    }
}
