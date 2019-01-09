using StudyMSL.Models;
using StudyMSL.Plugins.Timer;
using StudyMSL.Services;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace StudyMSL.ViewModels
{
    public class PictureSpellingViewModel : INotifyPropertyChanged
    {
        /*..........Attribute Assignments..........*/
        string resourcesurl = "https://studymsl.azurewebsites.net/uploads/";
        bool taken1 = false, taken2 = false, taken3 = false, taken4 = false, taken5 = false, taken6 = false, taken7 = false, taken8 = false;

        private List<SpellingQuestion> _SpellingQuestionsList;
        public List<SpellingQuestion> SpellingQuestionsList
        {
            get { return _SpellingQuestionsList; }
            set
            {
                _SpellingQuestionsList = value;
                OnPropertyChanged();
            }
        }

        private Progress _recordedprogress = new Progress();
        public Progress recordedprogress
        {
            get { return _recordedprogress; }
            set
            {
                _recordedprogress = value;
                OnPropertyChanged();
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

        private string _image_dir;
        public string image_dir
        {
            get { return _image_dir; }
            set
            {
                _image_dir = value;
                OnPropertyChanged();
            }
        }

        private string _answer;
        public string answer
        {
            get { return _answer; }
            set
            {
                _answer = value;
                OnPropertyChanged();
            }
        }

        private string _a_image1;
        public string a_image1
        {
            get { return _a_image1; }
            set
            {
                _a_image1 = value;
                OnPropertyChanged();
            }
        }

        private string _a_image2;
        public string a_image2
        {
            get { return _a_image2; }
            set
            {
                _a_image2 = value;
                OnPropertyChanged();
            }
        }

        private string _a_image3;
        public string a_image3
        {
            get { return _a_image3; }
            set
            {
                _a_image3 = value;
                OnPropertyChanged();
            }
        }

        private string _a_image4;
        public string a_image4
        {
            get { return _a_image4; }
            set
            {
                _a_image4 = value;
                OnPropertyChanged();
            }
        }

        private string _a_image5;
        public string a_image5
        {
            get { return _a_image5; }
            set
            {
                _a_image5 = value;
                OnPropertyChanged();
            }
        }

        private string _a_image6;
        public string a_image6
        {
            get { return _a_image6; }
            set
            {
                _a_image6 = value;
                OnPropertyChanged();
            }
        }

        private string _a_image7;
        public string a_image7
        {
            get { return _a_image7; }
            set
            {
                _a_image7 = value;
                OnPropertyChanged();
            }
        }

        private string _a_image8;
        public string a_image8
        {
            get { return _a_image8; }
            set
            {
                _a_image8 = value;
                OnPropertyChanged();
            }
        }

        private string _q_image1;
        public string q_image1
        {
            get { return _q_image1; }
            set
            {
                _q_image1 = value;
                OnPropertyChanged();
            }
        }

        private string _q_image2;
        public string q_image2
        {
            get { return _q_image2; }
            set
            {
                _q_image2 = value;
                OnPropertyChanged();
            }
        }

        private string _q_image3;
        public string q_image3
        {
            get { return _q_image3; }
            set
            {
                _q_image3 = value;
                OnPropertyChanged();
            }
        }

        private string _q_image4;
        public string q_image4
        {
            get { return _q_image4; }
            set
            {
                _q_image4 = value;
                OnPropertyChanged();
            }
        }

        private string _q_image5;
        public string q_image5
        {
            get { return _q_image5; }
            set
            {
                _q_image5 = value;
                OnPropertyChanged();
            }
        }

        private string _q_image6;
        public string q_image6
        {
            get { return _q_image6; }
            set
            {
                _q_image6 = value;
                OnPropertyChanged();
            }
        }

        private string _q_image7;
        public string q_image7
        {
            get { return _q_image7; }
            set
            {
                _q_image7 = value;
                OnPropertyChanged();
            }
        }

        private string _q_image8;
        public string q_image8
        {
            get { return _q_image8; }
            set
            {
                _q_image8 = value;
                OnPropertyChanged();
            }
        }

        private string _q_image1_val;
        public string q_image1_val
        {
            get { return _q_image1_val; }
            set
            {
                _q_image1_val = value;
                OnPropertyChanged();
            }
        }

        private string _q_image2_val;
        public string q_image2_val
        {
            get { return _q_image2_val; }
            set
            {
                _q_image2_val = value;
                OnPropertyChanged();
            }
        }

        private string _q_image3_val;
        public string q_image3_val
        {
            get { return _q_image3_val; }
            set
            {
                _q_image3_val = value;
                OnPropertyChanged();
            }
        }

        private string _q_image4_val;
        public string q_image4_val
        {
            get { return _q_image4_val; }
            set
            {
                _q_image4_val = value;
                OnPropertyChanged();
            }
        }

        private string _q_image5_val;
        public string q_image5_val
        {
            get { return _q_image5_val; }
            set
            {
                _q_image5_val = value;
                OnPropertyChanged();
            }
        }

        private string _q_image6_val;
        public string q_image6_val
        {
            get { return _q_image6_val; }
            set
            {
                _q_image6_val = value;
                OnPropertyChanged();
            }
        }

        private string _q_image7_val;
        public string q_image7_val
        {
            get { return _q_image7_val; }
            set
            {
                _q_image7_val = value;
                OnPropertyChanged();
            }
        }

        private string _q_image8_val;
        public string q_image8_val
        {
            get { return _q_image8_val; }
            set
            {
                _q_image8_val = value;
                OnPropertyChanged();
            }
        }

        private int _score = 0;
        public int score
        {
            get { return _score; }
            set
            {
                _score = value;
                OnPropertyChanged();
            }
        }

        private int _number;
        public int number
        {
            get { return _number; }
            set
            {
                _number = value;
                OnPropertyChanged();
            }
        }

        private Timer _timer;
        public Timer timer
        {
            get { return _timer; }
            set
            {
                _timer = value;
                OnPropertyChanged();
            }
        }

        private TimeSpan _duration = new TimeSpan(0, 0, 0, 60);
        public TimeSpan duration
        {
            get { return _duration; }
            set
            {
                _duration = value;
                OnPropertyChanged();
            }
        }

        private double _time = 60;
        public double time
        {
            get { return _time; }
            set
            {
                _time = value;
                OnPropertyChanged();
            }
        }

        Random rdm = new Random();
        /*.........................................*/


        /*..........Default Constructor..........*/
        public PictureSpellingViewModel()
        {
        }
        /*.......................................*/


        /*..........QAlphabetSpelling Methods..........*/
        public void Init(string type)
        {
            InitDataAsync(type);

            _timer = new Timer(TimeSpan.FromSeconds(1), CountDown);
            duration = _duration;
            score = 0;
        }

        private async Task InitDataAsync(string type)
        {
            var spellingquestionServices = new SpellingQuestionServices();

            try
            {
                SpellingQuestionsList = await spellingquestionServices.GetSpellingQuestions(type);
            }
            catch (Exception exc)
            {
            }
            NextQuestion(type);
        }

        //set current question and answer
        public void NextQuestion(string type)
        {
            taken1 = false;
            taken2 = false;
            taken3 = false;
            taken4 = false;
            taken5 = false;
            taken6 = false;
            taken7 = false;
            taken8 = false;

            int qindex = rdm.Next(0, SpellingQuestionsList.Count);
            SpellingQuestion selectedItem = SpellingQuestionsList[qindex];

            image_dir = selectedItem.image_dir;
            answer = selectedItem.answer;

            int rdm1 = rdm.Next(1, 9);
            int rdm2 = rdm.Next(1, 9);
            int rdm3 = rdm.Next(1, 9);
            int rdm4 = rdm.Next(1, 9);
            int rdm5 = rdm.Next(1, 9);
            int rdm6 = rdm.Next(1, 9);
            int rdm7 = rdm.Next(1, 9);
            int rdm8 = rdm.Next(1, 9);

            randomizeImage(rdm1, selectedItem.image1_dir, type);
            randomizeImage(rdm2, selectedItem.image2_dir, type);
            randomizeImage(rdm3, selectedItem.image3_dir, type);
            randomizeImage(rdm4, selectedItem.image4_dir, type);
            randomizeImage(rdm5, selectedItem.image5_dir, type);
            randomizeImage(rdm6, selectedItem.image6_dir, type);
            randomizeImage(rdm7, selectedItem.image7_dir, type);
            randomizeImage(rdm8, selectedItem.image8_dir, type);

            SpellingQuestionsList.RemoveAt(qindex);
        }

        //set image to display on which image viewer
        public void randomizeImage(int img_viewer, string image, string type)
        {
            string full;
            bool done = false;

            if (type == "alphabet")
            {
                var ext = "alphabets/Alphabet_" + image + ".jpg";
                full = resourcesurl + ext;
            }
            else
            {
                var ext = "numbers/Number_" + image + ".jpg";
                full = resourcesurl + ext;
            }
            
            while (done != true)
            {
                if (img_viewer == 1)
                {
                    if (taken1 != true)
                    {
                        q_image1 = full;
                        q_image1_val = image;
                        taken1 = true;
                        done = true;
                    }
                }
                else if (img_viewer == 2)
                {
                    if (taken2 != true)
                    {
                        q_image2 = full;
                        q_image2_val = image;
                        taken2 = true;
                        done = true;
                    }
                }
                else if (img_viewer == 3)
                {
                    if (taken3 != true)
                    {
                        q_image3 = full;
                        q_image3_val = image;
                        taken3 = true;
                        done = true;
                    }
                }
                else if (img_viewer == 4)
                {
                    if (taken4 != true)
                    {
                        q_image4 = full;
                        q_image4_val = image;
                        taken4 = true;
                        done = true;
                    }
                }
                else if (img_viewer == 5)
                {
                    if (taken5 != true)
                    {
                        q_image5 = full;
                        q_image5_val = image;
                        taken5 = true;
                        done = true;
                    }
                }
                else if (img_viewer == 6)
                {
                    if (taken6 != true)
                    {
                        q_image6 = full;
                        q_image6_val = image;
                        taken6 = true;
                        done = true;
                    }
                }
                else if (img_viewer == 7)
                {
                    if (taken7 != true)
                    {
                        q_image7 = full;
                        q_image7_val = image;
                        taken7 = true;
                        done = true;
                    }
                }
                else
                {
                    if (taken8 != true)
                    {
                        q_image8 = full;
                        q_image8_val = image;
                        taken8 = true;
                        done = true;
                    }
                }

                if (done == true)
                {
                    break;
                }
                else
                {
                    img_viewer = rdm.Next(1, 9);
                }
            }
        }

        //set answer image to display on which answer image viewer
        public void setImage(int position, string value, string type)
        {
            string ext;

            if (type == "alphabet")
            {
                ext = "alphabets/Alphabet_";
            }
            else
            {
                ext = "numbers/Number_";
            }

            if (position == 1)
            {
                a_image1 = resourcesurl + ext + value + ".jpg";
            }
            else if (position == 2)
            {
                a_image2 = resourcesurl + ext + value + ".jpg";
            }
            else if (position == 3)
            {
                a_image3 = resourcesurl + ext + value + ".jpg";
            }
            else if (position == 4)
            {
                a_image4 = resourcesurl + ext + value + ".jpg";
            }
            else if (position == 5)
            {
                a_image5 = resourcesurl + ext + value + ".jpg";
            }
            else if (position == 6)
            {
                a_image6 = resourcesurl + ext + value + ".jpg";
            }
            else if (position == 7)
            {
                a_image7 = resourcesurl + ext + value + ".jpg";
            }
            else
            {
                a_image8 = resourcesurl + ext + value + ".jpg";
            }
        }

        //set question number
        public void setQuestionNo(int qNumber)
        {
            number = qNumber;
        }

        //change score
        public void setScore(int changescore)
        {
            score += changescore;
        }

        //return score
        public int getScore()
        {
            return score;
        }

        //return time
        public double getTime()
        {
            return time;
        }

        //return image value
        public string getValue(int image_viewer)
        {
            if (image_viewer == 1)
            {
                return q_image1_val;
            }
            else if (image_viewer == 2)
            {
                return q_image2_val;
            }
            else if (image_viewer == 3)
            {
                return q_image3_val;
            }
            else if (image_viewer == 4)
            {
                return q_image4_val;
            }
            else if (image_viewer == 5)
            {
                return q_image5_val;
            }
            else if (image_viewer == 6)
            {
                return q_image6_val;
            }
            else if (image_viewer == 7)
            {
                return q_image7_val;
            }
            else
            {
                return q_image8_val;
            }
        }

        //empty answer images
        public void emptyImage()
        {
            a_image1 = null;
            a_image2 = null;
            a_image3 = null;
            a_image4 = null;
            a_image5 = null;
            a_image6 = null;
            a_image7 = null;
            a_image8 = null;
        }

        //check answer
        public bool isCorrect(string useranswer)
        {
            if (useranswer == answer)
            {
                //-->if answer is correct
                score += 1;
                return true;
            }
            return false;
        }
        /*.............................................*/


        /*..........Timer Methods..........*/
        //start the timer
        public void startTimer()
        {
            timer.Start();
        }

        //manage the timer countdown
        private void CountDown()
        {
            //set display countdown time
            time = duration.TotalSeconds;

            if (duration.TotalSeconds == 0)
            {
                //-->if countdown ends
                stopTimer();
                displayTimeOut();
            }
            else
            {
                //-->if countdown
                duration = _duration.Subtract(new TimeSpan(0, 0, 0, 1));
            }
        }

        //stop the timer
        public void stopTimer()
        {
            duration = new TimeSpan(0, 0, 0, 60);
            _timer.Stop();
        }

        //call the view alert
        private async void displayTimeOut()
        {
            MessagingCenter.Send(this, "TimeOut");
        }
        /*.................................*/


        /*..........Progress Methods..........*/
        //manage the progress
        public async void DoProgress(string questionid, string questiontitle, string questiontype, string questioncontent)
        {
            var userid = App.Current.Properties["Userid"] as string;
            var message = await CheckProgressAsync(userid, questionid);

            if (!message)
            {
                //-->if record not exist
                setPostProgressData(userid, questionid, questiontitle, questioncontent);
                PostProgressAsync();
            }
            else
            {
                //-->if record existed
                recordedprogress = await GetProgressAsync(userid, questionid);

                if (Convert.ToInt32(recordedprogress.content_desc) < score)
                {
                    //-->if current score is higher than record's score
                    var result = await DeleteProgressAsync();

                    if (result)
                    {
                        //-->if successfully deleted a record
                        setPostProgressData(userid, questionid, questiontitle, questioncontent);
                        PostProgressAsync();
                    }
                }
            }
        }

        //check for a progress existence
        private async Task<bool> CheckProgressAsync(string userid, string contentid)
        {
            var progressServices = new ProgressServices();
            var response = await progressServices.GetProgressBool(userid, contentid);
            return response;
        }

        //get a progress object
        private async Task<Progress> GetProgressAsync(string userid, string contentid)
        {
            var progressServices = new ProgressServices();
            var response = await progressServices.GetProgress(userid, contentid);
            return response;
        }

        //post a progress object
        private async Task PostProgressAsync()
        {
            var progressServices = new ProgressServices();
            await progressServices.PostProgress(progressdetails);
        }

        //delete a progress object
        private async Task<bool> DeleteProgressAsync()
        {
            var progressServices = new ProgressServices();
            var response = await progressServices.DeleteProgressBool(recordedprogress.p_id);
            return response;
        }

        //set a progress data to be posted
        private void setPostProgressData(string userid, string questionid, string questiontitle, string questioncontent)
        {
            progressdetails.user_id = userid;
            progressdetails.content_id = questionid;
            progressdetails.content_name = questiontitle + " - " + questioncontent;
            progressdetails.content_desc = score.ToString();
            progressdetails.date_completed = DateTime.Now;
        }

        //destroy progress objects
        public void destroyProgress()
        {
            _progressdetails = new Progress();
            _recordedprogress = new Progress();
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