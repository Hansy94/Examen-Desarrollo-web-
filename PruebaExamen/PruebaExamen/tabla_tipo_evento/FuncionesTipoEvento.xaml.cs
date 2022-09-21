using PruebaExamen.tabla_tickets;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace PruebaExamen.tabla_tipo_evento
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class FuncionesTipoEvento : ContentPage
    {
        public FuncionesTipoEvento()
        {
            InitializeComponent();
        }
        async void Post(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new Tevento());
        }

        async void delete(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new DeleteTipoEvento());
        }
        async void put(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new PutTipoEvento());
        }
        async void get(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new GetTipoEvento());
        }

    }
}

