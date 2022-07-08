﻿using EventProjectSWP.DTOs;
using EventProjectSWP.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace EventProjectSWP.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EventController : ControllerBase
    {
        private readonly IConfiguration _configuration;
        public EventController(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        [HttpGet("get-event-list")]
        public IActionResult Get()
        {
            try
            {
                string query = @"Select E.event_id, E.admin_id, E.location_id, event_name, event_content, event_status, event_start, event_end, tblLocation.location_detail, 
       tblAdmin.admin_id, tblAdmin.admin_name,
       tblPayment.payment_fee, tblPayment.payment_url,
       tblCategory.category_name,
       tblImage.image_url,tblVideo.video_url    
       from tblEvent E
       inner JOIN tblLocation ON E.location_id = tblLocation.location_id
       inner JOIN tblPayment ON E.event_id = tblPayment.event_id
       inner JOIN tblAdmin ON E.admin_id = tblAdmin.admin_id
       inner JOIN tblCategory ON e.category_id = tblCategory.category_id
       inner JOIN tblImage ON e.event_id = tblImage.event_id
       inner JOIN tblVideo ON e.event_id = tblVideo.event_id";
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
                    /*
                    List<GetListEvent> listEvents = new List<GetListEvent>();
                    for (int i = 0; i < table.Rows.Count; i++)
                    {
                        listEvents.Add(new GetListEvent()
                        {
                            eventID = Convert.ToInt32(table.Rows[i]["event_id"]),
                            eventName = table.Rows[i]["event_name"].ToString(),
                            eventContent = table.Rows[i]["event_content"].ToString(),
                            eventStatus = (bool)table.Rows[i]["event_status"],
                            eventStart = Convert.ToDateTime(table.Rows[i]["event_start"]),
                            eventEnd = Convert.ToDateTime(table.Rows[i]["event_end"]),
                            locationDetail = table.Rows[i]["location_detail"].ToString(),
                            adminId = Convert.ToInt32(table.Rows[i]["admin_id"]),
                            adminName = table.Rows[i]["admin_name"].ToString(),
                            paymentFee = Convert.ToInt32(table.Rows[i]["payment_fee"]),
                            paymentUrl = table.Rows[i]["payment_url"].ToString(),
                            categoryName = table.Rows[i]["category_name"].ToString(),
                            //sua so 1 thanh user id truyen vao
                            canFeedBack = CheckFeedBack(Convert.ToInt32(table.Rows[i]["event_id"]), 1)
                        });
                    }
                    return Ok(new Response<List<GetListEvent>>(listEvents));*/
                    return Ok(new Response<DataTable>(table, null));
                }
                return BadRequest(new Response<string>("No Data"));


            }
            catch (Exception e)
            {
                return BadRequest(new Response<string>(e.Message));
            }
        }
        [HttpGet("get-event-with-image")]
        public IActionResult GetEventWithImage()
        {
            try
            {
                /*string query = @"Select E.event_id, event_name, event_content, event_timeline, created_by, created_by,event_status,payment_status,category_id,location_id,admin_id,I.image_url,v.video_url
From dbo.tblEvent E, tblImage I, tblVideo V
Where E.event_id = I.event_id ";
                */
                string query = @"Select E.event_id, event_name, event_content, event_timeline, created_by, created_by,event_status,payment_status,category_id,location_id,admin_id,I.image_url
From dbo.tblEvent E, tblImage I
Where E.event_id = I.event_id ";
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
            catch (Exception e)
            {
                return BadRequest(new Response<string>(e.Message));
            }
        }
        [HttpGet("get-imageurl-by-eventid")]
        public IActionResult GetImageUrl(int id)
        {
            try
            {
                /*string query = @"Select E.event_id, event_name, event_content, event_timeline, created_by, created_by,event_status,payment_status,category_id,location_id,admin_id,I.image_url,v.video_url
From dbo.tblEvent E, tblImage I, tblVideo V
Where E.event_id = I.event_id ";
                */
                string query = @"Select I.image_url
                                 From dbo.tblEvent E, tblImage I
                                 Where E.event_id = @event_id ";
                DataTable table = new DataTable();
                string sqlDataSource = _configuration.GetConnectionString("EventAppConn");
                SqlDataReader myReader;
                using (SqlConnection myCon = new SqlConnection(sqlDataSource))
                {
                    myCon.Open();
                    using (SqlCommand myCommand = new SqlCommand(query, myCon))
                    {
                        myCommand.Parameters.AddWithValue("@event_id",id);
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
            catch (Exception e)
            {
                return BadRequest(new Response<string>(e.Message));
            }
        }
        [HttpGet("get-videourl-by-eventid")]
        public IActionResult GetVideoUrl(int id)
        {
            try
            {
                /*string query = @"Select E.event_id, event_name, event_content, event_timeline, created_by, created_by,event_status,payment_status,category_id,location_id,admin_id,I.image_url,v.video_url
From dbo.tblEvent E, tblImage I, tblVideo V
Where E.event_id = I.event_id ";
                */
                string query = @"Select V.video_url
                                 From dbo.tblEvent E, tblVideo V
                                 Where E.event_id = @event_id ";
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
            catch (Exception e)
            {
                return BadRequest(new Response<string>(e.Message));
            }
        }

        [HttpGet("show-upcoming-event")]
        public IActionResult Show_upcoming_event()
        {
            try
            {
                string query = @"Select E.event_id, E.admin_id, E.location_id, event_name, event_content, event_status, event_start, event_end, tblLocation.location_detail, 
       tblAdmin.admin_id, tblAdmin.admin_name,
       tblPayment.payment_fee, tblPayment.payment_url,
       tblCategory.category_name
       from tblEvent E
       FULL JOIN tblLocation ON E.location_id = tblLocation.location_id
       FULL JOIN tblPayment ON E.event_id = tblPayment.event_id
       FULL JOIN tblAdmin ON E.admin_id = tblAdmin.admin_id
       FULL JOIN tblCategory ON e.category_id = tblCategory.category_id
       where event_start >= GETDATE()";

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
            catch (Exception e)
            {
                return BadRequest(new Response<string>(e.Message));
            }
        }

        [HttpGet("show-past-event")]
        public IActionResult Show_past_event()
        {
            try
            {
                string query = @"Select E.event_id, E.admin_id, E.location_id, event_name, event_content, event_status, event_start, event_end, tblLocation.location_detail, 
       tblAdmin.admin_id, tblAdmin.admin_name,
       tblPayment.payment_fee, tblPayment.payment_url,
       tblCategory.category_name
       from tblEvent E
       FULL JOIN tblLocation ON E.location_id = tblLocation.location_id
       FULL JOIN tblPayment ON E.event_id = tblPayment.event_id
       FULL JOIN tblAdmin ON E.admin_id = tblAdmin.admin_id
       FULL JOIN tblCategory ON e.category_id = tblCategory.category_id
       where event_start < GETDATE()";

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
            catch (Exception e)
            {
                return BadRequest(new Response<string>(e.Message));
            }

        }

        [HttpPost("add-event")]
        public IActionResult Post(AddEvent addEvent)
        {
            try
            {
                string query = @"insert into dbo.tblEvent(event_name,event_content,event_start,event_end,created_by,event_code,event_status,payment_status,category_id,location_id,admin_id) 
values (@event_name,@event_content,@event_start,@event_end,@created_by,@event_code,@event_status,@payment_status,@category_id,@location_id,@admin_id)";

                string sqlDataSource = _configuration.GetConnectionString("EventAppConn");
                SqlDataReader myReader;
                using (SqlConnection myCon = new SqlConnection(sqlDataSource))
                {
                    myCon.Open();
                    using (SqlCommand myCommand = new SqlCommand(query, myCon))
                    {
                        myCommand.Parameters.AddWithValue("@event_name", addEvent.eventName);
                        myCommand.Parameters.AddWithValue("@event_content", addEvent.eventContent);
                        myCommand.Parameters.AddWithValue("@event_start", addEvent.eventStart);
                        myCommand.Parameters.AddWithValue("@event_end", addEvent.eventEnd);
                        myCommand.Parameters.AddWithValue("@created_by", addEvent.createdBy);
                        myCommand.Parameters.AddWithValue("@event_status", addEvent.eventStatus);
                        myCommand.Parameters.AddWithValue("@category_id", addEvent.categoryID);
                        myCommand.Parameters.AddWithValue("@location_id", addEvent.locationID);
                        myCommand.Parameters.AddWithValue("@admin_id ", addEvent.adminID);
                        myReader = myCommand.ExecuteReader();
                        myReader.Close();
                        myCon.Close();
                    }
                }
                return Ok(new Response<string>(null, "Add Sucessfully"));
            }
            catch (Exception e)
            {
                return BadRequest(new Response<string>(e.Message));
            }
        }

        [HttpPut("update-event")]
        public IActionResult Put(Event Event)
        {
            try
            {
                string query = @"update dbo.tblEvent 
                           set event_name = @event_name, event_content = @event_content, 
                           event_start = @event_start,event_end = @event_end, created_by = @created_by,  
                           event_code = @event_code, event_status = @event_status, 
                           payment_status = @payment_status, category_id = @category_id, 
                           location_id = @location_id, admin_id = @admin_id 
                           where event_id = @event_id";

                DataTable table = new DataTable();
                string sqlDataSource = _configuration.GetConnectionString("EventAppConn");
                SqlDataReader myReader;
                using (SqlConnection myCon = new SqlConnection(sqlDataSource))
                {
                    myCon.Open();
                    using (SqlCommand myCommand = new SqlCommand(query, myCon))
                    {
                        myCommand.Parameters.AddWithValue("@event_name", Event.eventName);
                        myCommand.Parameters.AddWithValue("@event_content", Event.eventContent);
                        myCommand.Parameters.AddWithValue("@event_start", Event.eventStart);
                        myCommand.Parameters.AddWithValue("@event_end", Event.eventEnd);
                        myCommand.Parameters.AddWithValue("@created_by", Event.createdBy);
                        myCommand.Parameters.AddWithValue("@event_code", Event.eventCode);
                        myCommand.Parameters.AddWithValue("@event_status", Event.eventStatus);
                        myCommand.Parameters.AddWithValue("@payment_status", Event.eventStatus);
                        myCommand.Parameters.AddWithValue("@category_id", Event.categoryID);
                        myCommand.Parameters.AddWithValue("@location_id", Event.locationID);
                        myCommand.Parameters.AddWithValue("@admin_id ", Event.adminID);
                        myCommand.Parameters.AddWithValue("@event_id", Event.eventID);
                        myReader = myCommand.ExecuteReader();
                        myReader.Close();
                        myCon.Close();
                    }
                }            
                    return Ok("Update Successfully");          
            }catch (Exception ex)
            {
                return BadRequest(new Response<string>(ex.Message));
            }

        }

        [HttpPut("Update-event-status-true/false-by-endtime")]
        public IActionResult UpdateEvenStatusByEndTime()
        {
            try
            {
                string query = @"update tblEvent 
                                 set event_status = case 
                                 when GETDATE() > event_end then 'False'
                                 else 'True' end";

                DataTable table = new DataTable();
                string sqlDataSource = _configuration.GetConnectionString("EventAppConn");
                SqlDataReader myReader;
                using (SqlConnection myCon = new SqlConnection(sqlDataSource))
                {
                    myCon.Open();
                    using (SqlCommand myCommand = new SqlCommand(query, myCon))
                    {
                        myReader = myCommand.ExecuteReader();
                        myReader.Close();
                        myCon.Close();

                    }
                }
                return Ok("Set Event Status Successfully");
            }
            catch (Exception ex)
            {
                return BadRequest(new Response<string>(ex.Message));
            }
        }

        [HttpDelete("delete-event")]
        public IActionResult Delete(string id)
        {
            try
            {
                string query = @"delete from dbo.tblEvent where event_id = @event_id";

                string sqlDataSource = _configuration.GetConnectionString("EventAppConn");
                SqlDataReader myReader;
                using (SqlConnection myCon = new SqlConnection(sqlDataSource))
                {
                    myCon.Open();
                    using (SqlCommand myCommand = new SqlCommand(query, myCon))
                    {
                        myCommand.Parameters.AddWithValue("@event_id", id);
                        myReader = myCommand.ExecuteReader();
                        myReader.Close();
                        myCon.Close();

                    }
                }
                    return Ok("Delete Successfully");
                
                return BadRequest(new Response<string>("No Data"));
            }catch (Exception ex)
            {
                return BadRequest(new Response<string>(ex.Message));
            }
      
        }

        [HttpGet("get-event-by-name")]
        public IActionResult GetEventByName(string name)
        {
            try
            {
                string query = @"Select E.event_id, E.admin_id, E.location_id, event_name, event_content, event_status, event_start, event_end, tblLocation.location_detail, 
       tblAdmin.admin_id, tblAdmin.admin_name,
       tblPayment.payment_fee, tblPayment.payment_url,
       tblCategory.category_name,
       tblImage.image_url,tblVideo.video_url    
       from tblEvent E
       inner JOIN tblLocation ON E.location_id = tblLocation.location_id
       inner JOIN tblPayment ON E.event_id = tblPayment.event_id
       inner JOIN tblAdmin ON E.admin_id = tblAdmin.admin_id
       inner JOIN tblCategory ON e.category_id = tblCategory.category_id
       inner JOIN tblImage ON e.event_id = tblImage.event_id
       inner JOIN tblVideo ON e.event_id = tblVideo.event_id
       where event_name LIKE @event_name ";
                DataTable table = new DataTable();
                string sqlDataSource = _configuration.GetConnectionString("EventAppConn");
                SqlDataReader myReader;
                using (SqlConnection myCon = new SqlConnection(sqlDataSource))
                {
                    myCon.Open();
                    using (SqlCommand myCommand = new SqlCommand(query, myCon))
                    {
                        myCommand.Parameters.AddWithValue("@event_name", "%"+name+"%");
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
            }catch(Exception ex)
            {
                return BadRequest(new Response<string>(ex.Message));
            }
           
        }

        [HttpGet("get-event-by-id")]
        public IActionResult GetEventById(int id)
        {
            try
            {
                string query = @"Select E.event_id, E.admin_id, E.location_id, event_name, event_content, event_status, event_start, event_end, tblLocation.location_detail, 
       tblAdmin.admin_id, tblAdmin.admin_name,
       tblPayment.payment_fee, tblPayment.payment_url,
       tblCategory.category_name,
       tblImage.image_url,tblVideo.video_url    
       from tblEvent E
       INNER JOIN tblLocation ON E.location_id = tblLocation.location_id
       INNER JOIN tblPayment ON E.event_id = tblPayment.event_id
       INNER JOIN tblAdmin ON E.admin_id = tblAdmin.admin_id
       INNER JOIN tblCategory ON e.category_id = tblCategory.category_id
       INNER JOIN tblImage ON e.event_id = tblImage.event_id
       INNER JOIN tblVideo ON e.event_id = tblVideo.event_id
       where E.event_id = @event_id";
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


        [HttpGet("get-event-by-timne")]
        public IActionResult GetEventByTime(string start_time, string end_time)
        {
            try
            {
                string query = @"Select E.event_id, E.admin_id, E.location_id, event_name, event_content, event_status, event_start, event_end, tblLocation.location_detail, 
       tblAdmin.admin_id, tblAdmin.admin_name,
       tblPayment.payment_fee, tblPayment.payment_url,
       tblCategory.category_name,
       tblImage.image_url,tblVideo.video_url    
       from tblEvent E
       inner JOIN tblLocation ON E.location_id = tblLocation.location_id
       inner JOIN tblPayment ON E.event_id = tblPayment.event_id
       inner JOIN tblAdmin ON E.admin_id = tblAdmin.admin_id
       inner JOIN tblCategory ON e.category_id = tblCategory.category_id
       inner JOIN tblImage ON e.event_id = tblImage.event_id
       inner JOIN tblVideo ON e.event_id = tblVideo.event_id
                           where event_start between 
                            @d1 AND @d2";
                DataTable table = new DataTable();
                string sqlDataSource = _configuration.GetConnectionString("EventAppConn");
                SqlDataReader myReader;
                using (SqlConnection myCon = new SqlConnection(sqlDataSource))
                {
                    myCon.Open();
                    using (SqlCommand myCommand = new SqlCommand(query, myCon))
                    {
                        //myCommand.Parameters.AddWithValue("",MySqlDbType.Date).Value = dateTimePicker1;
                        myCommand.Parameters.AddWithValue("@d1", start_time);
                        myCommand.Parameters.AddWithValue("@d2", end_time);
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
            }catch (Exception ex)
            {
                return BadRequest(new Response<string>(ex.Message));
            }   
        }


        [HttpGet("get-event-by-timne-specific")]
        public IActionResult GetEventByTimeSpecific(string event_time)
        {
            try
            {
                string query = @"Select E.event_id, E.admin_id, E.location_id, event_name, event_content, event_status, event_start, event_end, tblLocation.location_detail, 
       tblAdmin.admin_id, tblAdmin.admin_name,
       tblPayment.payment_fee, tblPayment.payment_url,
       tblCategory.category_name,
       tblImage.image_url,tblVideo.video_url    
       from tblEvent E
       inner JOIN tblLocation ON E.location_id = tblLocation.location_id
       inner JOIN tblPayment ON E.event_id = tblPayment.event_id
       inner JOIN tblAdmin ON E.admin_id = tblAdmin.admin_id
       inner JOIN tblCategory ON e.category_id = tblCategory.category_id
       inner JOIN tblImage ON e.event_id = tblImage.event_id
       inner JOIN tblVideo ON e.event_id = tblVideo.event_id 
                           where event_start = @event_start";
                DataTable table = new DataTable();
                string sqlDataSource = _configuration.GetConnectionString("EventAppConn");
                SqlDataReader myReader;
                using (SqlConnection myCon = new SqlConnection(sqlDataSource))
                {
                    myCon.Open();
                    using (SqlCommand myCommand = new SqlCommand(query, myCon))
                    {
                        //myCommand.Parameters.AddWithValue("",MySqlDbType.Date).Value = dateTimePicker1;
                        myCommand.Parameters.AddWithValue("@event_start", event_time);
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
            }catch(Exception ex)
            {
                return BadRequest(new Response<string>(ex.Message));
            }
            
        }

        private bool CheckFeedBack(int eventId, int userId)
        {
            string query = @"SELECT *
                           FROM tblEventParticipated
                           where tblEventParticipated.event_id = @event_id and tblEventParticipated.users_id = @users_id";
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
