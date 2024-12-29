using GoodCharmePerfume.DTO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GoodCharmePerfume.DAO
{
    public class CustomerDAO
    {
        private static CustomerDAO instance;

        public static CustomerDAO Instance
        {
            get => instance == null ? instance = new CustomerDAO() : instance;
            private set => instance = value;
        }

        private CustomerDAO() { }

        public string GetNextMaKH()
        {
            string query = "SELECT dbo.f_AutoMaKH()";
            string maKH = DataProvider.Instance.ExecuteScalar(query)?.ToString();
            return maKH;
        }

        public List<CustomerDTO> GetCustomerList()
        {
            List<CustomerDTO> list = new List<CustomerDTO>();
            string query = "SELECT * FROM KhachHang";
            DataTable data = DataProvider.Instance.ExecuteQuery(query);
            foreach (DataRow item in data.Rows)
            {
                CustomerDTO customer = new CustomerDTO(item);
                list.Add(customer);
            }
            return list;
        }

        public List<CustomerDTO> GetCustomerListById(string customerId)
        {
            List<CustomerDTO> list = new List<CustomerDTO>();
            string query = $"SELECT * FROM KhachHang WHERE MaKH = N'{customerId}'";
            DataTable data = DataProvider.Instance.ExecuteQuery(query);
            foreach (DataRow item in data.Rows)
            {
                CustomerDTO customer = new CustomerDTO(item);
                list.Add(customer);
            }
            return list;
        }

        public List<CustomerDTO> GetCustomerListByCustomerId(string customerId)
        {
            List<CustomerDTO> list = new List<CustomerDTO>();
            string query = $"SELECT * FROM KhachHang WHERE MaKH LIKE N'%{customerId}%'";
            DataTable data = DataProvider.Instance.ExecuteQuery(query);
            foreach (DataRow item in data.Rows)
            {
                CustomerDTO customer = new CustomerDTO(item);
                list.Add(customer);
            }
            return list;
        }

        public List<CustomerDTO> GetCustomerListByCustomerName(string customerName)
        {
            List<CustomerDTO> list = new List<CustomerDTO>();
            string query = $"SELECT * FROM KhachHang WHERE HoTenKH LIKE N'%{customerName}%'";
            DataTable data = DataProvider.Instance.ExecuteQuery(query);
            foreach (DataRow item in data.Rows)
            {
                CustomerDTO customer = new CustomerDTO(item);
                list.Add(customer);
            }
            return list;
        }

        public List<CustomerDTO> GetCustomerListByPhoneNumber(string phoneNumber)
        {
            List<CustomerDTO> list = new List<CustomerDTO>();
            string query = $"SELECT * FROM KhachHang WHERE DienThoai = N'{phoneNumber}'";
            DataTable data = DataProvider.Instance.ExecuteQuery(query);
            foreach (DataRow item in data.Rows)
            {
                CustomerDTO customer = new CustomerDTO(item);
                list.Add(customer);
            }
            return list;
        }

        public bool InsertCustomer(string hoTenKH, string gioiTinh, DateTime ngaySinh, string dienThoai, string email, string diaChi)
        {
            string query = "INSERT INTO KhachHang(MaKH, HoTenKH, GioiTinh, NgaySinh, DienThoai, Email, DiaChi) " +
                "VALUES (dbo.f_AutoMaKH(), @hoTenKH , @gioiTinh , @ngaySinh , @dienThoai , @email , @diaChi )";
            object[] parameters = new object[]
            {
                hoTenKH,
                (object)gioiTinh ?? DBNull.Value,
                (object)ngaySinh ?? DBNull.Value,
                dienThoai,
                (object)email ?? DBNull.Value,
                (object)diaChi ?? DBNull.Value
            };
            int result = DataProvider.Instance.ExecuteNonQuery(query, parameters);
            return result > 0;
        }

        public bool UpdateCustomer(string maKH, string hoTenKH, string gioiTinh, DateTime ngaySinh, string dienThoai, string email, string diaChi)
        {
            string query = "UPDATE KhachHang SET HoTenKH = @hoTenKH , GioiTinh = @gioiTinh , NgaySinh = @ngaySinh , DienThoai = @dienThoai , Email = @email , DiaChi = @diaChi WHERE MaKH = @maKH";
            object[] parameters = new object[]
            {
                hoTenKH,
                (object)gioiTinh ?? DBNull.Value,
                (object)ngaySinh ?? DBNull.Value,
                dienThoai,
                (object)email ?? DBNull.Value,
                (object)diaChi ?? DBNull.Value,
                maKH
            };
            int result = DataProvider.Instance.ExecuteNonQuery(query, parameters);
            return result > 0;
        }

        public bool DeleteCustomer(string maKH)
        {
            string query = string.Format("DELETE KhachHang WHERE MaKH = N'{0}'", maKH);
            int result = DataProvider.Instance.ExecuteNonQuery(query);
            return result > 0;
        }
    }
}
