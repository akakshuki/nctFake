using Api.Models.EF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Api.Models.DTOs
{
    public class CategoryMvs
    {
        public int ID { get; set; }
        public string CateName { get; set; }
        public Nullable<int> ID_root { get; set; }

        public virtual ICollection<RankMusic> RankMusics { get; set; }
    }
}