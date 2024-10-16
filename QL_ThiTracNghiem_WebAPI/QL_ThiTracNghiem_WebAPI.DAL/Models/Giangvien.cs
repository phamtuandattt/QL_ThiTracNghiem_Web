using System;
using System.Collections.Generic;

namespace QL_ThiTracNghiem_WebAPI.DAL.Models;

public partial class Giangvien
{
    public string Magv { get; set; } = null!;

    public string? Matkhau { get; set; }

    public string? Tengv { get; set; }

    public DateTime? Ngaysinh { get; set; }

    public string? Gioitinh { get; set; }

    public string? Quequan { get; set; }

    public string? Hocvi { get; set; }

    public string? Sdt { get; set; }

    public string? Email { get; set; }

    public string? Diachi { get; set; }

    public byte[]? Avata { get; set; }

    public string? Makhoa { get; set; }

    public int? Machucvu { get; set; }

    public virtual ICollection<CtNganhangcauhoi> CtNganhangcauhois { get; set; } = new List<CtNganhangcauhoi>();

    public virtual Chucvu? MachucvuNavigation { get; set; }

    public virtual Khoa? MakhoaNavigation { get; set; }

    public virtual ICollection<Hocphan> Mahocphans { get; set; } = new List<Hocphan>();
}
