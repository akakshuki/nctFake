using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Web;



namespace ModelViews.DTOs
{
    public class LyricsMusicDTO
    {
        public int ID { get; set; }
        [DisplayName("Lyrics")]
        public string LMusicDetail { get; set; }
        [DisplayName("Song")]
        public int MusicID { get; set; }
        public int UserID { get; set; }
        [DisplayName("Date Submitted ")]
        public DateTime LMusicDayCreate { get; set; }

        public MusicDTO MusicDto { get; set; }
        public UserDTO UserDto { get; set; }
    }
}