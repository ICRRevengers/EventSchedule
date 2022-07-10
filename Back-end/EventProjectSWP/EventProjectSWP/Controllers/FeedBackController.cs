using EventProjectSWP.DTOs;
using EventProjectSWP.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using System;
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
        public IActionResult GetUserParticipatedEvent(string id)
        {
            try
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
                if (table.Rows.Count > 0)
                {
                    return Ok(new Response<DataTable>(table));
                }
                return Ok(new Response<string>(null, "No Data"));
            }
            catch (Exception ex)
            {
                return BadRequest(new Response<string>(ex.Message));
            }
           
        }

        [HttpPost("add-feedback-to-event")]
        public IActionResult Post(AddFeedback Feedback)
        {
            try
            {
                string query = @"insert into tblFeedback values(@comment,@rating,@created_time,@event_id,@users_id)";

                DataTable table = new DataTable();
                string sqlDataSource = _configuration.GetConnectionString("EventAppConn");
                SqlDataReader myReader;
                using (SqlConnection myCon = new SqlConnection(sqlDataSource))
                {
                    myCon.Open();
                    using (SqlCommand myCommand = new SqlCommand(query, myCon))
                    {
                        myCommand.Parameters.AddWithValue("@comment", Feedback.comment);
                        myCommand.Parameters.AddWithValue("@rating", Feedback.rating);
                        myCommand.Parameters.AddWithValue("@created_time", DateTime.Now);
                        myCommand.Parameters.AddWithValue("@event_id", Feedback.eventId);
                        myCommand.Parameters.AddWithValue("@users_id", Feedback.userId);
                        myReader = myCommand.ExecuteReader();
                        myReader.Close();
                        myCon.Close();
                    }
                }
                var ableToFeedback = true;
                return Ok(new Response<bool>(ableToFeedback));
            }
            catch (Exception ex)
            {
                return BadRequest(new Response<string>(ex.Message));
            }
         
        }

        [HttpDelete("delete-feedback")]
        public IActionResult Delete(int id)
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
            if (table.Rows.Count > 0)
            {
                return Ok(new Response<DataTable>(table));
            }
            return BadRequest(new Response<string>("No Data"));
        }
    }
}
