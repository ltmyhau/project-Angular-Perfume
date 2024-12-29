using GoodCharmePerfume.DTO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GoodCharmePerfume.DAO
{
    public class OrderDAO
    {
        private static OrderDAO instance;

        public static OrderDAO Instance
        {
            get => instance == null ? instance = new OrderDAO() : instance;
            private set => instance = value;
        }

        private OrderDAO() { }

        public List<OrderDTO> GetOrdersList()
        {
            List<OrderDTO> list = new List<OrderDTO>();
            string query = "SELECT * FROM DonHang";
            DataTable data = DataProvider.Instance.ExecuteQuery(query);
            foreach (DataRow item in data.Rows)
            {
                OrderDTO order = new OrderDTO(item);
                list.Add(order);
            }
            return list;
        }
        public bool UpdateOrder(string maDH, string maKH, string maNV, string maTT, string maPTTT, DateTime ngayDat)
        {
            string query = "UPDATE DonHang SET MaKH = @maKH , MaNV = @maNV , MaTT = @maTT , MaPTTT = @maPTTT , NgayDat = @ngayDat WHERE MaDH = @maDH";
            object[] parameters = new object[]
            {
                maKH,
                string.IsNullOrEmpty(maNV) ? DBNull.Value : (object)maNV,
                maTT,
                maPTTT,
                ngayDat,
                maDH
            };
            int result = DataProvider.Instance.ExecuteNonQuery(query, parameters);
            return result > 0;
        }

        public bool DeleteOrder(string maDH)
        {
            string query = string.Format("DELETE DonHang WHERE MaDH = N'{0}'", maDH);
            int result = DataProvider.Instance.ExecuteNonQuery(query);
            return result > 0;
        }
    }
}
