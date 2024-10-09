using System;
using System.Collections.Generic;

namespace QL_ThiTracNghiem_WebAPI.DAL.Models;

public partial class Nganhangcauhoi
{
    public int Manganhang { get; set; }

    public int? Slcauhoi { get; set; }

    public DateOnly? Ngaytao { get; set; }

    public DateOnly? Ngaycapnhat { get; set; }

    public virtual ICollection<Cauhoi> Cauhois { get; set; } = new List<Cauhoi>();

    public virtual ICollection<CtNganhangcauhoi> CtNganhangcauhois { get; set; } = new List<CtNganhangcauhoi>();
}
