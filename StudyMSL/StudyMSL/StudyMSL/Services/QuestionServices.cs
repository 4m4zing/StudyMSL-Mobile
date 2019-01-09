using StudyMSL.Models;
using StudyMSL.Plugins.RestClient;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace StudyMSL.Services
{
    public class QuestionServices
    {
        //get a list of Question objects
        public async Task<List<Question>> GetQuestions(string type)
        {
            RestClient<Question> restClient = new RestClient<Question>();
            var list = await restClient.GetAsyncQuestions(type);

            return list;
        }
    }
}
