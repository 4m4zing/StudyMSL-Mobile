using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;

namespace StudyMSL.Droid
{
    //[Activity( Label = "Study MSL",
    //    Icon = "@drawable/Icon_StudyMSL_v4",
    //    Theme = "@style/SplashTheme", //Indicates the theme to use for this activity
    //    MainLauncher = true, //Set it as boot activity
    //    NoHistory = true)] //Doesn't place it in back stack
    //public class SplashActivity : Activity
    //{
    //    protected override void OnCreate(Bundle bundle)
    //    {
    //        base.OnCreate(bundle);
    //        System.Threading.Thread.Sleep(2000); //Let's wait awhile...
    //        this.StartActivity(typeof(MainActivity));
    //    }
    //}

    [Activity(Label = "Study MSL",
        Icon = "@drawable/Icon_StudyMSL_v4",
        Theme = "@style/SplashTheme", //Indicates the theme to use for this activity
        MainLauncher = true, //Set it as boot activity
        NoHistory = true)] //Doesn't place it in back stack
    public class SplashActivity : Activity
    {
        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);

            System.Threading.Thread.Sleep(1000); //Let's wait awhile...
            this.StartActivity(typeof(MainActivity));
        }
    }
}