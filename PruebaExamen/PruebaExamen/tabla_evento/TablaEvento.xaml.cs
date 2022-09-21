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

namespace PruebaExamen.tabla_evento
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class TablaEvento : ContentPage
    {
        private string url = "https://desfrlopez.me/hmatamoros2/api/tbl_eventos";
        public TablaEvento()
        {
            InitializeComponent();
        }
        private async Task tbl_teventoAsync()
        {
            using (var httpClient = new HttpClient())
            {
                evento E = new evento()
                {
                    nombre_evento = nomForm.Text,
                    fecha = fecForm.Text,
                    idtipoevento = idtForm.Text,



                };
                var body = E.toJson();
                HttpContent e = new StringContent(body, Encoding.UTF8, "application/json");
                var response = await httpClient.PostAsync(url,e );

                if (response.IsSuccessStatusCode)
                {
                    var content = await response.Content.ReadAsStringAsync();
                    evento contenido = JsonConvert.DeserializeObject<evento>(content);
                    resultado.Text = "evento creado: id = " + contenido.id_evento + " nombre = " + contenido.nombre_evento;
                }
                else
                {
                    resultado.Text = "Insercion Fallida";
                }

                nomForm.Text = "";
                fecForm.Text = "";
                idtForm.Text = "";
            }
        }
        private void Button_Clicked(object sender, EventArgs e)
        {
            tbl_teventoAsync();
        }

    }
}