using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace GoodCharmePerfume.DTO
{
    public class EmployeeDTO
    {
        private string maNV;
        private string hoTenNV;
        private string gioiTinh;
        private DateTime ngaySinh;
        private DateTime ngayVaoLam;
        private string dienThoai;
        private string email;
        private string diaChi;
        private byte[] hinhAnh;
        private string maTK;

        public string MaNV { get => maNV; set => maNV = value; }
        public string HoTenNV { get => hoTenNV; set => hoTenNV = value; }
        public string GioiTinh { get => gioiTinh; set => gioiTinh = value; }
        public DateTime NgaySinh { get => ngaySinh; set => ngaySinh = value; }
        public DateTime NgayVaoLam { get => ngayVaoLam; set => ngayVaoLam = value; }
        public string DienThoai { get => dienThoai; set => dienThoai = value; }
        public string Email { get => email; set => email = value; }
        public string DiaChi { get => diaChi; set => diaChi = value; }
        public byte[] HinhAnh { get => hinhAnh; set => hinhAnh = value; }
        public string MaTK { get => maTK; set => maTK = value; }

        public EmployeeDTO(string maNV, string hoTenNV, string gioiTinh, DateTime ngaySinh, DateTime ngayVaoLam, string dienThoai, string email, string diaChi, byte[] hinhAnh, string maTK)
        {
            this.maNV = maNV;
            this.hoTenNV = hoTenNV;
            this.gioiTinh = gioiTinh;
            this.ngaySinh = ngaySinh;
            this.ngayVaoLam = ngayVaoLam;
            this.dienThoai = dienThoai;
            this.email = email;
            this.diaChi = diaChi;
            this.hinhAnh = hinhAnh;
            this.maTK = maTK;
        }

        public EmployeeDTO(DataRow row)
        {
            this.maNV = row["maNV"].ToString();
            this.hoTenNV = row["hoTenNV"] != DBNull.Value ? row["hoTenNV"].ToString() : null;
            this.gioiTinh = row["gioiTinh"] != DBNull.Value ? row["gioiTinh"].ToString() : null;
            this.ngaySinh = row["ngaySinh"] != DBNull.Value ? Convert.ToDateTime(row["ngaySinh"]) : DateTime.MinValue;
            this.ngayVaoLam = row["ngayVaoLam"] != DBNull.Value ? Convert.ToDateTime(row["ngayVaoLam"]) : DateTime.MinValue;
            this.dienThoai = row["dienThoai"] != DBNull.Value ? row["dienThoai"].ToString() : null;
            this.email = row["email"].ToString();
            this.diaChi = row["diaChi"] != DBNull.Value ? row["diaChi"].ToString() : null;
            this.hinhAnh = row["hinhAnh"] as byte[];
            this.maTK = row["maTK"].ToString();
        }
    }
}
