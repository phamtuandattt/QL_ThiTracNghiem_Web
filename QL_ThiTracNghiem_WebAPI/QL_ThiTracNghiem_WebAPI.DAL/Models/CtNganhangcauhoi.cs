using System;
using System.Collections.Generic;

namespace QL_ThiTracNghiem_WebAPI.DAL.Models;

public partial class CtNganhangcauhoi
{
    public int Manganhang { get; set; }

    public string Magv { get; set; } = null!;

    public string Mahocphan { get; set; } = null!;

    public virtual Giangvien MagvNavigation { get; set; } = null!;

    public virtual Hocphan MahocphanNavigation { get; set; } = null!;

    public virtual Nganhangcauhoi ManganhangNavigation { get; set; } = null!;
}
