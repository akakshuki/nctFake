using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ModelViews.DTOs
{
    public class ViewMusicDTO
    {
        public int ID { get; set; }
        public int MusicID { get; set; }
        public DateTime ViewDayCreate { get; set; }
    }
}