using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace app.Models
{
    public partial class dataContext : DbContext
    {
        public dataContext()
        {
        }

        public dataContext(DbContextOptions<dataContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Personer> Personer { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                //This connection string should be moved out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263
                //optionsBuilder.UseSqlServer("Server=localhost,1433;Database=data;User Id=sa;Password=Password88");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Personer>(entity =>
            {
                entity.ToTable("personer");

                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .ValueGeneratedNever();
                    //.ValueGeneratedOnAdd();

                entity.Property(e => e.Adresse)
                    .HasColumnName("adresse")
                    .HasColumnType("varchar(50)");

                entity.Property(e => e.Adresse2)
                    .HasColumnName("adresse2")
                    .HasColumnType("varchar(50)");

                entity.Property(e => e.By)
                    .HasColumnName("by")
                    .HasColumnType("varchar(50)");

                entity.Property(e => e.Efternavn)
                    .HasColumnName("efternavn")
                    .HasColumnType("varchar(50)");

                entity.Property(e => e.Fornavn)
                    .HasColumnName("fornavn")
                    .HasColumnType("varchar(50)");

                entity.Property(e => e.Postnr).HasColumnName("postnr");

                entity.Property(e => e.Telefonnr).HasColumnName("telefonnr");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
