using StudyMSL.Models;
using StudyMSL.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace StudyMSL.Views.ProgressView
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class AssessmentProgressPage : ContentPage
    {
        //Variable Assignments
        public List<Progress> PLItems;
        public List<Progress> PGQItems;
        Progress progress = new Progress();

        //Default Ctor
        public AssessmentProgressPage()
        {
            InitializeComponent();

            var username = App.Current.Properties["Username"] as string;
            setAssessmentItems();
        }

        //Set Listview Assessment Items
        private async void setAssessmentItems()
        {
            var userid = App.Current.Properties["Userid"] as string;

            PGQItems = new List<Progress>();
            await setAssessmentProgress(userid, "F01G01");
            PGQItems.Add(new Progress(userid, "F01G01", "Alphabets - Memory Matching Games", progress.content_desc, progress.date_completed));
            await setAssessmentProgress(userid, "F01G02");
            PGQItems.Add(new Progress(userid, "F01G02", "Alphabets - Picture Spelling Games", progress.content_desc + "/4", progress.date_completed));
            await setAssessmentProgress(userid, "F01Q01");
            PGQItems.Add(new Progress(userid, "F01Q01", "Alphabets - Multiple Choice Questions", progress.content_desc + "/10", progress.date_completed));
            await setAssessmentProgress(userid, "F01Q02");
            PGQItems.Add(new Progress(userid, "F01Q02", "Alphabets - Fill in the Blank Questions", progress.content_desc + "/10", progress.date_completed));
            await setAssessmentProgress(userid, "F02G01");
            PGQItems.Add(new Progress(userid, "F02G01", "Numbers - Memory Matching Games", progress.content_desc, progress.date_completed));
            await setAssessmentProgress(userid, "F02G02");
            PGQItems.Add(new Progress(userid, "F02G02", "Numbers - Picture Spelling Games", progress.content_desc + "/4", progress.date_completed));
            await setAssessmentProgress(userid, "F02Q01");
            PGQItems.Add(new Progress(userid, "F02Q01", "Numbers - Multiple Choice Questions", progress.content_desc + "/10", progress.date_completed));
            await setAssessmentProgress(userid, "F02Q02");
            PGQItems.Add(new Progress(userid, "F02Q02", "Numbers - Fill in the Blank Questions", progress.content_desc + "/10", progress.date_completed));
            //await setAssessmentProgress(userid, "WG01");
            //PGQItems.Add(new Progress(userid, "WG01", "Words - Memory Matching Games", progress.content_desc, progress.date_completed));
            await setAssessmentProgress(userid, "WQ01");
            PGQItems.Add(new Progress(userid, "WQ01", "Words - Multiple Choice Questions", progress.content_desc + "/10", progress.date_completed));
            await setAssessmentProgress(userid, "WQ02");
            PGQItems.Add(new Progress(userid, "WQ02", "Words - Fill in the Blank Questions", progress.content_desc + "/10", progress.date_completed));
            lvProgressAssessment.ItemsSource = PGQItems;
        }

        //Get Listview Assessment Item
        private async Task setAssessmentProgress(string userid, string content_id)
        {
            await ((ProgressViewModel)BindingContext).setAssessmentProgresses(userid, content_id);
            progress = ((ProgressViewModel)BindingContext).getProgress();
        }
    }
}