using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModelViews.DTOs
{
    public class RankDTO
    {
        public int ID { get; set; }
        public string RMusicName { get; set; }
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:MM-dd-yyyy}", ApplyFormatInEditMode = true)]
        public DateTime RMusicStart { get; set; }
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:MM-dd-yyyy}", ApplyFormatInEditMode = true)]
        public DateTime RMusicEnd { get; set; }
        public int CateID { get; set; }
        public bool SongOrMusic { get; set; }


        public CategoryDTO CategoryDto { get; set; }
        public List<MusicDTO> MusicDtos { get; set; }
        public int OldWeekRankId { get; set; }
    }
}
