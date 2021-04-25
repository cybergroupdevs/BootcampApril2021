using System.Security.Claims;

namespace ExtractionOfData.Controllers
{
    public class UserModel
    {
        public ClaimsIdentity Username { get; internal set; }
        public string UserName { get; internal set; }
        public string EmailId { get; internal set; }
    }
}