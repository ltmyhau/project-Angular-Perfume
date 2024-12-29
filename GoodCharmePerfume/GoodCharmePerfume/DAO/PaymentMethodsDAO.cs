using GoodCharmePerfume.DTO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GoodCharmePerfume.DAO
{
    public class PaymentMethodsDAO
    {
        private static PaymentMethodsDAO instance;

        public static PaymentMethodsDAO Instance
        {
            get => instance == null ? instance = new PaymentMethodsDAO() : instance;
            private set => instance = value;
        }

        private PaymentMethodsDAO() { }

        public List<PaymentMethodsDTO> GetOrderStatusList()
        {
            List<PaymentMethodsDTO> list = new List<PaymentMethodsDTO>();
            string query = "SELECT * FROM PhuongThucThanhToan";
            DataTable data = DataProvider.Instance.ExecuteQuery(query);
            foreach (DataRow item in data.Rows)
            {
                PaymentMethodsDTO paymentMethod = new PaymentMethodsDTO(item);
                list.Add(paymentMethod);
            }
            return list;
        }
    }
}
