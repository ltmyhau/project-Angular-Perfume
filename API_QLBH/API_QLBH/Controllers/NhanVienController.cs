using API_QLBH.Model;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;
using System.Data;

namespace API_QLBH.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class NhanVienController : Controller
    {
        private readonly IConfiguration _configuration;
        public NhanVienController(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        [HttpGet]
        public JsonResult Get()
        {
            string query = "SELECT * FROM NhanVien";
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
        public JsonResult Post(NhanVien nhanVien)
        {
            string hinhAnhValue = string.IsNullOrEmpty(nhanVien.HinhAnh) ? "NULL" : $"'{nhanVien.HinhAnh}'";
            string query = String.Format("INSERT INTO NhanVien(MaNV, HoTenNV, GioiTinh, NgaySinh, NgayVaoLam, DienThoai, Email, DiaChi, HinhAnh) VALUES (dbo.f_AutoMaNV(), N'{0}', N'{1}', '{2}', '{3}', N'{4}', N'{5}', N'{6}', {7})",
                nhanVien.HoTenNV, nhanVien.GioiTinh, nhanVien.NgaySinh, nhanVien.NgayVaoLam, nhanVien.DienThoai, nhanVien.Email, nhanVien.DiaChi, hinhAnhValue);
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
        public JsonResult Put(NhanVien nhanVien)
        {
            string hinhAnhValue = string.IsNullOrEmpty(nhanVien.HinhAnh) ? "NULL" : $"'{nhanVien.HinhAnh}'";
            string query = String.Format("UPDATE NhanVien SET HoTenNV = N'{0}', GioiTinh = N'{1}', NgaySinh = '{2}', NgayVaoLam = '{3}', DienThoai = N'{4}', Email = N'{5}', DiaChi = N'{6}', HinhAnh = {7} WHERE MaNV = '{8}'",
                nhanVien.HoTenNV, nhanVien.GioiTinh, nhanVien.NgaySinh, nhanVien.NgayVaoLam, nhanVien.DienThoai, nhanVien.Email, nhanVien.DiaChi, hinhAnhValue, nhanVien.MaNV);
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
            string query = $"DELETE FROM NhanVien WHERE MaNV = '{ma}'";
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

        [Route("GetNhanVienTheoMaNV")]
        [HttpGet]
        public JsonResult GetNhanVienTheoMaNV(string id = "NV000001")
        {
            string query = $"SELECT * FROM NhanVien WHERE MaNV = '{id}'";
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
