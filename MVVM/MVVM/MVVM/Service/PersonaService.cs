using MVVM.Model;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;

namespace MVVM.Service
{
    public class PersonaService
    {
        public ObservableCollection<PersonaModel> personas { get; set; }

        public PersonaService()
        {
            if (personas == null)
            {
                personas = new ObservableCollection<PersonaModel>();
            }
        }
        
        public ObservableCollection<PersonaModel>Consultar(){
            return personas;
        }

        public void Guardar(PersonaModel modelo)
        {
            personas.Add(modelo);
        }

        public void Modificar(PersonaModel modelo)
        {
            for (int i = 0; i < personas.Count; i++)
            {
                if (personas[i].Id == modelo.Id)
                {
                    personas[i] = modelo;
                }
            }
        }

        public void Eliminar(string idPersona)
        {
            PersonaModel model = personas.FirstOrDefault(p => p.Id == idPersona);
            personas.Remove(model);
        }

    }
}
