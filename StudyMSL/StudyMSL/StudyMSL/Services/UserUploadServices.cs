using StudyMSL.Models;
using StudyMSL.Plugins.RestClient;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace StudyMSL.Services
{
    public class UserUploadServices
    {
        //post a userupload object
        public async Task<bool> PostUserUpload(UserUpload userupload)
        {
            RestClient<UserUpload> restClient = new RestClient<UserUpload>();
            var response = await restClient.PostAsyncUserUpload(userupload);
            return response;
        }
    }
}
