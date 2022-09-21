using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace PruebaExamen.tabla_tickets
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class PutTickets : ContentPage
    {
        private string url = "https://desfrlopez.me/hmatamoros2/api/tbl_tickets";
        public PutTickets()
        {
            InitializeComponent();
        }
        private async Task tbl_TicketsAsync()
        {
            using (var httpClient = new HttpClient())
            {
                tickets T = new tickets()
                {
                    id_tickets = int.Parse(idForm.Text),
                    fila = filForm.Text,
                    Precio = preForm.Text,
                    idevento = ideForm.Text,
                };
                url = url + "/" + T.id_tickets;
                var body = T.toJson();
                HttpContent ti = new StringContent(body, Encoding.UTF8, "application/json");
                var response = await httpClient.PutAsync(url, ti);

                if (response.IsSuccessStatusCode)
                {
                    var content = await response.Content.ReadAsStringAsync();
                    resultado.Text = "Actualizacion Exitosa";
                }
                else
                {
                    resultado.Text = "Insercion Fallida";
                }
                idForm.Text = "";
                filForm.Text = "";
                preForm.Text = "";
                ideForm.Text = "";
            }
        }
        private void Button_Clicked(object sender, EventArgs e)
        {
            tbl_TicketsAsync();
        }
        private void idForm_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

    }
}