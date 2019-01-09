
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
    public partial class LearningProgressPage : ContentPage
    {
        //Variable Assignments
        public List<Progress> PLItems;
        public List<Progress> PGQItems;
        Progress progress = new Progress();

        //Default Ctor
        public LearningProgressPage()
        {
            InitializeComponent();

            var username = App.Current.Properties["Username"] as string;
            setLearnItem();
        }

        //Set Listview Learning Items
        private async void setLearnItem()
        {
            var userid = App.Current.Properties["Userid"] as string;

            PLItems = new List<Progress>();
            await setLearnProgress(userid, "F01");
            PLItems.Add(new Progress(userid, "F01", "Fingerspelling - Alphabets", progress.content_desc, progress.date_completed));
            await setLearnProgress(userid, "F02");
            PLItems.Add(new Progress(userid, "F02", "Fingerspelling - Numbers", progress.content_desc, progress.date_completed));
            await setLearnProgress(userid, "W01");
            PLItems.Add(new Progress(userid, "W01", "Words - Greetings", progress.content_desc, progress.date_completed));
            await setLearnProgress(userid, "W02");
            PLItems.Add(new Progress(userid, "W02", "Words - Pronouns", progress.content_desc, progress.date_completed));
            await setLearnProgress(userid, "W03");
            PLItems.Add(new Progress(userid, "W03", "Words - Family", progress.content_desc, progress.date_completed));
            await setLearnProgress(userid, "W04");
            PLItems.Add(new Progress(userid, "W04", "Words - Questions", progress.content_desc, progress.date_completed));
            await setLearnProgress(userid, "W05");
            PLItems.Add(new Progress(userid, "W05", "Words - Conjunctions", progress.content_desc, progress.date_completed));
            await setLearnProgress(userid, "W06");
            PLItems.Add(new Progress(userid, "W06", "Words - Auxiliary Verbs", progress.content_desc, progress.date_completed));
            await setLearnProgress(userid, "W07");
            PLItems.Add(new Progress(userid, "W07", "Words - Feelings", progress.content_desc, progress.date_completed));
            await setLearnProgress(userid, "W08");
            PLItems.Add(new Progress(userid, "W08", "Words - Verb", progress.content_desc, progress.date_completed));
            await setLearnProgress(userid, "W14");
            PLItems.Add(new Progress(userid, "W14", "Words - Transports", progress.content_desc, progress.date_completed));
            lvProgressLearn.ItemsSource = PLItems;
        }

        //Get Listview Learning Item
        private async Task setLearnProgress(string userid, string content_id)
        {
            await ((ProgressViewModel)BindingContext).setLearnProgresses(userid, content_id);
            progress = ((ProgressViewModel)BindingContext).getProgress();
        }
    }
}