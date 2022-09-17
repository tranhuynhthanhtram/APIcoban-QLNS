using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

#nullable disable

namespace QLNS.DAL.Models
{
    public partial class QLNSContext : DbContext
    {
        public QLNSContext()
        {
        }

        public QLNSContext(DbContextOptions<QLNSContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Chitiethoadon> Chitiethoadons { get; set; }
        public virtual DbSet<Hoadon> Hoadons { get; set; }
        public virtual DbSet<Loaisach> Loaisaches { get; set; }
        public virtual DbSet<Nhaxuatban> Nhaxuatbans { get; set; }
        public virtual DbSet<Sach> Saches { get; set; }
        public virtual DbSet<Tacgia> Tacgia { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("Data Source=DESKTOP-R0FKJA2\\SQLEXPRESS;Initial Catalog=QLNS;Integrated Security=True");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("Relational:Collation", "SQL_Latin1_General_CP1_CI_AS");

            modelBuilder.Entity<Chitiethoadon>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("CHITIETHOADON");

                entity.Property(e => e.Giatien).HasColumnName("GIATIEN");

                entity.Property(e => e.Mahoadon).HasColumnName("MAHOADON");

                entity.Property(e => e.Masach).HasColumnName("MASACH");

                entity.Property(e => e.Soluong).HasColumnName("SOLUONG");

                entity.Property(e => e.Thanhtien).HasColumnName("THANHTIEN");

                entity.HasOne(d => d.MahoadonNavigation)
                    .WithMany()
                    .HasForeignKey(d => d.Mahoadon)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_CHITIETHOADON_HOADON");

                entity.HasOne(d => d.MasachNavigation)
                    .WithMany()
                    .HasForeignKey(d => d.Masach)
                    .HasConstraintName("FK_CHITIETHOADON_SACH");
            });

            modelBuilder.Entity<Hoadon>(entity =>
            {
                entity.HasKey(e => e.Mahoadon)
                    .HasName("PK__HOADON__A4999DF5A1E5664E");

                entity.ToTable("HOADON");

                entity.Property(e => e.Mahoadon)
                    .ValueGeneratedNever()
                    .HasColumnName("MAHOADON");

                entity.Property(e => e.Ngaylap)
                    .HasColumnType("datetime")
                    .HasColumnName("NGAYLAP");

                entity.Property(e => e.Tenkhachhang)
                    .HasMaxLength(50)
                    .HasColumnName("TENKHACHHANG");

                entity.Property(e => e.Tongtien)
                    .HasColumnType("decimal(10, 2)")
                    .HasColumnName("TONGTIEN");
            });

            modelBuilder.Entity<Loaisach>(entity =>
            {
                entity.HasKey(e => e.Maloaisach)
                    .HasName("PK__LOAISACH__FDAD87DF38B3DD22");

                entity.ToTable("LOAISACH");

                entity.Property(e => e.Maloaisach)
                    .ValueGeneratedNever()
                    .HasColumnName("MALOAISACH");

                entity.Property(e => e.Tenloaisach)
                    .HasMaxLength(30)
                    .HasColumnName("TENLOAISACH");
            });

            modelBuilder.Entity<Nhaxuatban>(entity =>
            {
                entity.HasKey(e => e.Manhaxuatban)
                    .HasName("PK__NHAXUATB__78640139FA2E83FE");

                entity.ToTable("NHAXUATBAN");

                entity.Property(e => e.Manhaxuatban)
                    .ValueGeneratedNever()
                    .HasColumnName("MANHAXUATBAN");

                entity.Property(e => e.Tennhaxuatban)
                    .HasMaxLength(50)
                    .HasColumnName("TENNHAXUATBAN");
            });

            modelBuilder.Entity<Sach>(entity =>
            {
                entity.HasKey(e => e.Masach)
                    .HasName("PK__SACH__3FC48E4C65EC6A01");

                entity.ToTable("SACH");

                entity.Property(e => e.Masach)
                    .ValueGeneratedNever()
                    .HasColumnName("MASACH");

                entity.Property(e => e.Giamua).HasColumnName("GIAMUA");

                entity.Property(e => e.Maloaisach).HasColumnName("MALOAISACH");

                entity.Property(e => e.Manhaxuatban).HasColumnName("MANHAXUATBAN");

                entity.Property(e => e.Matg).HasColumnName("MATG");

                entity.Property(e => e.Namxuatban)
                    .HasColumnType("datetime")
                    .HasColumnName("NAMXUATBAN");

                entity.Property(e => e.Tensach)
                    .HasMaxLength(100)
                    .HasColumnName("TENSACH");

                entity.HasOne(d => d.MaloaisachNavigation)
                    .WithMany(p => p.Saches)
                    .HasForeignKey(d => d.Maloaisach)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_SACH_LOAISACH");

                entity.HasOne(d => d.ManhaxuatbanNavigation)
                    .WithMany(p => p.Saches)
                    .HasForeignKey(d => d.Manhaxuatban)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_SACH_NHAXUATBAN");

                entity.HasOne(d => d.MatgNavigation)
                    .WithMany(p => p.Saches)
                    .HasForeignKey(d => d.Matg)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_SACH_TACGIA");
            });

            modelBuilder.Entity<Tacgia>(entity =>
            {
                entity.HasKey(e => e.Matg)
                    .HasName("PK__TACGIA__6023721ABCA0D437");

                entity.ToTable("TACGIA");

                entity.Property(e => e.Matg)
                    .ValueGeneratedNever()
                    .HasColumnName("MATG");

                entity.Property(e => e.Nammat)
                    .HasColumnType("date")
                    .HasColumnName("NAMMAT");

                entity.Property(e => e.Namsinh)
                    .HasColumnType("date")
                    .HasColumnName("NAMSINH");

                entity.Property(e => e.Quequan)
                    .HasMaxLength(20)
                    .HasColumnName("QUEQUAN");

                entity.Property(e => e.Tentg)
                    .HasMaxLength(40)
                    .HasColumnName("TENTG");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
