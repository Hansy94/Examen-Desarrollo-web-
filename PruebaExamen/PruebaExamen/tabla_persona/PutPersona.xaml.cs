using Newtonsoft.Json;
using PruebaExamen.tabla_evento;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace PruebaExamen.tabla_persona
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class PutPersona : ContentPage
    {
        private string url = "https://desfrlopez.me/hmatamoros2/api/tbl_persona";
        public PutPersona()
        {
            InitializeComponent();
        }
        private async Task tbl_teventoAsync()
        {
            using (var httpClient = new HttpClient())
            {
                persona P = new persona()
                {
                    id_membresia = int.Parse(idForm.Text),
                    nombre_persona = nomForm.Text,
                    correo_electronico = corForm.Text,
                    idmembresia = idmForm.Text,


                };
                url = url + "/" + P.id_membresia;
                var body = P.toJson();
                HttpContent pe = new StringContent(body, Encoding.UTF8, "application/json");
                var response = await httpClient.PutAsync(url, pe);

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
                corForm.Text = "";
                idmForm.Text = "";
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