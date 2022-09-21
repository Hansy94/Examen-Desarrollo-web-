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
    public partial class PutEvento : ContentPage
    {
        private string url = "https://desfrlopez.me/hmatamoros2/api/tbl_eventos";
        public PutEvento()
        {
            InitializeComponent();
        }
        private async Task tbl_teventoAsync()
        {
            using (var httpClient = new HttpClient())
            {
                evento E = new evento()
                {
                    id_evento = int.Parse(idForm.Text),
                    nombre_evento = nomForm.Text,
                    fecha = fecForm.Text,
                    idtipoevento = idtForm.Text,
                };
                url = url + "/" + E.id_evento;
                var body = E.toJson();
                HttpContent e = new StringContent(body, Encoding.UTF8, "application/json");
                var response = await httpClient.PutAsync(url, e);

                if (response.IsSuccessStatusCode)
                {
                    var content = await response.Content.ReadAsStringAsync();
                    resultado.Text = "Actualizacion Exitosa";

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
        private void idForm_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

    }
}