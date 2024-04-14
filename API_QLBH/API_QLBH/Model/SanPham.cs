namespace API_QLBH.Model
{
    public class SanPham
    {
        public int MaSP { get; set; }
        public int MaLoaiSP { get; set; }
        public string TenLoaiSP { get; set; }
        public string TenSP { get; set; }
        public float GiaBan { get; set; }
        public int DungTich { get; set; }
        public string HinhSP { get; set; }
        public DateTime NgayThem { get; set; }
        public string MoTa { get; set; }
    }
}
