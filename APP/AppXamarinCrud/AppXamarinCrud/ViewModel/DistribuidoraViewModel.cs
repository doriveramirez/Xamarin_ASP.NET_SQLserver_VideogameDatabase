using MVVM.Model;
using MVVM.Service;
using MVVM.View;
using Newtonsoft.Json;
//using OfficeOpenXml.FormulaParsing.Excel.Functions.Text;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace MVVM.ViewModel
{
    public class DistribuidoraViewModel: Distribuidora
    {
        private Task<ObservableCollection<Distribuidora>> DistribuidorasTask { get; set; }
        private ObservableCollection<Distribuidora> DistribuidorasAux { get; set; }
        public ObservableCollection<Distribuidora> Distribuidoras { get; set; }

        public ObservableCollection<Distribuidora> Cosas { get; set; }

        //public Task<ObservableCollection<Distribuidora>> Distribuidoras { get; set; }

        Distribuidora modelo;

        DistribuidoraService servicio = new DistribuidoraService();

        public DistribuidoraViewModel()
        {
            ListViewAsync();
            GuardarCommand = new Command(async () => await Guardar(), () => !IsBusy);
            ModificarCommand = new Command(async () => await Modificar(), () => !IsBusy);
            EliminarCommand = new Command(async () => await Eliminar(), () => !IsBusy);
            LimpiarCommand = new Command(Limpiar, () => !IsBusy);
            IrCommand = new Command(Ir, () => !IsBusy);
        }

        private async Task ListViewAsync()
        {
            Distribuidoras = new ObservableCollection<Distribuidora>();
            DistribuidorasTask = servicio.Consultar();
            DistribuidorasAux = await DistribuidorasTask;
            for (int i = 0; i < DistribuidorasAux.Count; i++)
            {
                Distribuidoras.Add(DistribuidorasAux[i]);
            }
        }

        public bool IrBool { get; set; }

        public Command GuardarCommand { get; set; }

        public Command ModificarCommand { get; set; }

        public Command EliminarCommand { get; set; }

        public Command LimpiarCommand { get; set; }

        public Command IrCommand { get; set; }

        private async Task Guardar()
        {
            IsBusy = true;
            Guid idDistribuidora = Guid.NewGuid();
            modelo = new Distribuidora()
            {
                Nombre = Nombre,
                NumeroJuegosPublicados = NumeroJuegosPublicados,
                Imagen = Imagen,
                Id = idDistribuidora.ToString()
            };
            Console.WriteLine(modelo.Id + " _ " + modelo.NumeroJuegosPublicados + " _ " + modelo.Nombre + " _ " + modelo.Imagen);
            await servicio.Guardar(modelo);
            await Task.Delay(2000);
            IsBusy = false;
        }

        private async Task Modificar()
        {
            IsBusy = true;
            modelo = new Distribuidora()
            {
                Nombre = Nombre,
                NumeroJuegosPublicados = NumeroJuegosPublicados,
                Imagen = Imagen,
                Id = Id
            };
            servicio.Modificar(modelo);
            await Task.Delay(2000);
            IsBusy = false;
        }

        private async Task Eliminar()
        {
            IsBusy = true;
            servicio.Eliminar(Id);
            await Task.Delay(2000);
            IsBusy = false;
        }

        private void Limpiar()
        {
            Nombre = "";
            NumeroJuegosPublicados = 0;
            Imagen = null;
            Id = "";
        }

        private void Ir()
        {
            if (IrBool == false)
            {
                IrBool = true;
            } else
            {
                IrBool = false;
            }
        }

    }
}
