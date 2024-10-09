using System;
using System.Collections.Generic;

namespace QL_ThiTracNghiem_WebAPI.DAL.Models;

public partial class Chucvu
{
    public int Machucvu { get; set; }

    public string? Tenchucvu { get; set; }

    public virtual ICollection<Giangvien> Giangviens { get; set; } = new List<Giangvien>();
}
