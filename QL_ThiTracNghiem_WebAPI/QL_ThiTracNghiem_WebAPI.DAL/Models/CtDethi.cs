using System;
using System.Collections.Generic;

namespace QL_ThiTracNghiem_WebAPI.DAL.Models;

public partial class CtDethi
{
    public int Stt { get; set; }

    public int? Madethi { get; set; }

    public string? Madecon { get; set; }

    public int? Macauhoi { get; set; }

    public virtual Cauhoi? MacauhoiNavigation { get; set; }

    public virtual Dethi? MadethiNavigation { get; set; }
}
