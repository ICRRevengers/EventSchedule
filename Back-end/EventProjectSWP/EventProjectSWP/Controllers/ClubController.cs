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
    public class ClubController : ControllerBase
    {
        private readonly IConfiguration _configuration;
        public ClubController(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        [HttpGet("get-list-club")]
        public JsonResult Get()
        {
            string query = @"select club_id , club_name, club_phone , club_email from dbo.tblClub";

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

        [HttpPut("update-club")]
        public JsonResult Put(Club club)
        {
            string query = @"update dbo.tblClub set club_name =@club_name , club_phone=@club_phone , club_email=@club_email where club_id =@club_id";

            DataTable table = new DataTable();
            string sqlDataSource = _configuration.GetConnectionString("EventAppConn");
            SqlDataReader myReader;
            using (SqlConnection myCon = new SqlConnection(sqlDataSource))
            {
                myCon.Open();
                using (SqlCommand myCommand = new SqlCommand(query, myCon))
                {
                    myCommand.Parameters.AddWithValue("@club_name", club.ClubName);
                    myCommand.Parameters.AddWithValue("@club_phone", club.ClubPhone);
                    myCommand.Parameters.AddWithValue("@club_email", club.ClubEmail);
                    myCommand.Parameters.AddWithValue("@club_id", club.ClubID);
                    myReader = myCommand.ExecuteReader();
                    myReader.Close();
                    myCon.Close();

                }
            }
            return new JsonResult("Succeesful");
        }

        [HttpGet("get-club-by-id")]
        public JsonResult GetClubById(string id)
        {
            string query = @"select club_name, club_phone , club_email from dbo.tblClub where club_id = @club_id";

            DataTable table = new DataTable();
            string sqlDataSource = _configuration.GetConnectionString("EventAppConn");
            SqlDataReader myReader;
            using (SqlConnection myCon = new SqlConnection(sqlDataSource))
            {
                myCon.Open();
                using (SqlCommand myCommand = new SqlCommand(query, myCon))
                {
                    myCommand.Parameters.AddWithValue("@club_id", id);
                    myReader = myCommand.ExecuteReader();
                    table.Load(myReader);
                    myReader.Close();
                    myCon.Close();

                }
            }
            return new JsonResult(table);
        }

        [HttpGet("get-club-by-name")]
        public JsonResult GetClubByName(string name)
        {
            string query = @"select club_name, club_phone , club_email from dbo.tblClub where club_name = @club_name";


            DataTable table = new DataTable();
            string sqlDataSource = _configuration.GetConnectionString("EventAppConn");
            SqlDataReader myReader;
            using (SqlConnection myCon = new SqlConnection(sqlDataSource))
            {
                myCon.Open();
                using (SqlCommand myCommand = new SqlCommand(query, myCon))
                {
                    myCommand.Parameters.AddWithValue("@club_name", name);
                    myReader = myCommand.ExecuteReader();
                    table.Load(myReader);
                    myReader.Close();
                    myCon.Close();

                }
            }
            return new JsonResult(table);
        }
        [HttpGet("login-club")]
        public JsonResult loginClub(string clubName, string clubPassword)
        {
            string query = @"select club_name, club_phone , club_email from dbo.tblClub where club_name =@club_name and club_password = @club_password";
            DataTable table = new DataTable();
            string sqlDataSource = _configuration.GetConnectionString("EventAppConn");
            SqlDataReader myReader;
            using (SqlConnection myCon = new SqlConnection(sqlDataSource))
            {
                myCon.Open();
                using (SqlCommand myCommand = new SqlCommand(query, myCon))
                {
                    myCommand.Parameters.AddWithValue("@club_name", clubName);
                    myCommand.Parameters.AddWithValue("@club_password", clubPassword);
                    myReader = myCommand.ExecuteReader();
                    table.Load(myReader);
                    myReader.Close();
                    myCon.Close();

                }
            }
            return new JsonResult(table);

        }

        /*[HttpPut("Check attend")]
        public JsonResult CheckAttend(UserInfo user, int id)
        {
            string query = @"update dbo.tblUser set user_status = @user_status where users_id =@users_id";
            DataTable table = new DataTable();
            string sqlDataSource = _configuration.GetConnectionString("EventAppConn");
            SqlDataReader myReader;
            using (SqlConnection myCon = new SqlConnection(sqlDataSource))
            {
                myCon.Open();
                using (SqlCommand myCommand = new SqlCommand(query, myCon))
                {
                    myCommand.Parameters.AddWithValue("@users_id", id);
                    myCommand.Parameters.AddWithValue("@user_status", user.user_status);                   
                    myReader = myCommand.ExecuteReader();
                    myReader.Close();
                    myCon.Close();

                }
            }
            return new JsonResult("Check attend success");
        }*/

        [HttpPut("Check attend")]
        public JsonResult CheckAttend(bool status, int id)
        {
            string query = @"update tblEventParticipated set users_status = @users_status where users_id = @users_id";
            DataTable table = new DataTable();
            string sqlDataSource = _configuration.GetConnectionString("EventAppConn");
            SqlDataReader myReader;
            using (SqlConnection myCon = new SqlConnection(sqlDataSource))
            {
                myCon.Open();
                using (SqlCommand myCommand = new SqlCommand(query, myCon))
                {
                    myCommand.Parameters.AddWithValue("@users_id", id);
                    myCommand.Parameters.AddWithValue("@users_status", status);
                    myReader = myCommand.ExecuteReader();
                    myReader.Close();
                    myCon.Close();

                }
            }
            return new JsonResult("Check attend success");
        }

    }
}
