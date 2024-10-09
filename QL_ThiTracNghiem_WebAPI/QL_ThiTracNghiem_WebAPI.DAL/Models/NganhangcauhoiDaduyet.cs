using System;
using System.Collections.Generic;

namespace QL_ThiTracNghiem_WebAPI.DAL.Models;

public partial class NganhangcauhoiDaduyet
{
    public string Manh { get; set; } = null!;

    public string Mahocphan { get; set; } = null!;

    public int Macauhoi { get; set; }

    public virtual Cauhoi MacauhoiNavigation { get; set; } = null!;

    public virtual Hocphan MahocphanNavigation { get; set; } = null!;
}
