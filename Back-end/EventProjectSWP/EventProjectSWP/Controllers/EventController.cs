using EventProjectSWP.DTOs;
using EventProjectSWP.Models;
using EventProjectSWP.Services;
using EventProjectSWP.Settings;
using Firebase.Auth;
using Firebase.Storage;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Threading;
using System.Threading.Tasks;

namespace EventProjectSWP.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EventController : ControllerBase
    {
        private static string ApiKey = "AIzaSyBD1WOLrBowJynUn__LBCxB8l1vWS9JI2k";
        private static string Bucket = "testfirebase-a9644.appspot.com";
        private static string AuthEmail = "duc123456789987654321@gmail.com";
        private static string AuthPassword = "123456789987654321";
        private readonly IHostingEnvironment _env;
        private readonly IConfiguration _configuration;
        public EventController(IConfiguration configuration, IHostingEnvironment env)
        {
            _configuration = configuration;
            _env = env;
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
       left JOIN tblLocation ON E.location_id = tblLocation.location_id
       left JOIN tblPayment ON E.event_id = tblPayment.event_id
       left JOIN tblAdmin ON E.admin_id = tblAdmin.admin_id
       left JOIN tblCategory ON e.category_id = tblCategory.category_id
       left JOIN tblImage ON e.event_id = tblImage.event_id
       left JOIN tblVideo ON e.event_id = tblVideo.event_id";
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


        [HttpGet("get-event-club-admin-own")]
        public IActionResult GêtventClubAdminOwn(int adminId)
        {
            try
            {
                
                string query = @"Select E.event_id, E.admin_id, E.location_id, event_name, event_content, event_status, event_start, event_end, tblLocation.location_detail, 
       tblAdmin.admin_name,
       tblPayment.payment_fee, tblPayment.payment_url,
       tblCategory.category_name,
       tblImage.image_url,tblVideo.video_url    
       from tblEvent E
       left JOIN tblLocation ON E.location_id = tblLocation.location_id
       left JOIN tblPayment ON E.event_id = tblPayment.event_id
       left JOIN tblAdmin ON E.admin_id = tblAdmin.admin_id
       left JOIN tblCategory ON e.category_id = tblCategory.category_id
       left JOIN tblImage ON e.event_id = tblImage.event_id
       left JOIN tblVideo ON e.event_id = tblVideo.event_id
       where tblAdmin.admin_id = @admin_id";
                DataTable table = new DataTable();
                string sqlDataSource = _configuration.GetConnectionString("EventAppConn");
                SqlDataReader myReader;
                using (SqlConnection myCon = new SqlConnection(sqlDataSource))
                {
                    myCon.Open();
                    using (SqlCommand myCommand = new SqlCommand(query, myCon))
                    {
                        myCommand.Parameters.AddWithValue("@admin_id", adminId);
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
       tblCategory.category_name,
       tblImage.image_url,tblVideo.video_url    
       from tblEvent E
       left JOIN tblLocation ON E.location_id = tblLocation.location_id
       left JOIN tblPayment ON E.event_id = tblPayment.event_id
       left JOIN tblAdmin ON E.admin_id = tblAdmin.admin_id
       left JOIN tblCategory ON e.category_id = tblCategory.category_id
       left JOIN tblImage ON e.event_id = tblImage.event_id
       left JOIN tblVideo ON e.event_id = tblVideo.event_id
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



        [HttpGet("show-upcoming-event-of-a-club")]
        public IActionResult Show_upcoming_event_of_a_club(int adminId)
        {
            try
            {
                string query = @"Select E.event_id, E.admin_id, E.location_id, event_name, event_content, event_status, event_start, event_end, tblLocation.location_detail, 
       tblAdmin.admin_id, tblAdmin.admin_name,
       tblPayment.payment_fee, tblPayment.payment_url,
       tblCategory.category_name,
       tblImage.image_url,tblVideo.video_url    
       from tblEvent E
       left JOIN tblLocation ON E.location_id = tblLocation.location_id
       left JOIN tblPayment ON E.event_id = tblPayment.event_id
       left JOIN tblAdmin ON E.admin_id = tblAdmin.admin_id
       left JOIN tblCategory ON e.category_id = tblCategory.category_id
       left JOIN tblImage ON e.event_id = tblImage.event_id
       left JOIN tblVideo ON e.event_id = tblVideo.event_id
       where event_start >= GETDATE()
       and E.admin_id = @admin_id  ";

                DataTable table = new DataTable();
                string sqlDataSource = _configuration.GetConnectionString("EventAppConn");
                SqlDataReader myReader;
                using (SqlConnection myCon = new SqlConnection(sqlDataSource))
                {
                    myCon.Open();
                    using (SqlCommand myCommand = new SqlCommand(query, myCon))
                    {
                        myCommand.Parameters.AddWithValue("@admin_id", adminId);
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
       tblCategory.category_name,
       tblImage.image_url,tblVideo.video_url    
       from tblEvent E
       left JOIN tblLocation ON E.location_id = tblLocation.location_id
       left JOIN tblPayment ON E.event_id = tblPayment.event_id
       left JOIN tblAdmin ON E.admin_id = tblAdmin.admin_id
       left JOIN tblCategory ON e.category_id = tblCategory.category_id
       left JOIN tblImage ON e.event_id = tblImage.event_id
       left JOIN tblVideo ON e.event_id = tblVideo.event_id
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



        [HttpGet("show-past-event-of-a-club")]
        public IActionResult Show_past_event_of_a_club(int adminId)
        {
            try
            {
                string query = @"Select E.event_id, E.admin_id, E.location_id, event_name, event_content, event_status, event_start, event_end, tblLocation.location_detail, 
       tblAdmin.admin_id, tblAdmin.admin_name,
       tblPayment.payment_fee, tblPayment.payment_url,
       tblCategory.category_name,
       tblImage.image_url,tblVideo.video_url    
       from tblEvent E
       left JOIN tblLocation ON E.location_id = tblLocation.location_id
       left JOIN tblPayment ON E.event_id = tblPayment.event_id
       left JOIN tblAdmin ON E.admin_id = tblAdmin.admin_id
       left JOIN tblCategory ON e.category_id = tblCategory.category_id
       left JOIN tblImage ON e.event_id = tblImage.event_id
       left JOIN tblVideo ON e.event_id = tblVideo.event_id
       where event_start < GETDATE()
       and E.admin_id = @admin_id  ";

                DataTable table = new DataTable();
                string sqlDataSource = _configuration.GetConnectionString("EventAppConn");
                SqlDataReader myReader;
                using (SqlConnection myCon = new SqlConnection(sqlDataSource))
                {
                    myCon.Open();
                    using (SqlCommand myCommand = new SqlCommand(query, myCon))
                    {
                        myCommand.Parameters.AddWithValue("@admin_id", adminId);
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
        public IActionResult PostAsync(AddEvent eventcs)
        {
            //System.Diagnostics.Debug.WriteLine(eventcs.eventStart);
            /*
             [FromForm] MultipleFilesUpload objectFile
            CheckEvent CheckEvent = new CheckEvent();
           List<string> errorList = CheckEvent.checkAddEventNull(eventName, eventCotent, eventStart, eventEnd, categoryID, locationID, adminID);
           if (errorList.Count > 0)
           {
               return BadRequest(new Response<List<string>>(errorList));
           }
           string eventName, string eventCotent, DateTime eventStart, DateTime eventEnd, bool eventStatus, string categoryID, string locationID, string adminID, string paymentUrl, int paymentFee
             myCommand.Parameters.AddWithValue("@event_name", eventName);
                        myCommand.Parameters.AddWithValue("@event_content", eventCotent);
                        myCommand.Parameters.AddWithValue("@event_start", eventStart);
                        myCommand.Parameters.AddWithValue("@event_end", eventEnd);
                        myCommand.Parameters.AddWithValue("@event_status", eventStatus);
                        myCommand.Parameters.AddWithValue("@category_id", categoryID);
                        myCommand.Parameters.AddWithValue("@location_id", locationID);
                        myCommand.Parameters.AddWithValue("@admin_id ", adminID);
           */
            string imgname;
            Boolean check;
            FileStream ms;
            try
            {
                string queryAddEvent = @"insert into dbo.tblEvent(event_name,event_content,event_start,event_end,event_status,category_id,location_id,admin_id) 
                                         values(@event_name,@event_content,@event_start,@event_end,@event_status,@category_id,@location_id,@admin_id) SELECT SCOPE_IDENTITY() as [event_id]";
                string queryAddPayment = @"insert into dbo.tblPayment(payment_url,payment_fee,event_id)
                                         values(@payment_url,@payment_fee,@event_id)";
                string sqlDataSource = _configuration.GetConnectionString("EventAppConn");
                CheckEvent checkevent = new CheckEvent();
                string eventchecklocation = checkevent.checkLocation(sqlDataSource);
                if(eventchecklocation.Equals("Location is not available"))
                {
                    return BadRequest(new Response<string>(eventchecklocation));
                }else
                    if (eventchecklocation.Equals("OK")){
                    checkevent = new CheckEvent();
                    string eventcheckdate = checkevent.checkOccupied(eventcs.eventStart, eventcs.eventEnd, sqlDataSource);
                    if (!eventcheckdate.Equals("Ok"))
                    {
                        return BadRequest(new Response<string>(eventcheckdate));
                    }
                }
                DataTable table = new DataTable();
                DataTable table2 = new DataTable();
                SqlDataReader myReader;
                using (SqlConnection myCon = new SqlConnection(sqlDataSource))
                {
                    myCon.Open();
                    using (SqlCommand myCommand = new SqlCommand(queryAddEvent, myCon))
                    {
                        myCommand.Parameters.AddWithValue("@event_name", eventcs.eventName);
                        myCommand.Parameters.AddWithValue("@event_content", eventcs.eventContent);
                        myCommand.Parameters.AddWithValue("@event_start", eventcs.eventStart);
                        myCommand.Parameters.AddWithValue("@event_end", eventcs.eventEnd);
                        myCommand.Parameters.AddWithValue("@event_status", eventcs.eventStatus);
                        myCommand.Parameters.AddWithValue("@category_id", eventcs.categoryID);
                        myCommand.Parameters.AddWithValue("@location_id", eventcs.locationID);
                        myCommand.Parameters.AddWithValue("@admin_id ", eventcs.adminID);
                        myReader = myCommand.ExecuteReader();
                        table.Load(myReader);
                        myReader.Close();
                    }
                    using (SqlCommand myCommand = new SqlCommand(queryAddPayment, myCon))
                    {
                        if(eventcs.paymentUrl == null || eventcs.paymentFee == 0)
                        {
                            myCommand.Parameters.AddWithValue("@payment_url", "No fee");
                        }
                        else
                        {
                            myCommand.Parameters.AddWithValue("@payment_url", eventcs.paymentUrl);
                        }
                        myCommand.Parameters.AddWithValue("@payment_fee", eventcs.paymentFee);
                        foreach (DataRow data in table.Rows)
                        {
                            
                            myCommand.Parameters.AddWithValue("@event_id", data["event_id"].ToString());
                        }
                        myReader = myCommand.ExecuteReader();
                        myReader.Close();
                    }
                }
                /*
                var files = objectFile.files;
                if(files == null)
                {
                    return Ok(new Response<string>(null, "Add Event and Payment but no image"));
                }
                foreach (var file in files)
                {
                    string path = Directory.GetCurrentDirectory() + "\\images\\";
                    do
                    {
                        RandomRD rD = new RandomRD(_configuration);
                        imgname = rD.Random_Name();
                        check = rD.CheckRandom_ImageName(imgname);
                    } while (check);
                    if (file.Length > 0)
                    {

                        if (!Directory.Exists(path))
                        {
                            Directory.CreateDirectory(path);
                        }
                        
                        using (FileStream fileStream = System.IO.File.Create(path + file.FileName))
                        {
                            file.CopyTo(fileStream);
                            fileStream.Flush();
                        }
                        ms = new FileStream(Path.Combine(path, file.FileName), FileMode.Open);
                        var auth = new FirebaseAuthProvider(new FirebaseConfig(ApiKey));
                        var a = await auth.SignInWithEmailAndPasswordAsync(AuthEmail, AuthPassword);
                        var cancellation = new CancellationTokenSource();

                        var task = new FirebaseStorage(
                            Bucket,
                            new FirebaseStorageOptions
                            {
                                AuthTokenAsyncFactory = () => Task.FromResult(a.FirebaseToken),
                                ThrowOnCancel = true
                            })
                            .Child("Images")
                            .Child($"{imgname}")
                            .PutAsync(ms, cancellation.Token);
                        string link = await task;
                */
                RandomRD rD = new RandomRD(_configuration);
                imgname = rD.Random_Name();
                string queryAddImage = @"insert into tblImage values (@image_url,@event_id,@image_name)";
                        string checkquery = @"select * from tblImage where image_name = @image_name";
                        table2 = new DataTable();
                        using (SqlConnection myCon = new SqlConnection(sqlDataSource))
                        {
                            myCon.Open();
                            using (SqlCommand myCommand = new SqlCommand(queryAddImage, myCon))
                            {
                                //myCommand.Parameters.AddWithValue("@image_id", id);
                                myCommand.Parameters.AddWithValue("@image_url", eventcs.imageUrl);
                                myCommand.Parameters.AddWithValue("@image_name", imgname);
                                foreach (DataRow data in table.Rows)
                                {

                                    myCommand.Parameters.AddWithValue("@event_id", data["event_id"].ToString());
                                }
                                myReader = myCommand.ExecuteReader();
                                table2.Load(myReader);
                                myReader.Close();
                            }
                            using (SqlCommand myCommand = new SqlCommand(checkquery, myCon))
                            {
                                myCommand.Parameters.AddWithValue("@image_name", imgname);
                                myReader = myCommand.ExecuteReader();
                                table2.Load(myReader);
                                myReader.Close();
                                myCon.Close();
                            }
                        }
                        /*
                        ms.Close();
                        DirectoryInfo DI = new DirectoryInfo(path);
                        foreach (FileInfo fileinfo in DI.GetFiles())
                        {
                            fileinfo.Delete();
                        }
                        Directory.Delete(path);
                        */
                    //}
                //}
                    return Ok(new Response<string>(null ,"Add Sucessfully"));
            }
            catch (Exception e)
            {
                return BadRequest(new Response<string>(e.Message));
            }          
        }

        [HttpPut("update-event")]
        public IActionResult Put(UpdateEvent Event)
        {
            try
            {
                string query = @"update dbo.tblEvent 
                              set event_name = @event_name, event_content = @event_content, 
                              event_start = @event_start,event_end = @event_end,  
                              event_status = @event_status, 
                              category_id = @category_id, 
                              location_id = @location_id, admin_id = @admin_id 
                              where event_id = @event_id";
                string query2 = @"update dbo.tblPayment
                                set payment_url = @payment_url,
                                payment_fee = @payment_fee
                                where event_id = @event_id";
                string query3 = @"update tblImage set image_url=  @image_url where event_id =@event_id";
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
                        myCommand.Parameters.AddWithValue("@event_status", Event.eventStatus);
                        myCommand.Parameters.AddWithValue("@category_id", Event.categoryID);
                        myCommand.Parameters.AddWithValue("@location_id", Event.locationID);
                        myCommand.Parameters.AddWithValue("@admin_id ", Event.adminID);
                        myCommand.Parameters.AddWithValue("@event_id", Event.eventID);
                        myReader = myCommand.ExecuteReader();
                        myReader.Close();
                    }
                    using (SqlCommand myCommand = new SqlCommand(query2, myCon))
                    {
                        if (Event.paymentUrl == null || Event.paymentFee == 0)
                        {
                            myCommand.Parameters.AddWithValue("@payment_url", "No fee");
                        }
                        else
                        {
                            myCommand.Parameters.AddWithValue("@payment_url", Event.paymentUrl);
                        }
                        myCommand.Parameters.AddWithValue("@payment_fee", Event.paymentFee);
                        myCommand.Parameters.AddWithValue("@event_id", Event.eventID);
                        myReader = myCommand.ExecuteReader();
                        myReader.Close();
                    }

                    using (SqlCommand myCommand = new SqlCommand(query3, myCon))
                    {
                        myCommand.Parameters.AddWithValue("@image_url", Event.imageUrl);
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
       left JOIN tblLocation ON E.location_id = tblLocation.location_id
       left JOIN tblPayment ON E.event_id = tblPayment.event_id
       left JOIN tblAdmin ON E.admin_id = tblAdmin.admin_id
       left JOIN tblCategory ON e.category_id = tblCategory.category_id
       left JOIN tblImage ON e.event_id = tblImage.event_id
       left JOIN tblVideo ON e.event_id = tblVideo.event_id
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
       left JOIN tblLocation ON E.location_id = tblLocation.location_id
       left JOIN tblPayment ON E.event_id = tblPayment.event_id
       left JOIN tblAdmin ON E.admin_id = tblAdmin.admin_id
       left JOIN tblCategory ON e.category_id = tblCategory.category_id
       left JOIN tblImage ON e.event_id = tblImage.event_id
       left JOIN tblVideo ON e.event_id = tblVideo.event_id
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
       left JOIN tblLocation ON E.location_id = tblLocation.location_id
       left JOIN tblPayment ON E.event_id = tblPayment.event_id
       left JOIN tblAdmin ON E.admin_id = tblAdmin.admin_id
       left JOIN tblCategory ON e.category_id = tblCategory.category_id
       left JOIN tblImage ON e.event_id = tblImage.event_id
       left JOIN tblVideo ON e.event_id = tblVideo.event_id
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
       left JOIN tblLocation ON E.location_id = tblLocation.location_id
       left JOIN tblPayment ON E.event_id = tblPayment.event_id
       left JOIN tblAdmin ON E.admin_id = tblAdmin.admin_id
       left JOIN tblCategory ON e.category_id = tblCategory.category_id
       left JOIN tblImage ON e.event_id = tblImage.event_id
       left JOIN tblVideo ON e.event_id = tblVideo.event_id 
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

        [HttpGet("Get-Location-Open")]
        public IActionResult GetLocationOpen()
        {
            try
            {
                string query = @"select location_id, location_detail ,location_status from tblLocation 
                                 where location_status = 'open' or location_status = 'Open'";
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
            catch (Exception ex)
            {
                return BadRequest(new Response<string>(ex.Message));
            }
        }

        [HttpGet("get-category-list")]
        public IActionResult GetCategorylist()
        {
            try
            {
                string query = @"select category_id, category_name from tblCategory ";
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
            catch (Exception ex)
            {
                return BadRequest(new Response<string>(ex.Message));
            }
        }




        [HttpGet("search-in-club")]
        public IActionResult SearchInClub(string name, int adminId)
        {
            try
            {
                string query = @"Select E.event_id, E.admin_id, E.location_id, event_name, event_content, event_status, event_start, event_end, tblLocation.location_detail, 
       tblAdmin.admin_id, tblAdmin.admin_name,
       tblPayment.payment_fee, tblPayment.payment_url,
       tblCategory.category_name,
       tblImage.image_url,tblVideo.video_url    
       from tblEvent E
       left JOIN tblLocation ON E.location_id = tblLocation.location_id
       left JOIN tblPayment ON E.event_id = tblPayment.event_id
       left JOIN tblAdmin ON E.admin_id = tblAdmin.admin_id
       left JOIN tblCategory ON e.category_id = tblCategory.category_id
       left JOIN tblImage ON e.event_id = tblImage.event_id
       left JOIN tblVideo ON e.event_id = tblVideo.event_id
       where event_name LIKE @event_name 
       and E.admin_id = @admin_id";
                DataTable table = new DataTable();
                string sqlDataSource = _configuration.GetConnectionString("EventAppConn");
                SqlDataReader myReader;
                using (SqlConnection myCon = new SqlConnection(sqlDataSource))
                {
                    myCon.Open();
                    using (SqlCommand myCommand = new SqlCommand(query, myCon))
                    {
                        myCommand.Parameters.AddWithValue("@event_name", "%" + name + "%");
                        myCommand.Parameters.AddWithValue("@admin_id", adminId);
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

    }
}
