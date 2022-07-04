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
    public class UserController : ControllerBase
    {
        private readonly IConfiguration _configuration;
        public UserController(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        

        [HttpGet("get-list-user")]
        public IActionResult Get()
        {
            string query = @"select users_id, users_name, users_phone, users_address, users_email from dbo.tblUser";

            DataTable table = new DataTable();
            string sqlDataSource = _configuration.GetConnectionString("EventAppConn");
            SqlDataReader myReader;
            using(SqlConnection myCon = new SqlConnection(sqlDataSource))
            {
                myCon.Open();
                using(SqlCommand myCommand = new SqlCommand(query, myCon))
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

        [HttpPost("add-user")]
        public IActionResult Post(UserInfo user)
        {
            string query = @"insert into dbo.tblUser(users_id, users_name,users_phone,users_address,users_email) values(@users_id,@users_name,@users_phone,@users_address,@users_email)";

            DataTable table = new DataTable();
            string sqlDataSource = _configuration.GetConnectionString("EventAppConn");
            SqlDataReader myReader;
            using (SqlConnection myCon = new SqlConnection(sqlDataSource))
            {
                myCon.Open();
                using (SqlCommand myCommand = new SqlCommand(query, myCon))
                {
                    myCommand.Parameters.AddWithValue("@users_id", user.UserId);
                
                    myCommand.Parameters.AddWithValue("@users_name", user.UserName);
                    myCommand.Parameters.AddWithValue("@users_phone", user.Phone);
                    myCommand.Parameters.AddWithValue("@users_address", user.Address);
                    myCommand.Parameters.AddWithValue("@users_email", user.Email);
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

        [HttpPut("update-user")]
        public IActionResult Put(UserInfo user)
        {
            string query = @"update dbo.tblUser set users_name = @users_name , users_phone = @users_phone , users_address = @users_address , users_email = @users_email where users_id = @users_id";

            DataTable table = new DataTable();
            string sqlDataSource = _configuration.GetConnectionString("EventAppConn");
            SqlDataReader myReader;
            using (SqlConnection myCon = new SqlConnection(sqlDataSource))
            {
                myCon.Open();
                using (SqlCommand myCommand = new SqlCommand(query, myCon))
                {
                    myCommand.Parameters.AddWithValue("@users_name", user.UserName);
                    myCommand.Parameters.AddWithValue("@users_phone", user.Phone);
                    myCommand.Parameters.AddWithValue("@users_address", user.Address);
                    myCommand.Parameters.AddWithValue("@users_email", user.Email);
                    myCommand.Parameters.AddWithValue("@users_id", user.UserId);
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


        /* [HttpDelete("delete-user")]
         public JsonResult Delete(string name)
         {
             string query = @"delete from dbo.tblUser where users_name = @users_name";

             DataTable table = new DataTable();
             string sqlDataSource = _configuration.GetConnectionString("EventAppConn");
             SqlDataReader myReader;
             using (SqlConnection myCon = new SqlConnection(sqlDataSource))
             {
                 myCon.Open();
                 using (SqlCommand myCommand = new SqlCommand(query, myCon))
                 {
                     myCommand.Parameters.AddWithValue("@users_name", name);
                     myReader = myCommand.ExecuteReader();
                     myReader.Close();
                     myCon.Close();

                 }
             }
             return new JsonResult("Succeesful");
         }*/

        [HttpGet("get-user-by-id")]
        public IActionResult GetUserByID(string id)
        {
            string query = @"select users_id, users_name, users_phone, users_address, users_email from dbo.tblUser
             where users_id = @users_id";


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

        [HttpGet("get-user-by-name")]
        public IActionResult GetUserByName(string name)
        {
            string query = @"select users_id, users_name, users_phone, users_address, users_email from dbo.tblUser
             where users_name like concat  ( @users_name,'%')";


            DataTable table = new DataTable();
            string sqlDataSource = _configuration.GetConnectionString("EventAppConn");
            SqlDataReader myReader;
            using (SqlConnection myCon = new SqlConnection(sqlDataSource))
            {
                myCon.Open();
                using (SqlCommand myCommand = new SqlCommand(query, myCon))
                {
                    myCommand.Parameters.AddWithValue("@users_name", name);
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

    }
}
