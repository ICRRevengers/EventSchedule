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
        public IActionResult Get()
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
            if (table.Rows.Count > 0)
            {
                return Ok(new Response<DataTable>(table));
            }
            return BadRequest(new Response<string>("No Data in Image"));
        }
        //Thêm mới hình ảnh 
        [HttpPost("Add-image")]
        // Add image bằng cách browse hình ảnh(Trong quá trình tạo event)
        public async Task<IActionResult> Post([FromForm] MultipleFilesUpload objectFile, int eventid)
        {
            
            string imgname;
            //int id;
            Boolean check;
            FileStream ms;
            DataTable table = new DataTable();
            try
            {
                var files = objectFile.files;
                foreach(var file in files)
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
                        string query = @"insert into tblImage values (@image_url,@event_id,@image_name)";
                        string checkquery = @"select * from tblImage where image_name = @image_name";
                        table = new DataTable();
                        string sqlDataSource = _configuration.GetConnectionString("EventAppConn");
                        SqlDataReader myReader;
                        using (SqlConnection myCon = new SqlConnection(sqlDataSource))
                        {
                            myCon.Open();
                            using (SqlCommand myCommand = new SqlCommand(query, myCon))
                            {
                                //myCommand.Parameters.AddWithValue("@image_id", id);
                                myCommand.Parameters.AddWithValue("@image_url", link);
                                myCommand.Parameters.AddWithValue("@image_name", imgname);
                                myCommand.Parameters.AddWithValue("@event_id", eventid);
                                myReader = myCommand.ExecuteReader();
                                myReader.Close();
                            }
                            using (SqlCommand myCommand = new SqlCommand(checkquery, myCon))
                            {
                                myCommand.Parameters.AddWithValue("@image_name", imgname);
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
                }
               
                if (table.Rows.Count > 0)
                {
                    return Ok("Image uploaded successfully");
                }
                return BadRequest("Image have failed to upload");
            }
            catch (Exception e)
            {
                return BadRequest(new Response<string>("Something wrong when trying to add Image"));
            }
        }

        [HttpPost("Delete-image")]
        // Delete image dựa vào Image
        public async Task<IActionResult> Delete(Image imageInfo)
        {
            try
            {
                string checkquery1 = @"select image_name from tblImage where image_id = @image_id";
                DataTable table = new DataTable();
                string sqlDataSource = _configuration.GetConnectionString("EventAppConn");
                SqlDataReader myReader;
                using (SqlConnection myCon = new SqlConnection(sqlDataSource))
                {
                    myCon.Open();
                    using (SqlCommand myCommand = new SqlCommand(checkquery1, myCon))
                    {
                        myCommand.Parameters.AddWithValue("@image_id", imageInfo.imageId);
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
                        .Child("Images")
                        .Child($"{imageInfo.imageName}")
                        .DeleteAsync();
                    string query = @"delete from tblImage where image_id = @image_id";
                    string checkquery = @"select image_name from tblImage where image_id = @image_id";
                    table = new DataTable();
                    using (SqlConnection myCon = new SqlConnection(sqlDataSource))
                    {
                        myCon.Open();
                        using (SqlCommand myCommand = new SqlCommand(query, myCon))
                        {
                            myCommand.Parameters.AddWithValue("@image_id", imageInfo.imageId);
                            myReader = myCommand.ExecuteReader();
                            myReader.Close();
                        }
                        using (SqlCommand myCommand = new SqlCommand(checkquery, myCon))
                        {
                            myCommand.Parameters.AddWithValue("@image_id", imageInfo.imageId);
                            myReader = myCommand.ExecuteReader();
                            table.Load(myReader);
                            myReader.Close();
                            myCon.Close();
                        }
                    }
                    if (table.Rows.Count > 0)
                    {
                        return  BadRequest(new Response<string>("Failed to delete Image")); ;
                    }
                    return Ok("Image deleted successfully");
                }
                else
                {
                    return BadRequest(new Response<string>("No Image was found"));
                }
                
            }
            catch (Exception e)
            {
                return BadRequest(new Response<string>("Something wrong when trying to delete Image"));
            }
        }
        
        [HttpPost("Update-image")]
        // Update image dựa vào tên của image, update bằng cách browse hình ảnh
        public async Task<IActionResult> Update([FromForm] FileUpload objectFile, string ImageName)
        {
            FileStream ms;
            try
            {
                string path = Directory.GetCurrentDirectory() + "\\images\\";
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
                        .Child("Images")
                        .Child($"{ImageName}")
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
                    return Ok("Image uploaded successfully");
            }
            catch (Exception e)
            {
                return BadRequest(new Response<string>("Something wrong when trying to delete Image"));
            }
        }
        
    }
}
   

