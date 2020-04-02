using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ModelViews.DTOs { 

    public class QualityDTO
    {
        public int ID { get; set; }
        public string QualityName { get; set; }
        public bool QualityVip { get; set; }

        public List<QualityMusicDTO> QualityMusicDtos { get; set; } 
    }
}