using System;
using System.Collections.Generic;

namespace QL_ThiTracNghiem_WebAPI.DAL.Models;

public partial class Cauhoi
{
    public int Macauhoi { get; set; }

    public string? Noidung { get; set; }

    public string? Dapan1 { get; set; }

    public string? Dapan2 { get; set; }

    public string? Dapan3 { get; set; }

    public string? Dapan4 { get; set; }

    public string? Dapandung { get; set; }

    public DateOnly? Ngaytao { get; set; }

    public DateOnly? Ngaycapnhat { get; set; }

    public int? Manganhang { get; set; }

    public string? Mahocphan { get; set; }

    public virtual ICollection<CtDethi> CtDethis { get; set; } = new List<CtDethi>();

    public virtual Hocphan? MahocphanNavigation { get; set; }

    public virtual Nganhangcauhoi? ManganhangNavigation { get; set; }

    public virtual ICollection<NganhangcauhoiDaduyet> NganhangcauhoiDaduyets { get; set; } = new List<NganhangcauhoiDaduyet>();
}
