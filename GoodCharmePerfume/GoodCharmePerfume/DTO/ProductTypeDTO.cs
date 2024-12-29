using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GoodCharmePerfume.DTO
{
    public class ProductTypeDTO
    {
        private string maLoaiSP;
        private string tenLoaiSP;
        public ProductTypeDTO() { }

        public string MaLoaiSP { get => maLoaiSP; set => maLoaiSP = value; }
        public string TenLoaiSP { get => tenLoaiSP; set => tenLoaiSP = value; }

        public ProductTypeDTO(string maLoaiSP, string tenLoaiSP)
        {
            this.maLoaiSP = maLoaiSP;
            this.tenLoaiSP = tenLoaiSP;
        }

        public ProductTypeDTO(DataRow row)
        {
            this.maLoaiSP = row["maLoaiSP"].ToString();
            this.tenLoaiSP = row["tenLoaiSP"].ToString();
        }
    }
}
