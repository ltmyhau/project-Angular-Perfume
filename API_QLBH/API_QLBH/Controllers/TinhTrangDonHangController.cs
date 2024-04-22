using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;
using System.Data;

namespace API_QLBH.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TinhTrangDonHangController : ControllerBase
    {
        private readonly IConfiguration _configuration;
        public TinhTrangDonHangController(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        [HttpGet]
        public JsonResult Get()
        {
            string query = "SELECT * FROM TinhTrangDonHang";
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
