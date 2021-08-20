using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using System.Threading.Tasks;
using tareamvvm.Model;
using System.Collections.ObjectModel;
using tareamvvm.Servicio;
using Xamarin.Forms;

namespace tareamvvm.ViewModel
{
    public class EmpleadoViewModel : EmpleadoModel
    {
        public ObservableCollection<EmpleadoModel> Empleados { get; set; }
        EmpleadoServicio servicio = new EmpleadoServicio();
        EmpleadoModel modelo;

        public EmpleadoViewModel()
        {
            Empleados = servicio.Consultar();
            GuardarCommand = new Command(async () => await Guardar(), () => !Isbusy);
            ModificarCommand = new Command(async () => await Modificar(), () => !Isbusy);
            EliminarCommand = new Command(async () => await Eliminar(), () => !Isbusy);
            LimpiarCommand = new Command(Limpiar, () => !Isbusy);
        }

        public Command GuardarCommand { get; set; }

        public Command ModificarCommand { get; set; }

        public Command EliminarCommand { get; set; }

        public Command LimpiarCommand { get; set; }

        private async Task Guardar()
        {
            Isbusy = true;
            Guid IdEmpleado = Guid.NewGuid();
            modelo = new EmpleadoModel()
            {
                Nombre = Nombre,
                Apellido = Apellido,
                Edad = Edad,
                Direccion = Direccion,
                Puesto = Puesto,
                Id = IdEmpleado.ToString()
            };
            servicio.Guardar(modelo);
            await Task.Delay(2000);
            Isbusy = false;
        }

        private async Task Modificar()
        {
            Isbusy = true;
            
            modelo = new EmpleadoModel()
            {
                Nombre = Nombre,
                Apellido = Apellido,
                Edad = Edad,
                Direccion = Direccion,
                Puesto = Puesto,
                Id = Id
            };
            servicio.Modificar(modelo);
            await Task.Delay(2000);
            Isbusy = false;
        }

        private async Task Eliminar()
        {
            Isbusy = true;
            servicio.Eliminar(Id);
            await Task.Delay(2000);
            Isbusy = false;
        }

        private void Limpiar()
        {
            Nombre = "";
            Apellido = "";
            Edad = 0;
            Direccion = "";
            Puesto = "";
            Id = "";

        }
    }
}
