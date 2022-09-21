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
    public partial class PutTipoEvento : ContentPage
    {
        private string url = "https://desfrlopez.me/hmatamoros2/api/tbl_tipo_evento";
        public PutTipoEvento()
        {
            InitializeComponent();
        }
        private async Task tbl_teventoAsync()
        {
            using (var httpClient = new HttpClient())
            {
                tipoevento TE = new tipoevento()
                {
                    id_tipo_evento = int.Parse(idForm.Text),
                    descripcion = desForm.Text,

                };
                url = url + "/" + TE.id_tipo_evento;
                var body = TE.toJson();
                HttpContent te = new StringContent(body, Encoding.UTF8, "application/json");
                var response = await httpClient.PutAsync(url, te);

                if (response.IsSuccessStatusCode)
                {
                    var content = await response.Content.ReadAsStringAsync();
                    resultado.Text = "Actualizacion Exitosa";
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
        private void idForm_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

    }
}