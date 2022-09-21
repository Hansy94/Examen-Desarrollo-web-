using Newtonsoft.Json;
using PruebaExamen.tabla_persona;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace PruebaExamen.tabla_tickets
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Ttickets : ContentPage
    {
        private string url = "https://desfrlopez.me/hmatamoros2/api/tbl_tickets";
        public Ttickets()
        {
            InitializeComponent();
        }
        private async Task tbl_TicketsAsync()
        {
            using (var httpClient = new HttpClient())
            {
                tickets T = new tickets()
                {
                    fila = filForm.Text,
                    Precio = preForm.Text,
                    idevento = ideForm.Text,



                };
                var body = T.toJson();
                HttpContent ti = new StringContent(body, Encoding.UTF8, "application/json");
                var response = await httpClient.PostAsync(url, ti);

                if (response.IsSuccessStatusCode)
                {
                    var content = await response.Content.ReadAsStringAsync();
                    tickets contenido = JsonConvert.DeserializeObject<tickets>(content);
                    resultado.Text = "fila = " + contenido.fila + " Precio = " + contenido.Precio;
                }
                else
                {
                    resultado.Text = "Insercion Fallida";
                }

                filForm.Text = "";
                preForm.Text = "";
                ideForm.Text = "";
            }
        }
        private void Button_Clicked(object sender, EventArgs e)
        {
            tbl_TicketsAsync();
        }

    }
}