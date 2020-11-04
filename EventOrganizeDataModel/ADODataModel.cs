namespace EventOrganizeDataModel
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class ADODataModel : DbContext
    {
        public ADODataModel()
            : base("name=ADODataModel")
        {
        }

        public virtual DbSet<Attendant> Attendants { get; set; }
        public virtual DbSet<cls_Place> cls_Place { get; set; }
        public virtual DbSet<cls_Resources> cls_Resources { get; set; }
        public virtual DbSet<cls_Role> cls_Role { get; set; }
        public virtual DbSet<Event> Events { get; set; }
        public virtual DbSet<sysdiagram> sysdiagrams { get; set; }
        public virtual DbSet<UserProfile> UserProfiles { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<cls_Place>()
                .Property(e => e.Name)
                .IsUnicode(false);

            modelBuilder.Entity<cls_Place>()
                .Property(e => e.Address)
                .IsUnicode(false);

            modelBuilder.Entity<cls_Place>()
                .HasMany(e => e.Events)
                .WithOptional(e => e.cls_Place)
                .HasForeignKey(e => e.PlaceId);

            modelBuilder.Entity<cls_Resources>()
                .Property(e => e.Name)
                .IsUnicode(false);

            modelBuilder.Entity<cls_Resources>()
                .HasMany(e => e.Events)
                .WithOptional(e => e.cls_Resources)
                .HasForeignKey(e => e.ResourceId);

            modelBuilder.Entity<cls_Role>()
                .Property(e => e.Name)
                .IsUnicode(false);

            modelBuilder.Entity<cls_Role>()
                .HasMany(e => e.Attendants)
                .WithOptional(e => e.cls_Role)
                .HasForeignKey(e => e.RoleId);

            modelBuilder.Entity<cls_Role>()
                .HasMany(e => e.UserProfiles)
                .WithOptional(e => e.cls_Role)
                .HasForeignKey(e => e.RoleId);

            modelBuilder.Entity<Event>()
                .Property(e => e.Name)
                .IsUnicode(false);

            modelBuilder.Entity<UserProfile>()
                .Property(e => e.Name)
                .IsUnicode(false);

            modelBuilder.Entity<UserProfile>()
                .Property(e => e.Surname)
                .IsUnicode(false);

            modelBuilder.Entity<UserProfile>()
                .Property(e => e.EMail)
                .IsUnicode(false);

            modelBuilder.Entity<UserProfile>()
                .Property(e => e.Password)
                .IsUnicode(false);

            modelBuilder.Entity<UserProfile>()
                .HasMany(e => e.Attendants)
                .WithOptional(e => e.UserProfile)
                .HasForeignKey(e => e.UserId);

            modelBuilder.Entity<UserProfile>()
                .HasMany(e => e.Events)
                .WithOptional(e => e.UserProfile)
                .HasForeignKey(e => e.CreatorId);
        }
    }
}
