using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using Newtonsoft.Json;
using StudyMSL.Models;
using System.Collections.ObjectModel;

namespace StudyMSL.Plugins.RestClient
{
    /// <summary>
    /// RestClient implements methods for calling CRUD operations
    /// using HTTP.
    /// </summary>
    public class RestClient<T>
    {
        private const string WebServiceUrl = "https://studymsl.azurewebsites.net/api/";

        //..........start GET..........
        //-->start Learn..........
        public async Task<List<T>> GetAsyncLearn(string id)
        {
            string ext = "learns/" + id;
            var httpClient = new HttpClient();
            var json = await httpClient.GetStringAsync(WebServiceUrl + ext);
            var taskModels = JsonConvert.DeserializeObject<List<T>>(json);

            return taskModels;
        }

        public async Task<List<T>> GetAsyncLearnByName(string keyword, string type)
        {
            string ext = "learns/searchbyname/" + keyword + ";" + type;
            var httpClient = new HttpClient();
            var json = await httpClient.GetStringAsync(WebServiceUrl + ext);
            var taskModels = JsonConvert.DeserializeObject<List<T>>(json);

            return taskModels;
        }

        public async Task<List<T>> GetAsyncLearnByNameMalay(string keyword, string type)
        {
            string ext = "learns/searchbyname/malay/" + keyword + ";" + type;
            var httpClient = new HttpClient();
            var json = await httpClient.GetStringAsync(WebServiceUrl + ext);
            var taskModels = JsonConvert.DeserializeObject<List<T>>(json);

            return taskModels;
        }

        public async Task<List<T>> GetAsyncLearnByNameAll(string keyword, string type)
        {
            string ext = "learns/searchbyname/all/" + keyword + ";" + type;
            var httpClient = new HttpClient();
            var json = await httpClient.GetStringAsync(WebServiceUrl + ext);
            var taskModels = JsonConvert.DeserializeObject<List<T>>(json);

            return taskModels;
        }

        public async Task<T> GetAsyncLearnByNameExact(string keyword, string type)
        {
            string ext = "learns/searchbynameexact/" + keyword + ";" + type;
            var httpClient = new HttpClient();
            var json = await httpClient.GetStringAsync(WebServiceUrl + ext);
            var taskModels = JsonConvert.DeserializeObject<T>(json);

            return taskModels;
        }

        public async Task<bool> GetAsyncLearnByNameExactBool(string keyword, string type)
        {
            string ext = "learns/searchbynameexact/" + keyword + ";" + type;
            var httpClient = new HttpClient();
            var response = await httpClient.GetAsync(WebServiceUrl + ext);

            return response.IsSuccessStatusCode;
        }

        public async Task<T> GetAsyncLearnByNameExactMalay(string keyword, string type)
        {
            string ext = "learns/searchbynameexact/malay/" + keyword + ";" + type;
            var httpClient = new HttpClient();
            var json = await httpClient.GetStringAsync(WebServiceUrl + ext);
            var taskModels = JsonConvert.DeserializeObject<T>(json);

            return taskModels;
        }

        public async Task<bool> GetAsyncLearnByNameExactBoolMalay(string keyword, string type)
        {
            string ext = "learns/searchbynameexact/malay/" + keyword + ";" + type;
            var httpClient = new HttpClient();
            var response = await httpClient.GetAsync(WebServiceUrl + ext);

            return response.IsSuccessStatusCode;
        }
        //end Learn..........


        //-->start Question..........
        public async Task<List<T>> GetAsyncQuestions(string type)
        {
            string ext = "questions/" + type;
            var httpClient = new HttpClient();
            var json = await httpClient.GetStringAsync(WebServiceUrl + ext);
            var taskModels = JsonConvert.DeserializeObject<List<T>>(json);

            return taskModels;
        }
        //end Question..........


        //-->start SpellingQuestion..........
        public async Task<List<T>> GetAsyncSpellingQuestions(string type)
        {
            string ext = "spellingquestions/" + type;
            var httpClient = new HttpClient();
            var json = await httpClient.GetStringAsync(WebServiceUrl + ext);
            var taskModels = JsonConvert.DeserializeObject<List<T>>(json);

            return taskModels;
        }
        //end SpellingQuestion..........


