using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GoodCharmePerfume.DTO
{
    public class OrderStatusDTO
    {
        private string maTT;
        private string tinhTrang;

        public OrderStatusDTO() { }

        public string MaTT { get => maTT; set => maTT = value; }
        public string TinhTrang { get => tinhTrang; set => tinhTrang = value; }

        public OrderStatusDTO(string maTT, string tinhTrang)
        {
            this.maTT = maTT;
            this.tinhTrang = tinhTrang;
        }

        public OrderStatusDTO(DataRow row)
        {
            this.maTT = row["maTT"].ToString();
            this.tinhTrang = row["tinhTrang"].ToString();
        }
    }
}
