using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GoodCharmePerfume.DTO
{
    public class OrdersInfoDTO
    {
        private string maDH;
        private string maKH;
        private string hoTenKH;
        private string maNV;
        private string hoTenNV;
        private DateTime ngayDat;
        private string maTT;
        private string tinhTrang;
        private string maPTTT;
        private string tenPTTT;

        public OrdersInfoDTO() { }

        public string MaDH { get => maDH; set => maDH = value; }
        public string MaKH { get => maKH; set => maKH = value; }
        public string HoTenKH { get => hoTenKH; set => hoTenKH = value; }
        public string MaNV { get => maNV; set => maNV = value; }
        public string HoTenNV { get => hoTenNV; set => hoTenNV = value; }
        public DateTime NgayDat { get => ngayDat; set => ngayDat = value; }
        public string MaTT { get => maTT; set => maTT = value; }
        public string TinhTrang { get => tinhTrang; set => tinhTrang = value; }
        public string MaPTTT { get => maPTTT; set => maPTTT = value; }
        public string TenPTTT { get => tenPTTT; set => tenPTTT = value; }

        public OrdersInfoDTO(string maDH, string maKH, string hoTenKH, string maNV, string hoTenNV, DateTime ngayDat, string maTT, string tinhTrang, string maPTTT, string tenPTTT)
        {
            this.maDH = maDH;
            this.maKH = maKH;
            this.hoTenKH = hoTenKH;
            this.maNV = maNV;
            this.hoTenNV = hoTenNV;
            this.ngayDat = ngayDat;
            this.maTT = maTT;
            this.tinhTrang = tinhTrang;
            this.maPTTT = maPTTT;
            this.tenPTTT = tenPTTT;
        }

        public OrdersInfoDTO(DataRow row)
        {
            this.maDH = row["maDH"].ToString();
            this.maKH = row["maKH"].ToString();
            this.hoTenKH = row["hoTenKH"].ToString();
            this.maNV = row["maNV"].ToString();
            this.hoTenNV = row["hoTenNV"].ToString();
            this.ngayDat = row["ngayDat"] != DBNull.Value ? Convert.ToDateTime(row["ngayDat"]) : DateTime.MinValue;
            this.maTT = row["maTT"].ToString();
            this.tinhTrang = row["tinhTrang"].ToString();
            this.maPTTT = row["maPTTT"].ToString();
            this.tenPTTT = row["tenPTTT"].ToString();
        }
    }
}
