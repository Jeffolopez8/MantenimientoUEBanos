using Android.App;
using Android.Content;
using Android.Content.PM;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MantenimientoUEBanos.Droid.Resources
{
    [Activity(Label = "Mantenimiento UEBaños App", Icon = "@mipmap/LOGO",
       Theme = "@style/nuevotema", MainLauncher = true,
       ConfigurationChanges = ConfigChanges.ScreenSize)]
    internal class SplashScreen : Activity
    {
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            StartActivity(new Intent(Application.Context, typeof(MainActivity)));
            // Create your application here
        }
    }
}