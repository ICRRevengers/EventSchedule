using System.Linq;
using System.Security.Claims;

namespace EventProjectSWP.Models
{
    public class UserInfo
    {
        public int UserId { get; set; }
        public string UserName { get; set; }

        public string Email { get; set; }
       // public int user_status { get; set; }
        internal static UserInfo GetUserLoginInfo(ClaimsIdentity identity)
        {
            if (identity.Claims.Count() == 0 || identity.Claims.FirstOrDefault(x => x.Type == ClaimTypes.Email) == null)
            {
                return null;
            }
            return new UserInfo
            {
                email = identity.Claims.FirstOrDefault(x => x.Type == ClaimTypes.Email).Value,
                userName = identity.Claims.FirstOrDefault(x => x.Type == ClaimTypes.Name).Value
            };

        }

    }
   
}
