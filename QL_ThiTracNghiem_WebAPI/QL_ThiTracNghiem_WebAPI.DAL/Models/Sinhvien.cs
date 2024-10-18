using System;
using System.Collections.Generic;

namespace QL_ThiTracNghiem_WebAPI.DAL.Models;

public partial class Sinhvien
{
    public string Masv { get; set; } = null!;

    public string? Makhau { get; set; }

    public string? Tensv { get; set; }

    public string? Gioitinh { get; set; }

    public DateTime? Ngaysinh { get; set; }

    public string? Email { get; set; }

    public string? Sdt { get; set; }

    public string? Diachi { get; set; }

    public string? Quequan { get; set; }

    public string? Malop { get; set; }

    public string? Hocphi { get; set; }

    public virtual ICollection<CtCathi> CtCathis { get; set; } = new List<CtCathi>();

    public virtual ICollection<CtHocphan> CtHocphans { get; set; } = new List<CtHocphan>();

    public virtual Lophoc? MalopNavigation { get; set; }
}
