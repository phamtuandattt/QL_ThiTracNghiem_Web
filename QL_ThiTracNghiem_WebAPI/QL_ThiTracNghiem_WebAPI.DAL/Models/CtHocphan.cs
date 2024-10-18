using System;
using System.Collections.Generic;

namespace QL_ThiTracNghiem_WebAPI.DAL.Models;

public partial class CtHocphan
{
    public string Malophocphan { get; set; } = null!;

    public string Masv { get; set; } = null!;

    public string Mahocphan { get; set; } = null!;

    public string? Magv { get; set; }

    public int? Thu { get; set; }

    public string? Tiet { get; set; }

    public string? Phong { get; set; }

    public DateTime? Ngaybd { get; set; }

    public DateTime? Ngaykt { get; set; }

    public virtual Hocphan MahocphanNavigation { get; set; } = null!;

    public virtual Sinhvien MasvNavigation { get; set; } = null!;
}
