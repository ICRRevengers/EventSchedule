using EventProjectSWP.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using System;
using System.Data;
using System.Data.SqlClient;
using System.Text.RegularExpressions;

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
        
        [HttpGet("get-userinfo-join-event")]
        // lấy tất cả thông tin người dùng đã tham gia event
        public IActionResult Get()
        {
            try
            {
                string query = @"select U.users_id,users_name, users_phone,users_address,users_email,event_id,date_participated,payment_status
                                from tblEventParticipated EP, tblUser U
                                where Ep.users_id = U.users_id";

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
                if (table.Rows.Count > 0)
                {
                    return Ok(new Response<DataTable>(table));
                }
                return BadRequest(new Response<string>("No Data"));
            }
            catch (Exception ex)
            {
                return BadRequest(new Response<string>(ex.Message));
            } 
        }

        [HttpGet("get-all-event-i-joined")]
        // Lấy tất cả event mà 1 user tham gia 
        public IActionResult GetUserEvent(string id)
        {
            try
            {
                string query = @"select U.users_id,users_name, users_phone,users_address,users_email,date_participated, E.event_name
                             from tblEventParticipated EP, tblUser U, tblEvent E
                             where Ep.users_id = U.users_id and E.event_id = EP.event_id and U.users_id =  @users_id";
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
                if (table.Rows.Count > 0)
                {
                    return Ok(new Response<DataTable>(table));
                }
                return BadRequest(new Response<string>("No Data"));
            }
            catch (Exception ex)
            {
                return BadRequest(new Response<string>(ex.Message));
            }
           
        }

        [HttpGet("get-user-list-from-an-event")]
        // Lấy tất cả user từ 1 event
        public IActionResult GetUserParticipatedEvent(string id)
        {
            try
            {
                string query = @"select U.users_id,users_name, users_phone,users_address,users_email,event_id,date_participated,payment_status,users_status 
                             from tblEventParticipated EP, tblUser U
                             where Ep.users_id = U.users_id and EP.event_id = @event_id";
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
            catch (Exception ex)
            {
                return BadRequest(new Response<string>(ex.Message));
            }
      
        }


        [HttpPost("add-user-join-event")]
        public IActionResult Post(EventParticipated EventParticipated)
        {
            try
            {
                string query = @"insert into tblEventParticipated(event_id,users_id,date_participated) values(@event_id,@users_id,@date_participated)";        
                string sqlDataSource = _configuration.GetConnectionString("EventAppConn");
                SqlDataReader myReader;
                using (SqlConnection myCon = new SqlConnection(sqlDataSource))
                {
                    myCon.Open();
                    using (SqlCommand myCommand = new SqlCommand(query, myCon))
                    {
                        myCommand.Parameters.AddWithValue("@event_id", EventParticipated.eventID);
                        myCommand.Parameters.AddWithValue("@users_id", EventParticipated.userID);
                        myCommand.Parameters.AddWithValue("@date_participated", EventParticipated.dateParticipated);
                        myReader = myCommand.ExecuteReader();
                        myReader.Close();
                        myCon.Close();
                    }
                }
                    return Ok("Successfully");
            }
            catch (Exception ex)
            {
                return BadRequest(new Response<string>(ex.Message));
            }
         
        }

        [HttpGet("Check-user-participated")]
        public IActionResult Get(EventParticipated EventParticipated)
        {
            try
            {
                string query = @"insert into tblEventParticipated(event_id,users_id,date_participated) values(@event_id,@users_id,@date_participated)";
                string sqlDataSource = _configuration.GetConnectionString("EventAppConn");
                SqlDataReader myReader;
                using (SqlConnection myCon = new SqlConnection(sqlDataSource))
                {
                    myCon.Open();
                    using (SqlCommand myCommand = new SqlCommand(query, myCon))
                    {
                        myCommand.Parameters.AddWithValue("@event_id", EventParticipated.eventID);
                        myCommand.Parameters.AddWithValue("@users_id", EventParticipated.userID);
                        myCommand.Parameters.AddWithValue("@date_participated", EventParticipated.dateParticipated);
                        myReader = myCommand.ExecuteReader();
                        myReader.Close();
                        myCon.Close();
                    }
                }
                return Ok("Successfully");
            }
            catch (Exception ex)
            {
                return BadRequest(new Response<string>(ex.Message));
            }

        }
    }
}
