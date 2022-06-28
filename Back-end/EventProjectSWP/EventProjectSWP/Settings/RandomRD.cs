<<<<<<< HEAD
﻿using System;
using System.Collections.Generic;
=======
﻿using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
>>>>>>> backend-TranDuc
using System.Linq;
using System.Threading.Tasks;

namespace EventProjectSWP.Settings
{
    public class RandomRD
    {
<<<<<<< HEAD
=======
        private readonly IConfiguration _configuration;
        public RandomRD(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public string Random_ImageName()
        {
            var chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz0123456789";
            var stringChars = new char[8];
            var random = new Random();

            for (int i = 0; i < stringChars.Length; i++)
            {
                stringChars[i] = chars[random.Next(chars.Length)];
            }

            var finalString = new String(stringChars);
            return finalString;
        }

        public Boolean CheckRandom_ImageName(string imageName)
        {
            Boolean check = false; ;
            try
            {
                string query = @"select COUNT(*) from tblImage Where image_name Like @image_name";
                string sqlDataSource = _configuration.GetConnectionString("EventAppConn");
                SqlDataReader myReader;
                using (SqlConnection myCon = new SqlConnection(sqlDataSource))
                {
                    myCon.Open();
                    using (SqlCommand myCommand = new SqlCommand(query, myCon))
                    {
                        myCommand.Parameters.AddWithValue("@image_name", imageName);
                        myReader = myCommand.ExecuteReader();
                        int Exist = (int)myCommand.ExecuteScalar();
                        if (Exist > 0)
                        {
                            check = false;
                        }
                        else
                        {
                            check = true;
                        }
                        myReader.Close();
                        myCon.Close();

                    }
                }
            }
            catch (Exception e)
            {

            }

            return check;
        }

        public Boolean CheckRandom_ImageId(int id)
        {
            Boolean check = false;
            try
            {
                string query = @"select COUNT(*) from tblImage Where image_id Like @image_id";
                string sqlDataSource = _configuration.GetConnectionString("EventAppConn");
                SqlDataReader myReader;
                using (SqlConnection myCon = new SqlConnection(sqlDataSource))
                {
                    myCon.Open();
                    using (SqlCommand myCommand = new SqlCommand(query, myCon))
                    {
                        myCommand.Parameters.AddWithValue("@image_id", id);
                        myReader = myCommand.ExecuteReader();
                        int Exist = (int)myCommand.ExecuteScalar();
                        if (Exist > 0)
                        {
                            check = false;
                        }
                        else
                        {
                            check = true;
                        }
                        myReader.Close();
                        myCon.Close();

                    }
                }
            }
            catch (Exception e)
            {

            }
            return check;
        }
>>>>>>> backend-TranDuc
    }
}
