using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace QL_ThiTracNghiem_WebAPI.DAL.Models;

public partial class QlHethongthitracnghiemContext : DbContext
{
    public QlHethongthitracnghiemContext()
    {
    }

    public QlHethongthitracnghiemContext(DbContextOptions<QlHethongthitracnghiemContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Baithi> Baithis { get; set; }

    public virtual DbSet<Cathi> Cathis { get; set; }

    public virtual DbSet<Cauhoi> Cauhois { get; set; }

    public virtual DbSet<Chucvu> Chucvus { get; set; }

    public virtual DbSet<CtBaithi> CtBaithis { get; set; }

    public virtual DbSet<CtCathi> CtCathis { get; set; }

    public virtual DbSet<CtDethi> CtDethis { get; set; }

    public virtual DbSet<CtHocphan> CtHocphans { get; set; }

    public virtual DbSet<CtNganhangcauhoi> CtNganhangcauhois { get; set; }

    public virtual DbSet<Dethi> Dethis { get; set; }

    public virtual DbSet<Giangvien> Giangviens { get; set; }

    public virtual DbSet<Hocphan> Hocphans { get; set; }

    public virtual DbSet<Khoa> Khoas { get; set; }

    public virtual DbSet<Lophoc> Lophocs { get; set; }

    public virtual DbSet<Nganhangcauhoi> Nganhangcauhois { get; set; }

    public virtual DbSet<NganhangcauhoiDaduyet> NganhangcauhoiDaduyets { get; set; }

    public virtual DbSet<Sinhvien> Sinhviens { get; set; }

//    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
//#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
//        => optionsBuilder.UseSqlServer("server=DESKTOP-KD2BPDJ;database=QL_HETHONGTHITRACNGHIEM;Integrated Security = true;uid=sa;pwd=Aa123456@;TrustServerCertificate=True;MultipleActiveResultSets=true");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Baithi>(entity =>
        {
            entity.HasKey(e => e.Mabaithi);

            entity.ToTable("BAITHI");

            entity.Property(e => e.Mabaithi).HasColumnName("MABAITHI");
            entity.Property(e => e.Diem).HasColumnName("DIEM");
            entity.Property(e => e.Gionopbai)
                .HasMaxLength(50)
                .HasColumnName("GIONOPBAI");
            entity.Property(e => e.Macathi).HasColumnName("MACATHI");
            entity.Property(e => e.Masv)
                .HasMaxLength(10)
                .IsUnicode(false)
                .IsFixedLength()
                .HasColumnName("MASV");
            entity.Property(e => e.Tinhtrang)
                .HasMaxLength(20)
                .HasColumnName("TINHTRANG");
        });

        modelBuilder.Entity<Cathi>(entity =>
        {
            entity.HasKey(e => e.Macathi);

            entity.ToTable("CATHI");

            entity.Property(e => e.Macathi).HasColumnName("MACATHI");
            entity.Property(e => e.Giolambai)
                .HasMaxLength(10)
                .HasColumnName("GIOLAMBAI");
            entity.Property(e => e.Madecon)
                .HasMaxLength(10)
                .HasColumnName("MADECON");
            entity.Property(e => e.Madethi).HasColumnName("MADETHI");
            entity.Property(e => e.Mahocphan)
                .HasMaxLength(10)
                .IsUnicode(false)
                .IsFixedLength()
                .HasColumnName("MAHOCPHAN");
            entity.Property(e => e.Ngaythi).HasColumnName("NGAYTHI");
            entity.Property(e => e.Phongthi)
                .HasMaxLength(20)
                .HasColumnName("PHONGTHI");
            entity.Property(e => e.Tinhtrang).HasColumnName("TINHTRANG");
            entity.Property(e => e.Tinhtrangthi).HasColumnName("TINHTRANGTHI");

            entity.HasOne(d => d.MadethiNavigation).WithMany(p => p.Cathis)
                .HasForeignKey(d => d.Madethi)
                .HasConstraintName("FK_CATHI_DETHI");

            entity.HasOne(d => d.MahocphanNavigation).WithMany(p => p.Cathis)
                .HasForeignKey(d => d.Mahocphan)
                .HasConstraintName("FK_CATHI_HOCPHAN");
        });

