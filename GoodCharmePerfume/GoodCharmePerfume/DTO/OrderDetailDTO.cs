using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GoodCharmePerfume.DTO
{
    public class OrderDetailDTO
    {
        private string maDH;
        private string maSP;
        private string tenSP;
        private int giaBan;
        private int soLuong;
        private int thanhTien;

        public OrderDetailDTO() { }

        public string MaDH { get => maDH; set => maDH = value; }
        public string MaSP { get => maSP; set => maSP = value; }
        public string TenSP { get => tenSP; set => tenSP = value; }
        public int GiaBan { get => giaBan; set => giaBan = value; }
        public int SoLuong { get => soLuong; set => soLuong = value; }
        public int ThanhTien { get => thanhTien; set => thanhTien = value; }

        public OrderDetailDTO(string maDH, string maSP, string tenSP, int giaBan, int soLuong, int thanhTien)
        {
            this.maDH = maDH;
            this.maSP = maSP;
            this.tenSP = tenSP;
            this.giaBan = giaBan;
            this.soLuong = soLuong;
            this.thanhTien = thanhTien;
        }

        public OrderDetailDTO(DataRow row)
        {
            this.maDH = row["maDH"].ToString();
            this.maSP = row["maSP"].ToString();
            this.tenSP = row["tenSP"].ToString();
            this.giaBan = Convert.ToInt32(row["giaBan"]);
            this.soLuong = Convert.ToInt32(row["soLuong"]);
            this.thanhTien = Convert.ToInt32(row["thanhTien"]);
        }
    }
}
