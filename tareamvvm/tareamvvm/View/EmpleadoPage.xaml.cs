using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using tareamvvm.Model;
using tareamvvm.ViewModel;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace tareamvvm.View
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class EmpleadoPage : ContentPage
    {
        EmpleadoViewModel contexto = new EmpleadoViewModel();
        public EmpleadoPage()
        {
            InitializeComponent();
            BindingContext = contexto;
            LvEmpleados.ItemSelected += LvEmpleados_ItemSelected;
        }

        private void LvEmpleados_ItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            if (e.SelectedItem!=null)
            {
                EmpleadoModel modelo = (EmpleadoModel)e.SelectedItem;
                Navigation.PushAsync(new DetallePage(modelo));
               contexto.Nombre = modelo.Nombre;
               contexto.Apellido = modelo.Apellido;
               contexto.Edad = modelo.Edad;
               contexto.Direccion = modelo.Direccion;
               contexto.Puesto = modelo.Puesto;
               contexto.Id = modelo.Id;

            }
        }
    }
}