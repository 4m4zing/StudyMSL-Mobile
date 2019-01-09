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
    public class ContributeViewModel : INotifyPropertyChanged
    {
        /*..........Attribute Assignments..........*/
        private UserUpload _imagedetails = new UserUpload();
        public UserUpload imagedetails
        {
            get { return _imagedetails; }
            set
            {
                _imagedetails = value;
                OnPropertyChanged();
            }
        }
        /*.........................................*/


        /*..........Default Constructor..........*/
        public ContributeViewModel()
        {
        }
        /*.......................................*/


        /*..........Contribute Methods..........*/
        public void Init(string type, string name, string name_malay, string dir, string desc, string desc_malay, string uploader)
        {
            imagedetails.image_type = type;
            imagedetails.image_name = name;
            imagedetails.image_name_malay = name_malay;
            imagedetails.image_dir = dir;
            imagedetails.image_desc = desc;
            imagedetails.image_desc_malay = desc_malay;
            imagedetails.uploader = uploader;
            imagedetails.upload_time = DateTime.Now;

            PostUserUploadAsync();
        }

        //post a userupload object
        private async Task<bool> PostUserUploadAsync()
        {
            var useruploadServices = new UserUploadServices();
            var response = await useruploadServices.PostUserUpload(imagedetails);
            return response;
        }
        /*......................................*/


        /*..........Property Changed Event Handler..........*/
        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged([CallerMemberName] string propertyname = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyname));
        }
        /*..................................................*/
    }
}
