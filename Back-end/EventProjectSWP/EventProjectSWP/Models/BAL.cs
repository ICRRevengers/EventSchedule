namespace EventProjectSWP.Models
{
    public class BAL
    {
        public string GetLogin(Club login)
        {
            DAL dal = new DAL();    
            string response = dal.GetLogin(login);
            return response;
        }
    }
}
