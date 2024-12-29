using GoodCharmePerfume.DTO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GoodCharmePerfume.DAO
{
    public class OrdersInfoDAO
    {
        private static OrdersInfoDAO instance;

        public static OrdersInfoDAO Instance
        {
            get => instance == null ? instance = new OrdersInfoDAO() : instance;
            private set => instance = value;
        }

        private OrdersInfoDAO() { }

        public string GetNextMaSP()
        {
            string query = "SELECT dbo.f_AutoMaSP()";
            string maPhim = DataProvider.Instance.ExecuteScalar(query)?.ToString();
            return maPhim;
        }

        public List<OrdersInfoDTO> GetOrdersInfoList()
        {
            List<OrdersInfoDTO> list = new List<OrdersInfoDTO>();
            string query = "SELECT * FROM vwOrdersInfo";
            DataTable data = DataProvider.Instance.ExecuteQuery(query);
            foreach (DataRow item in data.Rows)
            {
                OrdersInfoDTO ordersInfo = new OrdersInfoDTO(item);
                list.Add(ordersInfo);
            }
            return list;
        }

        public List<OrdersInfoDTO> GetOrdersInfoListByOrderId(string orderId)
        {
            List<OrdersInfoDTO> list = new List<OrdersInfoDTO>();
            string query = $"SELECT * FROM vwOrdersInfo WHERE MaDH LIKE N'%{orderId}%'";
            DataTable data = DataProvider.Instance.ExecuteQuery(query);
            foreach (DataRow item in data.Rows)
            {
                OrdersInfoDTO ordersInfo = new OrdersInfoDTO(item);
                list.Add(ordersInfo);
            }
            return list;
        }

        public List<OrdersInfoDTO> GetOrdersInfoListByStatusId(string statusID)
        {
            List<OrdersInfoDTO> list = new List<OrdersInfoDTO>();
            string query = $"SELECT * FROM vwOrdersInfo WHERE MaTT = '{statusID}'";
            DataTable data = DataProvider.Instance.ExecuteQuery(query);
            foreach (DataRow item in data.Rows)
            {
                OrdersInfoDTO ordersInfo = new OrdersInfoDTO(item);
                list.Add(ordersInfo);
            }
            return list;
        }

        public List<OrdersInfoDTO> GetOrdersInfoListByPaymentId(string paymentID)
        {
            List<OrdersInfoDTO> list = new List<OrdersInfoDTO>();
            string query = $"SELECT * FROM vwOrdersInfo WHERE MaPTTT = '{paymentID}'";
            DataTable data = DataProvider.Instance.ExecuteQuery(query);
            foreach (DataRow item in data.Rows)
            {
                OrdersInfoDTO ordersInfo = new OrdersInfoDTO(item);
                list.Add(ordersInfo);
            }
            return list;
        }
    }
}
