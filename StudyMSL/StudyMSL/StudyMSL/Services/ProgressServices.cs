using StudyMSL.Models;
using StudyMSL.Plugins.RestClient;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace StudyMSL.Services
{
    public class ProgressServices
    {
        //get a progress object
        public async Task<Progress> GetProgress(string userid, string contentid)
        {
            RestClient<Progress> restClient = new RestClient<Progress>();
            var progress = await restClient.GetAsyncProgress(userid, contentid);

            return progress;
        }

        //get an existence response of a progress object
        public async Task<bool> GetProgressBool(string userid, string contentid)
        {
            RestClient<Progress> restClient = new RestClient<Progress>();
            var response = await restClient.GetAsyncProgressBool(userid, contentid);

            return response;
        }

        //post a progress object
        public async Task PostProgress(Progress progress)
        {
            RestClient<Progress> restClient = new RestClient<Progress>();
            var list = await restClient.PostAsyncProgress(progress);
        }

        //delete a progress object
        public async Task<bool> DeleteProgressBool(int progressid)
        {
            RestClient<Progress> restClient = new RestClient<Progress>();
            var response = await restClient.DeleteAsyncProgress(progressid);

            return response;
        }
    }
}

