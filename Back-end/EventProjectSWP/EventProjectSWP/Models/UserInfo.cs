using System.Linq;
using System.Security.Claims;

namespace EventProjectSWP.Models
{
    public class UserInfo
    {
        public string UserId { get; set; }
        public string UserName { get; set; }
        public int Phone { get; set; }
        public string Address { get; set; }
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
                Email = identity.Claims.FirstOrDefault(x => x.Type == ClaimTypes.Email).Value,
                UserName = identity.Claims.FirstOrDefault(x => x.Type == ClaimTypes.Name).Value
            };

        }

    }
   
}
