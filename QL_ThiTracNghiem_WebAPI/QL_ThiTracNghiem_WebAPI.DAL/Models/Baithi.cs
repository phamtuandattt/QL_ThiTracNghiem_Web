using System;
using System.Collections.Generic;

namespace QL_ThiTracNghiem_WebAPI.DAL.Models;

public partial class Baithi
{
    public int Mabaithi { get; set; }

    public string? Gionopbai { get; set; }

    public int? Diem { get; set; }

    public string? Masv { get; set; }

    public string? Tinhtrang { get; set; }

    public int? Macathi { get; set; }
}
