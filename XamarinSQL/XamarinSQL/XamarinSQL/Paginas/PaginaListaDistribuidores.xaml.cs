using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using XamarinSQL.Clases;

namespace XamarinSQL.Paginas
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class PaginaListaDistribuidores : ContentPage
    {
        public PaginaListaDistribuidores()
        {
            InitializeComponent();
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();
            Distribuidora.ItemsSource = BaseDatos.ObtenerDistribuidora();
        }

        private void Distribuidora_ItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            if (e.SelectedItem != null)
                NavegarEmpleado(e.SelectedItem as Distribuidora);
        }

        void btnNuevo_Click(object sender, EventArgs a)
        {
            NavegarEmpleado(new Distribuidora());
        }

        void NavegarEmpleado(Distribuidora distribuidora)
        {
            PaginaDistribuidores pagina = new PaginaDistribuidores();
            pagina.distribuidora = distribuidora;
            Navigation.PushAsync(pagina);
        }
    }
}