using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace StudyMSL.Views.Main
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class LearnPage : TabbedPage
	{
        //Default Ctor
		public LearnPage ()
		{
			InitializeComponent ();
		}
    }
}