using GoodCharmePerfume.DTO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GoodCharmePerfume.DAO
{
    public class EmployeeDAO
    {
        private static EmployeeDAO instance;

        public static EmployeeDAO Instance
        {
            get => instance == null ? instance = new EmployeeDAO() : instance;
            private set => instance = value;
        }

        private EmployeeDAO() { }

        public string GetNextMaNV()
        {
            string query = "SELECT dbo.f_AutoMaNV()";
            string maKH = DataProvider.Instance.ExecuteScalar(query)?.ToString();
            return maKH;
        }

        public List<EmployeeDTO> GetEmployeeList()
        {
            List<EmployeeDTO> list = new List<EmployeeDTO>();
            string query = "SELECT * FROM NhanVien";
            DataTable data = DataProvider.Instance.ExecuteQuery(query);
            foreach (DataRow item in data.Rows)
            {
                EmployeeDTO employee = new EmployeeDTO(item);
                list.Add(employee);
            }
            return list;
        }

        public List<EmployeeDTO> GetEmployeeListByAccountId(string accountId)
        {
            List<EmployeeDTO> list = new List<EmployeeDTO>();
            string query = "SELECT * FROM NhanVien WHERE MaTK = @accountId";
            DataTable data = DataProvider.Instance.ExecuteQuery(query, new object[] { accountId });
            foreach (DataRow item in data.Rows)
            {
                EmployeeDTO employee = new EmployeeDTO(item);
                list.Add(employee);
            }
            return list;
        }

        public bool InsertEmployee(string hoTenNV, string gioiTinh, DateTime ngaySinh, DateTime ngayVaoLam, string dienThoai, string email, string diaChi)
        {
            string query = "INSERT INTO NhanVien(MaNV, HoTenNV, GioiTinh, NgaySinh, NgayVaoLam, DienThoai, Email, DiaChi)  " +
                "VALUES (dbo.f_AutoMaNV(), @hoTenNV , @gioiTinh , @ngaySinh , @ngayVaoLam , @dienThoai , @email , @diaChi )";
            object[] parameters = new object[]
            {
                hoTenNV,
                (object)gioiTinh ?? DBNull.Value,
                (object)ngaySinh ?? DBNull.Value,
                (object)ngayVaoLam ?? DBNull.Value,
                dienThoai,
                (object)email ?? DBNull.Value,
                (object)diaChi ?? DBNull.Value
            };
            int result = DataProvider.Instance.ExecuteNonQuery(query, parameters);
            return result > 0;
        }

        public bool UpdateEmployee(string maNV, string hoTenNV, string gioiTinh, DateTime ngaySinh, DateTime ngayVaoLam, string dienThoai, string email, string diaChi)
        {
            string query = "UPDATE NhanVien SET HoTenNV = @hoTenNV , GioiTinh = @gioiTinh , NgaySinh = @ngaySinh , NgayVaoLam = @ngayVaoLam , DienThoai = @dienThoai , Email = @email , DiaChi = @diaChi WHERE MaNV = @maNV";
            object[] parameters = new object[]
            {
                hoTenNV,
                (object)gioiTinh ?? DBNull.Value,
                (object)ngaySinh ?? DBNull.Value,
                (object)ngayVaoLam ?? DBNull.Value,
                dienThoai,
                (object)email ?? DBNull.Value,
                (object)diaChi ?? DBNull.Value,
                maNV
            };
            int result = DataProvider.Instance.ExecuteNonQuery(query, parameters);
            return result > 0;
        }

        public bool DeleteEmployee(string maNV)
        {
            string query = string.Format("DELETE NhanVien WHERE MaNV = N'{0}'", maNV);
            int result = DataProvider.Instance.ExecuteNonQuery(query);
            return result > 0;
        }

        public List<EmployeeDTO> GetEmployeeListById(string employeeId)
        {
            List<EmployeeDTO> list = new List<EmployeeDTO>();
            string query = $"SELECT * FROM NhanVien WHERE MaNV = N'{employeeId}'";
            DataTable data = DataProvider.Instance.ExecuteQuery(query);
            foreach (DataRow item in data.Rows)
            {
                EmployeeDTO employee = new EmployeeDTO(item);
                list.Add(employee);
            }
            return list;
        }

        public List<EmployeeDTO> GetEmployeeListByEmployeeId(string employeeId)
        {
            List<EmployeeDTO> list = new List<EmployeeDTO>();
            string query = $"SELECT * FROM NhanVien WHERE MaNV LIKE N'%{employeeId}%'";
            DataTable data = DataProvider.Instance.ExecuteQuery(query);
            foreach (DataRow item in data.Rows)
            {
                EmployeeDTO employee = new EmployeeDTO(item);
                list.Add(employee);
            }
            return list;
        }

        public List<EmployeeDTO> GetEmployeeListByEmployeeName(string employeeName)
        {
            List<EmployeeDTO> list = new List<EmployeeDTO>();
            string query = $"SELECT * FROM NhanVien WHERE HoTenNV LIKE N'%{employeeName}%'";
            DataTable data = DataProvider.Instance.ExecuteQuery(query);
            foreach (DataRow item in data.Rows)
            {
                EmployeeDTO employee = new EmployeeDTO(item);
                list.Add(employee);
            }
            return list;
        }
    }
}
