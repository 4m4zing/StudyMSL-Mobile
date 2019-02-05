using StudyMSL.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace StudyMSL.Views.Sentences
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class SentencesLearningPage : ContentPage
    {
        //Variable Assignments
        string learntype;

        //Overload Ctor
        public SentencesLearningPage(string type)
        {
            InitializeComponent();
            learntype = type;
        }

        //Button Translate Event Handler
        private async void btnTranslate_OnClicked(object sender, EventArgs e)
        {
            if (!string.IsNullOrWhiteSpace(etySentence.Text))
            {
                btnTranslate.IsEnabled = false;

                ((LearnViewModel)BindingContext).emptyLearnList();

                //string[] toSplit = etySentence.Text.ToString().Split(' ');
                string[] toSplit = etySentence.Text.ToString().Split(" ,-!.?+*".ToCharArray(), StringSplitOptions.RemoveEmptyEntries);

                foreach (string word in toSplit)
                {
                    await ((LearnViewModel)BindingContext).WordsByWords(word, learntype);
                }

                ((LearnViewModel)BindingContext).setLearnOC();

                btnTranslate.IsEnabled = true;
            }
            else
            {
                await DisplayAlert("Warning", "Please enter a sentence in the required field \n\nClick OK to continue", "OK");
            }
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();

            DisplayAlert("Info", "Swipe the page left or right to go to the next gesture" + " \n\nClick OK to continue", "OK");
        }

        protected override void OnDisappearing()
        {
            base.OnDisappearing();

            MessagingCenter.Send(this, "Clear");
        }
    }
}