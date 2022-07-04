<<<<<<< HEAD
﻿using EventProjectSWP.Models;
=======
using EventProjectSWP.DTOs;
using EventProjectSWP.Models;
using EventProjectSWP.Services;
>>>>>>> main
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using System.Data;
using System.Data.SqlClient;
<<<<<<< HEAD
=======
using System.Threading.Tasks;
>>>>>>> main

namespace EventProjectSWP.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    
    public class AdminController : ControllerBase
    {
        private readonly IConfiguration _configuration;
        public AdminController(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        [HttpGet("get-list-admin")]
        public JsonResult Get()
        {
            string query = @"select admin_id , admin_name, admin_phone , admin_email from dbo.tblAdmin";

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

        [HttpPut("update-admin")]
        public JsonResult Put(Admin club)
        {
            string query = @"update dbo.tblAdmin set admin_name =@admin_name , admin_phone=@admin_phone , admin_email=@admin_email where admin_id =@admin_id";

            DataTable table = new DataTable();
            string sqlDataSource = _configuration.GetConnectionString("EventAppConn");
            SqlDataReader myReader;
            using (SqlConnection myCon = new SqlConnection(sqlDataSource))
            {
                myCon.Open();
                using (SqlCommand myCommand = new SqlCommand(query, myCon))
                {
                    myCommand.Parameters.AddWithValue("@admin_name", club.AdminName);
                    myCommand.Parameters.AddWithValue("@admin_phone", club.AdminPhone);
                    myCommand.Parameters.AddWithValue("@admin_email", club.AdminEmail);
                    myCommand.Parameters.AddWithValue("@admin_id", club.AdminID);
                    myReader = myCommand.ExecuteReader();
                    myReader.Close();
                    myCon.Close();

                }
            }
            return new JsonResult("Succeesful");
        }

        [HttpGet("get-admin-by-id")]
        public JsonResult GetClubById(string id)
        {
            string query = @"select admin_name, admin_phone , admin_email from dbo.tblAdmin where admin_id = @admin_id";

            DataTable table = new DataTable();
            string sqlDataSource = _configuration.GetConnectionString("EventAppConn");
            SqlDataReader myReader;
            using (SqlConnection myCon = new SqlConnection(sqlDataSource))
            {
                myCon.Open();
                using (SqlCommand myCommand = new SqlCommand(query, myCon))
                {
                    myCommand.Parameters.AddWithValue("@admin_id", id);
                    myReader = myCommand.ExecuteReader();
                    table.Load(myReader);
                    myReader.Close();
                    myCon.Close();

                }
            }
            return new JsonResult(table);
        }

        [HttpGet("get-admin-by-name")]
<<<<<<< HEAD
        public JsonResult GetClubByName(string name)
=======
        public async Task<IActionResult> GetClubByName(string name)
>>>>>>> main
        {
            string query = @"select admin_name, admin_phone , admin_email from dbo.tblAdmin where admin_name like concat (@admin_name, '%')";


            DataTable table = new DataTable();
            string sqlDataSource = _configuration.GetConnectionString("EventAppConn");
            SqlDataReader myReader;
            using (SqlConnection myCon = new SqlConnection(sqlDataSource))
            {
                myCon.Open();
                using (SqlCommand myCommand = new SqlCommand(query, myCon))
                {
                    myCommand.Parameters.AddWithValue("@admin_name", name);
                    myReader = myCommand.ExecuteReader();
                    table.Load(myReader);
                    myReader.Close();
                    myCon.Close();

                }
            }
<<<<<<< HEAD
            return new JsonResult(table);
        }
        [HttpGet("login-admin")]
        public JsonResult loginClub(string clubName, string clubPassword)
        {
            string query = @"select admin_name, admin_phone , admin_email from dbo.tblAdmin where admin_name =@admin_name and admin_password = @admin_password";
=======
            if (table.Rows.Count == 0)
            {
                return BadRequest("No data");
            }
                return Ok(table);
        }
        [HttpPost("login-admin")]
        public async Task<IActionResult> loginAdmin(LoginAdmin loginAdmin)
        {
            Authentication _authentication = new Authentication(_configuration);
            string query = @"select * from tblAdmin where admin_email = @admin_email and admin_password=@admin_password";
>>>>>>> main
            DataTable table = new DataTable();
            string sqlDataSource = _configuration.GetConnectionString("EventAppConn");
            SqlDataReader myReader;
            using (SqlConnection myCon = new SqlConnection(sqlDataSource))
            {
                myCon.Open();
                using (SqlCommand myCommand = new SqlCommand(query, myCon))
                {
<<<<<<< HEAD
                    myCommand.Parameters.AddWithValue("@admin_name", clubName);
                    myCommand.Parameters.AddWithValue("@admin_password", clubPassword);
=======
                    myCommand.Parameters.AddWithValue("@admin_email", loginAdmin.adminMail);
                    myCommand.Parameters.AddWithValue("@admin_password", loginAdmin.adminPassword);
>>>>>>> main
                    myReader = myCommand.ExecuteReader();
                    table.Load(myReader);
                    myReader.Close();
                    myCon.Close();

                }
            }
<<<<<<< HEAD
            return new JsonResult(table);
=======
            if (table.Rows.Count == 0)
            {
                return Redirect("https://localhost:3000/login?error=invalid-username-or-password");
            }

            UserInfo userInfo = new UserInfo()
            {
                Email = table.Rows[0]["admin_email"].ToString(),
                UserName = table.Rows[0]["admin_name"].ToString(),
            };
            var accessToken = _authentication.GenerateToken(userInfo);
            return Redirect($"https://localhost:3000/login?token={accessToken}");
>>>>>>> main

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




        /*  [HttpPut("Check attend")]
          public JsonResult CheckAttend(EventParticipated user, bool status)
          {
              string query = @"update tblEventParticipated set users_status = @users_status where event_id = @event_id, users_id = @users_id";
              DataTable table = new DataTable();
              string sqlDataSource = _configuration.GetConnectionString("EventAppConn");
              SqlDataReader myReader;
              using (SqlConnection myCon = new SqlConnection(sqlDataSource))
              {
                  myCon.Open();
                  using (SqlCommand myCommand = new SqlCommand(query, myCon))
                  {

                      myCommand.Parameters.AddWithValue("@users_id", user.UserID);
                      myCommand.Parameters.AddWithValue("@users_status", status);
                      myReader = myCommand.ExecuteReader();
                      myReader.Close();
                      myCon.Close();

                  }
              }
              return new JsonResult("Check attend success");
          }*/



        [HttpPut("Check attend")]
            public JsonResult CheckAttend(bool status, int user_id, int event_id)
            //public JsonResult CheckAttend(EventParticipated ev)
        {
            string query = @"update tblEventParticipated set users_status = @users_status where event_id = @event_id and users_id = @users_id";
            DataTable table = new DataTable();
            string sqlDataSource = _configuration.GetConnectionString("EventAppConn");
            SqlDataReader myReader;
            using (SqlConnection myCon = new SqlConnection(sqlDataSource))
            {
                myCon.Open();
                using (SqlCommand myCommand = new SqlCommand(query, myCon))
                {
                    myCommand.Parameters.AddWithValue("@event_id", event_id);
                    myCommand.Parameters.AddWithValue("@users_id", user_id);
                    myCommand.Parameters.AddWithValue("@users_status", status);
                    /*  myCommand.Parameters.AddWithValue("@event_id", ev.EventID);
                      myCommand.Parameters.AddWithValue("@users_id", ev.UserID);
                      myCommand.Parameters.AddWithValue("@users_status", ev.users_status);*/
                    myReader = myCommand.ExecuteReader();
                    myReader.Close();
                    myCon.Close();

                }
            }
            return new JsonResult("Check attend success");
        }

    }
}
