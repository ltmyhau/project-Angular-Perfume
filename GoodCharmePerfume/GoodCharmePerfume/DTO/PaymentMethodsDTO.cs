using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GoodCharmePerfume.DTO
{
    public class PaymentMethodsDTO
    {
        private string maPTTT;
        private string tenPTTT;

        public PaymentMethodsDTO() { }

        public string MaPTTT { get => maPTTT; set => maPTTT = value; }
        public string TenPTTT { get => tenPTTT; set => tenPTTT = value; }

        public PaymentMethodsDTO(string maPTTT, string tenPTTT)
        {
            this.maPTTT = maPTTT;
            this.tenPTTT = tenPTTT;
        }

        public PaymentMethodsDTO(DataRow row)
        {
            this.maPTTT = row["maPTTT"].ToString();
            this.tenPTTT = row["tenPTTT"].ToString();
        }
    }
}
