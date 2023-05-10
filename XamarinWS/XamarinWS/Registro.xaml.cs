using System;
using System.Collections.Generic;
using System.Net;
using Xamarin.Forms;

namespace XamarinWS
{	
	public partial class Registro : ContentPage
	{	
		public Registro ()
		{
			InitializeComponent ();
		}

		private async void btnInsertar_Clicked(object sender, EventArgs e)
		{

			try
			{
				WebClient cliente = new WebClient();
				var parametros = new System.Collections.Specialized.NameValueCollection();
				parametros.Add("codigo", txtCodigo.Text);
                parametros.Add("nombre", txtNombre.Text);
                parametros.Add("ubicacion", txtUbicacion.Text);
                parametros.Add("extension", txtExtension.Text);
                parametros.Add("tipo", txtTipo.Text);
                parametros.Add("variedad", txtVariedad.Text);
                parametros.Add("encargado", txtEncargado.Text);
                parametros.Add("ncamas", txtNCamas.Text);

				cliente.UploadValues("http://192.168.100.12/semana5/post.php", "POST", parametros);
				await DisplayAlert("Alerta", "Dato Ingresado Correctamente", "OK");


            }
			catch(Exception ex)
			{
				await DisplayAlert("Alerta", ex.Message, "Cerrar");
			}
		}

        private void btnRegresar_Clicked(object sender, EventArgs e)
        {

			Navigation.PushAsync(new MainPage());
        }
    }
}

