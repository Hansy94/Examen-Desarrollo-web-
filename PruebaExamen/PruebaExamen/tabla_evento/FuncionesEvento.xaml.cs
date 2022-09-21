using PruebaExamen.tabla_compras;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace PruebaExamen.tabla_evento
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class FuncionesEvento : ContentPage
    {
        public FuncionesEvento()
        {
            InitializeComponent();
        }

        async void Post(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new TablaEvento());
        }
        async void delete(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new DeleteEvento());
        }
        async void put(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new PutEvento());
        }
        async void get(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new GetEvento());
        }
    }
}