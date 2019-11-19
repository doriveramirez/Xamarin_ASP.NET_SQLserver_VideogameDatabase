using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace AppXamarinCrud
{
    // Learn more about making custom code visible in the Xamarin.Forms previewer
    // by visiting https://aka.ms/xamarinforms-previewer
    [DesignTimeVisible(false)]
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
            LlenarBicicletas();
        }

        private async void LlenarBicicletas()
        {
            HttpClient client = new HttpClient();

            String url = "http://192.168.103.86:40089/api/Values?type=json";
            Console.WriteLine("hola " + url);

            var result = await client.GetStringAsync(url);

            Console.WriteLine("bobosoyysere");


            //var bicycles = JsonConvert.DeserializeObject<List<Bicycle>>(result);
            //Console.WriteLine("hola");


            //var result = await client.GetAsync(url);
            //var json = result.Content.ReadAsStringAsync().Result;
            //Bicycle[] bicycles = Bicycle.FromJson(json);

            //listaBicicletas.ItemsSource = bicycles;

        }
    }
}