        modelBuilder.Entity<Cauhoi>(entity =>
        {
            entity.HasKey(e => e.Macauhoi);

            entity.ToTable("CAUHOI");

            entity.Property(e => e.Macauhoi).HasColumnName("MACAUHOI");
            entity.Property(e => e.Dapan1).HasColumnName("DAPAN1");
            entity.Property(e => e.Dapan2).HasColumnName("DAPAN2");
            entity.Property(e => e.Dapan3).HasColumnName("DAPAN3");
            entity.Property(e => e.Dapan4).HasColumnName("DAPAN4");
            entity.Property(e => e.Dapandung)
                .HasMaxLength(5)
                .IsUnicode(false)
                .IsFixedLength()
                .HasColumnName("DAPANDUNG");
            entity.Property(e => e.Mahocphan)
                .HasMaxLength(10)
                .IsUnicode(false)
                .IsFixedLength()
                .HasColumnName("MAHOCPHAN");
            entity.Property(e => e.Manganhang).HasColumnName("MANGANHANG");
            entity.Property(e => e.Ngaycapnhat).HasColumnName("NGAYCAPNHAT");
            entity.Property(e => e.Ngaytao).HasColumnName("NGAYTAO");
            entity.Property(e => e.Noidung).HasColumnName("NOIDUNG");

            entity.HasOne(d => d.MahocphanNavigation).WithMany(p => p.Cauhois)
                .HasForeignKey(d => d.Mahocphan)
                .HasConstraintName("FK_CAUHOI_MAHOCPHAN");

            entity.HasOne(d => d.ManganhangNavigation).WithMany(p => p.Cauhois)
                .HasForeignKey(d => d.Manganhang)
                .HasConstraintName("FK_CAUHOI_NGANHANGCAUHOI");
        });

        modelBuilder.Entity<Chucvu>(entity =>
        {
            entity.HasKey(e => e.Machucvu);

            entity.ToTable("CHUCVU");

            entity.Property(e => e.Machucvu).HasColumnName("MACHUCVU");
            entity.Property(e => e.Tenchucvu)
                .HasMaxLength(100)
                .HasColumnName("TENCHUCVU");
        });

        modelBuilder.Entity<CtBaithi>(entity =>
        {
            entity.HasKey(e => new { e.Mabaithi, e.Macauhoi });

            entity.ToTable("CT_BAITHI");

            entity.Property(e => e.Mabaithi).HasColumnName("MABAITHI");
            entity.Property(e => e.Macauhoi).HasColumnName("MACAUHOI");
            entity.Property(e => e.Cautraloi)
                .HasMaxLength(5)
                .IsUnicode(false)
                .IsFixedLength()
                .HasColumnName("CAUTRALOI");
        });

        modelBuilder.Entity<CtCathi>(entity =>
        {
            entity.HasKey(e => new { e.Macathi, e.Masv });

            entity.ToTable("CT_CATHI");

            entity.Property(e => e.Macathi).HasColumnName("MACATHI");
            entity.Property(e => e.Masv)
                .HasMaxLength(10)
                .IsUnicode(false)
                .IsFixedLength()
                .HasColumnName("MASV");
            entity.Property(e => e.Tensv).HasColumnName("TENSV");

            entity.HasOne(d => d.MacathiNavigation).WithMany(p => p.CtCathis)
                .HasForeignKey(d => d.Macathi)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_CT_CATHI_CATHI");

            entity.HasOne(d => d.MasvNavigation).WithMany(p => p.CtCathis)
                .HasForeignKey(d => d.Masv)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_CT_CATHI_SINHVIEN");
        });

