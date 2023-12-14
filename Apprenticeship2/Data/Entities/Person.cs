using Microsoft.AspNetCore.Identity;
namespace Apprenticeship2.Data.Entities
{
    public class Person : IdentityUser
    {
        public string FirstName {  get; set; }
        public string SecondName { get; set; }
        public string ThirdName { get; set; }
        public string LastName { get; set; }

        public string Email { get; set; }
        public int Age { get; set; }
        public string Address { get; set; }

    }
}
