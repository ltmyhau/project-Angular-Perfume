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
    public class SanPhamController : ControllerBase
    {
        private readonly IConfiguration _configuration;
        private readonly IWebHostEnvironment _env;
        public SanPhamController(IConfiguration configuration, IWebHostEnvironment env)
        {
            _configuration = configuration;
            _env = env;
        }

        [HttpGet]
        public JsonResult Get()
        {
            string query = "SELECT * FROM vwSanPham";
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
        public JsonResult Post(SanPham sanPham)
        {
            string hinhSPValue = string.IsNullOrEmpty(sanPham.HinhSP) ? "NULL" : $"'{sanPham.HinhSP}'";
            string moTaValue = string.IsNullOrEmpty(sanPham.MoTa) ? "NULL" : $"N'{sanPham.MoTa}'";
            string query = String.Format("INSERT INTO SanPham (MaSP, MaLoaiSP, TenSP, GiaBan, DungTich, SoLuongTon, NgayThem, HinhSP, MoTa) VALUES (dbo.f_AutoMaSP(), '{0}', N'{1}', {2}, {3}, {4}, GETDATE(), {5}, {6})",
                sanPham.MaLoaiSP, sanPham.TenSP, sanPham.GiaBan, sanPham.DungTich, sanPham.SoLuongTon, hinhSPValue, moTaValue);
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
        public JsonResult Put(SanPham sanPham)
        {
            string hinhSPValue = string.IsNullOrEmpty(sanPham.HinhSP) ? "NULL" : $"'{sanPham.HinhSP}'";
            string moTaValue = string.IsNullOrEmpty(sanPham.MoTa) ? "NULL" : $"N'{sanPham.MoTa}'";
            string query = String.Format("UPDATE SanPham SET MaLoaiSP = '{0}', TenSP = N'{1}', GiaBan = {2}, DungTich = {3}, SoLuongTon = {4}, HinhSP = {5}, MoTa = {6} WHERE MaSP = '{7}'",
                sanPham.MaLoaiSP, sanPham.TenSP, sanPham.GiaBan, sanPham.DungTich, sanPham.SoLuongTon, hinhSPValue, moTaValue, sanPham.MaSP);
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
            string query = $"DELETE FROM SanPham WHERE MaSP = '{ma}'";
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

        [Route("SaveFile")]
        [HttpPost]
        public JsonResult SaveFile()
        {
            try
            {
                var httpRequest = Request.Form;
                var postedFile = httpRequest.Files[0];
                string filename = postedFile.FileName;
                var physicalPath = _env.ContentRootPath + "/Photos/" + filename;

                using (var stream = new FileStream(physicalPath, FileMode.Create))
                {
                    postedFile.CopyTo(stream);
                }

                return new JsonResult(filename);
            }
            catch (Exception)
            {
                return new JsonResult("com.jpg");
            }
        }

        [Route("GetSanPhamMoi")]
        [HttpGet]
        public JsonResult GetSanPhamMoi(int limit = 10)
        {
            string query = $"SELECT TOP {limit} * FROM vwSanPham ORDER BY NgayThem DESC";
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

        [Route("GetSanPhamBanChay")]
        [HttpGet]
        public JsonResult GetSanPhamBanChay(int limit = 10)
        {
            string query = $"SELECT TOP {limit} sp.MaSP, TenSP, GiaBan, HinhSP FROM vwSanPham sp JOIN ChiTietDonHang ctdh ON ctdh.MaSP = sp.MaSP GROUP BY sp.MaSP, TenSP, GiaBan, HinhSP ORDER BY SUM(ctdh.SoLuong) DESC";
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

        [Route("GetSanPhamTheoMaSP")]
        [HttpGet]
        public JsonResult GetSanPhamTheoMaSP(string id = "SP000001")
        {
            string query = $"SELECT * FROM vwSanPham WHERE MaSP = '{id}'";
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

        [Route("GetSanPhamByID")]
        [HttpGet]
        public JsonResult GetSanPhamByID(string id = "SP000001")
        {
            string query = $"SELECT MaSP, TenSP, MaLoaiSP, GiaBan, SoLuongTon FROM SanPham WHERE MaSP = '{id}'";
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

        [Route("GetSanPhamTheoMaLoaiSP")]
        [HttpGet]
        public JsonResult GetSanPhamTheoMaLoaiSP(string id = "LSP000001")
        {
            string query = $"SELECT * FROM vwSanPham WHERE MaLoaiSP = '{id}'";
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

        [Route("GetNuocHoa")]
        [HttpGet]
        public JsonResult GetNuocHoa()
        {
            string query = $"SELECT * FROM vwSanPham WHERE MaLoaiSP = 'LSP000001' OR MaLoaiSP = 'LSP000002' OR MaLoaiSP = 'LSP000003' OR MaLoaiSP = 'LSP000004'";
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

        [Route("GetSanPhamKhac")]
        [HttpGet]
        public JsonResult GetSanPhamKhac()
        {
            string query = $"SELECT * FROM vwSanPham WHERE MaLoaiSP = 'LSP000005' OR MaLoaiSP = 'LSP000006' OR MaLoaiSP = 'LSP000007'";
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

        [Route("GetSanPhamTheoGia")]
        [HttpGet]
        public JsonResult GetSanPhamTheoGia(int tuGia = 0, int denGia = int.MaxValue)
        {
            string query = $"SELECT * FROM vwSanPham WHERE GiaBan BETWEEN {tuGia} AND {denGia}";
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

        [Route("GetSanPhamNgauNhien")]
        [HttpGet]
        public JsonResult GetSanPhamNgauNhien(int limit = 10)
        {
            string query = $"SELECT TOP {limit} * FROM SanPham ORDER BY NEWID()";
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

        [Route("SearchSanPham")]
        [HttpGet]
        public JsonResult SearchSanPham(string search)
        {
            string query = $"SELECT * FROM vwSanPham WHERE TenSP LIKE N'%{search}%' OR MoTa LIKE N'%{search}%' OR TenLoaiSP LIKE N'%{search}%'";
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
