using Microsoft.AspNetCore.Identity;

namespace ShareBook.Data
{
    public class AppUser : IdentityUser
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
    }
}