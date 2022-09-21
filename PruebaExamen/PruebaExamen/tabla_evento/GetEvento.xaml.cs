using Newtonsoft.Json;
using PruebaExamen.tabla_compras;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace PruebaExamen.tabla_evento
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class GetEvento : ContentPage
    {
        private string url = "https://desfrlopez.me/hmatamoros2/api/tbl_eventos";


        public GetEvento()
        {
            InitializeComponent();
            getevento();
        }

        protected override async void OnAppearing()
        {
            base.OnAppearing();
            getevento();
        }

        private async Task getevento()
        {
            using (var httpClient = new HttpClient())
            {

                var response = await httpClient.GetAsync(url);

                if (response.IsSuccessStatusCode)
                {
                    var content = await response.Content.ReadAsStringAsync();
                    List<evento> contenido = JsonConvert.DeserializeObject<List<evento>>(content);

                    string tempRes = "";

                    for (int i = 0; i < contenido.Count; i++)
                    {

                        tempRes = tempRes + "id evento: " + contenido[i].id_evento + "  nombre_evento: " + contenido[i].nombre_evento + "  fecha: " + contenido[i].fecha + "  idtipoevento: " + contenido[i].idtipoevento + "\n";

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