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
    public partial class MasterPage : ContentPage
    {
        //Variable Assignments
        public ListView ListView { get { return listView; } }
        public List<MainMenuItem> MMItems;

        //Default Ctor
        public MasterPage()
        {
            InitializeComponent();

            var username = Application.Current.Properties["Username"] as string;
            lblName.Text = username;

            if (username == "User")
            {
                setItemUser();
            }
            else
            {
                setItemNotUser();
            }
        }

        //Set Detail Listview Items for Registered User
        private void setItemNotUser()
        {
            MMItems = new List<MainMenuItem>();
            MMItems.Add(new MainMenuItem("Home", "Icon_Home_128.png", typeof(HomePage)));
            MMItems.Add(new MainMenuItem("Learn", "Icon_Learn_128.png", typeof(LearnPage)));
            MMItems.Add(new MainMenuItem("Games And Quizzes", "Icon_GameQuiz_128.png", typeof(GamesAndQuizzesPage)));
            MMItems.Add(new MainMenuItem("Progress", "Icon_Progress_128.png", typeof(ProgressPage)));
            MMItems.Add(new MainMenuItem("Contribute", "Icon_Contribute_128.png", typeof(ContributePage)));
            MMItems.Add(new MainMenuItem("Search", "Icon_Search_128.png", typeof(SearchPage)));
            MMItems.Add(new MainMenuItem("Account Settings", "Icon_Settings_128.png", typeof(SettingsPage)));
            ListView.ItemsSource = MMItems;
        }

        //Set Detail Listview Items for Unregistered User
        private void setItemUser()
        {
            MMItems = new List<MainMenuItem>();
            MMItems.Add(new MainMenuItem("Home", "Icon_Home_128.png", typeof(HomePage)));
            MMItems.Add(new MainMenuItem("Learn", "Icon_Learn_128.png", typeof(LearnPage)));
            MMItems.Add(new MainMenuItem("Games And Quizzes", "Icon_GameQuiz_128.png", typeof(GamesAndQuizzesPage)));
            MMItems.Add(new MainMenuItem("Search", "Icon_Search_128.png", typeof(SearchPage)));
            ListView.ItemsSource = MMItems;
        }

        //Label Logout Event Handler
        private async void lblLogout_OnClicked(object sender, EventArgs e)
        {
            Application.Current.MainPage = new NavigationPage(new LoginPage());
        }
    }
}