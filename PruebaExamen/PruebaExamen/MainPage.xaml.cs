using PruebaExamen.tabla_compras;
using PruebaExamen.tabla_evento;
using PruebaExamen.tabla_persona;
using PruebaExamen.tabla_tickets;
using PruebaExamen.tabla_tipo_evento;
using PruebaExamen.tabla_tipo_membresia;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace PruebaExamen
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
        }

        async void navegar_tbl_tipo_membresia(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new FuncionesMembresia ());
        }

        async void navegar_tbl_persona(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new FuncionesPersona());

        }
        async void navegar_tbl_compras(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new FuncionesCompras());

        }

        async void navegar_tbl_tickets(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new Funcionesticket());

        }

        async void navegar_tbl_evento(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new FuncionesEvento());

        }

        async void navegar_tbl_tipo_evento(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new FuncionesTipoEvento());
        }
    }
}


