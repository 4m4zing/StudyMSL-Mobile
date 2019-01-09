using StudyMSL.Plugins.CustomRenderer;
using StudyMSL.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace StudyMSL.Views.GamesAndQuizzes.Games.Memory
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class MemoryGamePage : ContentPage
    {
        //Variable Assignments
        int clicked1, clicked2;
        int counterClick = 0;
        double totalTime = 60;
        bool imgCard1_matched = false, imgCard2_matched = false, imgCard3_matched = false;
        bool imgCard4_matched = false, imgCard5_matched = false, imgCard6_matched = false;
        string questionid, questiontitle, questiontype, questioncontent;

        //Overload Ctor
        public MemoryGamePage(string id, string title, string type)
        {
            InitializeComponent();

            MessagingCenter.Subscribe<MemoryMatchingViewModel>(this, "TimeOut", (view) => DisplayAlertTime());
            ((MemoryMatchingViewModel)BindingContext).Init(type);
            ((MemoryMatchingViewModel)BindingContext).startTimer();

            questionid = id;
            questiontitle = title;
            questiontype = type;
            questioncontent = "Memory Matching Game";
        }

        //FrameCard 1 Event Handler
        void imgFrameCard1_OnClicked(object sender, EventArgs e)
        {
            if (clicked1 != 1 && clicked2 != 1 && imgCard1_matched != true)
            {
                updateCard(1);
                DoAnswer(1);
            }
        }

        //FrameCard 2 Event Handler
        void imgFrameCard2_OnClicked(object sender, EventArgs e)
        {
            if (clicked1 != 2 && clicked2 != 2 && imgCard2_matched != true)
            {
                updateCard(2);
                DoAnswer(2);
            }
        }

        //FrameCard 3 Event Handler
        void imgFrameCard3_OnClicked(object sender, EventArgs e)
        {
            if (clicked1 != 3 && clicked2 != 3 && imgCard3_matched != true)
            {
                updateCard(3);
                DoAnswer(3);
            }
        }

        //FrameCard 4 Event Handler
        void imgFrameCard4_OnClicked(object sender, EventArgs e)
        {
            if (clicked1 != 4 && clicked2 != 4 && imgCard4_matched != true)
            {
                updateCard(4);
                DoAnswer(4);
            }
        }

        //FrameCard 5 Event Handler
        void imgFrameCard5_OnClicked(object sender, EventArgs e)
        {
            if (clicked1 != 5 && clicked2 != 5 && imgCard5_matched != true)
            {
                updateCard(5);
                DoAnswer(5);
            }
        }

        //FrameCard 6 Event Handler
        void imgFrameCard6_OnClicked(object sender, EventArgs e)
        {
            if (clicked1 != 6 && clicked2 != 6 && imgCard6_matched != true)
            {
                updateCard(6);
                DoAnswer(6);
            }
        }

        //Handle Answer Checking
        void DoAnswer(int whichClicked)
        {
            ((MemoryMatchingViewModel)BindingContext).setStep();

            if (counterClick == 0)
            {
                counterClick++;
                clicked1 = whichClicked;
            }
            else if (counterClick == 1)
            {
                counterClick--;
                clicked2 = whichClicked;
                compare();
                clicked1 = 0;
                clicked2 = 0;
                updateCard();
            }
            else
            {
            }
        }

        //Compare Answer and Change Score
        void compare()
        {
            if (((MemoryMatchingViewModel)BindingContext).isCorrect(clicked1, clicked2))
            {
                DependencyService.Get<ToastAlert>().ShortAlert("Matched!  +2 points");
                checkDone(clicked1);
                checkDone(clicked2);
                checkComplete();
            }
            else
            {
                DependencyService.Get<ToastAlert>().ShortAlert("Not Matched!  -5 points");
            }
        }

        //Change Done Status
        void checkDone(int clicked)
        {
            if (clicked == 1)
            {
                imgCard1_matched = true;
            }
            else if (clicked == 2)
            {
                imgCard2_matched = true;
            }
            else if (clicked == 3)
            {
                imgCard3_matched = true;
            }
            else if (clicked == 4)
            {
                imgCard4_matched = true;
            }
            else if (clicked == 5)
            {
                imgCard5_matched = true;
            }
            else if (clicked == 6)
            {
                imgCard6_matched = true;
            }
            else
            {
            }
        }

        //Check If All Statuses Are Done
        void checkComplete()
        {
            if ((imgCard1_matched) && (imgCard2_matched) && (imgCard3_matched) && (imgCard4_matched) && (imgCard5_matched) && (imgCard6_matched))
            {
                DisplayAlertScore();
            }
        }

        //Handle Card Flipping
        async void updateCard(int val)
        {
            await Task.Delay(850);

            if (val == 1)
            {
                vf1.OnTapped(1);
            }
            if (val == 2)
            {
                vf2.OnTapped(1);
            }
            if (val == 3)
            {
                vf3.OnTapped(1);
            }
            if (val == 4)
            {
                vf4.OnTapped(1);
            }
            if (val == 5)
            {
                vf5.OnTapped(1);
            }
            if (val == 6)
            {
                vf6.OnTapped(1);
            }
        }

        //Handle Card Flipping
        async void updateCard()
        {
            await Task.Delay(2000);

            if (imgCard1_matched != true)
            {
                vf1.OnTapped(2);
            }
            if (imgCard2_matched != true)
            {
                vf2.OnTapped(2);
            }
            if (imgCard3_matched != true)
            {
                vf3.OnTapped(2);
            }
            if (imgCard4_matched != true)
            {
                vf4.OnTapped(2);
            }
            if (imgCard5_matched != true)
            {
                vf5.OnTapped(2);
            }
            if (imgCard6_matched != true)
            {
                vf6.OnTapped(2);
            }
        }

        //Show Score Alert
        private async void DisplayAlertScore()
        {
            var score = ((MemoryMatchingViewModel)BindingContext).getScore();
            var usedTime = totalTime - ((MemoryMatchingViewModel)BindingContext).getTime();
            int step = ((MemoryMatchingViewModel)BindingContext).getStep();
            ((MemoryMatchingViewModel)BindingContext).stopTimer();

            await Task.Delay(1000);

            await DisplayAlert("Game Over", "Score: " + score + "\nSteps: " + step + "\nTime used: " + usedTime + "s" + "\n\nClick OK to return", "OK");
            UpdateProgress();
            Navigation.PopAsync();
        }

        //Show Time Alert
        private async void DisplayAlertTime()
        {
            var score = ((MemoryMatchingViewModel)BindingContext).getScore();

            await DisplayAlert("Time's Up", "Score: " + score + " \n\nClick OK to return", "OK");
            UpdateProgress();
            Navigation.PopAsync();
        }

        //Handle Progress
        private void UpdateProgress()
        {
            var user = App.Current.Properties["Username"] as string;
            if (user != "User")
            {
                ((MemoryMatchingViewModel)BindingContext).DoProgress(questionid, questiontitle, questiontype, questioncontent);
            }
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();

            DisplayAlert("Info", "Within 60 seconds, try to match all gestures with their names" + " \n\nClick OK to continue", "OK");
        }

        protected override void OnDisappearing()
        {
            base.OnDisappearing();

            ((MemoryMatchingViewModel)BindingContext).stopTimer();
            MessagingCenter.Unsubscribe<MemoryMatchingViewModel>(this, "TimeOut");
        }

        //Handle Device Display Resolution
        protected override void OnSizeAllocated(double width, double height)
        {
            base.OnSizeAllocated(width, height);

            var size = width / 3;

            imgBackCard1.WidthRequest = size;
            imgBackCard1.HeightRequest = size;
            imgFrontCard1.WidthRequest = size;
            imgFrontCard1.HeightRequest = size;

            imgBackCard2.WidthRequest = size;
            imgBackCard2.HeightRequest = size;
            imgFrontCard2.WidthRequest = size;
            imgFrontCard2.HeightRequest = size;

            imgBackCard3.WidthRequest = size;
            imgBackCard3.HeightRequest = size;
            imgFrontCard3.WidthRequest = size;
            imgFrontCard3.HeightRequest = size;

            imgBackCard4.WidthRequest = size;
            imgBackCard4.HeightRequest = size;
            imgFrontCard4.WidthRequest = size;
            imgFrontCard4.HeightRequest = size;

            imgBackCard5.WidthRequest = size;
            imgBackCard5.HeightRequest = size;
            imgFrontCard5.WidthRequest = size;
            imgFrontCard5.HeightRequest = size;

            imgBackCard6.WidthRequest = size;
            imgBackCard6.HeightRequest = size;
            imgFrontCard6.WidthRequest = size;
            imgFrontCard6.HeightRequest = size;
        }
    }
}