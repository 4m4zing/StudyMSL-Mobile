using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Xamarin.Forms;

namespace StudyMSL
{
	public partial class App : Application
	{
		public App ()
		{
			InitializeComponent();

            //MainPage = new StudyMSL.Views.Main.MasterDetailMainPage();
            MainPage = new NavigationPage(new StudyMSL.Views.Main.LoginPage());
            //MainPage = new NavigationPage(new StudyMSL.Views.Sentences.SentencesLearningPage());
        }

        protected override void OnStart ()
		{
			// Handle when your app starts
		}

		protected override void OnSleep ()
		{
			// Handle when your app sleeps
		}

		protected override void OnResume ()
		{
			// Handle when your app resumes
		}
	}
}
