using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ModelViews.DTOs
{
    public class UserDTO
    {
        public int ID { get; set; }
        public string UserName { get; set; }
        public DateTime? UserDOB { get; set; }
        public bool? UserGender { get; set; }
        public bool UserVIP { get; set; }
        public string UserEmail { get; set; }
        public string UserPwd { get; set; }
        public string UserDescription { get; set; }
        public string UserNameUnsigned { get; set; }
        public string UserImage { get; set; }
        public HttpPostedFileBase FileImage { get; set; }
        public string LinkImage { get; set; }
        public DateTime UserDayCreate { get; set; }
        public int RoleID { get; set; }
        public bool UserActive { get; set; }
        public DateTime? DayVipEnd { get; set; }
        public string TokenUser { get; set; }




        public RoleDTO RoleDto { get; set; }
        public List<MusicDTO> MusicDtos { get; set; }
        public List<SingerMusicDTO> SingerMusicDtos { get; set; }
        public List<PlaylistDTO> PlaylistDtos { get; set; }
        public List<OrderVipDTO> OrderVipDtos { get; set; }



    }

    public class ResetPassword
    {
        public string Email { get; set; }
        [Required(ErrorMessage = "Chưa nhập mã số bí mật")]
        public string SerectCode { get; set; }
        [Required(ErrorMessage = "Hãy nhập mật khẩu mới")]
        public string NewPassword { get; set; }
        [Compare("Password", ErrorMessage = "Mật khẩu mới không khớp")]
        [Required(ErrorMessage = "Hãy nhập mật khẩu mới")]
        public string ConfirmNewPassword { get; set; }
    }
}