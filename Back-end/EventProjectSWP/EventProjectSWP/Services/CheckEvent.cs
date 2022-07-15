using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace EventProjectSWP.Services
{
    public class CheckEvent : ControllerBase
    {
        private readonly IConfiguration _configuration;
        private readonly IHostingEnvironment _env;
        public CheckEvent(IConfiguration configuration, IHostingEnvironment env)
        {
            _configuration = configuration;
            _env = env;
        }
        public CheckEvent()
        {
        }

        
        public List<string> checkAddEventNull(string eventName, string eventCotent, DateTime eventStart, DateTime eventEnd, string categoryID, string locationID, string adminID)
        {
            Dictionary<string, string> list = new Dictionary<string, string>();
            List<string> errorlist = new List<string>();
            list.Add("eventName", eventName); 
            list.Add("eventCotent", eventCotent); 
            list.Add("categoryID", categoryID); 
            list.Add("locationID", locationID);
            list.Add("adminID", adminID);

            foreach (var checkNul in list)
            {
                if (checkNul.Value == null)
                {
                    errorlist.Add(checkNul.Key + " is empty");
                }
            }
            if (eventStart == DateTime.MinValue)
            {
                errorlist.Add(nameof(eventStart) + " is empty");
            }
            if (eventEnd == DateTime.MinValue)
            {
                errorlist.Add(nameof(eventEnd) + " is empty");
            }
            return errorlist;
        }
        public string checkOccupied(DateTime Start, DateTime End, string connectString)
        {
            long startdt = long.Parse(Start.ToString("yyyyMMddHHmm"));
            long enddt = long.Parse(End.ToString("yyyyMMddHHmm"));
            try
            {
                string query = @"select A.admin_name,event_name,event_start,event_end
                from dbo.tblEvent E,tblAdmin A where E.admin_id = A.admin_id";
                DataTable table = new DataTable();
                SqlDataReader myReader;
                using (SqlConnection myCon = new SqlConnection(connectString))
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
                List<DateTime> listdtstart = new List<DateTime>();
                List<DateTime> listdtend = new List<DateTime>();
                List<string> listeventname = new List<string>();
                List<string> listadminname = new List<string>();
                for (int i = 0; i < table.Rows.Count; i++)
                {

                    listdtstart.Add(DateTime.Parse(table.Rows[i]["event_start"].ToString()));
                    listdtend.Add(DateTime.Parse(table.Rows[i]["event_end"].ToString()));
                    listeventname.Add(table.Rows[i]["event_name"].ToString());
                    listadminname.Add(table.Rows[i]["admin_name"].ToString());
                }
                for (int i = 0; i < listdtstart.Count; i++)
                {
                    long eventstart = long.Parse(listdtstart[i].ToString("yyyyMMddHHmm"));
                    long eventend = long.Parse(listdtend[i].ToString("yyyyMMddHHmm"));
                    if(startdt == eventstart|| startdt > eventstart && enddt < eventend|| startdt < eventstart && enddt > eventend)
                    {
                        return "Location and time of your event has been Occupied by another Event." +
                            " Occupied Event Name: "+ listeventname[i].ToString() +
                            "Occupied Club: "+ listadminname[i].ToString();
                    }

                }
                return "Ok";
            }
            catch(Exception error)
            {
                return error.ToString();
            }
            
        }
        public string checkLocation(string connectString)
        {
            try
            {
                string query = @"select E.event_name,E.event_start,E.event_end,L.location_status,event_status from tblLocation L,tblEvent E where L.location_id=E.location_id";
                DataTable table = new DataTable();
                SqlDataReader myReader;
                using (SqlConnection myCon = new SqlConnection(connectString))
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
                List<DateTime> listdtstart = new List<DateTime>();
                List<DateTime> listdtend = new List<DateTime>();
                List<string> listeventname = new List<string>();
                List<string> listlocationstatus = new List<string>();
                List<string> listeventstatus = new List<string>();

                for (int i = 0; i < table.Rows.Count; i++)
                {

                    listdtstart.Add(DateTime.Parse(table.Rows[i]["event_start"].ToString()));
                    listdtend.Add(DateTime.Parse(table.Rows[i]["event_end"].ToString()));
                    listeventname.Add(table.Rows[i]["event_name"].ToString());
                    listlocationstatus.Add(table.Rows[i]["location_status"].ToString());
                    listeventstatus.Add(table.Rows[i]["event_status"].ToString());
                }
                for (int i = 0; i < listdtstart.Count; i++)
                {
                    if (listlocationstatus[i].ToString().Equals("close")&& listeventstatus.ToString().Equals("1"))
                    {
                        return "Occupied";
                    }else
                        if(listlocationstatus[i].ToString().Equals("close") && listeventstatus.ToString().Equals("0"))
                    {
                        
                    }
                    else
                        if (listlocationstatus[i].ToString().Equals("close"))
                    {
                        return "Location is not available";
                    }
                }
                return "OK";
            }
            catch(Exception error)
            {
                return error.ToString();
            }
        }
    }
}
