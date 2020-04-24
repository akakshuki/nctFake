
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;


namespace ModelViews.DTOs { 
    public class CategoryDTO
    {
        public int ID { get; set; }
        public string CateName { get; set; }
        public int? ID_root { get; set; }
    //    public string CategoryRootName { get; set; }

        public List<PlaylistDto> PlaylistDtos { get; set; }
        public List<MusicDTO> MusicDtos { get; set; }
        public List<RankMusicDTO> RankMusicDtos { get; set; }
        public List<CategoryDTO> CategoryDtos { get; set; }
    }
}