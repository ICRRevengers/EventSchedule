using EventProjectSWP.DTOs;
using EventProjectSWP.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
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
                string query = @"select U.users_id,users_name, users_phone,users_address,users_email,date_participated, E.event_name, E.event_id
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
                    List<GetEventJoined> listEventJoined = new List<GetEventJoined>();
                    for (int i = 0; i < table.Rows.Count; i++)
                    {
                        listEventJoined.Add(new GetEventJoined()
                        {
                            date_participated = table.Rows[i]["date_participated"].ToString(),
                            event_id = table.Rows[i]["event_id"].ToString(),
                            event_name = table.Rows[i]["event_name"].ToString(),
                            users_address = table.Rows[i]["users_address"].ToString(),
                            users_email = table.Rows[i]["users_email"].ToString(),
                            users_name = table.Rows[i]["users_name"].ToString(),
                            users_phone = table.Rows[i]["users_phone"].ToString(),
                            users_id = Convert.ToInt32(table.Rows[0]["users_id"]),
                            is_feedback = CheckFeedBack(Convert.ToInt32(table.Rows[i]["event_id"]), Convert.ToInt32(table.Rows[i]["users_id"])),
                        });
                    }
                    return Ok(new Response<List<GetEventJoined>>(listEventJoined));
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
        public IActionResult Post(AddUserJoinEvent EventParticipated, bool paymentStatus, bool userStatus)
        {
            try
            {
                string query = @"insert into tblEventParticipated(event_id,users_id,date_participated, payment_status, users_status) values(@event_id,@users_id,@date_participated, 'false','false')";        
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

        private bool CheckFeedBack(int eventId, int userId)
        {
            string query = @"SELECT *
                           FROM tblFeedback
                           where tblFeedBack.event_id = @event_id and tblFeedback.users_id = @users_id";
            DataTable table = new DataTable();
            string sqlDataSource = _configuration.GetConnectionString("EventAppConn");
            SqlDataReader myReader;
            using (SqlConnection myCon = new SqlConnection(sqlDataSource))
            {
                myCon.Open();
                using (SqlCommand myCommand = new SqlCommand(query, myCon))
                {
                    myCommand.Parameters.AddWithValue("@event_id", eventId);
                    myCommand.Parameters.AddWithValue("@users_id", userId);
                    myReader = myCommand.ExecuteReader();
                    table.Load(myReader);
                    myReader.Close();
                    myCon.Close();

                }
            }
            if (table.Rows.Count > 0)
            {
                return true;
            }
            return false;
        }
    }   
}
