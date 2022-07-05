using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication.Google;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using EventProjectSWP.Models;
using Microsoft.AspNetCore.Cors;
using System.Net.Http;
using System.Net;
using EventProjectSWP.Services;
using System.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using System.Data;

namespace EventProjectSWP.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [EnableCors("AllowOrigin")]
    public class AuthenticationController : ControllerBase
    {
        
        private readonly IConfiguration _configuration;

        public AuthenticationController( IConfiguration configuration)
        {
           
            _configuration = configuration;
        }
        //login bang google cho users
        [HttpGet("google-login")]
        public IActionResult GoogleLogin()
        {
            var properties = new AuthenticationProperties { RedirectUri = Url.Action("GoogleResponse") };

            return Challenge(properties, GoogleDefaults.AuthenticationScheme);
        }
        [HttpGet]
        [Route("~/sigin-google")]
        public async Task<IActionResult> GoogleResponse()
        {
            Authentication _authentication = new Authentication(_configuration);
            var result = await HttpContext.AuthenticateAsync(CookieAuthenticationDefaults.AuthenticationScheme);
            var userInfo = _authentication.GetUserInfo(result);
            if (userInfo == null)
            {
                return Redirect("http://localhost:3000/login?error=fpt-invalid-email");
            }
            // Check email co ton tai chua
            string query = @"select * from tblUser Where users_email Like @users_email";

            DataTable table = new DataTable();
            string sqlDataSource = _configuration.GetConnectionString("EventAppConn");
            SqlDataReader myReader;
            SqlDataReader myReader1;
            using (SqlConnection myCon = new SqlConnection(sqlDataSource))
            {
                myCon.Open();
                using (SqlCommand myCommand = new SqlCommand(query, myCon))
                {
                    myCommand.Parameters.AddWithValue("@users_email", userInfo.Email);
                    myReader = myCommand.ExecuteReader();
                    table.Load(myReader);
                    if (table.Rows.Count == 0)
                    {
                        string addUser = @"insert into tblUser (users_id,users_name,users_phone,users_address,users_email) values (@users_id,@users_name,@users_phone,@users_address,@users_email)";
                        using (SqlCommand myCommand1 = new SqlCommand(addUser, myCon))
                        {
                            myCommand1.Parameters.AddWithValue("@users_id", "");
                            myCommand1.Parameters.AddWithValue("@users_name", userInfo.UserName);
                            myCommand1.Parameters.AddWithValue("@users_phone", "");
                            myCommand1.Parameters.AddWithValue("@users_address", "");
                            myCommand1.Parameters.AddWithValue("@users_email", userInfo.Email);
                            
                            myReader1 = myCommand1.ExecuteReader();
                            myReader1.Close();
                        }
                    }
            myReader.Close();
                    myCon.Close();
                }
            }
            var accessToken = await _authentication.GenerateToken(userInfo);
            return Redirect($"http://localhost:3000/login?token={accessToken}");
        }
    }
}