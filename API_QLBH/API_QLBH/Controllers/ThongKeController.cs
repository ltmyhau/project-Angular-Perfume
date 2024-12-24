using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;
using System.Data;

namespace API_QLBH.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ThongKeController : Controller
    {
        private readonly IConfiguration _configuration;
        public ThongKeController(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        [Route("overview")]
        [HttpGet]
        public JsonResult Get()
        {
            string query = "SELECT (SELECT COUNT(Madh) FROM DonHang) AS SoDonHang, (SELECT COUNT(MaSP) FROM SanPham) AS SoSanPham, (SELECT COUNT(MaKH) FROM KhachHang) AS SoKhachHang, (SELECT SUM(TongTien) FROM vwOrders) AS DoanhThu";
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
