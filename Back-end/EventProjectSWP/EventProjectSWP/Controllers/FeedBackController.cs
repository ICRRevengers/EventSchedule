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
    public class FeedBackController : ControllerBase
    {

        private readonly IConfiguration _configuration;
        public FeedBackController(IConfiguration configuration)
        {
            _configuration = configuration;
        }


        [HttpGet("get-event-feedback")]
        public JsonResult GetUserParticipatedEvent(string id)
        {
            string query = @"select comment , rating , created_time, users_id from tblFeedback where event_id = @event_id";
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

        [HttpPost("add-feedback-to-event")]
        public JsonResult Post(Feedback Feedback)
        {
            string query = @"insert into tblFeedback values(@feedback_id,@comment,@rating,@created_time,@event_id,@users_id)";

            DataTable table = new DataTable();
            string sqlDataSource = _configuration.GetConnectionString("EventAppConn");
            SqlDataReader myReader;
            using (SqlConnection myCon = new SqlConnection(sqlDataSource))
            {
                myCon.Open();
                using (SqlCommand myCommand = new SqlCommand(query, myCon))
                {
                    myCommand.Parameters.AddWithValue("@feedback_id", Feedback.FeedbackId);
                    myCommand.Parameters.AddWithValue("@comment", Feedback.Comment);
                    myCommand.Parameters.AddWithValue("@rating", Feedback.Rating);
                    myCommand.Parameters.AddWithValue("@created_time", Feedback.CreatedTime);
                    myCommand.Parameters.AddWithValue("@event_id", Feedback.EventId);
                    myCommand.Parameters.AddWithValue("@users_id", Feedback.UserId);
                    myReader = myCommand.ExecuteReader();
                    myReader.Close();
                    myCon.Close();
                }
            }
            return new JsonResult("Succeesful");
        }

        [HttpDelete("delete-feedback")]
        public JsonResult Delete(int id)
        {
            string query = @"delete from tblFeedback where feedback_id =@feedback_id ";

            DataTable table = new DataTable();
            string sqlDataSource = _configuration.GetConnectionString("EventAppConn");
            SqlDataReader myReader;
            using (SqlConnection myCon = new SqlConnection(sqlDataSource))
            {
                myCon.Open();
                using (SqlCommand myCommand = new SqlCommand(query, myCon))
                {
                    myCommand.Parameters.AddWithValue("@feedback_id", id);
                    myReader = myCommand.ExecuteReader();
                    myReader.Close();
                    myCon.Close();

                }
            }
            return new JsonResult("Succeesful");
        }
    }
}
