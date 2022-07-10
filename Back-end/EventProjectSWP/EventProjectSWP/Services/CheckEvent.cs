using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EventProjectSWP.Services
{
    public class CheckEvent
    {
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
    }
}
