namespace JWTconsume.Models
{
    public class CurrentUser
    {
        public int id { get; set; }
        public string username { get; set; }
        public object password { get; set; }
        public string email { get; set; }
    }

    public class Login
    {
        public string username { get; set; }
        public string password { get; set; }
        public bool status { get; set; }
        public string message { get; set; }
        public string token { get; set; }
        public CurrentUser currentUser { get; set; }
    }
}
