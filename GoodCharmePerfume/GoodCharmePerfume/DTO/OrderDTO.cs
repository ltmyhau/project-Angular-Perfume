using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GoodCharmePerfume.DTO
{
    public class OrderDTO
    {
        private string maDH;
        private string maKH;
        private string maNV;
        private string maTT;
        private string maPTTT;
        private DateTime ngayDat;
        private DateTime ngayGiao;

        public OrderDTO() { }

        public string MaDH { get => maDH; set => maDH = value; }
        public string MaKH { get => maKH; set => maKH = value; }
        public string MaNV { get => maNV; set => maNV = value; }
        public string MaTT { get => maTT; set => maTT = value; }
        public string MaPTTT { get => maPTTT; set => maPTTT = value; }
        public DateTime NgayDat { get => ngayDat; set => ngayDat = value; }
        public DateTime NgayGiao { get => ngayGiao; set => ngayGiao = value; }

        public OrderDTO(string maDH, string maKH, string maNV, string maTT, string maPTTT, DateTime ngayDat, DateTime ngayGiao)
        {
            this.maDH = maDH;
            this.maKH = maKH;
            this.maNV = maNV;
            this.maTT = maTT;
            this.maPTTT = maPTTT;
            this.ngayDat = ngayDat;
            this.ngayGiao = ngayGiao;
        }

        public OrderDTO(DataRow row)
        {
            this.maDH = row["maDH"].ToString();
            this.maKH = row["maKH"].ToString();
            this.maNV = row["maNV"].ToString();
            this.maTT = row["maTT"].ToString();
            this.maPTTT = row["maPTTT"].ToString();
            this.ngayDat = row["ngayDat"] != DBNull.Value ? Convert.ToDateTime(row["ngayDat"]) : DateTime.MinValue;
            this.ngayGiao = row["ngayGiao"] != DBNull.Value ? Convert.ToDateTime(row["ngayGiao"]) : DateTime.MinValue;
        }
    }
}
