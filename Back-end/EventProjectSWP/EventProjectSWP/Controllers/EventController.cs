using EventProjectSWP.DTOs;
using EventProjectSWP.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using MySql.Data.MySqlClient;
using System;
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
                string query = @"Select event_id, event_name, event_content, event_timeline,
                            created_by, created_by,event_status,payment_status,category_id,location_id
                           ,admin_id 
                            From dbo.tblEvent";

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

        [HttpGet("show-upcoming-event")]
        public IActionResult Show_upcoming_event()
        {
            try
            {
                string query = @"Select event_id, event_name, event_content, event_timeline,
                            created_by, created_by,event_status,payment_status,category_id,location_id
                           ,admin_id From dbo.tblEvent A
                           where A.event_timeline >= GETDATE()";

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
                string query = @"Select event_id, event_name, event_content, event_timeline,
                            created_by, created_by,event_status,payment_status,category_id,location_id
                           ,admin_id From dbo.tblEvent A
                           where A.event_timeline < GETDATE()";

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
                string query = @"insert into dbo.tblEvent(event_name,event_content,event_timeline,created_by,event_code,event_status,payment_status,category_id,location_id,admin_id) 
values (@event_name,@event_content,@event_timeline,@created_by,@event_code,@event_status,@payment_status,@category_id,@location_id,@admin_id)";

                string sqlDataSource = _configuration.GetConnectionString("EventAppConn");
                SqlDataReader myReader;
                using (SqlConnection myCon = new SqlConnection(sqlDataSource))
                {
                    myCon.Open();
                    using (SqlCommand myCommand = new SqlCommand(query, myCon))
                    {
                        myCommand.Parameters.AddWithValue("@event_name", addEvent.EventName);
                        myCommand.Parameters.AddWithValue("@event_content", addEvent.EventContent);
                        myCommand.Parameters.AddWithValue("@event_timeline", addEvent.EventTimeline);
                        myCommand.Parameters.AddWithValue("@created_by", addEvent.CreatedBy);
                        myCommand.Parameters.AddWithValue("@event_code", addEvent.EventCode);
                        myCommand.Parameters.AddWithValue("@event_status", addEvent.EventStatus);
                        myCommand.Parameters.AddWithValue("@payment_status", addEvent.EventStatus);
                        myCommand.Parameters.AddWithValue("@category_id", addEvent.CategoryID);
                        myCommand.Parameters.AddWithValue("@location_id", addEvent.LocationID);
                        myCommand.Parameters.AddWithValue("@admin_id ", addEvent.AdminID);
                        myReader = myCommand.ExecuteReader();
                        myReader.Close();
                        myCon.Close();
                    }
                }
                return Ok("Add Sucessfully");
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
                           event_timeline = @event_timeline, created_by = @created_by,  
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
                        myCommand.Parameters.AddWithValue("@event_name", Event.EventName);
                        myCommand.Parameters.AddWithValue("@event_content", Event.EventContent);
                        myCommand.Parameters.AddWithValue("@event_timeline", Event.EventTimeline);
                        myCommand.Parameters.AddWithValue("@created_by", Event.CreatedBy);
                        myCommand.Parameters.AddWithValue("@event_code", Event.EventCode);
                        myCommand.Parameters.AddWithValue("@event_status", Event.EventStatus);
                        myCommand.Parameters.AddWithValue("@payment_status", Event.EventStatus);
                        myCommand.Parameters.AddWithValue("@category_id", Event.CategoryID);
                        myCommand.Parameters.AddWithValue("@location_id", Event.LocationID);
                        myCommand.Parameters.AddWithValue("@admin_id ", Event.AdminID);
                        myCommand.Parameters.AddWithValue("@event_id", Event.EventID);
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
                string query = @"select event_content,created_by,event_code,event_status,payment_status,category_id,admin_id 
                              from dbo.tblEvent where event_name like concat (@event_name,'%')";
                DataTable table = new DataTable();
                string sqlDataSource = _configuration.GetConnectionString("EventAppConn");
                SqlDataReader myReader;
                using (SqlConnection myCon = new SqlConnection(sqlDataSource))
                {
                    myCon.Open();
                    using (SqlCommand myCommand = new SqlCommand(query, myCon))
                    {
                        myCommand.Parameters.AddWithValue("@event_name", name);
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
        [HttpGet("get-event-by-timne")]
        public IActionResult GetEventByTime(string start_time, string end_time)
        {
            try
            {
                string query = @"select event_content,created_by,event_code,event_status,payment_status,category_id,admin_id  from tblEvent 
                           where event_timeline between 
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
                string query = @"select event_content,created_by,event_code,event_status,payment_status,category_id,admin_id  from tblEvent 
                           where event_timeline = @event_timeline";
                DataTable table = new DataTable();
                string sqlDataSource = _configuration.GetConnectionString("EventAppConn");
                SqlDataReader myReader;
                using (SqlConnection myCon = new SqlConnection(sqlDataSource))
                {
                    myCon.Open();
                    using (SqlCommand myCommand = new SqlCommand(query, myCon))
                    {
                        //myCommand.Parameters.AddWithValue("",MySqlDbType.Date).Value = dateTimePicker1;
                        myCommand.Parameters.AddWithValue("@event_timeline", event_time);
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

    }
}
