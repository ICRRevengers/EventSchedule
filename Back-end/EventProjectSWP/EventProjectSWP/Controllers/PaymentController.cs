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
<<<<<<< HEAD
=======

>>>>>>> backend-Long
        private readonly IConfiguration _configuration;
        public PaymentController(IConfiguration configuration)
        {
            _configuration = configuration;
        }

<<<<<<< HEAD
        [HttpGet("get-Payment")]
        public JsonResult GetPayment()
        {
            string query = @"select * from tblPayment";
=======
        [HttpPut("update-payment")]
        public JsonResult Put(bool status, int id, int event_id)
        {
            string query = @"update tblEventParticipated set payment_status = @payment_status where users_id =@users_id and event_id = @event_id";
>>>>>>> backend-Long
            DataTable table = new DataTable();
            string sqlDataSource = _configuration.GetConnectionString("EventAppConn");
            SqlDataReader myReader;
            using (SqlConnection myCon = new SqlConnection(sqlDataSource))
            {
                myCon.Open();
                using (SqlCommand myCommand = new SqlCommand(query, myCon))
                {
<<<<<<< HEAD
                    myReader = myCommand.ExecuteReader();
                    table.Load(myReader);
                    myReader.Close();
                    myCon.Close();

                }
            }
            return new JsonResult(table);
        }

        [HttpPut("update-payment")]
        public JsonResult Put(bool status, string user_id, string event_id)
        {
            string query = @"update tblEventParticipated set payment_status = @payment_status where users_id =@users_id and event_id = @event_id";
=======
                    myCommand.Parameters.AddWithValue("@payment_status", status);
                    myCommand.Parameters.AddWithValue("@users_id", id);
                    myCommand.Parameters.AddWithValue("@event_id", event_id);
                    myReader = myCommand.ExecuteReader();
                    myReader.Close();
                    myCon.Close();
                }
            }
            return new JsonResult("Succeesful");
        }

        [HttpGet("get-Payment")]
        public JsonResult Get(int id)
        {
            string query = @"select * from tblPayment where event_id =@event_id";
>>>>>>> backend-Long

            DataTable table = new DataTable();
            string sqlDataSource = _configuration.GetConnectionString("EventAppConn");
            SqlDataReader myReader;
            using (SqlConnection myCon = new SqlConnection(sqlDataSource))
            {
                myCon.Open();
                using (SqlCommand myCommand = new SqlCommand(query, myCon))
                {
<<<<<<< HEAD
                    myCommand.Parameters.AddWithValue("@payment_status", status);
                    myCommand.Parameters.AddWithValue("@users_id", user_id);
                    myCommand.Parameters.AddWithValue("@event_id", event_id);
                    myReader = myCommand.ExecuteReader();
=======
                    myCommand.Parameters.AddWithValue("@event_id", id);
                    myReader = myCommand.ExecuteReader();
                    table.Load(myReader);
>>>>>>> backend-Long
                    myReader.Close();
                    myCon.Close();

                }
            }
<<<<<<< HEAD
            return new JsonResult("Succeesful");
=======
            return new JsonResult(table);
>>>>>>> backend-Long
        }
    }
}
