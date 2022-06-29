using EventProjectSWP.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using System.Data;
using System.Data.SqlClient;

namespace EventProjectSWP.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EventParticipatedController : ControllerBase
    {
        private readonly IConfiguration _configuration;
        public EventParticipatedController(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        [HttpPut("update-payment")]
        public JsonResult Put(bool status, string id)
        {
            string query = @"update tblEventParticipated set payment_status = @payment_status where users_id =@users_id";

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
                    myReader = myCommand.ExecuteReader();
                    myReader.Close();
                    myCon.Close();

                }
            }
            return new JsonResult("Succeesful");
        }

        [HttpGet("get-list-event-participated")]
        public JsonResult Get()
        {
            string query = @"select event_id , users_id, date_participated , payment_status from tblEventParticipated";

            DataTable table = new DataTable();
            string sqlDataSource = _configuration.GetConnectionString("EventAppConn");
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

        [HttpGet("get-list-user-join-event-participated")]
        public JsonResult GetUserEvent(string id)
        {
            string query = @"select event_id , date_participated , payment_status from tblEventParticipated where users_id = @users_id";
            DataTable table = new DataTable();
            string sqlDataSource = _configuration.GetConnectionString("EventAppConn");
            SqlDataReader myReader;
            using (SqlConnection myCon = new SqlConnection(sqlDataSource))
            {
                myCon.Open();
                using (SqlCommand myCommand = new SqlCommand(query, myCon))
                {
                    myCommand.Parameters.AddWithValue("@users_id", id);
                    myReader = myCommand.ExecuteReader();
                    table.Load(myReader);
                    myReader.Close();
                    myCon.Close();

                }
            }
            return new JsonResult(table);
        }

        [HttpGet("get-user-list-from-event")]
        public JsonResult GetUserParticipatedEvent(string id)
        {
            string query = @"select users_id , date_participated, payment_status from tblEventParticipated where event_id = @event_id";
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
            return new JsonResult(table);
        }



        [HttpPost("add-user-join-event")]
        public JsonResult Post(EventParticipated EventParticipated)
        {
            string query = @"insert into tblEventParticipated(event_id,users_id,date_participated) values(@event_id,@users_id,@date_participated)";

            DataTable table = new DataTable();
            string sqlDataSource = _configuration.GetConnectionString("EventAppConn");
            SqlDataReader myReader;
            using (SqlConnection myCon = new SqlConnection(sqlDataSource))
            {
                myCon.Open();
                using (SqlCommand myCommand = new SqlCommand(query, myCon))
                {
                    myCommand.Parameters.AddWithValue("@event_id", EventParticipated.EventID);
                    myCommand.Parameters.AddWithValue("@users_id", EventParticipated.UserID);
                    myCommand.Parameters.AddWithValue("@date_participated", EventParticipated.DateParticipated);
                    myReader = myCommand.ExecuteReader();
                    myReader.Close();
                    myCon.Close();
                }
            }
            return new JsonResult("Succeesful");
        }
      



    }
}
