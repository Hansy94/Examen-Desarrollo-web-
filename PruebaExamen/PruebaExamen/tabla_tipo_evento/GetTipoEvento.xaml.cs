using Newtonsoft.Json;
using PruebaExamen.tabla_tickets;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace PruebaExamen.tabla_tipo_evento
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class GetTipoEvento : ContentPage
    {

        private string url = "https://desfrlopez.me/hmatamoros2/api/tbl_tipo_evento";


        public GetTipoEvento()
        {
            InitializeComponent();
            gettipoevento();
        }

        protected override async void OnAppearing()
        {
            base.OnAppearing();
            gettipoevento();
        }

        private async Task gettipoevento()
        {
            using (var httpClient = new HttpClient())
            {

                var response = await httpClient.GetAsync(url);

                if (response.IsSuccessStatusCode)
                {
                    var content = await response.Content.ReadAsStringAsync();
                    List<tipoevento> contenido = JsonConvert.DeserializeObject<List<tipoevento>>(content);

                    string tempRes = "";

                    for (int i = 0; i < contenido.Count; i++)
                    {

                        tempRes = tempRes + "id tipo evento   : " + contenido[i].id_tipo_evento + "descripcion : " + contenido[i].descripcion  + "\n";

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