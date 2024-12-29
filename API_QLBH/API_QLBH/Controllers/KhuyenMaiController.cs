using API_QLBH.Model;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;
using System.Data;

namespace API_QLBH.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class KhuyenMaiController : Controller
    {
        private readonly IConfiguration _configuration;
        private readonly IWebHostEnvironment _env;
        public KhuyenMaiController(IConfiguration configuration, IWebHostEnvironment env)
        {
            _configuration = configuration;
            _env = env;
        }

        [HttpGet]
        public JsonResult Get()
        {
            string query = "SELECT * FROM KhuyenMai";
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
        public JsonResult Post(KhuyenMai khuyenMai)
        {
            string query = String.Format("INSERT INTO KhuyenMai (MaKM, Code, NgayTao, LoaiKM, UuDai, NgayBD, NgayKT) VALUES (dbo.f_AutoMaKM(), '{0}', GETDATE(), N'{1}', {2}, '{3}', '{4}')",
                khuyenMai.Code, khuyenMai.LoaiKM, khuyenMai.UuDai, khuyenMai.NgayBD, khuyenMai.NgayKT);
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
        public JsonResult Put(KhuyenMai khuyenMai)
        {
            string query = String.Format("UPDATE KhuyenMai SET Code = '{0}', LoaiKM = N'{1}', UuDai = {2}, NgayBD = '{3}', NgayKT = '{4}' WHERE MaKM = '{5}'",
                khuyenMai.Code, khuyenMai.LoaiKM, khuyenMai.UuDai, khuyenMai.NgayBD, khuyenMai.NgayKT, khuyenMai.MaKM);
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
            string query = $"DELETE FROM KhuyenMai WHERE MaKM = '{ma}'";
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

        [Route("GetKhuyenMaiTheoMaKM")]
        [HttpGet]
        public JsonResult GetKhuyenMaiTheoMaKM(string id = "KM000001")
        {
            string query = $"SELECT * FROM KhuyenMai WHERE MaKM = '{id}'";
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

        [Route("GetKhuyenMaiTheoCode")]
        [HttpGet]
        public JsonResult GetKhuyenMaiTheoCode(string code = "CODE")
        {
            string query = $"SELECT * FROM KhuyenMai WHERE Code = '{code}'";
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
