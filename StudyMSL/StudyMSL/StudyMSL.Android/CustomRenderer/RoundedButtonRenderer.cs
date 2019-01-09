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
using Xamarin.Forms.Platform.Android;

[assembly: ExportRenderer(typeof(RoundedButton), typeof(RoundedButtonRenderer))]
namespace StudyMSL.Droid.CustomRenderer
{
    public class RoundedButtonRenderer : ButtonRenderer
    {
        //private GradientDrawable _gradientBackground;

        public RoundedButtonRenderer(Context context) : base(context)
        {
        }
    }
}