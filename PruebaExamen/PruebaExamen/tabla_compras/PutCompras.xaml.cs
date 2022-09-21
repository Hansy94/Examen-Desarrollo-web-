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
    public partial class PutCompras : ContentPage
    {
        private string url = "https://desfrlopez.me/hmatamoros2/api/tbl_compras";

        public PutCompras()
        {
            InitializeComponent();
        }
        private async Task tbl_PutcomprasAsync()
        {
            using (var httpClient = new HttpClient())
            {
                compras C = new compras()
                {
                    id_compras = int.Parse(idForm.Text),
                    fecha_compra = fecForm.Text,
                    idmembresia = idmForm.Text,
                    idtickets = idtForm.Text,
                };
                url = url + "/" + C.id_compras;
                var body = C.toJson();
                HttpContent co = new StringContent(body, Encoding.UTF8, "application/json");
                var response = await httpClient.PutAsync(url, co);

                if (response.IsSuccessStatusCode)
                {
                    var content = await response.Content.ReadAsStringAsync();
                    resultado.Text = "Actualizacion Exitosa";

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
            tbl_PutcomprasAsync();
        }
        private void idForm_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

    }
}


    
