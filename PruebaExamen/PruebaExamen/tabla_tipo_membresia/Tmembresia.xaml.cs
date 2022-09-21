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

namespace PruebaExamen.tabla_tipo_membresia
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Tmembresia : ContentPage
    {
        private string url = "https://desfrlopez.me/hmatamoros2/api/tbl_tipo_membresia";

        public Tmembresia()
        {
            InitializeComponent();
        }

        private async Task tbl_tmembresiaAsync()
        {
            using (var httpClient = new HttpClient()){

                tipomembresia TM = new tipomembresia(){
                    descripcion = desForm.Text,  
                };

                string body = TM.toJson();
                HttpContent t = new StringContent(body, Encoding.UTF8, "application/json");
                var response = await httpClient.PostAsync(url, t);

                if (response.IsSuccessStatusCode)
                {
                    var content = await response.Content.ReadAsStringAsync();
                    tipomembresia contenido = JsonConvert.DeserializeObject<tipomembresia>(content);
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
            tbl_tmembresiaAsync();
        }

    }
}