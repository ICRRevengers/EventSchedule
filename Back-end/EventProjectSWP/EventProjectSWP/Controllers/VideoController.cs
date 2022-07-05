using EventProjectSWP.Models;
using EventProjectSWP.Settings;
using Firebase.Auth;
using Firebase.Storage;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using System;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Threading;
using System.Threading.Tasks;

namespace EventProjectSWP.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class VideoController : ControllerBase
    {
        private static string ApiKey = "AIzaSyBD1WOLrBowJynUn__LBCxB8l1vWS9JI2k";
        private static string Bucket = "testfirebase-a9644.appspot.com";
        private static string AuthEmail = "duc123456789987654321@gmail.com";
        private static string AuthPassword = "123456789987654321";
        private readonly IHostingEnvironment _env;
        private readonly IConfiguration _configuration;
        public VideoController(IConfiguration configuration, IHostingEnvironment env)
        {
            _configuration = configuration;
            _env = env;
        }
<<<<<<< HEAD
=======
        /*
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
        */
        //lấy video
>>>>>>> backend-Long
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
<<<<<<< HEAD
        [HttpPost("Add-video")]
        public async Task<IActionResult> Post([FromForm] FileUploadcs objectFile, int eventid)
=======
        //thêm hình ảnh
        [HttpPost("Add-image")]
        public async Task<JsonResult> Post([FromForm] FileUploadcs objectFile, int eventid)
>>>>>>> backend-Long
        {
            string vidname;
            int id;
            Boolean check;
            FileStream ms;
            DataTable table = new DataTable();
            try
            {
                string path = Directory.GetCurrentDirectory() + "\\videos\\";
                var file = objectFile.files;
                do
                {
                    RandomRD rD = new RandomRD(_configuration);
                    vidname = rD.Random_Name();
                    check = rD.CheckRandom_VideoName(vidname);
                } while (check);
                do
                {
                    Random rdid = new Random();
                    RandomRD rD = new RandomRD(_configuration);
                    id = rdid.Next(10000);
                    check = rD.CheckRandom_VideoId(id);
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
                        .Child("Videos")
                        .Child($"{vidname}")
                        .PutAsync(ms, cancellation.Token);
                    string link = await task;
                    string query = @"insert into tblVideo values (@video_id,@video_url,@event_id,@video_name)";
                    string checkquery = @"select * from tblVideo where video_id = @video_id";
                    string sqlDataSource = _configuration.GetConnectionString("EventAppConn");
                    SqlDataReader myReader;
                    using (SqlConnection myCon = new SqlConnection(sqlDataSource))
                    {
                        myCon.Open();
                        using (SqlCommand myCommand = new SqlCommand(query, myCon))
                        {
                            myCommand.Parameters.AddWithValue("@video_id", id);
                            myCommand.Parameters.AddWithValue("@video_url", link);
                            myCommand.Parameters.AddWithValue("@event_id", eventid);
                            myCommand.Parameters.AddWithValue("@video_name", vidname);
                            myReader = myCommand.ExecuteReader();
                            myReader.Close();
                        }
                        using (SqlCommand myCommand = new SqlCommand(checkquery, myCon))
                        {
                            myCommand.Parameters.AddWithValue("@video_id", id);
                            myReader = myCommand.ExecuteReader();
                            table.Load(myReader);
                            myReader.Close();
                            myCon.Close();
                        }
                    }
                    ms.Close();
                    DirectoryInfo DI = new DirectoryInfo(path);
                    foreach (FileInfo fileinfo in DI.GetFiles())
                    {
                        fileinfo.Delete();
                    }
                    Directory.Delete(path);
                }
                if (table.Rows.Count > 0)
                {
                    return Ok("Video uploaded successfully");

                }
                return BadRequest(new Response<string>("Failed to add Video"));
            }
            catch (Exception e)
            {
                //return BadRequest(new Response<string>("Something wrong when try to add video"));
                throw;
            }
        }
        [HttpPost("Delete-video")]
        // Delete video dựa vào Video
        public async Task<IActionResult> Delete(Video videoInfo)
        {
            try
            {
                string checkquery1 = @"select video_name from tblVideo where video_id = @video_id";
                DataTable table = new DataTable();
                string sqlDataSource = _configuration.GetConnectionString("EventAppConn");
                SqlDataReader myReader;
                using (SqlConnection myCon = new SqlConnection(sqlDataSource))
                {
                    myCon.Open();
                    using (SqlCommand myCommand = new SqlCommand(checkquery1, myCon))
                    {
                        myCommand.Parameters.AddWithValue("@video_id", videoInfo.VideoId);
                        myReader = myCommand.ExecuteReader();
                        table.Load(myReader);
                        myReader.Close();
                        myCon.Close();
                    }
                }
                if (table.Rows.Count > 0)
                {
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
                        .Child("Videos")
                        .Child($"{videoInfo.VideoName}")
                        .DeleteAsync();
                    string query = @"delete from tblVideo where video_id = @video_id";
                    string checkquery = @"select video_name from tblVideo where video_id = @video_id";
                    table = new DataTable();
                    using (SqlConnection myCon = new SqlConnection(sqlDataSource))
                    {
                        myCon.Open();
                        using (SqlCommand myCommand = new SqlCommand(query, myCon))
                        {
                            myCommand.Parameters.AddWithValue("@video_id", videoInfo.VideoId);
                            myReader = myCommand.ExecuteReader();
                            myReader.Close();
                        }
                        using (SqlCommand myCommand = new SqlCommand(checkquery, myCon))
                        {
                            myCommand.Parameters.AddWithValue("@video_id", videoInfo.VideoId);
                            myReader = myCommand.ExecuteReader();
                            table.Load(myReader);
                            myReader.Close();
                            myCon.Close();
                        }
                    }
                    if (table.Rows.Count > 0)
                    {
                        return BadRequest(new Response<string>("Failed to delete Video")); ;
                    }
                    return Ok("Video deleted successfully");
                }
                else
                {
                    return BadRequest(new Response<string>("No Video was found"));
                }

            }
            catch (Exception e)
            {
                return BadRequest(new Response<string>("Something wrong when trying to delete Image"));
            }
        }
        [HttpPost("Update-video")]
        // Update video dựa vào tên của video, update bằng cách browse hình ảnh
        public async Task<IActionResult> Update([FromForm] FileUploadcs objectFile, string VideoName)
        {
            FileStream ms;
            try
            {
                string path = Directory.GetCurrentDirectory() + "\\videos\\";
                var file = objectFile.files;
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
                        .Child("Videos")
                        .Child($"{VideoName}")
                        .PutAsync(ms, cancellation.Token);
                    await task;
                    ms.Close();
                    DirectoryInfo DI = new DirectoryInfo(path);
                    foreach (FileInfo fileinfo in DI.GetFiles())
                    {
                        fileinfo.Delete();
                    }
                    Directory.Delete(path);

                }
                return Ok("Video updated successfully");
            }
            catch (Exception e)
            {
                return BadRequest(new Response<string>("Something wrong when trying to delete Image"));
            }
        }
    }
}
