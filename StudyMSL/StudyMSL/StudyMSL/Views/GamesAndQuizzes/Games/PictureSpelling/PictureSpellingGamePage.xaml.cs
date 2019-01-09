using StudyMSL.Plugins.CustomRenderer;
using StudyMSL.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace StudyMSL.Views.GamesAndQuizzes.Games.PictureSpelling
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class PictureSpellingGamePage : ContentPage
    {
        //Variable Assignments
        int answered = 0;
        int position = 1;
        int totalTime = 60;
        string answer = "", questionid, questiontitle, questiontype, questioncontent;

        //Overload Ctor
        public PictureSpellingGamePage(string id, string title, string type)
        {
            InitializeComponent();

            MessagingCenter.Subscribe<PictureSpellingViewModel>(this, "TimeOut", (view) => DisplayAlertTime());
            ((PictureSpellingViewModel)BindingContext).Init(type);
            ((PictureSpellingViewModel)BindingContext).setQuestionNo(answered + 1);
            ((PictureSpellingViewModel)BindingContext).startTimer();

            questionid = id;
            questiontitle = title;
            questiontype = type;
            questioncontent = "Picture Spelling Game";
        }

        //Image 1 Event Handler
        private void image1_OnClicked(object sender, EventArgs e)
        {
            DoAnswer(1);
        }

        //Image 2 Event Handler
        private void image2_OnClicked(object sender, EventArgs e)
        {
            DoAnswer(2);
        }

        //Image 3 Event Handler
        private void image3_OnClicked(object sender, EventArgs e)
        {
            DoAnswer(3);
        }

        //Image 4 Event Handler
        private void image4_OnClicked(object sender, EventArgs e)
        {
            DoAnswer(4);
        }

        //Image 5 Event Handler
        private void image5_OnClicked(object sender, EventArgs e)
        {
            DoAnswer(5);
        }

        //Image 6 Event Handler
        private void image6_OnClicked(object sender, EventArgs e)
        {
            DoAnswer(6);
        }

        //Image 7 Event Handler
        private void image7_OnClicked(object sender, EventArgs e)
        {
            DoAnswer(7);
        }

        //Image 8 Event Handler
        private void image8_OnClicked(object sender, EventArgs e)
        {
            DoAnswer(8);
        }

        //Button CheckAnswer Event Handler
        private void btnCheckAnswer_OnClicked(object sender, EventArgs e)
        {
            if (answered < 3)
            {
                if (((PictureSpellingViewModel)BindingContext).isCorrect(answer))
                {
                    ((PictureSpellingViewModel)BindingContext).NextQuestion(questiontype);
                    position = 1;
                    ((PictureSpellingViewModel)BindingContext).emptyImage();
                    answer = "";
                    DependencyService.Get<ToastAlert>().ShortAlert("Correct Answer!  +1 point");

                    answered++;
                    ((PictureSpellingViewModel)BindingContext).setQuestionNo(answered + 1);
                }
                else
                {
                    DependencyService.Get<ToastAlert>().ShortAlert("Wrong Answer!  +0 point");
                }
            }
            else
            {
                if (((PictureSpellingViewModel)BindingContext).isCorrect(answer))
                {
                    DependencyService.Get<ToastAlert>().ShortAlert("Correct Answer!  +1 point");
                    answered++;
                }
                else
                {
                    DependencyService.Get<ToastAlert>().ShortAlert("Wrong Answer!  +0 point");
                }

                CheckComplete();
            }
        }

        //Button ResetAnswer Event Handler
        private void btnResetAnswer_OnClicked(object sender, EventArgs e)
        {
            position = 1;
            ((PictureSpellingViewModel)BindingContext).emptyImage();
            answer = "";
        }

        //Handle Answer Checking
        private void DoAnswer(int button)
        {
            if (position <= 8)
            {
                var addition = ((PictureSpellingViewModel)BindingContext).getValue(button);
                answer += addition;
                ((PictureSpellingViewModel)BindingContext).setImage(position, addition, questiontype);
                position++;
            }
        }

        //Change Done
        private void CheckComplete()
        {
            DisplayAlertScore();
        }

        //Show Score Alert
        private async void DisplayAlertScore()
        {
            var score = ((PictureSpellingViewModel)BindingContext).getScore();
            var usedTime = totalTime - ((PictureSpellingViewModel)BindingContext).getTime();
            ((PictureSpellingViewModel)BindingContext).stopTimer();

            await DisplayAlert("Game Over", "Score: " + score + "/4" + "\nTime used: " + usedTime + "s" + "\n\nClick OK to return", "OK");
            UpdateProgress();
            Navigation.PopAsync();
        }

        //Show Time Alert
        private async void DisplayAlertTime()
        {
            var score = ((PictureSpellingViewModel)BindingContext).getScore();

            await DisplayAlert("Time's Up", "Score: " + score + "/4" + " \n\nClick OK to return", "OK");
            UpdateProgress();
            Navigation.PopAsync();
        }

        //Handle Progress
        private void UpdateProgress()
        {
            var user = App.Current.Properties["Username"] as string;
            if (user != "User")
            {
                ((PictureSpellingViewModel)BindingContext).DoProgress(questionid, questiontitle, questiontype, questioncontent);
            }
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();

            DisplayAlert("Info", "Within 60 seconds, try to answer all 4 questions" + " \n\nClick OK to continue", "OK");
        }

        protected override void OnDisappearing()
        {
            base.OnDisappearing();

            ((PictureSpellingViewModel)BindingContext).stopTimer();
            MessagingCenter.Unsubscribe<PictureSpellingViewModel>(this, "TimeOut");
        }

        //Handle Device Display Resolution
        protected override void OnSizeAllocated(double width, double height)
        {
            base.OnSizeAllocated(width, height);

            var size1 = height / 4;
            var size2 = height / 9;
            var size3 = width / 10;

            imgQuestion.WidthRequest = size1;
            imgQuestion.HeightRequest = size1;

            imgQ1.WidthRequest = size2;
            imgQ1.HeightRequest = size2;
            imgQ2.WidthRequest = size2;
            imgQ2.HeightRequest = size2;
            imgQ3.WidthRequest = size2;
            imgQ3.HeightRequest = size2;
            imgQ4.WidthRequest = size2;
            imgQ4.HeightRequest = size2;
            imgQ5.WidthRequest = size2;
            imgQ5.HeightRequest = size2;
            imgQ6.WidthRequest = size2;
            imgQ6.HeightRequest = size2;
            imgQ7.WidthRequest = size2;
            imgQ7.HeightRequest = size2;
            imgQ8.WidthRequest = size2;
            imgQ8.HeightRequest = size2;

            imgA1.WidthRequest = size3;
            imgA1.HeightRequest = size3;
            imgA2.WidthRequest = size3;
            imgA2.HeightRequest = size3;
            imgA3.WidthRequest = size3;
            imgA3.HeightRequest = size3;
            imgA4.WidthRequest = size3;
            imgA4.HeightRequest = size3;
            imgA5.WidthRequest = size3;
            imgA5.HeightRequest = size3;
            imgA6.WidthRequest = size3;
            imgA6.HeightRequest = size3;
            imgA7.WidthRequest = size3;
            imgA7.HeightRequest = size3;
            imgA8.WidthRequest = size3;
            imgA8.HeightRequest = size3;
        }
    }
}