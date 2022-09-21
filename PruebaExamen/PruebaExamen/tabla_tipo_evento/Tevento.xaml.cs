using Newtonsoft.Json;
using PruebaExamen.tabla_tickets;
using PruebaExamen.tabla_tipo_membresia;
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
    public partial class Tevento : ContentPage
    {
        private string url = "https://desfrlopez.me/hmatamoros2/api/tbl_tipo_evento";
        public Tevento()
        {
            InitializeComponent();
        }
        private async Task tbl_teventoAsync()
        {
            using (var httpClient = new HttpClient())
            {
                tipoevento TE = new tipoevento()
                {
                    descripcion = desForm.Text,

                };
                var body = TE.toJson();
                HttpContent te = new StringContent(body, Encoding.UTF8, "application/json");
                var response = await httpClient.PostAsync(url, te);

                if (response.IsSuccessStatusCode)
                {
                    var content = await response.Content.ReadAsStringAsync();
                    tipoevento contenido = JsonConvert.DeserializeObject<tipoevento>(content);
                    resultado.Text = "descripcion = " + contenido.descripcion;
                        }
                else
                {
                    resultado.Text = "Insercion Fallida";
                }

                desForm.Text = "";

            }
        }
        private void Button_Clicked(object sender, EventArgs e)
        {
            tbl_teventoAsync();
        }

    }
}
