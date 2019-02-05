using StudyMSL.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace StudyMSL.Views.Learn.Fingerspelling
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class FingerspellingLearningPage : ContentPage
    {
        //Variable Assignments
        string learnid, learntitle, learntype, learncontent;

        //Overload Ctor
        public FingerspellingLearningPage(string id, string title, string type, string content)
        {
            InitializeComponent();

            learnid = id;
            learntitle = title;
            learntype = type;
            learncontent = content;
            Title = title;
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();

            ((LearnViewModel)BindingContext).Init(learnid);

            var user = App.Current.Properties["Username"] as string;
            if (user != "User")
            {
                ((LearnViewModel)BindingContext).DoProgress(learnid, learntitle, learntype, learncontent);
            }

            DisplayAlert("Info", "Swipe the page left or right to go to the next gesture" + " \n\nClick OK to continue", "OK");
        }

        protected override void OnDisappearing()
        {
            base.OnDisappearing();

            // Inform the view model that it is disappearing so that it can remove event handlers
            // and perform any other clean-up required..
            ((LearnViewModel)BindingContext).destroyProgress();
            MessagingCenter.Send(this, "Clear");
        }
    }
}