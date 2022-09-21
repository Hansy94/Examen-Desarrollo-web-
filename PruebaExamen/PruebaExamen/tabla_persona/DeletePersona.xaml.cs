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
    public partial class DeletePersona : ContentPage
    {
        private string url = "https://desfrlopez.me/hmatamoros2/api/tbl_persona";


        public DeletePersona()
        {
            InitializeComponent();
        }

        private async Task eliminarpersonasAsync()
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
            eliminarpersonasAsync();
        }
    }
}