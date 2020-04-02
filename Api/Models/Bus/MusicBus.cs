using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Api.Models.Dao;

using Api.Models.EF;
using ModelViews.DTOs;

namespace Api.Models.Bus
{
    public class MusicBus
    {
        public void AdminCreateMusic(MusicDTO music)
        {
            var data = new MusicDao().Create(new Music() {
               MusicDayCreate = DateTime.Now,
               MusicName = music.MusicName,
               MusicDownloadAllowed = true,
               SongOrMV = true,
               UserID = music.UserID,
               MusicImage = music.MusicImage
            });


        }

    }
}   