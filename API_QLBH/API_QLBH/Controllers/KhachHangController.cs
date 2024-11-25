﻿using API_QLBH.Model;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;
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

        [HttpDelete("{ma}")]
        public JsonResult Delete(int ma)
        {
            string query = @"DELETE FROM KhachHang WHERE MaKH = " + ma;
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
        public JsonResult GetKhachHangTheoMaKH(int id = 1)
        {
            string query = $"SELECT * FROM KhachHang WHERE MaKH = {id}";
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