        modelBuilder.Entity<CtDethi>(entity =>
        {
            entity.HasKey(e => e.Stt);

            entity.ToTable("CT_DETHI");

            entity.Property(e => e.Stt).HasColumnName("STT");
            entity.Property(e => e.Macauhoi).HasColumnName("MACAUHOI");
            entity.Property(e => e.Madecon)
                .HasMaxLength(10)
                .IsUnicode(false)
                .IsFixedLength()
                .HasColumnName("MADECON");
            entity.Property(e => e.Madethi).HasColumnName("MADETHI");

            entity.HasOne(d => d.MacauhoiNavigation).WithMany(p => p.CtDethis)
                .HasForeignKey(d => d.Macauhoi)
                .HasConstraintName("FK_CT_DETHI_CAUHOI");

            entity.HasOne(d => d.MadethiNavigation).WithMany(p => p.CtDethis)
                .HasForeignKey(d => d.Madethi)
                .HasConstraintName("FK_CT_DETHI_DETHI");
        });

        modelBuilder.Entity<CtHocphan>(entity =>
        {
            entity.HasKey(e => new { e.Malophocphan, e.Masv, e.Mahocphan });

            entity.ToTable("CT_HOCPHAN");

            entity.Property(e => e.Malophocphan)
                .HasMaxLength(12)
                .IsUnicode(false)
                .IsFixedLength()
                .HasColumnName("MALOPHOCPHAN");
            entity.Property(e => e.Masv)
                .HasMaxLength(10)
                .IsUnicode(false)
                .IsFixedLength()
                .HasColumnName("MASV");
            entity.Property(e => e.Mahocphan)
                .HasMaxLength(10)
                .IsUnicode(false)
                .IsFixedLength()
                .HasColumnName("MAHOCPHAN");
            entity.Property(e => e.Magv)
                .HasMaxLength(10)
                .IsUnicode(false)
                .IsFixedLength()
                .HasColumnName("MAGV");
            entity.Property(e => e.Ngaybd).HasColumnName("NGAYBD");
            entity.Property(e => e.Ngaykt).HasColumnName("NGAYKT");
            entity.Property(e => e.Phong)
                .HasMaxLength(10)
                .IsUnicode(false)
                .IsFixedLength()
                .HasColumnName("PHONG");
            entity.Property(e => e.Thu).HasColumnName("THU");
            entity.Property(e => e.Tiet)
                .HasMaxLength(10)
                .IsUnicode(false)
                .IsFixedLength()
                .HasColumnName("TIET");

            entity.HasOne(d => d.MahocphanNavigation).WithMany(p => p.CtHocphans)
                .HasForeignKey(d => d.Mahocphan)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_CT_HOCPHAN_HOCPHAN");

            entity.HasOne(d => d.MasvNavigation).WithMany(p => p.CtHocphans)
                .HasForeignKey(d => d.Masv)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_CT_HOCPHAN_SINHVIEN");
        });

        modelBuilder.Entity<CtNganhangcauhoi>(entity =>
        {
            entity.HasKey(e => new { e.Manganhang, e.Magv, e.Mahocphan });

            entity.ToTable("CT_NGANHANGCAUHOI");

            entity.Property(e => e.Manganhang).HasColumnName("MANGANHANG");
            entity.Property(e => e.Magv)
                .HasMaxLength(10)
                .IsUnicode(false)
                .IsFixedLength()
                .HasColumnName("MAGV");
            entity.Property(e => e.Mahocphan)
                .HasMaxLength(10)
                .IsUnicode(false)
                .IsFixedLength()
                .HasColumnName("MAHOCPHAN");

            entity.HasOne(d => d.MagvNavigation).WithMany(p => p.CtNganhangcauhois)
                .HasForeignKey(d => d.Magv)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_NGANHANGCAUHOI_GIANGVIEN");

            entity.HasOne(d => d.MahocphanNavigation).WithMany(p => p.CtNganhangcauhois)
                .HasForeignKey(d => d.Mahocphan)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_NGANHANGCAUHOI_HOCPHAN");

            entity.HasOne(d => d.ManganhangNavigation).WithMany(p => p.CtNganhangcauhois)
                .HasForeignKey(d => d.Manganhang)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_NGANHANGCAUHOI_NGANHANGCAUHOI");
        });

