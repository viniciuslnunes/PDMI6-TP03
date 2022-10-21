using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using System.Net.Http;
using Newtonsoft.Json;
namespace FetchData
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
            Login();
        }

        public async void Login()
        {
            var httpClient = new HttpClient();
            var response = await httpClient.GetStringAsync("http://10.0.2.2:50049/api/Logins1");
            var login = JsonConvert.DeserializeObject<List<Login>>(response);
            ListLogin.ItemsSource = login;
        }
        async void btnReload(object sender, EventArgs e)
        {
            var httpClient = new HttpClient();
            var response = await httpClient.GetStringAsync("http://10.0.2.2:50049/api/Logins1");
            var login = JsonConvert.DeserializeObject<List<Login>>(response);
            ListLogin.ItemsSource = login;
        }
    }
}
