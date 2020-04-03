using ModelViews.DTOs;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Web;
using System.Web.Script.Serialization;

namespace AppAdmin.Models.Service
{
    public class ApiService
    {
        #region User
        public static List<UserDTO> GetAllUser()
        {
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("https://localhost:44386/api/User/GetAllUser/");
                var responseTask = client.GetAsync(client.BaseAddress);
                responseTask.Wait();
                var result = responseTask.Result;
                if (result.IsSuccessStatusCode)
                {
                    var readTask = JsonConvert.DeserializeObject<List<UserDTO>>(result.Content.ReadAsStringAsync().Result);
                    return readTask;
                }
            }
            return null;
        }
        public static UserDTO GetUserById(int id)
        {
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("https://localhost:44386/api/User/GetUserById/" + id.ToString());
                var responseTask = client.GetAsync(client.BaseAddress);
                responseTask.Wait();
                var result = responseTask.Result;
                if (result.IsSuccessStatusCode)
                {
                    var readTask = JsonConvert.DeserializeObject<UserDTO>(result.Content.ReadAsStringAsync().Result);
                    return readTask;
                }
            }
            return null;
        }
        public static List<UserDTO> GetUserByIdRole(int id)
        {
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("https://localhost:44386/api/User/GetUserByIdRole/" + id.ToString());
                var responseTask = client.GetAsync(client.BaseAddress);
                responseTask.Wait();
                var result = responseTask.Result;
                if (result.IsSuccessStatusCode)
                {
                    var readTask = JsonConvert.DeserializeObject<List<UserDTO>>(result.Content.ReadAsStringAsync().Result);
                    return readTask;
                }
            }
            return null;
        }
        public static UserDTO CreateSinger(UserDTO userDTO)
        {
            using (HttpClient client = new HttpClient())
            {
                client.DefaultRequestHeaders.Accept.Clear();
                var response = client.PostAsync("https://localhost:44386/api/User/CreateSinger/", new StringContent(
                    new JavaScriptSerializer().Serialize(userDTO), Encoding.UTF8, "application/json")).Result;
                if (response.StatusCode == System.Net.HttpStatusCode.OK)
                {
                    return userDTO;
                }
            }
            return null;
        }
        public static UserDTO CreateUser(UserDTO userDTO)
        {
            using (HttpClient client = new HttpClient())
            {
                client.DefaultRequestHeaders.Accept.Clear();
                var response = client.PostAsync("https://localhost:44386/api/User/CreateUser/", new StringContent(
                    new JavaScriptSerializer().Serialize(userDTO), Encoding.UTF8, "application/json")).Result;
                if (response.StatusCode == System.Net.HttpStatusCode.OK)
                {
                    return userDTO;
                }
            }
            return null;
        }
        public static UserDTO UpdateCate(UserDTO userDTO)
        {
            using (HttpClient client = new HttpClient())
            {
                client.DefaultRequestHeaders.Accept.Clear();
                var response = client.PostAsync("https://localhost:44386/api/User/UpdateCate/", new StringContent(
                    new JavaScriptSerializer().Serialize(userDTO), Encoding.UTF8, "application/json")).Result;
                if (response.StatusCode == System.Net.HttpStatusCode.OK)
                {
                    return userDTO;
                }
            }
            return null;
        }
        public static bool DeleteCate(int id)
        {
            using (HttpClient client = new HttpClient())
            {
                client.DefaultRequestHeaders.Accept.Clear();
                var response = client.DeleteAsync("https://localhost:44386/api/User/DeleteCate/" + id.ToString()).Result;
                if (response.StatusCode == System.Net.HttpStatusCode.OK)
                {
                    return true;
                }
            }
            return false;
        }
        #endregion
    }
}