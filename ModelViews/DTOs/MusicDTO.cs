﻿using System;
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
        public int CategoryId { get; set; }
        public string MusicImage { get; set; }
        public HttpPostedFileBase FileImage { get; set; }
        public string LinkImage { get; set; }
        public DateTime MusicDayCreate { get; set; }
        public string MusicNameUnsigned { get; set; }
        public int? MusicRelated { get; set; }
        public int  GradeRank { get; set; }

        public UserDTO UserDto { get; set; }
        public QualityMusicDTO QualityMusicDto { get; set; }
        public List<QualityDTO> QualityDtos { get; set; }
        public List<HistoryUserDTO> HistoryUserDtos { get; set; }
        public List<SingerMusicDTO> SingerMusicDtOs { get; set; }
        public CategoryDTO CategoryDto { get; set; }
        public IEnumerable<QualityMusicDTO> QualityMusicDTOs { get; set; }
    }
}