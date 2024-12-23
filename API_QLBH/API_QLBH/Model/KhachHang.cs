﻿namespace API_QLBH.Model
{
    public class KhachHang
    {
        public string MaKH { get; set; }
        public string HoTenKH { get; set; }
        public string GioiTinh { get; set; }
        public DateTime NgaySinh { get; set; }
        public string DienThoai { get; set; }
        public string Email { get; set; }
        public string DiaChi { get; set; }
        public string Phuong { get; set; }
        public string Quan { get; set; }
        public string ThanhPho { get; set; }
        public int? MaTK { get; set; }
        public string? HinhAnh { get; set; }
    }

    public class KhachHangInfo
    {
        public string MaKH { get; set; }
        public string HoTenKH { get; set; }
        public string GioiTinh { get; set; }
        public DateTime NgaySinh { get; set; }
        public string DienThoai { get; set; }
        public string Email { get; set; }
        public string? HinhAnh { get; set; }
    }

    public class KhachHangAddress
    {
        public string MaKH { get; set; }
        public string HoTenKH { get; set; }
        public string DienThoai { get; set; }
        public string DiaChi { get; set; }
        public string Phuong { get; set; }
        public string Quan { get; set; }
        public string ThanhPho { get; set; }
    }
}
