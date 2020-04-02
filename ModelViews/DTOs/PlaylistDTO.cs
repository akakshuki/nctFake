﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ModelViews.DTOs { 
    public class PlaylistDTO
    {
        public int ID { get; set; }
        public string PlaylistName { get; set; }
        public int UserID { get; set; }
        public int CateID { get; set; }
        public string PlaylistImage { get; set; }
        public string PlaylistDescription { get; set; }

        public CategoryDTO CategoryDto { get; set; }
        public UserDTO UserDto { get; set; }
        
    }
}