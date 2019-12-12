namespace Student.DAL.Entity
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class StudentDataModel1 : DbContext
    {
        public StudentDataModel1()
            : base("name=StudentDataModel1")
        {
        }

        public virtual DbSet<Major> Major { get; set; }
        public virtual DbSet<Position> Position { get; set; }
        public virtual DbSet<Record> Record { get; set; }
        public virtual DbSet<StudentInfo> StudentInfo { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Major>()
                .Property(e => e.MajorName)
                .IsUnicode(false);

            modelBuilder.Entity<Position>()
                .Property(e => e.PName)
                .IsUnicode(false);

            modelBuilder.Entity<Record>()
                .Property(e => e.RecordPassword)
                .IsUnicode(false);

            modelBuilder.Entity<StudentInfo>()
                .Property(e => e.StudentName)
                .IsUnicode(false);

            modelBuilder.Entity<StudentInfo>()
                .Property(e => e.StudentSex)
                .IsUnicode(false);

            modelBuilder.Entity<StudentInfo>()
                .Property(e => e.StudentPhone)
                .IsUnicode(false);

            //modelBuilder.Entity<StudentInfo>()
            //    .HasMany(e => e.Record)
            //    .WithRequired(e => e.StudentInfo)
            //    .WillCascadeOnDelete(false);
        }
    }
}
