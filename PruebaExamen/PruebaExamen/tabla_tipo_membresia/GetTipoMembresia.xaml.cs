using Newtonsoft.Json;
using PruebaExamen.tabla_tipo_evento;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace PruebaExamen.tabla_tipo_membresia
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class GetTipoMembresia : ContentPage
    {
        private string url = "https://desfrlopez.me/hmatamoros2/api/tbl_tipo_membresia";


        public GetTipoMembresia()
        {
            InitializeComponent();
            gettipomembresia();
        }

        protected override async void OnAppearing()
        {
            base.OnAppearing();
            gettipomembresia();
        }

        private async Task gettipomembresia()
        {
            using (var httpClient = new HttpClient())
            {

                var response = await httpClient.GetAsync(url);

                if (response.IsSuccessStatusCode)
                {
                    var content = await response.Content.ReadAsStringAsync();
                    List<tipomembresia> contenido = JsonConvert.DeserializeObject<List<tipomembresia>>(content);

                    string tempRes = "";

                    for (int i = 0; i < contenido.Count; i++)
                    {

                        tempRes = tempRes + "id tipo membresia   : " + contenido[i].id_tipo_membresia + "descripcion : " + contenido[i].descripcion + "\n";

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