using System;
using Android.Widget;
using Android.App;
using XamarinWS.Droid;
[assembly: Xamarin.Forms.Dependency(typeof(MensajeAndroid))] //Este archivo es consicerao al momento de ejecutar la app

namespace XamarinWS.Droid
{
	public class MensajeAndroid : Mensaje
	{
		public MensajeAndroid()
		{
		}

        public void longAlert(string mensaje)
        {
            Toast.MakeText(Application.Context , mensaje, ToastLength.Long).Show();
        }

        public void shortAlert(string mensaje)
        {
            Toast.MakeText(Application.Context, mensaje, ToastLength.Short).Show();
        }
    }
}

