using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Globalization;
using System.Runtime.CompilerServices;
using System.Text;
using Xamarin.Forms;

namespace MVVM.Model
{

    public partial class Distribuidora
    {
        [JsonProperty("Id")]
        public string Id { get; set; }

        [JsonProperty("Nombre")]
        public string Nombre { get; set; }

        [JsonProperty("NumeroJuegosPublicados")]
        public int NumeroJuegosPublicados { get; set; }

        [JsonProperty("Imagen")]
        public Image Imagen { get; set; }

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

        public event PropertyChangedEventHandler PropertyChanged;

        public void OnPropertyChanged([CallerMemberName]string nombre = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nombre));
        }
    }

    public partial class Distribuidora
    {
        public static Distribuidora[] FromJson(string json) => JsonConvert.DeserializeObject<Distribuidora[]>(json, AppXamarinCrud.Converter.Settings);
    }

    public static class Serialize
    {
        public static string ToJson(this Distribuidora[] self) => JsonConvert.SerializeObject(self, AppXamarinCrud.Converter.Settings);
    }

    internal static class Converter
    {
        public static readonly JsonSerializerSettings Settings = new JsonSerializerSettings
        {
            MetadataPropertyHandling = MetadataPropertyHandling.Ignore,
            DateParseHandling = DateParseHandling.None,
            Converters =
            {
                new IsoDateTimeConverter { DateTimeStyles = DateTimeStyles.AssumeUniversal }
            },
        };
    }

    

    //public class Distribuidora : INotifyPropertyChanged
    //{

    //    public event PropertyChangedEventHandler PropertyChanged;

    //    public void OnPropertyChanged([CallerMemberName]string nombre = "")
    //    {
    //        PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nombre));
    //    }

    //    private bool isBusy = false;

    //    public bool IsBusy
    //    {
    //        get { return isBusy = false; }
    //        set
    //        {
    //            isBusy = value;
    //            OnPropertyChanged();
    //        }
    //    }

    //    private string id;

    //    public string Id
    //    {
    //        get { return id; }
    //        set
    //        {
    //            id = value;
    //            OnPropertyChanged();
    //        }
    //    }

    //    private string nombre;

    //    public string Nombre
    //    {
    //        get { return nombre; }
    //        set
    //        {
    //            nombre = value;
    //            OnPropertyChanged();
    //        }
    //    }

    //    private int numeroJuegosPublicados;

    //    public int NumeroJuegosPublicados
    //    {
    //        get { return numeroJuegosPublicados; }
    //        set
    //        {
    //            numeroJuegosPublicados = value;
    //            OnPropertyChanged();
    //        }
    //    }


    //    private Image image;

    //    public Image Image
    //    {
    //        get { return image; }
    //        set { 
    //            image = value;
    //            OnPropertyChanged();
    //        }
    //    }

    //}
}
