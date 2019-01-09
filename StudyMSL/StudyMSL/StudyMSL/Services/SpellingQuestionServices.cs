using StudyMSL.Models;
using StudyMSL.Plugins.RestClient;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace StudyMSL.Services
{
    public class SpellingQuestionServices
    {
        //get a list of QAlphabetSpelling Objects
        public async Task<List<SpellingQuestion>> GetSpellingQuestions(string type)
        {
            RestClient<SpellingQuestion> restClient = new RestClient<SpellingQuestion>();
            var list = await restClient.GetAsyncSpellingQuestions(type);

            return list;
        }
    }
}
