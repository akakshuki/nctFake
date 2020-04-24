using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ModelViews.DTOs
{
    public class HistoryUserDTO
    {
        public int ID { get; set; }
        public int UserID { get; set; }
        public int MusicID { get; set; }

        public MusicDTO MusicDto { get; set; }
        public UserDTO UserDto { get; set; }
    }
}