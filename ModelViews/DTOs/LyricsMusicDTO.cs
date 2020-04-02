using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;



namespace ModelViews.DTOs
{
    public class LyricsMusicDTO
    {
        public int ID { get; set; }
        public string LMusicDetail { get; set; }
        public int MusicID { get; set; }
        public int UserID { get; set; }
        public bool WaitApproval { get; set; }
        public bool NotApproved { get; set; }
        public bool NewNotice { get; set; }
        public DateTime LMusicDayCreate { get; set; }

        public MusicDTO MusicDto { get; set; }
    }
}