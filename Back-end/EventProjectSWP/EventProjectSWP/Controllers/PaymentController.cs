using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using System.Data;
using System.Data.SqlClient;

namespace EventProjectSWP.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PaymentController : ControllerBase
    {

        private readonly IConfiguration _configuration;
        public PaymentController(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        [HttpPut("update-payment")]
        public IActionResult Put(bool status, int id, int event_id)
        {
            string query = @"update tblEventParticipated set payment_status = @payment_status where users_id =@users_id and event_id = @event_id";
            DataTable table = new DataTable();
            string sqlDataSource = _configuration.GetConnectionString("EventAppConn");
            SqlDataReader myReader;
            using (SqlConnection myCon = new SqlConnection(sqlDataSource))
            {
                myCon.Open();
                using (SqlCommand myCommand = new SqlCommand(query, myCon))
                {
                    myCommand.Parameters.AddWithValue("@payment_status", status);
                    myCommand.Parameters.AddWithValue("@users_id", id);
                    myCommand.Parameters.AddWithValue("@event_id", event_id);
                    myReader = myCommand.ExecuteReader();
                    myReader.Close();
                    myCon.Close();
                }
            }
            if (table.Rows.Count > 0)
            {
                return Ok(new Response<DataTable>(table));
            }
            return BadRequest(new Response<string>("No Data"));
        }

        [HttpGet("get-Payment")]
        public IActionResult Get(int id)
        {
            string query = @"select * from tblPayment where event_id =@event_id";

            DataTable table = new DataTable();
            string sqlDataSource = _configuration.GetConnectionString("EventAppConn");
            SqlDataReader myReader;
            using (SqlConnection myCon = new SqlConnection(sqlDataSource))
            {
                myCon.Open();
                using (SqlCommand myCommand = new SqlCommand(query, myCon))
                {
                    myCommand.Parameters.AddWithValue("@event_id", id);
                    myReader = myCommand.ExecuteReader();
                    table.Load(myReader);
                    myReader.Close();
                    myCon.Close();

                }
            }
            if (table.Rows.Count > 0)
            {
                return Ok(new Response<DataTable>(table));
            }
            return BadRequest(new Response<string>("No Data"));
        }
    }
}
