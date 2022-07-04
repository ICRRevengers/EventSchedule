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
<<<<<<< HEAD
=======
        */
>>>>>>> main
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
        [HttpPost("Add-image")]
        public async Task<JsonResult> Post([FromForm] FileUploadcs objectFile, int eventid)
        {
            string vidname;
            int id;
            Boolean check;
            FileStream ms;
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

                    DataTable table = new DataTable();
                    string sqlDataSource = _configuration.GetConnectionString("EventAppConn");
                    SqlDataReader myReader;
                    using (SqlConnection myCon = new SqlConnection(sqlDataSource))
                    {
                        myCon.Open();
                        using (SqlCommand myCommand = new SqlCommand(query, myCon))
                        {
                            myCommand.Parameters.AddWithValue("@video_id", id);
                            myCommand.Parameters.AddWithValue("@video_url", link);
                            myCommand.Parameters.AddWithValue("@video_name", vidname);
                            myCommand.Parameters.AddWithValue("@event_id", eventid);
                            myReader = myCommand.ExecuteReader();
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
            }
            catch (Exception e)
            {
                return new JsonResult(e);
            }
            return new JsonResult("Video Uploaded Succeesful");
        }
    }
}
