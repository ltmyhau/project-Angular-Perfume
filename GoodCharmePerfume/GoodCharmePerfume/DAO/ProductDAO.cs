using GoodCharmePerfume.DTO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GoodCharmePerfume.DAO
{
    public class ProductDAO
    {
        private static ProductDAO instance;

        public static ProductDAO Instance
        {
            get => instance == null ? instance = new ProductDAO() : instance;
            private set => instance = value;
        }

        private ProductDAO() { }

        public string GetNextMaSP()
        {
            string query = "SELECT dbo.f_AutoMaSP()";
            string maPhim = DataProvider.Instance.ExecuteScalar(query)?.ToString();
            return maPhim;
        }

        public List<ProductDTO> GetProductList()
        {
            List<ProductDTO> list = new List<ProductDTO>();
            string query = "SELECT * FROM vwSanPham ORDER BY MaSP";
            DataTable data = DataProvider.Instance.ExecuteQuery(query);
            foreach (DataRow item in data.Rows)
            {
                ProductDTO product = new ProductDTO(item);
                list.Add(product);
            }
            return list;
        }

        public List<ProductDTO> GetProductListByProductName(string productName)
        {
            List<ProductDTO> list = new List<ProductDTO>();
            string query = $"SELECT * FROM vwSanPham WHERE TenSP LIKE N'%{productName}%' ORDER BY MaSP";
            DataTable data = DataProvider.Instance.ExecuteQuery(query);
            foreach (DataRow item in data.Rows)
            {
                ProductDTO product = new ProductDTO(item);
                list.Add(product);
            }
            return list;
        }

        public List<ProductDTO> GetProductListByPrice(int fromPrice, int toPrice)
        {
            List<ProductDTO> list = new List<ProductDTO>();
            string query = $"SELECT * FROM vwSanPham WHERE GiaBan BETWEEN {fromPrice} AND {toPrice} ORDER BY MaSP";
            DataTable data = DataProvider.Instance.ExecuteQuery(query);
            foreach (DataRow item in data.Rows)
            {
                ProductDTO product = new ProductDTO(item);
                list.Add(product);
            }
            return list;
        }

        public List<ProductDTO> GetProductListByProductTypeId(string productTypeId)
        {
            List<ProductDTO> list = new List<ProductDTO>();
            string query = $"SELECT * FROM vwSanPham WHERE MaLoaiSP = N'{productTypeId}' ORDER BY MaSP";
            DataTable data = DataProvider.Instance.ExecuteQuery(query);
            foreach (DataRow item in data.Rows)
            {
                ProductDTO product = new ProductDTO(item);
                list.Add(product);
            }
            return list;
        }

        public bool InsertProduct(string maLoaiSP, string tenSP, int giaBan, int dungTich, int soLuongTon, string hinhSP, DateTime ngayThem, string moTa)
        {
            string query = "INSERT INTO SanPham (MaSP, MaLoaiSP, TenSP, GiaBan, DungTich, SoLuongTon, HinhSP, NgayThem, MoTa) " +
                "VALUES (dbo.f_AutoMaSP(), @maLoaiSP , @tenSP , @giaBan , @dungTich , @soLuongTon , @hinhSP , @ngayThem , @moTa )";
            object[] parameters = new object[]
            {
                maLoaiSP,
                tenSP,
                giaBan,
                (object)dungTich ?? DBNull.Value,
                soLuongTon,
                hinhSP,
                ngayThem,
                (object)moTa ?? DBNull.Value
            };
            int result = DataProvider.Instance.ExecuteNonQuery(query, parameters);
            return result > 0;
        }

        public bool UpdateProduct(string maSP, string maLoaiSP, string tenSP, int giaBan, int dungTich, int soLuongTon, string hinhSP, DateTime ngayThem, string moTa)
        {
            string query = "UPDATE SanPham SET MaLoaiSP = @maLoaiSP , TenSP = @tenSP , GiaBan = @giaBan , DungTich = @dungTich , SoLuongTon = @soLuongTon , HinhSP = @hinhSP , NgayThem = @ngayThem , MoTa = @moTa WHERE MaSP = @maSP";
            object[] parameters = new object[]
            {
                maLoaiSP,
                tenSP,
                giaBan,
                (object)dungTich ?? DBNull.Value,
                soLuongTon,
                hinhSP,
                ngayThem,
                (object)moTa ?? DBNull.Value,
                maSP
            };
            int result = DataProvider.Instance.ExecuteNonQuery(query, parameters);
            return result > 0;
        }

        public bool DeleteProduct(string maSP)
        {
            string query = string.Format("DELETE SanPham WHERE MaSP = N'{0}'", maSP);
            int result = DataProvider.Instance.ExecuteNonQuery(query);
            return result > 0;
        }

        public string GetProductImgByProductID(string maSP)
        {
            string query = "SELECT HinhSP FROM SanPham WHERE MaSP = @MaSP";
            object result = DataProvider.Instance.ExecuteScalar(query, new object[] { maSP });
            if (result != null && result != DBNull.Value)
            {
                return (string)result;
            }

            return null;
        }
    }
}
