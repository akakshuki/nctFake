//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Api.Models.EF
{
    using System;
    using System.Collections.Generic;
    
    public partial class Music
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Music()
        {
            this.HistoryUsers = new HashSet<HistoryUser>();
            this.LyricsMusics = new HashSet<LyricsMusic>();
            this.PlaylistMusics = new HashSet<PlaylistMusic>();
            this.RankMusics = new HashSet<RankMusic>();
        }
    
        public int ID { get; set; }
        public string MusicName { get; set; }
        public int UserID { get; set; }
        public int CategoryId { get; set; }
        public bool MusicDownloadAllowed { get; set; }
        public int MusicView { get; set; }
        public bool SongOrMV { get; set; }
        public string MusicImage { get; set; }
        public System.DateTime MusicDayCreate { get; set; }
        public string MusicNameUnsigned { get; set; }
        public Nullable<int> MusicRelated { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<HistoryUser> HistoryUsers { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<LyricsMusic> LyricsMusics { get; set; }
        public virtual User User { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<PlaylistMusic> PlaylistMusics { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<RankMusic> RankMusics { get; set; }
    }
}
