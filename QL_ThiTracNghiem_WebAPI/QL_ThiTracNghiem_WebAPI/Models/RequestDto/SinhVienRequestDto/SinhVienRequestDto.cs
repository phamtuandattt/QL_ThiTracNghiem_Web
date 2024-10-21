namespace QL_ThiTracNghiem_WebAPI.Models.RequestDto.SinhVienRequestDto
{
    public class SinhVienRequestDto
    {
        public string? Masv { get; set; }

        public string? Makhau { get; set; }

        public string? Tensv { get; set; }

        public string? Gioitinh { get; set; }

        public DateTime? Ngaysinh { get; set; }

        public string? Email { get; set; }

        public string? Sdt { get; set; }

        public string? Diachi { get; set; }

        public string? Quequan { get; set; }

        public string? Malop { get; set; }

        public string? Hocphi { get; set; }

        public string? NganhDaoTao { get; set; } = "20";
        public string? MaKhoa { get; set; }
        public string? NamNhapHoc { get; set; }
    }
}
