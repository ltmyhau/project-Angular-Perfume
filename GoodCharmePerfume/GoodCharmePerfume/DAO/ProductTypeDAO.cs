using GoodCharmePerfume.DTO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GoodCharmePerfume.DAO
{
    public class ProductTypeDAO
    {
        private static ProductTypeDAO instance;

        public static ProductTypeDAO Instance
        {
            get => instance == null ? instance = new ProductTypeDAO() : instance;
            private set => instance = value;
        }

        private ProductTypeDAO() { }

        public string GetNextMaLoaiSP()
        {
            string query = "SELECT dbo.f_AutoMaLoaiSP()";
            string maTL = DataProvider.Instance.ExecuteScalar(query)?.ToString();
            return maTL;
        }

        public bool InsertProductType(string tenLoaiSP)
        {
            string query = $"INSERT INTO LoaiSP(MaLoaiSP, TenLoaiSP) VALUES (dbo.f_AutoMaLoaiSP(), N'{tenLoaiSP}')";
            int result = DataProvider.Instance.ExecuteNonQuery(query);
            return result > 0;
        }

        public bool UpdateProductType(string maLoaiSP, string tenLoaiSP)
        {
            string query = $"UPDATE LoaiSP SET TenLoaiSP = N'{tenLoaiSP}' WHERE MaLoaiSP = N'{maLoaiSP}'";
            int result = DataProvider.Instance.ExecuteNonQuery(query);
            return result > 0;
        }

        public bool DeleteProductType(string maLoaiSP)
        {
            string query = $"DELETE LoaiSP WHERE MaLoaiSP = N'{maLoaiSP}'";
            int result = DataProvider.Instance.ExecuteNonQuery(query);
            return result > 0;
        }

        public List<ProductTypeDTO> GetProductTypeList()
        {
            List<ProductTypeDTO> list = new List<ProductTypeDTO>();
            string query = "SELECT * FROM LoaiSP";
            DataTable data = DataProvider.Instance.ExecuteQuery(query);
            foreach (DataRow item in data.Rows)
            {
                ProductTypeDTO productType = new ProductTypeDTO(item);
                list.Add(productType);
            }
            return list;
        }

        public List<ProductTypeDTO> GetProductTypeListById(string maLoaiSP)
        {
            List<ProductTypeDTO> list = new List<ProductTypeDTO>();
            string query = string.Format("SELECT * FROM LoaiSP WHERE MaLoaiSP = '{0}'", maLoaiSP);
            DataTable data = DataProvider.Instance.ExecuteQuery(query);
            foreach (DataRow item in data.Rows)
            {
                ProductTypeDTO productType = new ProductTypeDTO(item);
                list.Add(productType);
            }
            return list;
        }
    }
}
