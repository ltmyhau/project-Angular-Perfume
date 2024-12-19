using API_QLBH.Model;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;
using System.Data;

namespace API_QLBH.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ChiTietDonHangController : ControllerBase
    {
        private readonly IConfiguration _configuration;
        public ChiTietDonHangController(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        [HttpGet]
        public JsonResult Get()
        {
            string query = "SELECT * FROM ChiTietDonHang";
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
        public JsonResult Post(List<ChiTietDonHang> cthds)
        {
            string query = "INSERT INTO ChiTietDonHang (MaDH, MaSP, SoLuong) VALUES (@MaDH, @MaSP, @SoLuong)";
            String sqlDataSource = _configuration.GetConnectionString("QLBH_GoodCharme");
            using (SqlConnection myCon = new SqlConnection(sqlDataSource))
            {
                myCon.Open();
                using (SqlTransaction transaction = myCon.BeginTransaction())
                {
                    try
                    {
                        foreach (var cthd in cthds)
                        {
                            using (SqlCommand myCommand = new SqlCommand(query, myCon, transaction))
                            {
                                myCommand.Parameters.AddWithValue("@MaDH", cthd.MaDH);
                                myCommand.Parameters.AddWithValue("@MaSP", cthd.MaSP);
                                myCommand.Parameters.AddWithValue("@SoLuong", cthd.SoLuong);
                                myCommand.ExecuteNonQuery();
                            }
                        }
                        transaction.Commit();
                        return new JsonResult("Thêm mới thành công!");
                    }
                    catch (Exception ex)
                    {
                        transaction.Rollback();
                        return new JsonResult($"Lỗi: {ex.Message}");
                    }
                }
            }
        }

        [HttpGet("{orderId}")]
        public JsonResult GetOrderDetailsByOrderId(string orderId)
        {
            string query = @"SELECT sp.*, ctdh.SoLuong FROM ChiTietDonHang ctdh JOIN SanPham sp ON ctdh.MaSP = sp.MaSP WHERE ctdh.MaDH = @MaDH";
            DataTable table = new DataTable();
            string sqlDataSource = _configuration.GetConnectionString("QLBH_GoodCharme");

            using (SqlConnection myCon = new SqlConnection(sqlDataSource))
            {
                myCon.Open();
                using (SqlCommand myCommand = new SqlCommand(query, myCon))
                {
                    myCommand.Parameters.AddWithValue("@MaDH", orderId);
                    SqlDataReader myReader = myCommand.ExecuteReader();
                    table.Load(myReader);
                    myReader.Close();
                    myCon.Close();
                }
            }

            return new JsonResult(table);
        }

    }
}
