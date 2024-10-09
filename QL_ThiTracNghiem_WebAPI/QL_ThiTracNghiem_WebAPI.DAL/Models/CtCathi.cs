using System;
using System.Collections.Generic;

namespace QL_ThiTracNghiem_WebAPI.DAL.Models;

public partial class CtCathi
{
    public int Macathi { get; set; }

    public string Masv { get; set; } = null!;

    public string? Tensv { get; set; }

    public virtual Cathi MacathiNavigation { get; set; } = null!;

    public virtual Sinhvien MasvNavigation { get; set; } = null!;
}