        //-->start Progresses..........
        public async Task<List<T>> GetAsyncProgresses(string id)
        {
            string ext = "progresses/" + id;
            var httpClient = new HttpClient();
            var json = await httpClient.GetStringAsync(WebServiceUrl + ext);
            var taskModels = JsonConvert.DeserializeObject<List<T>>(json);

            return taskModels;
        }

        public async Task<T> GetAsyncProgress(string id, string content)
        {
            string ext = "progresses/" + id + ";" + content;
            var httpClient = new HttpClient();
            var json = await httpClient.GetStringAsync(WebServiceUrl + ext);
            var taskModels = JsonConvert.DeserializeObject<T>(json);

            return taskModels;
        }

        public async Task<bool> GetAsyncProgressBool(string id, string content)
        {
            string ext = "progresses/" + id + ";" + content;
            var httpClient = new HttpClient();
            var response = await httpClient.GetAsync(WebServiceUrl + ext);

            return response.IsSuccessStatusCode;
        }
        //end Progresses..........


        //-->start Login..........
        public async Task<T> GetAsyncLogin(string u)
        {
            string ext = "logins/" + u;
            var httpClient = new HttpClient();
            var json = await httpClient.GetStringAsync(WebServiceUrl + ext);
            var taskModels = JsonConvert.DeserializeObject<T>(json);

            return taskModels;
        }

        public async Task<bool> getAsyncLoginBool(string u, string p)
        {
            string ext = "logins/" + u + ";" + p;
            var httpClient = new HttpClient();
            var response = await httpClient.GetAsync(WebServiceUrl + ext);

            return response.IsSuccessStatusCode;
        }
        //end Login..........
        //..........end GET..........



        //..........start POST..........
        public async Task<bool> PostAsyncUserUpload(T t)
        {
            string ext = "useruploads/";
            var httpClient = new HttpClient();
            var json = JsonConvert.SerializeObject(t);
            HttpContent httpContent = new StringContent(json);
            httpContent.Headers.ContentType = new MediaTypeHeaderValue("application/json");
            var result = await httpClient.PostAsync(WebServiceUrl + ext, httpContent);

            return result.IsSuccessStatusCode;
        }


        public async Task<bool> PostAsyncLogin(T t)
        {
            string ext = "logins/";
            var httpClient = new HttpClient();
            var json = JsonConvert.SerializeObject(t);
            HttpContent httpContent = new StringContent(json);
            httpContent.Headers.ContentType = new MediaTypeHeaderValue("application/json");
            var result = await httpClient.PostAsync(WebServiceUrl + ext, httpContent);

            return result.IsSuccessStatusCode;
        }


        public async Task<bool> PostAsyncProgress(T t)
        {
            string ext = "progresses/";
            var httpClient = new HttpClient();
            var json = JsonConvert.SerializeObject(t);
            HttpContent httpContent = new StringContent(json);
            httpContent.Headers.ContentType = new MediaTypeHeaderValue("application/json");
            var result = await httpClient.PostAsync(WebServiceUrl + ext, httpContent);

            return result.IsSuccessStatusCode;
        }
        //..........end POST..........



        //..........start PUT..........
        public async Task<bool> PutAsyncLogin(int id, T t)
        {
            string ext = "logins/";
            var httpClient = new HttpClient();
            var json = JsonConvert.SerializeObject(t);
            HttpContent httpContent = new StringContent(json);
            httpContent.Headers.ContentType = new MediaTypeHeaderValue("application/json");
            var result = await httpClient.PutAsync(WebServiceUrl + ext + id, httpContent);

            return result.IsSuccessStatusCode;
        }
        //..........end PUT..........



        //..........start DELETE..........
        public async Task<bool> DeleteAsync(int id, T t)
        {
            var httpClient = new HttpClient();

            var response = await httpClient.DeleteAsync(WebServiceUrl + id);

            return response.IsSuccessStatusCode;
        }

        public async Task<bool> DeleteAsyncProgress(int id)
        {
            string ext = "progresses/";
            var httpClient = new HttpClient();

            var response = await httpClient.DeleteAsync(WebServiceUrl + ext + id);

            return response.IsSuccessStatusCode;
        }
        //..........end DELETE..........
    }
}
