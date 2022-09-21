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
    public partial class DeleteTicket : ContentPage
    {
        private string url = "https://desfrlopez.me/hmatamoros2/api/tbl_tickets";


        public DeleteTicket()
        {
            InitializeComponent();
        }

        private async Task eliminarticketssAsync()
        {
            using (var httpClient = new HttpClient())
            {

                url = url + "/" + idForm.Text; // mandamos de parametro de url del id a modificar

                var response = await httpClient.DeleteAsync(url);

                if (response.IsSuccessStatusCode)
                {
                    var content = await response.Content.ReadAsStringAsync();
                    resultado.Text = "Borrado Exitoso";
                }
                else
                {
                    resultado.Text = "Borrado Fallido";
                }

                idForm.Text = "";


            }
        }

        private void Button_Clicked(object sender, EventArgs e)
        {
            eliminarticketssAsync();
        }
    }
}