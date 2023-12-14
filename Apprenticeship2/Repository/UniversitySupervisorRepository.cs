using Apprenticeship2.Data.Entities;
using Apprenticeship2.Data;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace Apprenticeship2.Repository
{
    public class UniversitySupervisorRepository : IUniversitySupervisorRepository
    {
        ApplicationDbContext context;
        private readonly UserManager<Person> _userManager;
        public UniversitySupervisorRepository(ApplicationDbContext context, UserManager<Person> _userManager)
        {
            this.context = context;
            this._userManager = _userManager;
        }

        public List<UniversitySupervisor> GetAllSupervisor()
        {
            return context.universitySupervisors.Include(s => s.university).ToList();
        }

        public async Task addSupervisor(UniversitySupervisor sup, string password)
        {
            var user = CreateUser();
            user.FirstName = sup.FirstName;
            user.SecondName = sup.SecondName;
            user.ThirdName = sup.ThirdName;
            user.LastName = sup.LastName;
            user.Email = sup.Email;
            user.EmailConfirmed = true;
            user.UserName = sup.Email.ToUpper();
            user.NormalizedEmail = sup.Email.ToUpper();
            user.NormalizedUserName = sup.Email.ToUpper();
            user.Address = sup.Address;
            user.Age = sup.Age;
            user.universityId = sup.universityId;
            user.PhoneNumber= sup.PhoneNumber;
            var result = await _userManager.CreateAsync(user, password);
            
        }

        public UniversitySupervisor selectOne(string sup)
        {
            UniversitySupervisor supervisor = context.universitySupervisors.Where(US => US.Id == sup).SingleOrDefault();
            return supervisor;
        }

        public void updateSupervisorRecord(UniversitySupervisor sup)
        {
            var user = context.universitySupervisors.Where(us => us.Id == sup.Id).SingleOrDefault();
            user.FirstName = sup.FirstName;
            user.SecondName = sup.SecondName;
            user.ThirdName = sup.ThirdName;
            user.LastName = sup.LastName;
            user.Email = sup.Email;
            user.Address = sup.Address;
            user.Age = sup.Age;
            user.universityId = sup.universityId;
            context.SaveChanges();
           
        }

        public void deleteSupervisor(string sup)
        {
            UniversitySupervisor supervisor = selectOne(sup);
            context.universitySupervisors.Remove(supervisor);
            context.SaveChanges();
        }
        private UniversitySupervisor CreateUser()
        {
            try
            {
                return Activator.CreateInstance<UniversitySupervisor>();
            }
            catch
            {
                throw new InvalidOperationException($"Can't create an instance of '{nameof(Person)}'. " +
                    $"Ensure that '{nameof(Person)}' is not an abstract class and has a parameterless constructor, or alternatively " +
                    $"override the register page in /Areas/Identity/Pages/Account/Register.cshtml");
            }
        }
    }
}
