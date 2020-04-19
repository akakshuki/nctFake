﻿//------------------------------------------------------------------------------
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
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    
    public partial class ProjectNCTEntities : DbContext
    {
        public ProjectNCTEntities()
            : base("name=ProjectNCTEntities")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<Category> Categories { get; set; }
        public virtual DbSet<HistoryUser> HistoryUsers { get; set; }
        public virtual DbSet<LyricsMusic> LyricsMusics { get; set; }
        public virtual DbSet<Music> Musics { get; set; }
        public virtual DbSet<OrderVip> OrderVips { get; set; }
        public virtual DbSet<PackageVip> PackageVips { get; set; }
        public virtual DbSet<Partner> Partners { get; set; }
        public virtual DbSet<Payment> Payments { get; set; }
        public virtual DbSet<Playlist> Playlists { get; set; }
        public virtual DbSet<PlaylistMusic> PlaylistMusics { get; set; }
        public virtual DbSet<Quality> Qualities { get; set; }
        public virtual DbSet<QualityMusic> QualityMusics { get; set; }
        public virtual DbSet<Rank> Ranks { get; set; }
        public virtual DbSet<RankMusic> RankMusics { get; set; }
        public virtual DbSet<Role> Roles { get; set; }
        public virtual DbSet<SingerMusic> SingerMusics { get; set; }
        public virtual DbSet<sysdiagram> sysdiagrams { get; set; }
        public virtual DbSet<User> Users { get; set; }
        public virtual DbSet<ViewMusic> ViewMusics { get; set; }
    }
}
