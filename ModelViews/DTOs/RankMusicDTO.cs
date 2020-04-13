
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ModelViews.DTOs
{
    public class RankMusicDTO
    {
        public int ID { get; set; }
        public int RankID { get; set; }
        public int MusicID { get; set; }
        public int RMusicGrade { get; set; }

        public  MusicDTO MusicDto { get; set; }
        public RankDTO RankDto { get; set; }
    }
}