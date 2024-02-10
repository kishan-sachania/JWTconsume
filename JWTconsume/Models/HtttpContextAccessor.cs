namespace JWTconsume.Models
{
    public class HtttpContextAccessor
    {
        private readonly IHttpContextAccessor context;

        public HtttpContextAccessor(IHttpContextAccessor httpContextAccessor)
        {
            context = httpContextAccessor;
        }
    }
}