        modelBuilder.Entity<Dethi>(entity =>
        {
            entity.HasKey(e => e.Madethi);

            entity.ToTable("DETHI");

            entity.Property(e => e.Madethi).HasColumnName("MADETHI");
            entity.Property(e => e.Mahocphan)
                .HasMaxLength(10)
                .IsUnicode(false)
                .IsFixedLength()
                .HasColumnName("MAHOCPHAN");
            entity.Property(e => e.Ngaytao).HasColumnName("NGAYTAO");
            entity.Property(e => e.Slcauhoi).HasColumnName("SLCAUHOI");
            entity.Property(e => e.Tglambai).HasColumnName("TGLAMBAI");
            entity.Property(e => e.Tinhtrang).HasColumnName("TINHTRANG");

            entity.HasOne(d => d.MahocphanNavigation).WithMany(p => p.Dethis)
                .HasForeignKey(d => d.Mahocphan)
                .HasConstraintName("FK_DETHI_HOCPHAN");
        });

        modelBuilder.Entity<Giangvien>(entity =>
        {
            entity.HasKey(e => e.Magv);

            entity.ToTable("GIANGVIEN");

            entity.Property(e => e.Magv)
                .HasMaxLength(10)
                .IsUnicode(false)
                .IsFixedLength()
                .HasColumnName("MAGV");
            entity.Property(e => e.Avata)
                .HasColumnType("image")
                .HasColumnName("AVATA");
            entity.Property(e => e.Diachi)
                .HasMaxLength(100)
                .HasColumnName("DIACHI");
            entity.Property(e => e.Email)
                .HasMaxLength(100)
                .HasColumnName("EMAIL");
            entity.Property(e => e.Gioitinh)
                .HasMaxLength(5)
                .HasColumnName("GIOITINH");
            entity.Property(e => e.Hocvi)
                .HasMaxLength(50)
                .HasColumnName("HOCVI");
            entity.Property(e => e.Machucvu).HasColumnName("MACHUCVU");
            entity.Property(e => e.Makhoa)
                .HasMaxLength(2)
                .IsUnicode(false)
                .IsFixedLength()
                .HasColumnName("MAKHOA");
            entity.Property(e => e.Matkhau)
                .HasMaxLength(20)
                .IsUnicode(false)
                .IsFixedLength()
                .HasColumnName("MATKHAU");
            entity.Property(e => e.Ngaysinh).HasColumnName("NGAYSINH");
            entity.Property(e => e.Quequan)
                .HasMaxLength(20)
                .HasColumnName("QUEQUAN");
            entity.Property(e => e.Sdt)
                .HasMaxLength(10)
                .IsUnicode(false)
                .IsFixedLength()
                .HasColumnName("SDT");
            entity.Property(e => e.Tengv)
                .HasMaxLength(50)
                .HasColumnName("TENGV");

            entity.HasOne(d => d.MachucvuNavigation).WithMany(p => p.Giangviens)
                .HasForeignKey(d => d.Machucvu)
                .HasConstraintName("FK_GIANGVIEN_CHUCVU");

            entity.HasOne(d => d.MakhoaNavigation).WithMany(p => p.Giangviens)
                .HasForeignKey(d => d.Makhoa)
                .HasConstraintName("FK_GIANGVIEN_KHOA");
        });

