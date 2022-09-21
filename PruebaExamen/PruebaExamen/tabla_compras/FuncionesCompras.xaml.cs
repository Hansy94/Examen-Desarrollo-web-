using PruebaExamen.tabla_tipo_membresia;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace PruebaExamen.tabla_compras
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class FuncionesCompras : ContentPage
    {
        public FuncionesCompras()
        {
            InitializeComponent();
        }

        async void Post(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new Tcompras());
        }

        async void delete(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new DeleteTcompras());
        }
        async void put(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new PutCompras());
        }
        async void get(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new GetCompras());
        }
    }
}