using MVVM.Model;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;

namespace MVVM.Service
{
    public class DistribuidoraService
    {
        public ObservableCollection<Distribuidora> distribuidoras { get; set; }

        public DistribuidoraService()
        {
            if (distribuidoras == null)
            {
                distribuidoras = new ObservableCollection<Distribuidora>();
            }
        }
        
        public ObservableCollection<Distribuidora>Consultar(){
            return distribuidoras;
        }

        public void Guardar(Distribuidora modelo)
        {
            distribuidoras.Add(modelo);
        }

        public void Modificar(Distribuidora modelo)
        {
            for (int i = 0; i < distribuidoras.Count; i++)
            {
                if (distribuidoras[i].Id == modelo.Id)
                {
                    distribuidoras[i] = modelo;
                }
            }
        }

        public void Eliminar(string idDistribuidora)
        {
            Distribuidora model = distribuidoras.FirstOrDefault(d => d.Id == idDistribuidora);
            distribuidoras.Remove(model);
        }

    }
}
