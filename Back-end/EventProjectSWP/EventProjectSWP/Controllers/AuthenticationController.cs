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
using System;

namespace EventProjectSWP.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [EnableCors("AllowOrigin")]
    public class AuthenticationController : ControllerBase
    {
        
        private readonly IConfiguration _configuration;
        private readonly IAuthentication _authentication;

        public AuthenticationController(IConfiguration configuration, IAuthentication authentication)
        {    
            _configuration = configuration;
            _authentication = authentication;
        }
        //login cho user bằng google
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
                    myCommand.Parameters.AddWithValue("@users_email", userInfo.email);
                    myReader = myCommand.ExecuteReader();
                    table.Load(myReader);
                    if (table.Rows.Count == 0)
                    {
                        string addUser = @"insert into tblUser (users_name,users_phone,users_address,users_email) values (@users_name,@users_phone,@users_address,@users_email)";
                        using (SqlCommand myCommand1 = new SqlCommand(addUser, myCon))
                        {
                            
                            myCommand1.Parameters.AddWithValue("@users_name", userInfo.userName);
                            myCommand1.Parameters.AddWithValue("@users_phone", "");
                            myCommand1.Parameters.AddWithValue("@users_address", "");
                            myCommand1.Parameters.AddWithValue("@users_email", userInfo.email);                            
                            myReader1 = myCommand1.ExecuteReader();
                            myReader1.Close();
                        }
                        myReader = myCommand.ExecuteReader();
                        table.Load(myReader);
                    }
                    myReader.Close();
                    myCon.Close();
                }
            }
            var user = new UserInfo()
            {
                userId = Convert.ToInt32(table.Rows[0]["users_id"]),
                userName = table.Rows[0]["users_name"].ToString(),
                email = table.Rows[0]["users_email"].ToString(),
            };
            var accessToken = await _authentication.GenerateTokenUser(user);
            return Redirect($"http://localhost:3000/login?token={accessToken}");
        }
    }
}