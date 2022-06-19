using EventProjectSWP.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace EventProjectSWP.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LoginController : ControllerBase
    {

        private readonly IConfiguration _configuration;
        public LoginController(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        [Route("api/values/GetLogin")]
        [HttpPost]
        public string GetLogin(Club login)
        {
            /*BAL bal = new BAL();
            string response = bal.GetLogin(login);
            return response;*/
            SqlDataAdapter da = new SqlDataAdapter();
            da = new SqlDataAdapter("Select club_name, club_phone from tblClub where club_email = '" + login.ClubEmail + "' and club_password = '" + login.ClubPassword + "' ", con);
           DataTable dt = new DataTable();
            da.Fill(dt);
            if (dt.Rows.Count > 0)
                return "logged in";
            else
                return "login fail";
        }



        [HttpGet("login-by-admin-blub")]
        public JsonResult GetClubByName(Club login)
        {
            string query = @"Select * from tblClub where club_email = '" + login.ClubEmail + "' and club_password = '" + login.ClubPassword + "' ";

           /* SqlDataAdapter da = new SqlDataAdapter();
            da = new SqlDataAdapter("Select club_name, club_phone from tblClub where club_email = '" + login.ClubEmail + "' and club_password = '" + login.ClubPassword + "' ", con);*/

            DataTable table = new DataTable();
            string sqlDataSource = _configuration.GetConnectionString("EventAppConn");
            SqlDataReader myReader;
            using (SqlConnection myCon = new SqlConnection(sqlDataSource))
            {
                myCon.Open();
                using (SqlCommand myCommand = new SqlCommand(query, myCon))
                {
                    myCommand.Parameters.AddWithValue("@club_email", login.ClubEmail);
                    myCommand.Parameters.AddWithValue("@club_password", login.ClubPassword);
                    myReader = myCommand.ExecuteReader();
                    //table.Load(myReader);

                    myReader.Close();
                    myCon.Close();

                }
            }
            return new JsonResult(table);
        }
    }
}
