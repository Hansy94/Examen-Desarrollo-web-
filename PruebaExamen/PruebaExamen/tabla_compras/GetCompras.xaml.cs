using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace PruebaExamen.tabla_compras
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class GetCompras : ContentPage
    {
        private string url = "https://desfrlopez.me/hmatamoros2/api/tbl_compras";


        public GetCompras()
        {
            InitializeComponent();
            getcompras();
        }

        protected void OnAppearing()
        {
            base.OnAppearing();
            getcompras();
        }

        private async Task getcompras()
        {
            using (var httpClient = new HttpClient())
            {

                var response = await httpClient.GetAsync(url);

                if (response.IsSuccessStatusCode)
                {
                    var content = await response.Content.ReadAsStringAsync();
                    List<compras> contenido = JsonConvert.DeserializeObject<List<compras>>(content);

                    string tempRes = "";

                    for (int i = 0; i < contenido.Count; i++)
                    {

                        tempRes = tempRes + "idCompras: " + contenido[i].id_compras + " fecha compra: " + contenido[i].fecha_compra + "  idmembresia: " + contenido[i].idmembresia + "  idtickets: " + contenido[i].idtickets + "\n";

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