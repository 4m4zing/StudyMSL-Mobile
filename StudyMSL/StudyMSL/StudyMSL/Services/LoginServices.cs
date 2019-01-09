using StudyMSL.Models;
using StudyMSL.Plugins.RestClient;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace StudyMSL.Services
{
    public class LoginServices
    {
        //get an existence response of a login object
        public async Task<bool> CheckLogin(string u, string p)
        {
            RestClient<Login> restClient = new RestClient<Login>();
            var response = await restClient.getAsyncLoginBool(u, p);

            return response;
        }

        //get a login object
        public async Task<Login> GetLogin(string u)
        {
            RestClient<Login> restClient = new RestClient<Login>();
            var login = await restClient.GetAsyncLogin(u);

            return login;
        }

        //post a login object
        public async Task<bool> PostLogin(Login login)
        {
            RestClient<Login> restClient = new RestClient<Login>();
            var response = await restClient.PostAsyncLogin(login);
            return response;
        }

        //put a login object
        public async Task<bool> PutLogin(int id, Login login)
        {
            RestClient<Login> restClient = new RestClient<Login>();
            var response = await restClient.PutAsyncLogin(id, login);
            return response;
        }
    }
}

