namespace QL_ThiTracNghiem_WebAPI.Models.RequestDto.LopHocRequestDto
{
    public class LopHocRequestDto
    {
        public string? MaLop { get; set; }
        public string? TenLop { get; set; }
        public int SiSo { get; set; } = 0;
        public string? MaKhoa { get; set; }
    }
}
