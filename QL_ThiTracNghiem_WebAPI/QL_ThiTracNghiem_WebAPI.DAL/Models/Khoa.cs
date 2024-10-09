using System;
using System.Collections.Generic;

namespace QL_ThiTracNghiem_WebAPI.DAL.Models;

public partial class Khoa
{
    public string Makhoa { get; set; } = null!;

    public string Tenkhoa { get; set; } = null!;

    public int? Soluonggiangvien { get; set; }

    public int? Soluongmonhoc { get; set; }

    public int? Songanhdaotao { get; set; }

    public virtual ICollection<Giangvien> Giangviens { get; set; } = new List<Giangvien>();

    public virtual ICollection<Hocphan> Hocphans { get; set; } = new List<Hocphan>();

    public virtual ICollection<Lophoc> Lophocs { get; set; } = new List<Lophoc>();
}