        modelBuilder.Entity<Hocphan>(entity =>
        {
            entity.HasKey(e => e.Mahocphan);

            entity.ToTable("HOCPHAN");

            entity.Property(e => e.Mahocphan)
                .HasMaxLength(10)
                .IsUnicode(false)
                .IsFixedLength()
                .HasColumnName("MAHOCPHAN");
            entity.Property(e => e.Makhoa)
                .HasMaxLength(2)
                .IsUnicode(false)
                .IsFixedLength()
                .HasColumnName("MAKHOA");
            entity.Property(e => e.Sotc).HasColumnName("SOTC");
            entity.Property(e => e.SotietLt).HasColumnName("SOTIET_LT");
            entity.Property(e => e.SotietTh).HasColumnName("SOTIET_TH");
            entity.Property(e => e.Tenhocphan)
                .HasMaxLength(100)
                .HasColumnName("TENHOCPHAN");

            entity.HasOne(d => d.MakhoaNavigation).WithMany(p => p.Hocphans)
                .HasForeignKey(d => d.Makhoa)
                .HasConstraintName("FK_HOCPHAN_KHOA");

            entity.HasMany(d => d.Magvs).WithMany(p => p.Mahocphans)
                .UsingEntity<Dictionary<string, object>>(
                    "CtGiangday",
                    r => r.HasOne<Giangvien>().WithMany()
                        .HasForeignKey("Magv")
                        .OnDelete(DeleteBehavior.ClientSetNull)
                        .HasConstraintName("FK_CT_GIANGDAY_GIANGVIEN"),
                    l => l.HasOne<Hocphan>().WithMany()
                        .HasForeignKey("Mahocphan")
                        .OnDelete(DeleteBehavior.ClientSetNull)
                        .HasConstraintName("FK_CT_GIANGDAY_HOCPHAN"),
                    j =>
                    {
                        j.HasKey("Mahocphan", "Magv");
                        j.ToTable("CT_GIANGDAY");
                        j.IndexerProperty<string>("Mahocphan")
                            .HasMaxLength(10)
                            .IsUnicode(false)
                            .IsFixedLength()
                            .HasColumnName("MAHOCPHAN");
                        j.IndexerProperty<string>("Magv")
                            .HasMaxLength(10)
                            .IsUnicode(false)
                            .IsFixedLength()
                            .HasColumnName("MAGV");
                    });
        });

        modelBuilder.Entity<Khoa>(entity =>
        {
            entity.HasKey(e => e.Makhoa).HasName("PK__KHOA__22F41770B8494882");

            entity.ToTable("KHOA");

            entity.Property(e => e.Makhoa)
                .HasMaxLength(2)
                .IsUnicode(false)
                .HasDefaultValueSql("([DBO].[AUTO__MAKHOA]())")
                .IsFixedLength()
                .HasColumnName("MAKHOA");
            entity.Property(e => e.Soluonggiangvien).HasColumnName("SOLUONGGIANGVIEN");
            entity.Property(e => e.Soluongmonhoc).HasColumnName("SOLUONGMONHOC");
            entity.Property(e => e.Songanhdaotao).HasColumnName("SONGANHDAOTAO");
            entity.Property(e => e.Tenkhoa)
                .HasMaxLength(100)
                .HasColumnName("TENKHOA");
        });

        modelBuilder.Entity<Lophoc>(entity =>
        {
            entity.HasKey(e => e.Malop);

            entity.ToTable("LOPHOC");

            entity.Property(e => e.Malop)
                .HasMaxLength(10)
                .IsUnicode(false)
                .IsFixedLength()
                .HasColumnName("MALOP");
            entity.Property(e => e.Makhoa)
                .HasMaxLength(2)
                .IsUnicode(false)
                .IsFixedLength()
                .HasColumnName("MAKHOA");
            entity.Property(e => e.Siso).HasColumnName("SISO");
            entity.Property(e => e.Tenlop)
                .HasMaxLength(50)
                .HasColumnName("TENLOP");

            entity.HasOne(d => d.MakhoaNavigation).WithMany(p => p.Lophocs)
                .HasForeignKey(d => d.Makhoa)
                .HasConstraintName("FK_LOPHOC_KHOA");
        });

