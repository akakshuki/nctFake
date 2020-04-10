using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ModelViews.DTOs
{
    public class SingerMusicDTO
    {
        public int ID { get; set; }
        public int MusicID { get; set; }
        public int SingerID { get; set; }

        public  UserDTO  UserDto { get; set; }
        public MusicDTO MusicDto { get; set; }
    }
}