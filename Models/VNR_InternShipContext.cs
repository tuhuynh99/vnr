using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace fourth.Models
{
    public partial class VNR_InternShipContext : DbContext
    {
        public VNR_InternShipContext(DbContextOptions<VNR_InternShipContext> options)
            : base(options)
        {
        }

        public virtual DbSet<KhoaHoc> KhoaHocs { get; set; } = null!;
        public virtual DbSet<MonHoc> MonHocs { get; set; } = null!;


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<KhoaHoc>(entity =>
            {
                entity.ToTable("KhoaHoc");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.TenKhoaHoc).HasMaxLength(30);
            });

            modelBuilder.Entity<MonHoc>(entity =>
            {
                entity.ToTable("MonHoc");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.KhoaHocId).HasColumnName("KhoaHocID");

                entity.Property(e => e.MoTa).HasMaxLength(100);

                entity.Property(e => e.TenMonHoc).HasMaxLength(100);

                entity.HasOne(d => d.KhoaHoc)
                    .WithMany(p => p.MonHocs)
                    .HasForeignKey(d => d.KhoaHocId)
                    .HasConstraintName("FK_dbo.BaiHat_dbo.TheLoai_TheLoaiID");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
