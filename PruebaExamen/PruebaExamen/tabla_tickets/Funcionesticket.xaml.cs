using PruebaExamen.tabla_persona;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace PruebaExamen.tabla_tickets
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Funcionesticket : ContentPage
    {
        public Funcionesticket()
        {
            InitializeComponent();
        }
        async void Post(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new Ttickets());
        }

        async void delete(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new DeleteTicket());
        }

        async void put(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new PutTickets());
        }

        async void get(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new GetTicket());
        }
    }
}


