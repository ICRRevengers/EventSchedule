using EventProjectSWP.Models;
using EventProjectSWP.Settings;
using Firebase.Auth;
using Firebase.Storage;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
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
    public class ImageController : ControllerBase
    {

        private static string ApiKey = "AIzaSyBD1WOLrBowJynUn__LBCxB8l1vWS9JI2k";
        private static string Bucket = "testfirebase-a9644.appspot.com";
        private static string AuthEmail = "duc123456789987654321@gmail.com";
        private static string AuthPassword = "123456789987654321";
        private readonly IHostingEnvironment _env;

        private readonly IConfiguration _configuration;
        public ImageController(IConfiguration configuration, IHostingEnvironment env)
        {
            _configuration = configuration;
            _env = env;
        }

        /*
        [HttpPost("add-image")]
        public JsonResult Post(Image image)
        {
            string query = @"insert into tblImage values (@image_id,@image_url,@event_id)";

            DataTable table = new DataTable();
            string sqlDataSource = _configuration.GetConnectionString("EventAppConn");
            SqlDataReader myReader;
            using (SqlConnection myCon = new SqlConnection(sqlDataSource))
            {
                myCon.Open();
                using (SqlCommand myCommand = new SqlCommand(query, myCon))
                {
                    myCommand.Parameters.AddWithValue("@image_id", image.ImageId);
                    myCommand.Parameters.AddWithValue("@image_url", image.ImageUrl);
                    myCommand.Parameters.AddWithValue("@event_id", image.EventId);
                    myReader = myCommand.ExecuteReader();
                    myReader.Close();
                    myCon.Close();
                }
            }
            return new JsonResult("Succeesful");
        }
        */
        //Lấy hình ảnh
        [HttpGet("get-image")]
        public JsonResult Get()
        {
            string query = @"select * from tblImage";

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
        //Thêm mới hình ảnh 
        [HttpPost("Add-image")]
        public async Task<JsonResult> Post([FromForm] FileUploadcs objectFile, int eventid)
        {
            string imgname;
            int id;
            Boolean check;
            FileStream ms;
            try
            {
                string path = Directory.GetCurrentDirectory() + "\\images\\";
                var file = objectFile.files;
                do
                {
                    RandomRD rD = new RandomRD(_configuration);
                    imgname = rD.Random_Name();
                    check = rD.CheckRandom_ImageName(imgname);
                } while (check);
                do
                {
                    Random rdid = new Random();
                    RandomRD rD = new RandomRD(_configuration);
                    id = rdid.Next(10000);
                    check = rD.CheckRandom_ImageId(id);
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

                    // you can use CancellationTokenSource to cancel the upload midway
                    var cancellation = new CancellationTokenSource();

                    var task = new FirebaseStorage(
                        Bucket,
                        new FirebaseStorageOptions
                        {
                            AuthTokenAsyncFactory = () => Task.FromResult(a.FirebaseToken),
                            ThrowOnCancel = true                        // when you cancel the upload, exception is thrown. By default no exception is thrown
                        // when you cancel the upload, exception is thrown. By default no exception is thrown
                    })
                        .Child("Images")
                        .Child($"{imgname}")
                        .PutAsync(ms, cancellation.Token);
                    string link = await task;
                    string query = @"insert into tblImage values (@image_id,@image_url,@event_id,@image_name)";

                    DataTable table = new DataTable();
                    string sqlDataSource = _configuration.GetConnectionString("EventAppConn");
                    SqlDataReader myReader;
                    using (SqlConnection myCon = new SqlConnection(sqlDataSource))
                    {
                        myCon.Open();
                        using (SqlCommand myCommand = new SqlCommand(query, myCon))
                        {
                            myCommand.Parameters.AddWithValue("@image_id", id);
                            myCommand.Parameters.AddWithValue("@image_url", link);
                            myCommand.Parameters.AddWithValue("@image_name", imgname);
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
            return new JsonResult("Image Uploaded Succeesful");
        }
    }
   
}
