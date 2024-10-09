using System;
using System.Collections.Generic;

namespace QL_ThiTracNghiem_WebAPI.DAL.Models;

public partial class Cathi
{
    public int Macathi { get; set; }

    public string? Mahocphan { get; set; }

    public int? Madethi { get; set; }

    public string? Madecon { get; set; }

    public DateOnly? Ngaythi { get; set; }

    public string? Phongthi { get; set; }

    public string? Giolambai { get; set; }

    public bool? Tinhtrang { get; set; }

    public bool? Tinhtrangthi { get; set; }

    public virtual ICollection<CtCathi> CtCathis { get; set; } = new List<CtCathi>();

    public virtual Dethi? MadethiNavigation { get; set; }

    public virtual Hocphan? MahocphanNavigation { get; set; }
}
