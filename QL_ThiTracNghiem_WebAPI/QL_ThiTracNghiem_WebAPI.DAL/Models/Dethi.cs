using System;
using System.Collections.Generic;

namespace QL_ThiTracNghiem_WebAPI.DAL.Models;

public partial class Dethi
{
    public int Madethi { get; set; }

    public string? Mahocphan { get; set; }

    public DateOnly? Ngaytao { get; set; }

    public int? Tglambai { get; set; }

    public int? Slcauhoi { get; set; }

    public bool? Tinhtrang { get; set; }

    public virtual ICollection<Cathi> Cathis { get; set; } = new List<Cathi>();

    public virtual ICollection<CtDethi> CtDethis { get; set; } = new List<CtDethi>();

    public virtual Hocphan? MahocphanNavigation { get; set; }
}
