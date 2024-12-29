using GoodCharmePerfume.DTO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GoodCharmePerfume.DAO
{
    public class OrderStatusDAO
    {
        private static OrderStatusDAO instance;

        public static OrderStatusDAO Instance
        {
            get => instance == null ? instance = new OrderStatusDAO() : instance;
            private set => instance = value;
        }

        private OrderStatusDAO() { }

        public List<OrderStatusDTO> GetOrderStatusList()
        {
            List<OrderStatusDTO> list = new List<OrderStatusDTO>();
            string query = "SELECT * FROM TinhTrangDonHang";
            DataTable data = DataProvider.Instance.ExecuteQuery(query);
            foreach (DataRow item in data.Rows)
            {
                OrderStatusDTO orderStatus = new OrderStatusDTO(item);
                list.Add(orderStatus);
            }
            return list;
        }
    }
}
