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
    public class EventController : ControllerBase
    {
        private readonly IConfiguration _configuration;
        public EventController(IConfiguration configuration)
        {
            _configuration = configuration;
        }


        [HttpGet("get-event-list")]
        public JsonResult Get()
        {
            string query = @"Select event_id, event_name, event_content, event_timeline,
                            created_by, created_by,event_status,payment_status,category_id,location_id,
                            image_id,video_id,users_id,club_id 
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
            return new JsonResult(table);
        }

        [HttpPost("add-event")]
        public JsonResult Post(Event Event)
        {
            string query = @"insert into dbo.tblEvent(event_id,event_name,event_content,event_timeline,created_by,event_code,event_status,payment_status,category_id,location_id,image_id,video_id,users_id,club_id) 
values (@event_id,@event_name,@event_content,@event_timeline,@created_by,@event_code,@event_status,@payment_status,@category_id,@location_id,@image_id,@video_id,@users_id,@club_id)";

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
                    myCommand.Parameters.AddWithValue("@image_id", Event.ImageID);
                    myCommand.Parameters.AddWithValue("@video_id", Event.VideoID);
                    myCommand.Parameters.AddWithValue("@users_id", Event.UserID);
                    myCommand.Parameters.AddWithValue("@club_id ", Event.ClubID);
                    myCommand.Parameters.AddWithValue("@event_id", Event.EventID);
                    myReader = myCommand.ExecuteReader();
                    myReader.Close();
                    myCon.Close();

                }
            }
            return new JsonResult("Succeesful");
        }

        [HttpPut("update-event")]
        public JsonResult Put(Event Event)
        {
            string query = @"update dbo.tblEvent 
                           set event_name = @event_name, event_content = @event_content, 
                           event_timeline = @event_timeline, created_by = @created_by,  
                           event_code = @event_code, event_status = @event_status, 
                           payment_status = @payment_status, category_id = @category_id, 
                           location_id = @location_id, image_id = @image_id, 
                           video_id = @video_id, users_id = @users_id, club_id = @club_id 
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
                    myCommand.Parameters.AddWithValue("@image_id", Event.ImageID);
                    myCommand.Parameters.AddWithValue("@video_id", Event.VideoID);
                    myCommand.Parameters.AddWithValue("@users_id", Event.UserID);
                    myCommand.Parameters.AddWithValue("@club_id ", Event.ClubID);
                    myCommand.Parameters.AddWithValue("@event_id", Event.EventID);
                    myReader = myCommand.ExecuteReader();
                    myReader.Close();
                    myCon.Close();

                }
            }
            return new JsonResult("Succeesful");
        }

        [HttpDelete("delete-event")]
        public JsonResult Delete(string id)
        {
            string query = @"delete from dbo.tblEvent where event_id = @event_id";

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
                    myReader.Close();
                    myCon.Close();

                }
            }
            return new JsonResult("Succeesful");
        }

        [HttpGet("get-event-by-name")]
        public JsonResult GetEventByName(string name)
        {
            string query = @"select event_content,created_by,event_code,event_status,payment_status,category_id,location_id,image_id,video_id,users_id,club_id 
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
            return new JsonResult(table);
        }

    }
}
