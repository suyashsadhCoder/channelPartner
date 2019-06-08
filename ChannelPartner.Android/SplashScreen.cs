using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.Content.PM;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using ChannelPartner.Controls;
using Plugin.Permissions;

namespace ChannelPartner.Droid
{
    [Activity(Label = "Channel Partner", Theme = "@style/MainTheme.Splash", MainLauncher = true, NoHistory = true)]
    public class SplashScreen : Activity
    {
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            
            
            StartActivity(typeof(MainActivity));
        }
       
    }
}