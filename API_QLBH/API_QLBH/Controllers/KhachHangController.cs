using API_QLBH.Model;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;
using System;
using System.Data;

namespace API_QLBH.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class KhachHangController : ControllerBase
    {
        private readonly IConfiguration _configuration;
        public KhachHangController(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        [HttpGet]
        public JsonResult Get()
        {
            string query = "SELECT * FROM KhachHang";
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
        public JsonResult Post(KhachHang khachHang)
        {
            string hinhAnhValue = string.IsNullOrEmpty(khachHang.HinhAnh) ? "NULL" : $"'{khachHang.HinhAnh}'";
            string query = String.Format("INSERT INTO KhachHang(MaKH, HoTenKH, GioiTinh, NgaySinh, DienThoai, Email, DiaChi, Phuong, Quan, ThanhPho, HinhAnh) VALUES (dbo.f_AutoMaKH(), N'{0}', N'{1}', '{2}', N'{3}', N'{4}', N'{5}', N'{6}', N'{7}', N'{8}', {9})",
                khachHang.HoTenKH, khachHang.GioiTinh, khachHang.NgaySinh, khachHang.DienThoai, khachHang.Email, khachHang.DiaChi, khachHang.Phuong, khachHang.Quan, khachHang.ThanhPho, hinhAnhValue);
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
        public JsonResult Put(KhachHang khachHang)
        {
            string hinhKHValue = string.IsNullOrEmpty(khachHang.HinhAnh) ? "NULL" : $"'{khachHang.HinhAnh}'";
            string query = String.Format("UPDATE KhachHang SET HoTenKH = N'{0}', GioiTinh = N'{1}', NgaySinh = '{2}', DienThoai = N'{3}', Email = N'{4}', DiaChi = N'{5}', Phuong = N'{6}', Quan = N'{7}', ThanhPho = N'{8}', HinhAnh = {9} WHERE MaKH = '{10}'",
                khachHang.HoTenKH, khachHang.GioiTinh, khachHang.NgaySinh, khachHang.DienThoai, khachHang.Email, khachHang.DiaChi, khachHang.Phuong, khachHang.Quan, khachHang.ThanhPho, hinhKHValue, khachHang.MaKH);
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

        [HttpPut("update-info/{maKH}")]
        public JsonResult Put(string maKH, KhachHangInfo khachHang)
        {
            string hinhKHValue = string.IsNullOrEmpty(khachHang.HinhAnh) ? "NULL" : $"'{khachHang.HinhAnh}'";
            string query = String.Format("UPDATE KhachHang SET HoTenKH = N'{0}', GioiTinh = N'{1}', NgaySinh = '{2}', DienThoai = N'{3}', Email = N'{4}', HinhAnh = {5} WHERE MaKH = '{6}'",
                khachHang.HoTenKH, khachHang.GioiTinh, khachHang.NgaySinh, khachHang.DienThoai, khachHang.Email, hinhKHValue, maKH);
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

        [HttpPut("update-address/{maKH}")]
        public JsonResult Put(string maKH, KhachHangAddress khachHang)
        {
            string query = String.Format("UPDATE KhachHang SET HoTenKH = N'{0}', DienThoai = N'{1}', DiaChi = N'{2}', Phuong = N'{3}', Quan = N'{4}', ThanhPho = N'{5}' WHERE MaKH = '{6}'",
                khachHang.HoTenKH, khachHang.DienThoai, khachHang.DiaChi, khachHang.Phuong, khachHang.Quan, khachHang.ThanhPho, maKH);
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
            string query = $"DELETE FROM KhachHang WHERE MaKH = '{ma}'";
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

        [Route("GetKhachHangTheoMaKH")]
        [HttpGet]
        public JsonResult GetKhachHangTheoMaKH(string id = "KH000001")
        {
            string query = $"SELECT * FROM KhachHang WHERE MaKH = '{id}'";
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
