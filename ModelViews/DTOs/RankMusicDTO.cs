
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ModelViews.DTOs
{
    public class RankMusicDTO
    {
        public int ID { get; set; }
        public string RMusicName { get; set; }
        public System.DateTime RMusicStart { get; set; }
        public System.DateTime RMusicEnd { get; set; }
        public int MusicID { get; set; }
        public int CateID { get; set; }
        public int RMusicGrade { get; set; }


        public  CategoryDTO CategoryDto { get; set; }
        public  MusicDTO MusicDto { get; set; }
    }
}