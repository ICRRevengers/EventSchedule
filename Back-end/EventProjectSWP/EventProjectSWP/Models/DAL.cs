using System.Data;
using System.Data.SqlClient;
using EventProjectSWP.Models;
namespace EventProjectSWP.Models
{
    public class DAL
    {
        SqlDataAdapter da = null;
        DataTable dt = null;
        SqlConnection con = new SqlConnection("Data Source=.;Initial Catalog=EventSchedule;User Id=sa;password=12345");
        // string sqlDataSource = _configuration.GetConnectionString("EventAppConn");
        public string GetLogin(Club login)
        {
            da = new SqlDataAdapter("Select club_name, club_phone from tblClub where club_email = '" + login.ClubEmail + "' and club_password = '" + login.ClubPassword + "' ", con);
            dt = new DataTable();
            da.Fill(dt);
            if (dt.Rows.Count > 0)
                return "logged in";
            else
                return "login fail";
        }
    }
}
