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
    public class LoginViewModel : INotifyPropertyChanged
    {
        /*..........Attribute Assignments..........*/
        private Login _logindetails = new Login();
        public Login logindetails
        {
            get { return _logindetails; }
            set
            {
                _logindetails = value;
                OnPropertyChanged();
            }
        }

        private Login _recordedlogin = new Login();
        public Login recordedlogin
        {
            get { return _recordedlogin; }
            set
            {
                _recordedlogin = value;
                OnPropertyChanged();
            }
        }
        /*.........................................*/


        /*..........Default Constructor..........*/
        public LoginViewModel()
        {
        }
        /*.......................................*/


        /*..........Login Methods..........*/
        public async Task<bool> RegisterLogin(string username, string password, string email)
        {
            logindetails.uname = username;
            logindetails.pword = password;
            logindetails.email = email;

            var message = await PostLoginAsync();
            return message;
        }

        public async Task<bool> ChangePassword(string username, string oldpassword, string newpassword)
        {
            recordedlogin = await getLogin(username);

            if (recordedlogin.pword.Equals(oldpassword))
            {
                logindetails.user_id = recordedlogin.user_id;
                logindetails.uname = recordedlogin.uname;
                logindetails.pword = newpassword;
                logindetails.email = recordedlogin.email;

                var message = await PutLoginAsync(username);
                return message;
            }
            else
            {
                return false;
            }
        }

        //check for a login existence
        public async Task<bool> VerifyLogin(string username, string password)
        {
            var loginServices = new LoginServices();
            bool result = await loginServices.CheckLogin(username, password);
            return result;
        }

        //get userid
        public async Task<string> getUserID(string username)
        {
            var userid = await getLogin(username);
            return userid.user_id.ToString();
        }

        //get userid
        public async Task<int> getIntUserID(string username)
        {
            var userid = await getLogin(username);
            return userid.user_id;
        }

        //get a login object
        public async Task<Login> getLogin(string username)
        {
            var loginServices = new LoginServices();
            var result = await loginServices.GetLogin(username);
            return result;
        }

        //post a login object
        private async Task<bool> PostLoginAsync()
        {
            var loginServices = new LoginServices();
            var response = await loginServices.PostLogin(logindetails);
            return response;
        }

        //put an existing login object
        private async Task<bool> PutLoginAsync(string username)
        {
            var loginServices = new LoginServices();
            var response = await loginServices.PutLogin(recordedlogin.user_id, logindetails);
            return response;
        }
        /*.................................*/


        /*..........Property Changed Event Handler..........*/
        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged([CallerMemberName] string propertyname = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyname));
        }
        /*..................................................*/
    }
}

