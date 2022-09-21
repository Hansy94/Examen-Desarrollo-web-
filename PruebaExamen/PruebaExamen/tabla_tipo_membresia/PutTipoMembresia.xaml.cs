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
    public partial class PutTipoMembresia : ContentPage
    {
        private string url = "https://desfrlopez.me/hmatamoros2/api/tbl_tipo_membresia";

        public PutTipoMembresia()
        {
            InitializeComponent();
        }

        private async Task tbl_tmembresiaAsync()
        {
            using (var httpClient = new HttpClient())
            {

                tipomembresia TM = new tipomembresia()
                {
                    id_tipo_membresia = int.Parse(idForm.Text),
                    descripcion = desForm.Text,
                    
                };
                url = url + "/" + TM.id_tipo_membresia;
                var body = TM.toJson();
                HttpContent t = new StringContent(body, Encoding.UTF8, "application/json");
                var response = await httpClient.PutAsync(url, t);

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
            tbl_tmembresiaAsync();
        }
        private void idForm_TextChanged(object sender, TextChangedEventArgs e)
        {

        }
    }
}