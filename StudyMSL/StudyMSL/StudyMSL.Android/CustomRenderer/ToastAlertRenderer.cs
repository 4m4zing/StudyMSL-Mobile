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
using StudyMSL.Droid.CustomRenderer;
using StudyMSL.Plugins.CustomRenderer;
using Xamarin.Forms;

[assembly: Xamarin.Forms.Dependency(typeof(ToastAlertRenderer))]
namespace StudyMSL.Droid.CustomRenderer
{
    public class ToastAlertRenderer: ToastAlert
    {
        public void LongAlert(string message)
        {
            Toast.MakeText(Android.App.Application.Context, message, ToastLength.Long).Show();
        }

        public void ShortAlert(string message)
        {
            Toast.MakeText(Android.App.Application.Context, message, ToastLength.Short).Show();
        }
    }
}