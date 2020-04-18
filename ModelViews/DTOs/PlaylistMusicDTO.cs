using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModelViews.DTOs
{
    public class PlaylistMusicDTO
    {
        public int ID { get; set; }
        public int PlaylistID { get; set; }
        public int MusicID { get; set; }

        public PlaylistDTO PlaylistDto { get; set; }
        public virtual MusicDTO MusicDto { get; set; }
    }
}
