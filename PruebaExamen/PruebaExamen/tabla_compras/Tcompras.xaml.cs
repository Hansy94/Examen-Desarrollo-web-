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

namespace PruebaExamen.tabla_compras
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Tcompras : ContentPage
    {
        private string url = "https://desfrlopez.me/hmatamoros2/api/tbl_compras";

        public Tcompras()
        {
            InitializeComponent();
        }
        private async Task tbl_comprasAsync()
        {
            using (var httpClient = new HttpClient())
            {
                compras C = new compras()
                {
                    fecha_compra = fecForm.Text,
                    idmembresia = idmForm.Text,
                    idtickets = idtForm.Text,
                };
                var body = C.toJson();
                HttpContent co = new StringContent(body, Encoding.UTF8, "application/json");
                var response = await httpClient.PostAsync(url, co);

                if (response.IsSuccessStatusCode)
                {
                    var content = await response.Content.ReadAsStringAsync();
                    compras contenido = JsonConvert.DeserializeObject<compras>(content);
                    resultado.Text = "compra creada: id = " + contenido.id_compras + " fecha = " + contenido.fecha_compra;
                }
                else
                {
                    resultado.Text = "Insercion Fallida";
                }

                fecForm.Text = "";
                idtForm.Text = "";
                idmForm.Text = "";
            }
        }
        private void Button_Clicked(object sender, EventArgs e)
        {
            tbl_comprasAsync();
        }

    }
}