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
        public static UserDTO UpdateUser(UserDTO userDTO)
        {
            using (HttpClient client = new HttpClient())
            {
                client.DefaultRequestHeaders.Accept.Clear();
                var response = client.PostAsync("https://localhost:44386/api/User/UpdateUser/", new StringContent(
                    new JavaScriptSerializer().Serialize(userDTO), Encoding.UTF8, "application/json")).Result;
                if (response.StatusCode == System.Net.HttpStatusCode.OK)
                {
                    return userDTO;
                }
            }
            return null;
        }
        public static bool DeleteUser(int id)
        {
            using (HttpClient client = new HttpClient())
            {
                client.DefaultRequestHeaders.Accept.Clear();
                var response = client.DeleteAsync("https://localhost:44386/api/User/DeleteUser/" + id.ToString()).Result;
                if (response.StatusCode == System.Net.HttpStatusCode.OK)
                {
                    return true;
                }
            }
            return false;
        }
        #endregion
        #region Category
        public static List<CategoryDTO> GetAllCate()
        {
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("https://localhost:44386/api/Category/GetAllCate/");
                var responseTask = client.GetAsync(client.BaseAddress);
                responseTask.Wait();
                var result = responseTask.Result;
                if (result.IsSuccessStatusCode)
                {
                    var readTask = JsonConvert.DeserializeObject<List<CategoryDTO>>(result.Content.ReadAsStringAsync().Result);
                    return readTask;
                }
            }
            return null;
        }
        public static CategoryDTO GetCateById(int id)
        {
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("https://localhost:44386/api/Category/GetCateById/" + id.ToString());
                var responseTask = client.GetAsync(client.BaseAddress);
                responseTask.Wait();
                var result = responseTask.Result;
                if (result.IsSuccessStatusCode)
                {
                    var readTask = JsonConvert.DeserializeObject<CategoryDTO>(result.Content.ReadAsStringAsync().Result);
                    return readTask;
                }
            }
            return null;
        }
        public static List<RoleDTO> GetRoleById(int id)
        {
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("https://localhost:44386/api/Category/GetRoleById/" + id.ToString());
                var responseTask = client.GetAsync(client.BaseAddress);
                responseTask.Wait();
                var result = responseTask.Result;
                if (result.IsSuccessStatusCode)
                {
                    var readTask = JsonConvert.DeserializeObject<List<RoleDTO>>(result.Content.ReadAsStringAsync().Result);
                    return readTask;
                }
            }
            return null;
        }
        public static CategoryDTO CreateCate(CategoryDTO categoryDTO)
        {
            using (HttpClient client = new HttpClient())
            {
                client.DefaultRequestHeaders.Accept.Clear();
                var response = client.PostAsync("https://localhost:44386/api/Category/CreateCate/", new StringContent(
                    new JavaScriptSerializer().Serialize(categoryDTO), Encoding.UTF8, "application/json")).Result;
                if (response.StatusCode == System.Net.HttpStatusCode.OK)
                {
                    return categoryDTO;
                }
            }
            return null;
        }
        public static CategoryDTO UpdateCate(CategoryDTO categoryDTO)
        {
            using (HttpClient client = new HttpClient())
            {
                client.DefaultRequestHeaders.Accept.Clear();
                var response = client.PostAsync("https://localhost:44386/api/Category/UpdateCate/", new StringContent(
                    new JavaScriptSerializer().Serialize(categoryDTO), Encoding.UTF8, "application/json")).Result;
                if (response.StatusCode == System.Net.HttpStatusCode.OK)
                {
                    return categoryDTO;
                }
            }
            return null;
        }
        public static bool DeleteCate(int id)
        {
            using (HttpClient client = new HttpClient())
            {
                client.DefaultRequestHeaders.Accept.Clear();
                var response = client.DeleteAsync("https://localhost:44386/api/Category/DeleteCate/" + id.ToString()).Result;
                if (response.StatusCode == System.Net.HttpStatusCode.OK)
                {
                    return true;
                }
            }
            return false;
        }
        #endregion
        #region Playlist
        public static List<PlaylistDTO> GetAllPlaylist()
        {
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("https://localhost:44386/api/Playlist/GetAllPlaylist/");
                var responseTask = client.GetAsync(client.BaseAddress);
                responseTask.Wait();
                var result = responseTask.Result;
                if (result.IsSuccessStatusCode)
                {
                    var readTask = JsonConvert.DeserializeObject<List<PlaylistDTO>>(result.Content.ReadAsStringAsync().Result);
                    return readTask;
                }
            }
            return null;
        }
        public static PlaylistDTO GetPlaylistById(int id)
        {
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("https://localhost:44386/api/Playlist/GetPlaylistById/" + id.ToString());
                var responseTask = client.GetAsync(client.BaseAddress);
                responseTask.Wait();
                var result = responseTask.Result;
                if (result.IsSuccessStatusCode)
                {
                    var readTask = JsonConvert.DeserializeObject<PlaylistDTO>(result.Content.ReadAsStringAsync().Result);
                    return readTask;
                }
            }
            return null;
        }
        public static List<PlaylistDTO> GetPlaylistByIdUser(int id)
        {
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("https://localhost:44386/api/Playlist/GetPlaylistByIdUser/" + id.ToString());
                var responseTask = client.GetAsync(client.BaseAddress);
                responseTask.Wait();
                var result = responseTask.Result;
                if (result.IsSuccessStatusCode)
                {
                    var readTask = JsonConvert.DeserializeObject<List<PlaylistDTO>>(result.Content.ReadAsStringAsync().Result);
                    return readTask;
                }
            }
            return null;
        }
        public static PlaylistDTO CreatePlaylist(PlaylistDTO playlistDTO)
        {
            using (HttpClient client = new HttpClient())
            {
                client.DefaultRequestHeaders.Accept.Clear();
                var response = client.PostAsync("https://localhost:44386/api/Playlist/CreatePlaylist/", new StringContent(
                    new JavaScriptSerializer().Serialize(playlistDTO), Encoding.UTF8, "application/json")).Result;
                if (response.StatusCode == System.Net.HttpStatusCode.OK)
                {
                    return playlistDTO;
                }
            }
            return null;
        }
        public static PlaylistDTO UpdatePlaylist(PlaylistDTO playlistDTO)
        {
            using (HttpClient client = new HttpClient())
            {
                client.DefaultRequestHeaders.Accept.Clear();
                var response = client.PostAsync("https://localhost:44386/api/Playlist/UpdatePlaylist/", new StringContent(
                    new JavaScriptSerializer().Serialize(playlistDTO), Encoding.UTF8, "application/json")).Result;
                if (response.StatusCode == System.Net.HttpStatusCode.OK)
                {
                    return playlistDTO;
                }
            }
            return null;
        }
        public static bool DeletePlaylist(int id)
        {
            using (HttpClient client = new HttpClient())
            {
                client.DefaultRequestHeaders.Accept.Clear();
                var response = client.DeleteAsync("https://localhost:44386/api/Playlist/DeletePlaylist/" + id.ToString()).Result;
                if (response.StatusCode == System.Net.HttpStatusCode.OK)
                {
                    return true;
                }
            }
            return false;
        }
        #endregion
        #region Partner
        public static List<PartnerDTO> GetAllPartner()
        {
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("https://localhost:44386/api/Playlist/GetAllPlaylist/");
                var responseTask = client.GetAsync(client.BaseAddress);
                responseTask.Wait();
                var result = responseTask.Result;
                if (result.IsSuccessStatusCode)
                {
                    var readTask = JsonConvert.DeserializeObject<List<PartnerDTO>>(result.Content.ReadAsStringAsync().Result);
                    return readTask;
                }
            }
            return null;
        }
        public static PartnerDTO CreatePartner(PartnerDTO partnerDTO)
        {
            using (HttpClient client = new HttpClient())
            {
                client.DefaultRequestHeaders.Accept.Clear();
                var response = client.PostAsync("https://localhost:44386/api/Playlist/CreatePlaylist/", new StringContent(
                    new JavaScriptSerializer().Serialize(partnerDTO), Encoding.UTF8, "application/json")).Result;
                if (response.StatusCode == System.Net.HttpStatusCode.OK)
                {
                    return partnerDTO;
                }
            }
            return null;
        }
        public static PartnerDTO UpdatePartner(PartnerDTO partnerDTO)
        {
            using (HttpClient client = new HttpClient())
            {
                client.DefaultRequestHeaders.Accept.Clear();
                var response = client.PostAsync("https://localhost:44386/api/Playlist/UpdatePlaylist/", new StringContent(
                    new JavaScriptSerializer().Serialize(partnerDTO), Encoding.UTF8, "application/json")).Result;
                if (response.StatusCode == System.Net.HttpStatusCode.OK)
                {
                    return partnerDTO;
                }
            }
            return null;
        }
        #endregion
    }
}