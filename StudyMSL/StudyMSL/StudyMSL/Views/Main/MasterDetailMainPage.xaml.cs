using StudyMSL.Models;
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
	public partial class MasterDetailMainPage : MasterDetailPage
	{
        //Default Ctor
		public MasterDetailMainPage ()
		{
            InitializeComponent();

            masterPage.ListView.ItemTapped += OnItemTapped;
        }

        //Listview Detail Tap Handler
        private void OnItemTapped(Object sender, ItemTappedEventArgs args)
        {
            var item = args.Item as MainMenuItem;
            if (item != null)
            {
                Detail = new NavigationPage((Page)Activator.CreateInstance(item.TargetType));
                IsPresented = false;
            }
        }
    }
}