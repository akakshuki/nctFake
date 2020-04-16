using ModelViews.DTOs;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;


namespace AppAdmin.Areas.Client.Models.ServiceClient
{
    public class ApiService
    {
        private HttpClient _client = null;

        public ApiService()
        {
            _client = new HttpClient {BaseAddress = new Uri("https://localhost:44384/api/") };
        }

        public HttpClient ApiClient()
        {
            return _client;
        }

        public async Task<HttpResponseMessage> GetData(string url)
        {
            var res = await _client.GetAsync(url);
            return res;
        }

        public async Task<HttpResponseMessage> PostData<T>(string url, T data)
        {
            var res = await _client.PostAsJsonAsync(url, data);
            return res;
        }
        public async Task<HttpResponseMessage> PostDataItem(string url, object data)
        {
            var res = await _client.PostAsJsonAsync(url, data);
            return res;
        }

        public async Task<HttpResponseMessage> GetDataById(string url, object id)
        {
            var res = await _client.GetAsync(url + "/" + id.ToString());
            return res;
        }

        public async Task<HttpResponseMessage> DeleteDataById(string url, object id)
        {
            var res = await _client.DeleteAsync(url + "/" + id.ToString());
            return res;
        }

        public async Task<HttpResponseMessage> Update<T>(string url, object id, T data)
        {
            var res = await _client.PutAsJsonAsync(url + "/" + id, data);
            return res;
        }
    }


    public static class ApiServiceClient
    {
        private static ApiService _api = null;

        static ApiServiceClient() => _api = new ApiService();



        public static async Task<bool> UserResetPassword(string email)
        {
            try
            {
                var postTask = await _api.PostData<string>("UserClient", email);
                if (postTask.IsSuccessStatusCode) return true;
                return false;

            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                return false;
            }
        }

        public static async Task<bool> UserChangePassword(UserDTO userDto)
        {
            try
            {
                var postTask = await _api.PostData<UserDTO>("UserClient/UserResetPassword", userDto);
                if (postTask.IsSuccessStatusCode) return true;
                return false;
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                return false;
            }
        }
       
    }
   
}