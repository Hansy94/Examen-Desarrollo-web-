using Newtonsoft.Json;
using PruebaExamen.tabla_evento;
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
    public partial class GetPersona : ContentPage
    {
        private string url = "https://desfrlopez.me/hmatamoros2/api/tbl_persona";


        public GetPersona()
        {
            InitializeComponent();
            getpersona();
        }

        protected override async void OnAppearing()
        {
            base.OnAppearing();
            getpersona();
        }

        private async Task getpersona()
        {
            using (var httpClient = new HttpClient())
            {

                var response = await httpClient.GetAsync(url);

                if (response.IsSuccessStatusCode)
                {
                    var content = await response.Content.ReadAsStringAsync();
                    List<persona> contenido = JsonConvert.DeserializeObject<List<persona>>(content);
                    List<tipomembresia> cont = JsonConvert.DeserializeObject<List<tipomembresia>>(content);


                    string tempRes = "";

                    for (int i = 0; i < contenido.Count; i++)
                    {

                        tempRes = tempRes + "id membresia : " + contenido[i].id_membresia + cont[i].descripcion + "  nombre persona: " + contenido[i].nombre_persona + "  correo_electronico: " + contenido[i].correo_electronico + "  idmembresia: " + contenido[i].idmembresia + "\n";

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