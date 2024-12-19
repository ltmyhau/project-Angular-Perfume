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

        //[HttpPost]
        //public JsonResult Post(KhachHang khachHang)
        //{
        //    string query = String.Format("INSERT INTO KhachHang (Email, MatKhau, HoTenKH, GioiTinh, NgaySinh, DienThoai, DiaChi) VALUES (N'{0}', {1}, N'{2}', N'{3}', CONVERT(DATETIME, '{4}', 105), N'{5}', N'{6}')",
        //        khachHang.Email, khachHang.MatKhau, khachHang.HoTenKH, khachHang.GioiTinh, khachHang.NgaySinh, khachHang.DienThoai, khachHang.DiaChi);
        //    DataTable table = new DataTable();
        //    String sqlDataSource = _configuration.GetConnectionString("QLBH_GoodCharme");
        //    SqlDataReader myReader;
        //    using (SqlConnection myCon = new SqlConnection(sqlDataSource))
        //    {
        //        myCon.Open();
        //        using (SqlCommand myCommand = new SqlCommand(query, myCon))
        //        {
        //            myReader = myCommand.ExecuteReader();
        //            table.Load(myReader);
        //            myReader.Close();
        //            myCon.Close();
        //        }
        //    }
        //    return new JsonResult("Thêm mới thành công!");
        //}

        //[HttpPut]
        //public JsonResult Put(KhachHang khachHang)
        //{
        //    string query = String.Format("UPDATE KhachHang SET Email = N'{0}', MatKhau = {1}, HoTenKH = N'{2}', GioiTinh = N'{3}', NgaySinh = CONVERT(DATETIME, '{4}', 105), DienThoai = N'{5}', DiaChi = N'{6}' WHERE MaKH = {7}",
        //        khachHang.Email, khachHang.MatKhau, khachHang.HoTenKH, khachHang.GioiTinh, khachHang.NgaySinh, khachHang.DienThoai, khachHang.DiaChi, khachHang.MaKH);
        //    DataTable table = new DataTable();
        //    String sqlDataSource = _configuration.GetConnectionString("QLBH_GoodCharme");
        //    SqlDataReader myReader;
        //    using (SqlConnection myCon = new SqlConnection(sqlDataSource))
        //    {
        //        myCon.Open();
        //        using (SqlCommand myCommand = new SqlCommand(query, myCon))
        //        {
        //            myReader = myCommand.ExecuteReader();
        //            table.Load(myReader);
        //            myReader.Close();
        //            myCon.Close();
        //        }
        //    }
        //    return new JsonResult("Cập nhật thành công!");
        //}

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
