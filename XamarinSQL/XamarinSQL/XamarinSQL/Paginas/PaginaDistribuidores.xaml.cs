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
    public partial class PaginaDistribuidores : ContentPage
    {
        public Distribuidora distribuidora;

        public PaginaDistribuidores()
        {
            InitializeComponent();
        }
        protected override void OnAppearing()
        {
            base.OnAppearing();

            BindingContext = this.distribuidora;
        }

        void btnGuardar_Click(object sender, EventArgs a)
        {
            if (distribuidora.Id == 0)
                BaseDatos.AgregarDistribuidora(distribuidora);
            else
                BaseDatos.ModificarDistribuidora(distribuidora);
            Navigation.PopAsync();
        }

        void btnEliminar_Click(object sender, EventArgs a)
        {
            if (distribuidora.Id != 0)
            {
                BaseDatos.EliminarDistribuidora(distribuidora);
                Navigation.PopAsync();
            }
        }
    }
}