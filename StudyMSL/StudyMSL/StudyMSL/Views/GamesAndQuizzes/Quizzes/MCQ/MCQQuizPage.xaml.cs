﻿using StudyMSL.Plugins.CustomRenderer;
using StudyMSL.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace StudyMSL.Views.GamesAndQuizzes.Quizzes.MCQ
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class MCQQuizPage : ContentPage
    {
        //Variable Assignments
        int answered = 0;
        int questionQuantity = 10;
        double totalTime = 60;
        string contentid, questionid, questiontitle, questiontype, questioncontent;

        //Overload Ctor
        public MCQQuizPage(string id, string title, string type)
        {
            InitializeComponent();

            MessagingCenter.Subscribe<QuestionViewModel>(this, "TimeOut", (view) => DisplayAlertTime());
            ((QuestionViewModel)BindingContext).Init(type);
            ((QuestionViewModel)BindingContext).setQuestionNo(answered + 1);
            ((QuestionViewModel)BindingContext).startTimer();
            //this.BindingContext = new QAlphabetsViewModel();

            questionid = id;
            questiontitle = title;
            questiontype = type;
            questioncontent = "Multiple Choice Questions";
        }

        //Button Answer 1 Event Handler
        private void btnAnswer1_OnClicked(object sender, EventArgs e)
        {
            DoAnswer(1);
        }

        //Button Answer 2 Event Handler
        private void btnAnswer2_OnClicked(object sender, EventArgs e)
        {
            DoAnswer(2);
        }

        //Button Answer 3 Event Handler
        private void btnAnswer3_OnClicked(object sender, EventArgs e)
        {
            DoAnswer(3);
        }

        //Button Answer 4 Event Handler
        private void btnAnswer4_OnClicked(object sender, EventArgs e)
        {
            DoAnswer(4);
        }

        //Handle Answer Checking
        private void DoAnswer(int clickedButton)
        {
            answered++;

            if (answered < questionQuantity)
            {
                CheckAnswer(clickedButton);
                ((QuestionViewModel)BindingContext).NextQuestion();
                ((QuestionViewModel)BindingContext).setQuestionNo(answered + 1);
            }
            else
            {
                CheckAnswer(clickedButton);
                CheckComplete();
            }
        }

        //Check Answer and Change Score
        void CheckAnswer(int clickedButton)
        {
            if (((QuestionViewModel)BindingContext).isCorrect(clickedButton))
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
        private void CheckComplete()
        {
            DisplayAlertScore();
        }

        //Show Score Alert
        private async void DisplayAlertScore()
        {
            var score = ((QuestionViewModel)BindingContext).getScore();
            var usedTime = totalTime - ((QuestionViewModel)BindingContext).getTime();
            ((QuestionViewModel)BindingContext).stopTimer();

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

            var size = height / 2.5;

            imgQuestion.WidthRequest = size;
            imgQuestion.HeightRequest = size;
        }
    }
}