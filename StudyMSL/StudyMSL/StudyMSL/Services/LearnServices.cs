using StudyMSL.Models;
using StudyMSL.Plugins.RestClient;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace StudyMSL.Services
{
    public class LearnServices
    {
        //get a list of learn objects which contain the specified id
        public async Task<List<Learn>> GetLearn(string id)
        {
            RestClient<Learn> restClient = new RestClient<Learn>();
            var list = await restClient.GetAsyncLearn(id);

            return list;
        }

        //get a list of learn objects which contain the specified keyword
        public async Task<List<Learn>> GetLearnByName(string keyword, string type)
        {
            RestClient<Learn> restClient = new RestClient<Learn>();
            var list = await restClient.GetAsyncLearnByName(keyword, type);

            return list;
        }

        //get a list of learn objects which contain the specified keyword
        public async Task<List<Learn>> GetLearnByNameAll(string keyword, string type)
        {
            RestClient<Learn> restClient = new RestClient<Learn>();
            var list = await restClient.GetAsyncLearnByNameAll(keyword, type);

            return list;
        }

        //get a learn object which matches the specified keyword
        public async Task<Learn> GetLearnByNameExact(string keyword, string type)
        {
            RestClient<Learn> restClient = new RestClient<Learn>();
            var obj = await restClient.GetAsyncLearnByNameExact(keyword, type);

            return obj;
        }

        //get a existence response of learn objects which matches the specified keyword
        public async Task<bool> GetLearnByNameExactBool(string keyword, string type)
        {
            RestClient<Learn> restClient = new RestClient<Learn>();
            var response = await restClient.GetAsyncLearnByNameExactBool(keyword, type);

            return response;
        }

        //get a learn object which matches the specified keyword
        public async Task<Learn> GetLearnByNameExactMalay(string keyword, string type)
        {
            RestClient<Learn> restClient = new RestClient<Learn>();
            var obj = await restClient.GetAsyncLearnByNameExactMalay(keyword, type);

            return obj;
        }

        //get a existence response of learn objects which matches the specified keyword
        public async Task<bool> GetLearnByNameExactBoolMalay(string keyword, string type)
        {
            RestClient<Learn> restClient = new RestClient<Learn>();
            var response = await restClient.GetAsyncLearnByNameExactBoolMalay(keyword, type);

            return response;
        }
    }
}

