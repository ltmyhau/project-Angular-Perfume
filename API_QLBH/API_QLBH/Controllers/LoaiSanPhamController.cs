using API_QLBH.Model;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;
using System.Collections.Generic;
using System.Data;

namespace API_QLBH.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LoaiSanPhamController : ControllerBase
    {
        private readonly IConfiguration _configuration;
        private readonly IWebHostEnvironment _env;
        public LoaiSanPhamController(IConfiguration configuration, IWebHostEnvironment env)
        {
            _configuration = configuration;
            _env = env;
        }

        [Route("GetNextID")]
        [HttpGet]
        public string GetNextID()
        {
            string query = "SELECT dbo.f_AutoMaLoaiSP() AS MaLoaiSP";
            string result = string.Empty;
            string sqlDataSource = _configuration.GetConnectionString("QLBH_GoodCharme");

            using (SqlConnection myCon = new SqlConnection(sqlDataSource))
            {
                myCon.Open();
                using (SqlCommand myCommand = new SqlCommand(query, myCon))
                {
                    SqlDataReader myReader = myCommand.ExecuteReader();
                    if (myReader.Read())
                    {
                        result = myReader["MaLoaiSP"].ToString();
                    }
                    myReader.Close();
                }
                myCon.Close();
            }

            return result;
        }

        [HttpGet]
        public JsonResult Get()
        {
            string query = "SELECT * FROM vwLoaiSP";
            DataTable table = new DataTable();
            String sqlDataSource = _configuration.GetConnectionString("QLBH_GoodCharme");
            SqlDataReader myReader;
            using (SqlConnection myCon = new SqlConnection(sqlDataSource))
            {
                myCon.Open();
                using (SqlCommand myCommand = new SqlCommand(query, myCon))
                {
                    myReader = myCommand.ExecuteReader();
                    table.Load(myReader);
                    myReader.Close();
                    myCon.Close();
                }
            }
            return new JsonResult(table);
        }

        [HttpPost]
        public JsonResult Post(LoaiSanPham loaiSP)
        {
            string query = String.Format("INSERT INTO LoaiSP(MaLoaiSP, TenLoaiSP) VALUES (dbo.f_AutoMaLoaiSP(), N'{0}')", loaiSP.TenLoaiSP);
            DataTable table = new DataTable();
            String sqlDataSource = _configuration.GetConnectionString("QLBH_GoodCharme");
            SqlDataReader myReader;
            using (SqlConnection myCon = new SqlConnection(sqlDataSource))
            {
                myCon.Open();
                using (SqlCommand myCommand = new SqlCommand(query, myCon))
                {
                    myReader = myCommand.ExecuteReader();
                    table.Load(myReader);
                    myReader.Close();
                    myCon.Close();
                }
            }
            return new JsonResult("Thêm mới thành công!");
        }

        [HttpPut]
        public JsonResult Put(LoaiSanPham loaiSP)
        {
            string query = String.Format("UPDATE LoaiSP SET TenLoaiSP = N'{0}' WHERE MaLoaiSP = N'{1}'", loaiSP.TenLoaiSP, loaiSP.MaLoaiSP);
            DataTable table = new DataTable();
            String sqlDataSource = _configuration.GetConnectionString("QLBH_GoodCharme");
            SqlDataReader myReader;
            using (SqlConnection myCon = new SqlConnection(sqlDataSource))
            {
                myCon.Open();
                using (SqlCommand myCommand = new SqlCommand(query, myCon))
                {
                    myReader = myCommand.ExecuteReader();
                    table.Load(myReader);
                    myReader.Close();
                    myCon.Close();
                }
            }
            return new JsonResult("Cập nhật thành công!");
        }

        [HttpDelete("{ma}")]
        public JsonResult Delete(string ma)
        {
            string query = $"DELETE FROM LoaiSP WHERE MaLoaiSP = '{ma}'";
            DataTable table = new DataTable();
            String sqlDataSource = _configuration.GetConnectionString("QLBH_GoodCharme");
            SqlDataReader myReader;
            using (SqlConnection myCon = new SqlConnection(sqlDataSource))
            {
                myCon.Open();
                using (SqlCommand myCommand = new SqlCommand(query, myCon))
                {
                    myReader = myCommand.ExecuteReader();
                    table.Load(myReader);
                    myReader.Close();
                    myCon.Close();
                }
            }
            return new JsonResult("Xóa bỏ thành công!");
        }

        [Route("GetLoaiSanPhamTheoMaLoaiSP")]
        [HttpGet]
        public JsonResult GetLoaiSanPhamTheoMaLoaiSP(string id = "LSP000001")
        {
            string query = $"SELECT * FROM LoaiSP WHERE MaLoaiSP = '{id}'";
            DataTable table = new DataTable();
            String sqlDataSource = _configuration.GetConnectionString("QLBH_GoodCharme");
            SqlDataReader myReader;
            using (SqlConnection myCon = new SqlConnection(sqlDataSource))
            {
                myCon.Open();
                using (SqlCommand myCommand = new SqlCommand(query, myCon))
                {
                    myReader = myCommand.ExecuteReader();
                    table.Load(myReader);
                    myReader.Close();
                    myCon.Close();
                }
            }
            return new JsonResult(table);
        }
    }
}
