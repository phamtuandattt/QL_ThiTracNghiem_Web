using System;
using System.Collections.Generic;

namespace QL_ThiTracNghiem_WebAPI.DAL.Models;

public partial class Lophoc
{
    public string Malop { get; set; } = null!;

    public string? Tenlop { get; set; }

    public int? Siso { get; set; }

    public string? Makhoa { get; set; }

    public virtual Khoa? MakhoaNavigation { get; set; }

    public virtual ICollection<Sinhvien> Sinhviens { get; set; } = new List<Sinhvien>();
}
