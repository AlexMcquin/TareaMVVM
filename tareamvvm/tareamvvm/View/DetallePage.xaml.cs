using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using tareamvvm.Model;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace tareamvvm.View
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class DetallePage : ContentPage
    {
        public DetallePage(EmpleadoModel modelo)
        {
            InitializeComponent();
            BindingContext = modelo;
        }
    }
}