using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ModelViews.DTOs
{
    public class QualityMusicDTO
    {
        public int ID { get; set; }
        public int MusicID { get; set; }
        public string MusicFile { get; set; }
        public int QualityID { get; set; }
        public bool QMusicApproved { get; set; }
        public bool NewFile { get; set; }

        public MusicDTO MusicDto { get; set; }
        public QualityDTO QualityDto { get; set; }


    }
}