using Microsoft.AspNetCore.Mvc;

namespace JWTconsume.Models
{
    public class Ragistered
    {
        public int Id { get; set; } 
        public string username { get; set; }
        public string password { get; set; }
        public string email { get; set; }

        public static implicit operator Ragistered(ActionResult<Ragistered> v)
        {
            throw new NotImplementedException();
        }
    }
}
