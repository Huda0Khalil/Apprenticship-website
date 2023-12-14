using Apprenticeship2.Data;
using Apprenticeship2.Data.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace Apprenticeship2.Repository
{
    public class TeamLeaderRepository : ITeamLeaderRepository
    {
        ApplicationDbContext context;
        private readonly UserManager<Person> _userManager;
        public TeamLeaderRepository(ApplicationDbContext context, UserManager<Person> _userManager) { 
            this.context = context;
            this._userManager = _userManager;
        }
        public async Task addLeader(TeamLeader leader, string password)
        {
            var user = CreateUser();
            user.FirstName = leader.FirstName;
            user.SecondName = leader.SecondName;
            user.ThirdName = leader.ThirdName;
            user.LastName = leader.LastName;
            user.Email = leader.Email;
            user.UserName = leader.Email.ToUpper();
            user.NormalizedEmail = leader.Email.ToUpper();
            user.NormalizedUserName = leader.Email.ToUpper();
            user.EmailConfirmed = true;
            user.Address = leader.Address;
            user.Age = leader.Age;
            user.companyId = leader.companyId ;
            user.PhoneNumber = leader.PhoneNumber;
            
         
            var result = await _userManager.CreateAsync(user, password);
        }

        public void deleteLeder(string leader)
        {
            TeamLeader Tleader = selectOne(leader);
            context.teamLeaders.Remove(Tleader);
            context.SaveChanges();
        }

        public List<TeamLeader> GetAllLeaders()
        {
            return context.teamLeaders.Include(x => x.Company).ToList();

        }

        public TeamLeader selectOne(string leader)
        {
            var Tleader = context.teamLeaders.Where(s => s.Id == leader).SingleOrDefault();
            return Tleader;
        }

        public void updateLeaderRecord(TeamLeader teamleader)
        {
            var user = context.teamLeaders.Where(s => s.Id == teamleader.Id).SingleOrDefault();
            user.FirstName = teamleader.FirstName;
            user.SecondName = teamleader.SecondName;
            user.ThirdName = teamleader.ThirdName;
            user.LastName = teamleader.LastName;
            user.Address = teamleader.Address;
            user.Age = teamleader.Age;
            user.PhoneNumber = teamleader.PhoneNumber;
            user.companyId = teamleader.companyId;
            context.SaveChanges();
        }
        private TeamLeader CreateUser()
        {
            try
            {
                return Activator.CreateInstance<TeamLeader>();
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
