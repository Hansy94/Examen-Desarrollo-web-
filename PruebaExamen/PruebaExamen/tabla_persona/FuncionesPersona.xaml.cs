using PruebaExamen.tabla_evento;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace PruebaExamen.tabla_persona
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class FuncionesPersona : ContentPage
    {
        public FuncionesPersona()
        {
            InitializeComponent();
        }
        async void Post(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new Tpersona());
        }

        async void delete(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new DeletePersona());
        }
        async void put(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new PutPersona());
        }
        async void get(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new GetPersona());
        }
    }
}