namespace ProjectEWS.Entity
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class DataContext : DbContext
    {
        public DataContext()
            : base("name=DataContext")
        {
        }

        public virtual DbSet<Coordinator> Coordinators { get; set; }
        public virtual DbSet<Cours> Courses { get; set; }
        public virtual DbSet<Magazine> Magazines { get; set; }
        public virtual DbSet<MasterRole> MasterRoles { get; set; }
        public virtual DbSet<Master> Masters { get; set; }
        public virtual DbSet<Role> Roles { get; set; }
        public virtual DbSet<Semester> Semesters { get; set; }
        public virtual DbSet<Student> Students { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Coordinator>()
                .Property(e => e.UserName)
                .IsUnicode(false);

            modelBuilder.Entity<Coordinator>()
                .Property(e => e.Pass)
                .IsUnicode(false);

            modelBuilder.Entity<Coordinator>()
                .Property(e => e.FullName)
                .IsUnicode(false);

            modelBuilder.Entity<Coordinator>()
                .Property(e => e.Email)
                .IsUnicode(false);

            modelBuilder.Entity<Cours>()
                .Property(e => e.Name)
                .IsUnicode(false);

            modelBuilder.Entity<Cours>()
                .HasMany(e => e.Coordinators)
                .WithOptional(e => e.Cours)
                .HasForeignKey(e => e.CourseId);

            modelBuilder.Entity<Magazine>()
                .Property(e => e.Url)
                .IsUnicode(false);

            modelBuilder.Entity<Magazine>()
                .Property(e => e.Comment)
                .IsUnicode(false);

            modelBuilder.Entity<Master>()
                .Property(e => e.UserName)
                .IsUnicode(false);

            modelBuilder.Entity<Master>()
                .Property(e => e.Pass)
                .IsUnicode(false);

            modelBuilder.Entity<Role>()
                .Property(e => e.Name)
                .IsUnicode(false);

            modelBuilder.Entity<Semester>()
                .Property(e => e.Name)
                .IsUnicode(false);

            modelBuilder.Entity<Student>()
                .Property(e => e.UserName)
                .IsUnicode(false);

            modelBuilder.Entity<Student>()
                .Property(e => e.Pass)
                .IsUnicode(false);

            modelBuilder.Entity<Student>()
                .Property(e => e.FullName)
                .IsUnicode(false);

            modelBuilder.Entity<Student>()
                .Property(e => e.ImgUrl)
                .IsUnicode(false);
        }
    }
}
