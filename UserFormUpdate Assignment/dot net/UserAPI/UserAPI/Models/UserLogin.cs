namespace UserAPI.Models
{
    public class UserLogin
    {
        public int user_id { get; set; }
        public string user_name { get; set; }
        public string user_email { get; set; }
        public string password { get; set; }
    }
}