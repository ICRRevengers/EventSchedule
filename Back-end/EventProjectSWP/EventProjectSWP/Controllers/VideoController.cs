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
    public class VideoController : ControllerBase
    {
        private readonly IConfiguration _configuration;
        public VideoController(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        [HttpPost("add-video")]
        public JsonResult Post(Video video)
        {
            string query = @"insert into tblVideo values (@video_id,@video_url,@event_id)";

            DataTable table = new DataTable();
            string sqlDataSource = _configuration.GetConnectionString("EventAppConn");
            SqlDataReader myReader;
            using (SqlConnection myCon = new SqlConnection(sqlDataSource))
            {
                myCon.Open();
                using (SqlCommand myCommand = new SqlCommand(query, myCon))
                {
                    myCommand.Parameters.AddWithValue("@video_id", video.VideoId);
                    myCommand.Parameters.AddWithValue("@video_url", video.VideoUrl);
                    myCommand.Parameters.AddWithValue("@event_id", video.EventId);
                    myReader = myCommand.ExecuteReader();
                    myReader.Close();
                    myCon.Close();
                }
            }
            return new JsonResult("Succeesful");
        }
        [HttpGet("get-video")]
        public JsonResult Get()
        {
            string query = @"select * from tblVideo";

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
    }
}
