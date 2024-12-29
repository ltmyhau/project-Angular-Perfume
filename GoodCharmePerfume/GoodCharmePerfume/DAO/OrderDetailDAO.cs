using GoodCharmePerfume.DTO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GoodCharmePerfume.DAO
{
    public class OrderDetailDAO
    {
        private static OrderDetailDAO instance;

        public static OrderDetailDAO Instance
        {
            get => instance == null ? instance = new OrderDetailDAO() : instance;
            private set => instance = value;
        }

        private OrderDetailDAO() { }

        public List<OrderDetailDTO> GetOrderDetailListByOrderID(string orderId)
        {
            List<OrderDetailDTO> list = new List<OrderDetailDTO>();
            string query = $"SELECT ctdh.MaDH, sp.MaSP, sp.TenSP, sp.GiaBan, ctdh. SoLuong, sp.GiaBan * ctdh. SoLuong AS ThanhTien FROM ChiTietDonHang ctdh JOIN SanPham sp ON ctdh.MaSP = sp.MaSP WHERE MaDH = '{orderId}'";
            DataTable data = DataProvider.Instance.ExecuteQuery(query);
            foreach (DataRow item in data.Rows)
            {
                OrderDetailDTO orderDetail = new OrderDetailDTO(item);
                list.Add(orderDetail);
            }
            return list;
        }
    }
}
