using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ModelViews.DTOs;

namespace ModelViews.DTOs { 
    public class RoleDTO
    {
        public int ID { get; set; }
        public string RoleName { get; set; }


        public List<UserDTO> UserDtos { get; set; }
    }
}