        modelBuilder.Entity<Nganhangcauhoi>(entity =>
        {
            entity.HasKey(e => e.Manganhang);

            entity.ToTable("NGANHANGCAUHOI");

            entity.Property(e => e.Manganhang).HasColumnName("MANGANHANG");
            entity.Property(e => e.Ngaycapnhat).HasColumnName("NGAYCAPNHAT");
            entity.Property(e => e.Ngaytao).HasColumnName("NGAYTAO");
            entity.Property(e => e.Slcauhoi).HasColumnName("SLCAUHOI");
        });

        modelBuilder.Entity<NganhangcauhoiDaduyet>(entity =>
        {
            entity.HasKey(e => new { e.Manh, e.Mahocphan, e.Macauhoi });

            entity.ToTable("NGANHANGCAUHOI_DADUYET");

            entity.Property(e => e.Manh)
                .HasMaxLength(10)
                .IsUnicode(false)
                .IsFixedLength()
                .HasColumnName("MANH");
            entity.Property(e => e.Mahocphan)
                .HasMaxLength(10)
                .IsUnicode(false)
                .IsFixedLength()
                .HasColumnName("MAHOCPHAN");
            entity.Property(e => e.Macauhoi).HasColumnName("MACAUHOI");

            entity.HasOne(d => d.MacauhoiNavigation).WithMany(p => p.NganhangcauhoiDaduyets)
                .HasForeignKey(d => d.Macauhoi)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_NGANHANGCAUHOI_DADUYET_CAUHOI");

            entity.HasOne(d => d.MahocphanNavigation).WithMany(p => p.NganhangcauhoiDaduyets)
                .HasForeignKey(d => d.Mahocphan)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_NGANHANGCAUHOI_DADUYET_HOCPHAN");
        });

        modelBuilder.Entity<Sinhvien>(entity =>
        {
            entity.HasKey(e => e.Masv);

            entity.ToTable("SINHVIEN");

            entity.Property(e => e.Masv)
                .HasMaxLength(10)
                .IsUnicode(false)
                .IsFixedLength()
                .HasColumnName("MASV");
            entity.Property(e => e.Diachi)
                .HasMaxLength(100)
                .HasColumnName("DIACHI");
            entity.Property(e => e.Email)
                .HasMaxLength(100)
                .HasColumnName("EMAIL");
            entity.Property(e => e.Gioitinh)
                .HasMaxLength(5)
                .HasColumnName("GIOITINH");
            entity.Property(e => e.Hocphi)
                .HasMaxLength(10)
                .HasColumnName("HOCPHI");
            entity.Property(e => e.Makhau)
                .HasMaxLength(20)
                .IsUnicode(false)
                .IsFixedLength()
                .HasColumnName("MAKHAU");
            entity.Property(e => e.Malop)
                .HasMaxLength(10)
                .IsUnicode(false)
                .IsFixedLength()
                .HasColumnName("MALOP");
            entity.Property(e => e.Ngaysinh).HasColumnName("NGAYSINH");
            entity.Property(e => e.Quequan)
                .HasMaxLength(100)
                .HasColumnName("QUEQUAN");
            entity.Property(e => e.Sdt)
                .HasMaxLength(10)
                .IsUnicode(false)
                .IsFixedLength()
                .HasColumnName("SDT");
            entity.Property(e => e.Tensv)
                .HasMaxLength(50)
                .HasColumnName("TENSV");

            entity.HasOne(d => d.MalopNavigation).WithMany(p => p.Sinhviens)
                .HasForeignKey(d => d.Malop)
                .HasConstraintName("FK_SINHVIEN_LOPHOC");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
