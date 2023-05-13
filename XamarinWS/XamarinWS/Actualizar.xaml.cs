using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Net.Http;
using Newtonsoft.Json;
using Xamarin.Forms;
namespace XamarinWS
{	
	public partial class Actualizar : ContentPage
	{
        private const string Url = "http://192.168.100.12/semana5/post.php"; //tiene que ser la IP de maquina
        private readonly HttpClient client = new HttpClient();
        private ObservableCollection<XamarinWS.Ws.Datos> _post;
        private int id;

        public Actualizar (int id2)
		{
			InitializeComponent ();
            id = id2;
            Obtener();
            
		}

        public async void Obtener()
        {
            var content = await client.GetStringAsync(Url + "?codigo=" + id);

            await DisplayAlert("URL", Url + "?codigo=" + id, "Cerrar");
            await DisplayAlert("id", id.ToString(), "Cerrar");
            await DisplayAlert("Content", content.ToString(), "Cerrar");

            List<XamarinWS.Ws.Datos> posts = JsonConvert.DeserializeObject<List<XamarinWS.Ws.Datos>>(content);
            _post = new ObservableCollection<XamarinWS.Ws.Datos>(posts);
            MyListView1.ItemsSource = _post;
        }
    }
}

