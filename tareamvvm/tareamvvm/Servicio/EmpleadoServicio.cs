using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using tareamvvm.Model;

namespace tareamvvm.Servicio
{
    public class EmpleadoServicio
    {
        public ObservableCollection<EmpleadoModel> empleados { get; set; }

        public EmpleadoServicio()
        {
            if (empleados == null)
            {
                empleados = new ObservableCollection<EmpleadoModel>();
            }
        }


        public ObservableCollection<EmpleadoModel> Consultar()
        {
            return empleados;
        }

        public void Guardar(EmpleadoModel modelo) 
        {
            empleados.Add(modelo);
        }

        public void Modificar(EmpleadoModel modelo)
        {
            for (int i = 0; i < empleados.Count; i++)
            {
                if(empleados[i].Id==modelo.Id)
                {
                    empleados[i] = modelo;
                }
                        
            }
        }

        public void Eliminar(String idEmpleado)
        {
            EmpleadoModel modelo = empleados.FirstOrDefault(p => p.Id == idEmpleado);
            empleados.Remove(modelo);
        }
    }
}
