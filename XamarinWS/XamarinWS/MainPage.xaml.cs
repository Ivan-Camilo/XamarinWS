using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Xamarin.Forms;

namespace XamarinWS
{
    public partial class MainPage : ContentPage
    {

        private const string Url = "http://192.168.100.12/semana5/post.php"; //tiene que ser la IP de maquina
        private readonly HttpClient client = new HttpClient();
        private ObservableCollection<XamarinWS.Ws.Datos> _post;
        public MainPage()
        {
            InitializeComponent();
           
        }

        private async void btnGet_Clicked(object sender, EventArgs e)
        {
            var content = await client.GetStringAsync(Url);
            List<XamarinWS.Ws.Datos> posts = JsonConvert.DeserializeObject<List<XamarinWS.Ws.Datos>>(content);
            _post = new ObservableCollection<XamarinWS.Ws.Datos>(posts);
            MyListView.ItemsSource = _post;
            base.OnAppearing();
        }

        private void btnRegistro_Clicked(object sender, EventArgs e)
        {
            Navigation.PushAsync(new Registro());
        }

       
        void MyListView_ItemTapped(System.Object sender, Xamarin.Forms.ItemTappedEventArgs e)
        {
          
            var id = (Ws.Datos)e.Item;
            int id2 = id.codigo;


            DisplayAlert("Alerta", id2.ToString(), "Cerrar");
            Navigation.PushAsync(new Actualizar(id2));
        }
    }
}

