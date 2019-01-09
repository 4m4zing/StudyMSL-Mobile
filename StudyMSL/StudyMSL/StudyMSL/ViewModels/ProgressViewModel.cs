using StudyMSL.Models;
using StudyMSL.Services;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace StudyMSL.ViewModels
{
    public class ProgressViewModel : INotifyPropertyChanged
    {
        /*..........Attribute Assignments..........*/
        private List<Progress> _progressList = new List<Progress>();
        public List<Progress> progressList
        {
            get { return _progressList; }
            set
            {
                _progressList = value;
                OnPropertyChanged();
            }
        }

        private Progress _progress;
        public Progress progress
        {
            get { return _progress; }
            set
            {
                _progress = value;
                OnPropertyChanged();
            }
        }
        /*.........................................*/


        /*..........Default Constructor..........*/
        public ProgressViewModel()
        {
        }
        /*.......................................*/


        /*..........Progress Methods..........*/
        public async Task setLearnProgresses(string userid, string contentid)
        {
            await GetLearnProgressAsync(userid, contentid);
        }

        public async Task setAssessmentProgresses(string userid, string contentid)
        {
            await GetAssessmentProgressAsync(userid, contentid);
        }

        //get or set a progress object for learn
        private async Task GetLearnProgressAsync(string userid, string contentid)
        {
            var progressServices = new ProgressServices();
            var message = await progressServices.GetProgressBool(userid, contentid);

            if (message)
            {
                //-->if record existed
                progress = await progressServices.GetProgress(userid, contentid);
            }
            else
            {
                //-->if record not exist
                progress = new Progress(userid, contentid, "NA", "NA", DateTime.Now);
            }
        }

        //get or set a progress object for assessment
        private async Task GetAssessmentProgressAsync(string userid, string contentid)
        {
            var progressServices = new ProgressServices();
            var message = await progressServices.GetProgressBool(userid, contentid);

            if (message)
            {
                //-->if record existed
                progress = await progressServices.GetProgress(userid, contentid);
            }
            else
            {
                //-->if record not exist
                progress = new Progress(userid, contentid, "NA", "0", DateTime.Now);
            }
        }

        //return progress object
        public Progress getProgress()
        {
            return progress;
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
