using StudyMSL.Plugins.CustomRenderer;
using StudyMSL.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace StudyMSL.Views.GamesAndQuizzes.Quizzes.FITB
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class FITBQuizPage : ContentPage
    {
        //Variable Assignments
        int answered = 0;
        int questionQuantity = 10;
        double totalTime = 60;
        string inputanswer, questionid, questiontitle, questiontype, questioncontent;

        //Overload Ctor
        public FITBQuizPage(string id, string title, string type)
        {
            InitializeComponent();

            if (type == "number")
            {
                etyAnswer.IsVisible = false;
                etyAnswerNumber.IsVisible = true;
            }
            else
            {
                etyAnswer.IsVisible = true;
                etyAnswerNumber.IsVisible = false;
            }

            etyAnswer.Completed += (object sender, EventArgs e) =>
            {
                btnNext_OnClicked(sender, e);
            };

            etyAnswerNumber.Completed += (object sender, EventArgs e) =>
            {
                btnNext_OnClicked(sender, e);
            };

            MessagingCenter.Subscribe<QuestionViewModel>(this, "TimeOut", (view) => DisplayAlertTime());
            ((QuestionViewModel)BindingContext).Init(type);
            ((QuestionViewModel)BindingContext).setQuestionNo(answered + 1);
            ((QuestionViewModel)BindingContext).startTimer();

            questionid = id;
            questiontitle = title;
            questiontype = type;
            questioncontent = "Fill in the Blank Questions";
        }

        //Entry Answer Text Event Handler
        private void etyAnswer_Text(object sender, TextChangedEventArgs e)
        {
            inputanswer = etyAnswer.Text.ToUpper();
        }

        //Entry AnswerNumber Text Event Handler
        private void etyAnswerNumber_Text(object sender, TextChangedEventArgs e)
        {
            inputanswer = etyAnswerNumber.Text.ToString();
        }

        //Button Next Event Handler
        private void btnNext_OnClicked(object sender, EventArgs e)
        {
            DoAnswer();
            etyAnswer.Text = "";
            etyAnswerNumber.Text = "";
        }

        //Handle Answer Checking
        private void DoAnswer()
        {
            answered++;

            if (answered < questionQuantity)
            {
                checkAnswer();
                ((QuestionViewModel)BindingContext).NextQuestion();
                ((QuestionViewModel)BindingContext).setQuestionNo(answered + 1);
            }
            else
            {
                checkAnswer();
                checkComplete();
            }
        }

        //Check Answer and Change Score
        private void checkAnswer()
        {
            if (((QuestionViewModel)BindingContext).isCorrect(inputanswer))
            {
                ((QuestionViewModel)BindingContext).setScore();
                DependencyService.Get<ToastAlert>().ShortAlert("Correct Answer!  +1 point");
            }
            else
            {
                DependencyService.Get<ToastAlert>().ShortAlert("Wrong Answer!  +0 point");
            }
        }

        //Check Done
        private void checkComplete()
        {
            DisplayAlertScore();
        }

        //Show Score Alert
        private async void DisplayAlertScore()
        {
            ((QuestionViewModel)BindingContext).stopTimer();
            var score = ((QuestionViewModel)BindingContext).getScore();
            var usedTime = totalTime - ((QuestionViewModel)BindingContext).getTime();

            await DisplayAlert("Game Over", "Score: " + score + "/10" + "\nTime used: " + usedTime + "s" + "\n\nClick OK to return", "OK");
            UpdateProgress();
            Navigation.PopAsync();
        }

        //Show Time Alert
        private async void DisplayAlertTime()
        {
            var score = ((QuestionViewModel)BindingContext).getScore();

            await DisplayAlert("Time's Up", "Score: " + score + "/10" + " \n\nClick OK to return", "OK");
            UpdateProgress();
            Navigation.PopAsync();
        }

        //Handle Progress
        private void UpdateProgress()
        {
            var user = App.Current.Properties["Username"] as string;
            if (user != "User")
            {
                ((QuestionViewModel)BindingContext).DoProgress(questionid, questiontitle, questiontype, questioncontent);
            }
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();
            DisplayAlert("Info", "Within 60 seconds, try to answer all 10 questions" + " \n\nClick OK to continue", "OK");
        }

        protected override void OnDisappearing()
        {
            base.OnDisappearing();

            ((QuestionViewModel)BindingContext).stopTimer();
            MessagingCenter.Unsubscribe<QuestionViewModel>(this, "TimeOut");
        }

        //Handle Device Display Resolution
        protected override void OnSizeAllocated(double width, double height)
        {
            base.OnSizeAllocated(width, height);

            var size = height / 1.8;

            imgQuestion.WidthRequest = size;
            imgQuestion.HeightRequest = size;
        }
    }
}