using Newtonsoft.Json;
using PruebaExamen.tabla_tipo_evento;
using PruebaExamen.tabla_tipo_membresia;
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
    public partial class Tpersona : ContentPage
    {
        private string url = "https://desfrlopez.me/hmatamoros2/api/tbl_persona";
        public Tpersona()
        {
            InitializeComponent();
        }
        private async Task tbl_teventoAsync()
        {
            using (var httpClient = new HttpClient())
            {
                persona P = new persona()
                {
                    nombre_persona = nomForm.Text,
                    correo_electronico = corForm.Text,
                    idmembresia = idmForm.Text,



                };
                var body = P.toJson();
                HttpContent pe = new StringContent(body, Encoding.UTF8, "application/json");
                var response = await httpClient.PostAsync(url, pe);

                if (response.IsSuccessStatusCode)
                {
                    var content = await response.Content.ReadAsStringAsync();
                    persona contenido = JsonConvert.DeserializeObject<persona>(content);
                    resultado.Text = "persona creada: id = " + contenido.id_membresia + " nombre = " + contenido.nombre_persona;
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

    }
}