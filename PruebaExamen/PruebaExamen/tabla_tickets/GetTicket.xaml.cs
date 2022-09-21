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
    public partial class GetTicket : ContentPage
    {
        private string url = "https://desfrlopez.me/hmatamoros2/api/tbl_tickets";


        public GetTicket()
        {
            InitializeComponent();
            gettickets();
        }

        protected override async void OnAppearing()
        {
            base.OnAppearing();
            gettickets();
        }

        private async Task gettickets()
        {
            using (var httpClient = new HttpClient())
            {

                var response = await httpClient.GetAsync(url);

                if (response.IsSuccessStatusCode)
                {
                    var content = await response.Content.ReadAsStringAsync();
                    List<tickets> contenido = JsonConvert.DeserializeObject<List<tickets>>(content);

                    string tempRes = "";

                    for (int i = 0; i < contenido.Count; i++)
                    {

                        tempRes = tempRes + "id tickets  : " + contenido[i].id_tickets + "  fila : " + contenido[i].fila + "  Precio: " + contenido[i].Precio + "idevento: " + contenido[i].idevento + "\n";

                    }

                    resultado.Text = tempRes;
                }
                else
                {
                    resultado.Text = "Carga Fallida de Paises";
                }




            }
        }

    }
}