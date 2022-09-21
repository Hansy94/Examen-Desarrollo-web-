using PruebaExamen.tabla_tipo_evento;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace PruebaExamen.tabla_tipo_membresia
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class FuncionesMembresia : ContentPage
    {
        public FuncionesMembresia()
        {
            InitializeComponent();
        }
        async void Post(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new Tmembresia());
        }
        async void delete(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new DeleteTipoMembresia());
        }

        async void put(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new PutTipoMembresia());
        }
        async void get(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new GetTipoMembresia());
        }
    }
}