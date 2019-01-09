using StudyMSL.Models;
using StudyMSL.Services;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace StudyMSL.ViewModels
{
    public class LearnViewModel : INotifyPropertyChanged
    {
        /*..........Attribute Assignments..........*/
        private ObservableCollection<Learn> _LearnOC = new ObservableCollection<Learn>();
        public ObservableCollection<Learn> LearnOC
        {
            get { return _LearnOC; }
            set
            {
                _LearnOC = value;
                OnPropertyChanged();
            }
        }

        private List<Learn> _LearnList = new List<Learn>();
        public List<Learn> LearnList
        {
            get { return _LearnList; }
            set
            {
                _LearnList = value;
                //OnPropertyChanged();
            }
        }

        private Progress _progressdetails = new Progress();
        public Progress progressdetails
        {
            get { return _progressdetails; }
            set
            {
                _progressdetails = value;
                OnPropertyChanged();
            }
        }
        /*.........................................*/


        /*..........Default Constructor..........*/
        public LearnViewModel()
        {
        }
        /*.......................................*/


        /*..........Learn Methods..........*/
        public void Init(string id)
        {
            GetDataAsync(id);

            //if (Settings.LanguageSetting == "English")
            //{
            //    _isVisibleEnglish = true;
            //    _isVisibleMalay = false;
            //}
            //else if (Settings.LanguageSetting == "Malay")
            //{
            //    _isVisibleEnglish = false;
            //    _isVisibleMalay = true;
            //}
        }

        //get an observablecollection list of learn objects
        private async Task GetDataAsync(string id)
        {
            var learnServices = new LearnServices();
            var list = await learnServices.GetLearn(id);
            LearnOC = new ObservableCollection<Learn>(list);
        }
        /*................................*/


        /*..........Sentence Methods..........*/
        public async Task WordsByWords(string keyword, string type)
        {
            await GetDataAsyncByWord(keyword, type);
        }

        public async Task WordsByWordsMalay(string keyword, string type)
        {
            await GetDataAsyncByWordMalay(keyword, type);
        }

        //get a list of learn objects
        private async Task GetDataAsyncByWord(string keyword, string type)
        {
            var learnServices = new LearnServices();
            var message = await learnServices.GetLearnByNameExactBool(keyword, type);

            if (message)
            {
                //-->if learn existed
                var learn = await learnServices.GetLearnByNameExact(keyword, type);
                LearnList.Add(learn);
            }
        }

        //get a list of learn objects
        private async Task GetDataAsyncByWordMalay(string keyword, string type)
        {
            var learnServices = new LearnServices();
            var message = await learnServices.GetLearnByNameExactBoolMalay(keyword, type);

            if (message)
            {
                //-->if learn existed
                var learn = await learnServices.GetLearnByNameExactMalay(keyword, type);
                LearnList.Add(learn);
            }
        }

        //set an observablecollection list of learn objects
        public void setLearnOC()
        {
            LearnOC = new ObservableCollection<Learn>(LearnList);
        }

        //empty an observablecollection list of learn objects
        public void emptyLearnOC()
        {
            LearnOC.Clear();
        }

        //empty a list of learn objects
        public void emptyLearnList()
        {
            LearnList.Clear();
        }
        /*....................................*/


        /*..........Progress Methods..........*/
        //manage the progress
        public async void DoProgress(string learnid, string learntitle, string learntype, string learncontent)
        {
            var userid = App.Current.Properties["Userid"] as string;
            var message = await CheckProgressAsync(userid, learnid);

            if (!message)
            {
                //-->if record not exist
                progressdetails.content_id = learnid;
                progressdetails.content_name = learntitle + " - " + learncontent;
                progressdetails.user_id = userid;
                progressdetails.content_desc = "Done";
                progressdetails.date_completed = DateTime.Now;

                PostProgressAsync();
            }
        }

        //check for a progress existence
        private async Task<bool> CheckProgressAsync(string userid, string contentid)
        {
            var progressServices = new ProgressServices();
            var response = await progressServices.GetProgressBool(userid, contentid);
            return response;
        }

        //post a progress object
        private async Task PostProgressAsync()
        {
            var progressServices = new ProgressServices();
            await progressServices.PostProgress(progressdetails);
        }

        //destroy progress objects
        public void destroyProgress()
        {
            _progressdetails = new Progress();
        }
        /*....................................*/


        /*..........Property Changed Event Handler..........*/
        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged([CallerMemberName] string propertyname = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyname));
        }
        /*..................................................*/
    }
}
