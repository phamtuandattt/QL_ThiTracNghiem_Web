namespace QL_ThiTracNghiem_WebAPI.Models.RequestDto.CT_HocPhanRequestDto
{
    public class CT_HocPhanRequestDto
    {
        public string Malophocphan { get; set; } = null!;

        public string Masv { get; set; } = null!;

        public string Mahocphan { get; set; } = null!;

        public string? Magv { get; set; }

        public int? Thu { get; set; }

        public string? Tiet { get; set; }

        public string? Phong { get; set; }

        public DateTime? Ngaybd { get; set; }

        public DateTime? Ngaykt { get; set; }
    }
}
