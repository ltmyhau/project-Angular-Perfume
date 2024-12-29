using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GoodCharmePerfume.DTO
{
    public class CustomerDTO
    {
        private string maKH;
        private string hoTenKH;
        private string gioiTinh;
        private DateTime ngaySinh;
        private string dienThoai;
        private string email;
        private string diaChi;
        private string phuong;
        private string quan;
        private string thanhPho;
        private string maTK;
        private byte[] hinhAnh;

        public string MaKH { get => maKH; set => maKH = value; }
        public string HoTenKH { get => hoTenKH; set => hoTenKH = value; }
        public string GioiTinh { get => gioiTinh; set => gioiTinh = value; }
        public DateTime NgaySinh { get => ngaySinh; set => ngaySinh = value; }
        public string DienThoai { get => dienThoai; set => dienThoai = value; }
        public string Email { get => email; set => email = value; }
        public string DiaChi { get => diaChi; set => diaChi = value; }
        public string Phuong { get => phuong; set => phuong = value; }
        public string Quan { get => quan; set => quan = value; }
        public string ThanhPho { get => thanhPho; set => thanhPho = value; }
        public string MaTK { get => maTK; set => maTK = value; }
        public byte[] HinhAnh { get => hinhAnh; set => hinhAnh = value; }

        public CustomerDTO(string maKH, string hoTenKH, string gioiTinh, DateTime ngaySinh, string dienThoai, string email, string diaChi, string phuong, string quan, string thanhPho, string maTK, byte[] hinhAnh)
        {
            this.maKH = maKH;
            this.hoTenKH = hoTenKH;
            this.gioiTinh = gioiTinh;
            this.ngaySinh = ngaySinh;
            this.dienThoai = dienThoai;
            this.email = email;
            this.diaChi = diaChi;
            this.phuong = phuong;
            this.quan = quan;
            this.thanhPho = thanhPho;
            this.maTK = maTK;
            this.hinhAnh = hinhAnh;
        }

        public CustomerDTO(DataRow row)
        {
            this.maKH = row["maKH"].ToString();
            this.hoTenKH = row["hoTenKH"].ToString();
            this.gioiTinh = row["gioiTinh"] != DBNull.Value ? row["gioiTinh"].ToString() : null;
            this.ngaySinh = row["ngaySinh"] != DBNull.Value ? Convert.ToDateTime(row["ngaySinh"]) : DateTime.MinValue;
            this.dienThoai = row["dienThoai"].ToString();
            this.email = row["email"] != DBNull.Value ? row["email"].ToString() : null;
            this.diaChi = row["diaChi"] != DBNull.Value ? row["diaChi"].ToString() : null;
            this.phuong = row["phuong"] != DBNull.Value ? row["phuong"].ToString() : null;
            this.quan = row["quan"] != DBNull.Value ? row["quan"].ToString() : null;
            this.thanhPho = row["thanhPho"] != DBNull.Value ? row["thanhPho"].ToString() : null;
            this.maTK = row["maTK"] != DBNull.Value ? row["maTK"].ToString() : null;
            this.hinhAnh = row["hinhAnh"] as byte[];
        }
    }
}
