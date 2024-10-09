using System;
using System.Collections.Generic;

namespace QL_ThiTracNghiem_WebAPI.DAL.Models;

public partial class Hocphan
{
    public string Mahocphan { get; set; } = null!;

    public string? Tenhocphan { get; set; }

    public int? Sotc { get; set; }

    public int? SotietLt { get; set; }

    public int? SotietTh { get; set; }

    public string? Makhoa { get; set; }

    public virtual ICollection<Cathi> Cathis { get; set; } = new List<Cathi>();

    public virtual ICollection<Cauhoi> Cauhois { get; set; } = new List<Cauhoi>();

    public virtual ICollection<CtHocphan> CtHocphans { get; set; } = new List<CtHocphan>();

    public virtual ICollection<CtNganhangcauhoi> CtNganhangcauhois { get; set; } = new List<CtNganhangcauhoi>();

    public virtual ICollection<Dethi> Dethis { get; set; } = new List<Dethi>();

    public virtual Khoa? MakhoaNavigation { get; set; }

    public virtual ICollection<NganhangcauhoiDaduyet> NganhangcauhoiDaduyets { get; set; } = new List<NganhangcauhoiDaduyet>();

    public virtual ICollection<Giangvien> Magvs { get; set; } = new List<Giangvien>();
}
