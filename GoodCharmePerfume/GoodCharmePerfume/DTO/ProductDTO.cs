using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace GoodCharmePerfume.DTO
{
    public class ProductDTO
    {
        private string maSP;
        private string maLoaiSP;
        private string tenSP;
        private int giaBan;
        private int dungTich;
        private int soLuongTon;
        private string hinhSP;
        private DateTime ngayThem;
        private string moTa;
        private string tenLoaiSP;
        private int tongSoLuongBan;

        public string MaSP { get => maSP; set => maSP = value; }
        public string MaLoaiSP { get => maLoaiSP; set => maLoaiSP = value; }
        public string TenSP { get => tenSP; set => tenSP = value; }
        public int GiaBan { get => giaBan; set => giaBan = value; }
        public int DungTich { get => dungTich; set => dungTich = value; }
        public int SoLuongTon { get => soLuongTon; set => soLuongTon = value; }
        public string HinhSP { get => hinhSP; set => hinhSP = value; }
        public DateTime NgayThem { get => ngayThem; set => ngayThem = value; }
        public string MoTa { get => moTa; set => moTa = value; }
        public string TenLoaiSP { get => tenLoaiSP; set => tenLoaiSP = value; }
        public int TongSoLuongBan { get => tongSoLuongBan; set => tongSoLuongBan = value; }

        public ProductDTO(string maSP, string maLoaiSP, string tenSP, int giaBan, int dungTich, int soLuongTon, string hinhSP, DateTime ngayThem, string moTa, string tenLoaiSP, int tongSoLuongBan)
        {
            this.maSP = maSP;
            this.maLoaiSP = maLoaiSP;
            this.tenSP = tenSP;
            this.giaBan = giaBan;
            this.dungTich = dungTich;
            this.soLuongTon = soLuongTon;
            this.hinhSP = hinhSP;
            this.ngayThem = ngayThem;
            this.moTa = moTa;
            this.tenLoaiSP = tenLoaiSP;
            this.tongSoLuongBan = tongSoLuongBan;
        }

        public ProductDTO(DataRow row)
        {
            this.maSP = row["maSP"].ToString();
            this.maLoaiSP = row["maLoaiSP"].ToString();
            this.tenSP = row["tenSP"].ToString();
            this.giaBan = Convert.ToInt32(row["giaBan"]);
            this.dungTich = Convert.ToInt32(row["dungTich"]);
            this.soLuongTon = Convert.ToInt32(row["soLuongTon"]);
            this.hinhSP = row["hinhSP"].ToString();
            this.ngayThem = Convert.ToDateTime(row["ngayThem"]);
            this.moTa = row["moTa"].ToString();
            this.tenLoaiSP = row["tenLoaiSP"].ToString();
            this.tongSoLuongBan = Convert.ToInt32(row["tongSoLuongBan"]);
        }
    }
}
