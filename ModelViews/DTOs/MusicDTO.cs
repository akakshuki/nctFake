using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ModelViews.DTOs
{
    public class MusicDTO
    {
        public int ID { get; set; }
        public string MusicName { get; set; }
        public int UserID { get; set; }
        public bool MusicDownloadAllowed { get; set; }
        public int MusicView { get; set; }
        public bool SongOrMV { get; set; }
        public string MusicImage { get; set; }
        public DateTime MusicDayCreate { get; set; }
        public string MusicNameUnsigned { get; set; }
        public int? MusicRelated { get; set; }


        public UserDTO UserDto { get; set; }
        public List<QualityDTO> QualityDtos { get; set; }
        public List<HistoryUserDTO> HistoryUserDtos { get; set; }


    }
}