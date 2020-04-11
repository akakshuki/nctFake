﻿using ModelViews.DTOs;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Web;
using System.Web.Script.Serialization;

namespace AppAdmin.Models.Service
{
    public class ApiService
    {
        private static string _baseUrl = null;


        public ApiService()
        {
            _baseUrl = "https://localhost:44384/api/";
        }

        #region an
        #region User

        public static List<UserDTO> GetAllUser()
        {
            //JavaScriptSerializer oJS2 = new JavaScriptSerializer();
            var settings = new JsonSerializerSettings
            {
                NullValueHandling = NullValueHandling.Ignore,
                MissingMemberHandling = MissingMemberHandling.Ignore
            };
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("https://localhost:44384/api/User/GetAllUser/");
                var responseTask = client.GetAsync(client.BaseAddress);
                responseTask.Wait();
                var result = responseTask.Result;
                if (result.IsSuccessStatusCode)
                {
                    var readTask =
                        JsonConvert.DeserializeObject<List<UserDTO>>(result.Content.ReadAsStringAsync().Result);
                    return readTask;
                }
            }

            return null;
        }
        public static List<UserDTO> GetAllUserNormal()
        {
            //JavaScriptSerializer oJS2 = new JavaScriptSerializer();
            var settings = new JsonSerializerSettings
            {
                NullValueHandling = NullValueHandling.Ignore,
                MissingMemberHandling = MissingMemberHandling.Ignore
            };
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("https://localhost:44384/api/User/GetAllUserNormal/");
                var responseTask = client.GetAsync(client.BaseAddress);
                responseTask.Wait();
                var result = responseTask.Result;
                if (result.IsSuccessStatusCode)
                {
                    var readTask = JsonConvert.DeserializeObject<List<UserDTO>>(result.Content.ReadAsStringAsync().Result, settings);
                    return readTask;
                }
            }
            return null;
        }
        public static List<UserDTO> GetAllUserVip()
        {
            //JavaScriptSerializer oJS2 = new JavaScriptSerializer();
            var settings = new JsonSerializerSettings
            {
                NullValueHandling = NullValueHandling.Ignore,
                MissingMemberHandling = MissingMemberHandling.Ignore
            };
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("https://localhost:44384/api/User/GetAllUserVip/");
                var responseTask = client.GetAsync(client.BaseAddress);
                responseTask.Wait();
                var result = responseTask.Result;
                if (result.IsSuccessStatusCode)
                {
                    var readTask = JsonConvert.DeserializeObject<List<UserDTO>>(result.Content.ReadAsStringAsync().Result, settings);
                    return readTask;
                }
            }
            return null;
        }



        public static List<UserDTO> GetAllSinger()
        {
            //JavaScriptSerializer oJS2 = new JavaScriptSerializer();
            var settings = new JsonSerializerSettings
            {
                NullValueHandling = NullValueHandling.Ignore,
                MissingMemberHandling = MissingMemberHandling.Ignore
            };
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("https://localhost:44384/api/User/GetAllSinger/");
                var responseTask = client.GetAsync(client.BaseAddress);
                responseTask.Wait();
                var result = responseTask.Result;
                if (result.IsSuccessStatusCode)
                {
                    var readTask = JsonConvert.DeserializeObject<List<UserDTO>>(result.Content.ReadAsStringAsync().Result, settings);
                    return readTask;
                }
            }
            return null;
        }
        public static UserDTO GetUserById(int id)
        {
            var settings = new JsonSerializerSettings
            {
                NullValueHandling = NullValueHandling.Ignore,
                MissingMemberHandling = MissingMemberHandling.Ignore
            };
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("https://localhost:44384/api/User/GetUserById/" + id.ToString());
                var responseTask = client.GetAsync(client.BaseAddress);
                responseTask.Wait();
                var result = responseTask.Result;
                if (result.IsSuccessStatusCode)
                {
                    var readTask = JsonConvert.DeserializeObject<UserDTO>(result.Content.ReadAsStringAsync().Result, settings);
                    return readTask;
                }
            }

            return null;
        }

        public static List<UserDTO> GetUserByIdRole(int id)
        {
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("https://localhost:44384/api/User/GetUserByIdRole/" + id.ToString());
                var responseTask = client.GetAsync(client.BaseAddress);
                responseTask.Wait();
                var result = responseTask.Result;
                if (result.IsSuccessStatusCode)
                {
                    var readTask =
                        JsonConvert.DeserializeObject<List<UserDTO>>(result.Content.ReadAsStringAsync().Result);
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
                var response = client.PostAsync("https://localhost:44384/api/User/CreateSinger/", new StringContent(
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
                var response = client.PostAsync("https://localhost:44384/api/User/CreateUser/", new StringContent(
                    new JavaScriptSerializer().Serialize(userDTO), Encoding.UTF8, "application/json")).Result;
                if (response.StatusCode == System.Net.HttpStatusCode.OK)
                {
                    return userDTO;
                }
            }

            return null;
        }
        public static UserDTO UpdateSinger(UserDTO userDTO)
        {
            using (HttpClient client = new HttpClient())
            {
                client.DefaultRequestHeaders.Accept.Clear();
                var response = client.PostAsync("https://localhost:44384/api/User/UpdateSinger/", new StringContent(
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
                var response = client.PostAsync("https://localhost:44384/api/User/UpdateUser/", new StringContent(
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
                var response = client.DeleteAsync("https://localhost:44384/api/User/DeleteUser/" + id.ToString())
                    .Result;
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
                client.BaseAddress = new Uri("https://localhost:44384/api/Category/GetAllCate/");
                var responseTask = client.GetAsync(client.BaseAddress);
                responseTask.Wait();
                var result = responseTask.Result;
                if (result.IsSuccessStatusCode)
                {
                    var readTask =
                        JsonConvert.DeserializeObject<List<CategoryDTO>>(result.Content.ReadAsStringAsync().Result);
                    return readTask;
                }
            }

            return null;
        }  public static List<CategoryDTO> GetAllListCategories()
        {
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("https://localhost:44384/api/Category/GetAllListCate/");
                var responseTask = client.GetAsync(client.BaseAddress);
                responseTask.Wait();
                var result = responseTask.Result;
                if (result.IsSuccessStatusCode)
                {
                    var readTask =
                        JsonConvert.DeserializeObject<List<CategoryDTO>>(result.Content.ReadAsStringAsync().Result);
                    return readTask;
                }
            }

            return null;
        }
        public static List<CategoryDTO> GetAllCateCon()
        {
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("https://localhost:44384/api/Category/GetAllCateCon/");
                var responseTask = client.GetAsync(client.BaseAddress);
                responseTask.Wait();
                var result = responseTask.Result;
                if (result.IsSuccessStatusCode)
                {
                    var readTask =
                        JsonConvert.DeserializeObject<List<CategoryDTO>>(result.Content.ReadAsStringAsync().Result);
                    return readTask;
                }
            }

            return null;
        }

        public static CategoryDTO GetCateById(int id)
        {
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("https://localhost:44384/api/Category/GetCateById/" + id.ToString());
                var responseTask = client.GetAsync(client.BaseAddress);
                responseTask.Wait();
                var result = responseTask.Result;
                if (result.IsSuccessStatusCode)
                {
                    var readTask =
                        JsonConvert.DeserializeObject<CategoryDTO>(result.Content.ReadAsStringAsync().Result);
                    return readTask;
                }
            }

            return null;
        }

        public static List<RoleDTO> GetRoleById(int id)
        {
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("https://localhost:44384/api/Category/GetRoleById/" + id.ToString());
                var responseTask = client.GetAsync(client.BaseAddress);
                responseTask.Wait();
                var result = responseTask.Result;
                if (result.IsSuccessStatusCode)
                {
                    var readTask =
                        JsonConvert.DeserializeObject<List<RoleDTO>>(result.Content.ReadAsStringAsync().Result);
                    return readTask;
                }
            }

            return null;
        }
        public static List<CategoryDTO> GetCateByIdRoot(int id)
        {
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("https://localhost:44384/api/Category/GetCateByIdRoot/" + id.ToString());
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
        public static CategoryDTO CreateCate(CategoryDTO categoryDTO)
        {
            using (HttpClient client = new HttpClient())
            {
                client.DefaultRequestHeaders.Accept.Clear();
                var response = client.PostAsync("https://localhost:44384/api/Category/CreateCate/", new StringContent(
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
                var response = client.PostAsync("https://localhost:44384/api/Category/UpdateCate/", new StringContent(
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
                var response = client.DeleteAsync("https://localhost:44384/api/Category/DeleteCate/" + id.ToString())
                    .Result;
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
                client.BaseAddress = new Uri("https://localhost:44384/api/Playlist/GetAllPlaylist/");
                var responseTask = client.GetAsync(client.BaseAddress);
                responseTask.Wait();
                var result = responseTask.Result;
                if (result.IsSuccessStatusCode)
                {
                    var readTask =
                        JsonConvert.DeserializeObject<List<PlaylistDTO>>(result.Content.ReadAsStringAsync().Result);
                    return readTask;
                }
            }

            return null;
        }

        public static PlaylistDTO GetPlaylistById(int id)
        {
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("https://localhost:44384/api/Playlist/GetPlaylistById/" + id.ToString());
                var responseTask = client.GetAsync(client.BaseAddress);
                responseTask.Wait();
                var result = responseTask.Result;
                if (result.IsSuccessStatusCode)
                {
                    var readTask =
                        JsonConvert.DeserializeObject<PlaylistDTO>(result.Content.ReadAsStringAsync().Result);
                    return readTask;
                }
            }

            return null;
        }

        public static List<PlaylistDTO> GetPlaylistByIdUser(int id)
        {
            using (var client = new HttpClient())
            {
                client.BaseAddress =
                    new Uri("https://localhost:44384/api/Playlist/GetPlaylistByIdUser/" + id.ToString());
                var responseTask = client.GetAsync(client.BaseAddress);
                responseTask.Wait();
                var result = responseTask.Result;
                if (result.IsSuccessStatusCode)
                {
                    var readTask =
                        JsonConvert.DeserializeObject<List<PlaylistDTO>>(result.Content.ReadAsStringAsync().Result);
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
                var response = client.PostAsync("https://localhost:44384/api/Playlist/CreatePlaylist/",
                    new StringContent(
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
                var response = client.PostAsync("https://localhost:44384/api/Playlist/UpdatePlaylist/",
                    new StringContent(
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
                var response = client
                    .DeleteAsync("https://localhost:44384/api/Playlist/DeletePlaylist/" + id.ToString()).Result;
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
                client.BaseAddress = new Uri("https://localhost:44384/api/Partner/GetAllPartner/");
                var responseTask = client.GetAsync(client.BaseAddress);
                responseTask.Wait();
                var result = responseTask.Result;
                if (result.IsSuccessStatusCode)
                {
                    var readTask =
                        JsonConvert.DeserializeObject<List<PartnerDTO>>(result.Content.ReadAsStringAsync().Result);
                    return readTask;
                }
            }

            return null;
        }

        public static PartnerDTO GetPartnerById(int id)
        {
            var settings = new JsonSerializerSettings
            {
                NullValueHandling = NullValueHandling.Ignore,
                MissingMemberHandling = MissingMemberHandling.Ignore
            };
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("https://localhost:44384/api/Partner/GetPartnerById/" + id.ToString());
                var responseTask = client.GetAsync(client.BaseAddress);
                responseTask.Wait();
                var result = responseTask.Result;
                if (result.IsSuccessStatusCode)
                {
                    var readTask = JsonConvert.DeserializeObject<PartnerDTO>(result.Content.ReadAsStringAsync().Result, settings);
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
                var response = client.PostAsync("https://localhost:44384/api/Partner/CreatePartner/",
                    new StringContent(
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
                var response = client.PostAsync("https://localhost:44384/api/Partner/UpdatePartner/",
                    new StringContent(
                        new JavaScriptSerializer().Serialize(partnerDTO), Encoding.UTF8, "application/json")).Result;
                if (response.StatusCode == System.Net.HttpStatusCode.OK)
                {
                    return partnerDTO;
                }
            }

            return null;
        }
        public static bool DeletePartner(int id)
        {
            using (HttpClient client = new HttpClient())
            {
                client.DefaultRequestHeaders.Accept.Clear();
                var response = client
                    .DeleteAsync("https://localhost:44384/api/Partner/DeletePartner/" + id.ToString()).Result;
                if (response.StatusCode == System.Net.HttpStatusCode.OK)
                {
                    return true;
                }
            }

            return false;
        }

        #endregion

        #region OrderVip
        public static List<OrderVipDTO> GetOrderVipByIdUser(int id)
        {
            var settings = new JsonSerializerSettings
            {
                NullValueHandling = NullValueHandling.Ignore,
                MissingMemberHandling = MissingMemberHandling.Ignore
            };
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("https://localhost:44384/api/OrderVip/GetOrderVipByIdUser/" + id.ToString());
                var responseTask = client.GetAsync(client.BaseAddress);
                responseTask.Wait();
                var result = responseTask.Result;
                if (result.IsSuccessStatusCode)
                {
                    var readTask =
                        JsonConvert.DeserializeObject<List<OrderVipDTO>>(result.Content.ReadAsStringAsync().Result,settings);
                    return readTask;
                }
            }

            return null;
        }
        #endregion

        #region LyricsMusic
        public static LyricsMusicDTO GetLyricByIdMusic(int id)
        {
            var settings = new JsonSerializerSettings
            {
                NullValueHandling = NullValueHandling.Ignore,
                MissingMemberHandling = MissingMemberHandling.Ignore
            };
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("https://localhost:44384/api/LyricsMusic/GetLyricByIdMusic/" + id.ToString());
                var responseTask = client.GetAsync(client.BaseAddress);
                responseTask.Wait();
                var result = responseTask.Result;
                if (result.IsSuccessStatusCode)
                {
                    var readTask = JsonConvert.DeserializeObject<LyricsMusicDTO>(result.Content.ReadAsStringAsync().Result, settings);
                    return readTask;
                }
            }

            return null;
        }
        public static LyricsMusicDTO GetLyricById(int id)
        {
            var settings = new JsonSerializerSettings
            {
                NullValueHandling = NullValueHandling.Ignore,
                MissingMemberHandling = MissingMemberHandling.Ignore
            };
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("https://localhost:44384/api/LyricsMusic/GetLyricById/" + id.ToString());
                var responseTask = client.GetAsync(client.BaseAddress);
                responseTask.Wait();
                var result = responseTask.Result;
                if (result.IsSuccessStatusCode)
                {
                    var readTask = JsonConvert.DeserializeObject<LyricsMusicDTO>(result.Content.ReadAsStringAsync().Result, settings);
                    return readTask;
                }
            }

            return null;
        }
        public static LyricsMusicDTO CreateLyrics(LyricsMusicDTO lyricsMusic)
        {
            using (HttpClient client = new HttpClient())
            {
                client.DefaultRequestHeaders.Accept.Clear();
                var response = client.PostAsync("https://localhost:44384/api/LyricsMusic/Create/", new StringContent(
                    new JavaScriptSerializer().Serialize(lyricsMusic), Encoding.UTF8, "application/json")).Result;
                if (response.StatusCode == System.Net.HttpStatusCode.OK)
                {
                    return lyricsMusic;
                }
            }

            return null;
        }
        public static LyricsMusicDTO UpdateLyrics(LyricsMusicDTO lyricsMusic)
        {
            using (HttpClient client = new HttpClient())
            {
                client.DefaultRequestHeaders.Accept.Clear();
                var response = client.PostAsync("https://localhost:44384/api/LyricsMusic/Update/", new StringContent(
                    new JavaScriptSerializer().Serialize(lyricsMusic), Encoding.UTF8, "application/json")).Result;
                if (response.StatusCode == System.Net.HttpStatusCode.OK)
                {
                    return lyricsMusic;
                }
            }
            return null;
        }
        #endregion

        #region QualityMusic
        public static List<QualityMusicDTO> GetAllQM()
        {
            //JavaScriptSerializer oJS2 = new JavaScriptSerializer();
            var settings = new JsonSerializerSettings
            {
                NullValueHandling = NullValueHandling.Ignore,
                MissingMemberHandling = MissingMemberHandling.Ignore
            };
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("https://localhost:44384/api/QualityMusic/GetAllQM/");
                var responseTask = client.GetAsync(client.BaseAddress);
                responseTask.Wait();
                var result = responseTask.Result;
                if (result.IsSuccessStatusCode)
                {
                    var readTask =
                        JsonConvert.DeserializeObject<List<QualityMusicDTO>>(result.Content.ReadAsStringAsync().Result);
                    return readTask;
                }
            }

            return null;
        }
        public static QualityMusicDTO GetQualityMusicById(int id)
        {
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("https://localhost:44384/api/QualityMusic/GetQualityMusicById/" + id.ToString());
                var responseTask = client.GetAsync(client.BaseAddress);
                responseTask.Wait();
                var result = responseTask.Result;
                if (result.IsSuccessStatusCode)
                {
                    var readTask =
                        JsonConvert.DeserializeObject<QualityMusicDTO>(result.Content.ReadAsStringAsync().Result);
                    return readTask;
                }
            }

            return null;
        }

        public static List<QualityMusicDTO> GetFileByIdMusic(int id)
        {
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("https://localhost:44384/api/QualityMusic/GetFileByIdMusic/" + id.ToString());
                var responseTask = client.GetAsync(client.BaseAddress);
                responseTask.Wait();
                var result = responseTask.Result;
                if (result.IsSuccessStatusCode)
                {
                    var readTask =
                        JsonConvert.DeserializeObject<List<QualityMusicDTO>>(result.Content.ReadAsStringAsync().Result);
                    return readTask;
                }
            }

            return null;
        }

        public static QualityMusicDTO CreateQualityMusic(QualityMusicDTO qualityMusic)
        {
            using (HttpClient client = new HttpClient())
            {
                client.DefaultRequestHeaders.Accept.Clear();
                var response = client.PostAsync("https://localhost:44384/api/QualityMusic/CreateQualityMusic/", new StringContent(
                    new JavaScriptSerializer().Serialize(qualityMusic), Encoding.UTF8, "application/json")).Result;
                if (response.StatusCode == System.Net.HttpStatusCode.OK)
                {
                    return qualityMusic;
                }
            }

            return null;
        }

        public static QualityMusicDTO UpdateFile(QualityMusicDTO qualityMusic)
        {
            using (HttpClient client = new HttpClient())
            {
                client.DefaultRequestHeaders.Accept.Clear();
                var response = client.PostAsync("https://localhost:44384/api/QualityMusic/UpdateFile/", new StringContent(
                    new JavaScriptSerializer().Serialize(qualityMusic), Encoding.UTF8, "application/json")).Result;
                if (response.StatusCode == System.Net.HttpStatusCode.OK)
                {
                    return qualityMusic;
                }
            }

            return null;
        }

        public static QualityMusicDTO UpdateQualityMusic(QualityMusicDTO qualityMusic)
        {
            using (HttpClient client = new HttpClient())
            {
                client.DefaultRequestHeaders.Accept.Clear();
                var response = client.PostAsync("https://localhost:44384/api/QualityMusic/UpdateQualityMusic/", new StringContent(
                    new JavaScriptSerializer().Serialize(qualityMusic), Encoding.UTF8, "application/json")).Result;
                if (response.StatusCode == System.Net.HttpStatusCode.OK)
                {
                    return qualityMusic;
                }
            }

            return null;
        }

        public static bool DeleteQualityMusic(int id)
        {
            using (HttpClient client = new HttpClient())
            {
                client.DefaultRequestHeaders.Accept.Clear();
                var response = client.DeleteAsync("https://localhost:44384/api/QualityMusic/DeleteQualityMusic/" + id.ToString())
                    .Result;
                if (response.StatusCode == System.Net.HttpStatusCode.OK)
                {
                    return true;
                }
            }

            return false;
        }
        #endregion
        #endregion

        #region hoang

        #region Music


        public static List<MusicDTO> GetAllMusic()
        {
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("https://localhost:44384/api/music/");
                var responseTask = client.GetAsync(client.BaseAddress);
                responseTask.Wait();
                var result = responseTask.Result;
                if (!result.IsSuccessStatusCode) return null;
                var readTask = JsonConvert.DeserializeObject<List<MusicDTO>>(result.Content.ReadAsStringAsync().Result);
                return readTask.ToList();
            }

        }

        public static List<MusicDTO> GetPagingMusic(Pagination pagination)
        {
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("" + "music/");
                var responseTask = client.PostAsync(client.BaseAddress, new StringContent(
                    new JavaScriptSerializer().Serialize(pagination), Encoding.UTF8, "application/json"));
                responseTask.Wait();
                var result = responseTask.Result;
                if (!result.IsSuccessStatusCode) return null;
                var readTask = JsonConvert.DeserializeObject<List<MusicDTO>>(result.Content.ReadAsStringAsync().Result);
                return readTask.Take(20).ToList();
            }

        }

        public static bool CreateMusic(MusicDTO music)
        {
            using (var client = new HttpClient())
            {
                var data = new StringContent(
                    new JavaScriptSerializer().Serialize(music), Encoding.UTF8, "application/json");
                client.DefaultRequestHeaders.Accept.Clear();

                var response = client.PostAsync("https://localhost:44384/api/music/", data).Result;

                if (response.StatusCode == System.Net.HttpStatusCode.OK)
                {
                    return true;
                }
            }

            return false;
        }

        public static bool UpdateMusic(MusicDTO music)
        {
            //up load if file have upload
            using (HttpClient client = new HttpClient())
            {
                var data = new StringContent(
                       new JavaScriptSerializer().Serialize(music), Encoding.UTF8, "application/json");
                client.DefaultRequestHeaders.Accept.Clear();

                var response = client.PutAsync("https://localhost:44384/api/music/" + music.ID, data).Result;

                if (response.StatusCode == System.Net.HttpStatusCode.OK)
                {
                    return true;
                }
            }

            return false;
        }

        public static bool DeleteMusic(int id)
        {
            using (HttpClient client = new HttpClient())
            {
                client.DefaultRequestHeaders.Accept.Clear();
                var response = client.DeleteAsync("https://localhost:44384/api/music/" + id).Result;
                if (response.StatusCode == System.Net.HttpStatusCode.OK)
                {
                    return true;
                }
            }

            return false;
        }


        public static MusicDTO GetMusicById(int id)
        {
            using var client = new HttpClient();
            client.BaseAddress = new Uri("https://localhost:44384/api/music/" + id.ToString());
            var responseTask = client.GetAsync(client.BaseAddress);
            responseTask.Wait();
            var result = responseTask.Result;
            if (!result.IsSuccessStatusCode) return null;
            var readTask = JsonConvert.DeserializeObject<MusicDTO>(result.Content.ReadAsStringAsync().Result);
            return readTask;
        }

        public static List<SingerMusicDTO> GetSingerOfMusicByMusicId(int id)
        {
            using var client = new HttpClient();
            client.BaseAddress = new Uri("https://localhost:44384/api/music/GetSingerMusicByMusicId/" + id.ToString());
            var responseTask = client.GetAsync(client.BaseAddress);
            responseTask.Wait();
            var result = responseTask.Result;
            if (!result.IsSuccessStatusCode) return null;
            var readTask = JsonConvert.DeserializeObject<List<SingerMusicDTO>>(result.Content.ReadAsStringAsync().Result);
            return readTask;
        }

        public static bool AddSingerToMusic(SingerMusicDTO singerMusic)
        {
            try
            {
                using var client = new HttpClient();
                var data = new StringContent(
                    new JavaScriptSerializer().Serialize(singerMusic), Encoding.UTF8, "application/json");
                client.DefaultRequestHeaders.Accept.Clear();
                var response = client.PostAsync("https://localhost:44384/api/music/AddSingerToMusic", data).Result;
                return response.StatusCode == System.Net.HttpStatusCode.OK;
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                return false;
            }
        }

        public static bool DeleteSingerToMusic(int id)
        {
            using (HttpClient client = new HttpClient())
            {
                client.DefaultRequestHeaders.Accept.Clear();
                var response = client.DeleteAsync("https://localhost:44384/api/music/DeleteSingerMusicByMusicId/" + id).Result;
                if (response.StatusCode == System.Net.HttpStatusCode.OK)
                {
                    return true;
                }
            }

            return false;
        }

        #endregion

        #region Payment

        public static bool CreatePayment(PaymentDTO payment)
        {

            using (HttpClient client = new HttpClient())
            {
                client.DefaultRequestHeaders.Accept.Clear();
                var response = client.PostAsync("https://localhost:44384/api/payment/", new StringContent(
                    new JavaScriptSerializer().Serialize(payment), Encoding.UTF8, "application/json")).Result;
                if (response.StatusCode == System.Net.HttpStatusCode.OK)
                {
                    return true;
                }
            }

            return false;

        }

        public static bool UpdatePayment(PaymentDTO payment)
        {

            using (HttpClient client = new HttpClient())
            {
                client.DefaultRequestHeaders.Accept.Clear();
                var response = client.PutAsync("https://localhost:44384/api/payment/" + payment.ID, new StringContent(
                    new JavaScriptSerializer().Serialize(payment), Encoding.UTF8, "application/json")).Result;
                if (response.StatusCode == System.Net.HttpStatusCode.OK)
                {
                    return true;
                }
            }

            return false;

        }


        public static bool DeletePayment(int id)
        {

            using (HttpClient client = new HttpClient())
            {
                client.DefaultRequestHeaders.Accept.Clear();
                var response = client.DeleteAsync("https://localhost:44384/api/payment/" + id).Result;
                if (response.StatusCode == System.Net.HttpStatusCode.OK)
                {
                    return true;
                }
            }

            return false;

        }

        public static List<PaymentDTO> GetAllPayment()
        {
            using (var client = new HttpClient())
            {

                client.BaseAddress = new Uri("https://localhost:44384/api/payment/");
                var responseTask = client.GetAsync(client.BaseAddress);
                responseTask.Wait();
                var result = responseTask.Result;
                if (!result.IsSuccessStatusCode) return null;
                var readTask =
                    JsonConvert.DeserializeObject<List<PaymentDTO>>(result.Content.ReadAsStringAsync().Result);
                return readTask.ToList();
            }

        }

        public static PaymentDTO GetPaymentById(int id)
        {
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("https://localhost:44384/api/payment/" + id.ToString());
                var responseTask = client.GetAsync(client.BaseAddress);
                responseTask.Wait();
                var result = responseTask.Result;
                if (!result.IsSuccessStatusCode) return null;
                var readTask = JsonConvert.DeserializeObject<PaymentDTO>(result.Content.ReadAsStringAsync().Result);
                return readTask;
            }


        }

        #endregion

        #region PackageVip

        public static List<PackageVipDTO> GetAllPackageVip()
        {
            using (var client = new HttpClient())
            {

                client.BaseAddress = new Uri("https://localhost:44384/api/packagevip/");
                var responseTask = client.GetAsync(client.BaseAddress);
                responseTask.Wait();
                var result = responseTask.Result;
                if (!result.IsSuccessStatusCode) return null;
                var readTask =
                    JsonConvert.DeserializeObject<List<PackageVipDTO>>(result.Content.ReadAsStringAsync().Result);
                return readTask.ToList();
            }

        }



        public static bool CreatePackageVip(PackageVipDTO packageVip)
        {

            using (HttpClient client = new HttpClient())
            {
                client.DefaultRequestHeaders.Accept.Clear();
                var response = client.PostAsync("https://localhost:44384/api/packageVip/", new StringContent(
                    new JavaScriptSerializer().Serialize(packageVip), Encoding.UTF8, "application/json")).Result;
                if (response.StatusCode == System.Net.HttpStatusCode.OK)
                {
                    return true;
                }
            }

            return false;

        }

        public static bool UpdatePackageVip(PackageVipDTO packageVip)
        {

            using (HttpClient client = new HttpClient())
            {
                client.DefaultRequestHeaders.Accept.Clear();
                var response = client.PutAsync("https://localhost:44384/api/packageVip/" + packageVip.ID,
                    new StringContent(
                        new JavaScriptSerializer().Serialize(packageVip), Encoding.UTF8, "application/json")).Result;
                if (response.StatusCode == System.Net.HttpStatusCode.OK)
                {
                    return true;
                }
            }

            return false;

        }


        public static bool DeletePackageVip(int id)
        {

            using (HttpClient client = new HttpClient())
            {
                client.DefaultRequestHeaders.Accept.Clear();
                var response = client.DeleteAsync("https://localhost:44384/api/packageVip/" + id).Result;
                if (response.StatusCode == System.Net.HttpStatusCode.OK)
                {
                    return true;
                }
            }

            return false;

        }

        public static PackageVipDTO GetPackageVipById(int id)
        {
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("https://localhost:44384/api/packageVip/" + id.ToString());
                var responseTask = client.GetAsync(client.BaseAddress);
                responseTask.Wait();
                var result = responseTask.Result;
                if (!result.IsSuccessStatusCode) return null;
                var readTask = JsonConvert.DeserializeObject<PackageVipDTO>(result.Content.ReadAsStringAsync().Result);
                return readTask;
            }


        }


        #endregion

        #region Quality

        public static object CreateQuality(QualityDTO quality)
        {
            using (HttpClient client = new HttpClient())
            {
                client.DefaultRequestHeaders.Accept.Clear();
                var response = client.PostAsync("https://localhost:44384/api/quality/", new StringContent(
                    new JavaScriptSerializer().Serialize(quality), Encoding.UTF8, "application/json")).Result;
                if (response.StatusCode == System.Net.HttpStatusCode.OK)
                {
                    return true;
                }
            }

            return false;
        }

        public static List<QualityDTO> GetAllQuality()
        {
            using (var client = new HttpClient())
            {

                client.BaseAddress = new Uri("https://localhost:44384/api/quality/");
                var responseTask = client.GetAsync(client.BaseAddress);
                responseTask.Wait();
                var result = responseTask.Result;
                if (!result.IsSuccessStatusCode) return null;
                var readTask =
                    JsonConvert.DeserializeObject<List<QualityDTO>>(result.Content.ReadAsStringAsync().Result);
                return readTask.ToList();
            }
        }

        public static bool DeleteQuality(int id)
        {
            using (HttpClient client = new HttpClient())
            {
                client.DefaultRequestHeaders.Accept.Clear();
                var response = client.DeleteAsync("https://localhost:44384/api/quality/" + id).Result;
                if (response.StatusCode == System.Net.HttpStatusCode.OK)
                {
                    return true;
                }
            }

            return false;
        }

        public static bool UpdateQuality(QualityDTO quality)
        {
            using (HttpClient client = new HttpClient())
            {
                client.DefaultRequestHeaders.Accept.Clear();
                var response = client.PutAsync("https://localhost:44384/api/quality/" + quality.ID,
                    new StringContent(
                        new JavaScriptSerializer().Serialize(quality), Encoding.UTF8, "application/json")).Result;
                if (response.StatusCode == System.Net.HttpStatusCode.OK)
                {
                    return true;
                }
            }

            return false;
        }
        public static QualityDTO GetQualityById(int id)
        {
            using var client = new HttpClient
            {
                BaseAddress = new Uri("https://localhost:44384/api/quality/" + id.ToString())
            };
            var responseTask = client.GetAsync(client.BaseAddress);
            responseTask.Wait();
            var result = responseTask.Result;
            if (!result.IsSuccessStatusCode) return null;
            var readTask = JsonConvert.DeserializeObject<QualityDTO>(result.Content.ReadAsStringAsync().Result);
            return readTask;
        }

        #endregion

        #endregion



    }
}