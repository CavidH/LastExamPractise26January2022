using Microsoft.AspNetCore.Identity;

namespace LastExamPractise26January2022.Data.Entities
{
    public class ApplicationUser :IdentityUser
    {
        public string Fullname { get; set; }
    }
}
