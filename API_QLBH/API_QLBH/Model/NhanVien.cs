namespace API_QLBH.Model
{
    public class NhanVien
    {
        public string MaNV { get; set; }
        public string HoTenNV { get; set; }
        public string GioiTinh { get; set; }
        public DateTime NgaySinh { get; set; }
        public DateTime NgayVaoLam { get; set; }
        public string DienThoai { get; set; }
        public string Email { get; set; }
        public string DiaChi { get; set; }
        public int? MaTK { get; set; }
        public string? HinhAnh { get; set; }
    }
}
