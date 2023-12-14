using Apprenticeship2.Data;
using Apprenticeship2.Data.Entities;

namespace Apprenticeship2.Repository
{
    public class UniversityRepository : IUniversityRepository
    { ApplicationDbContext context;
        public UniversityRepository(ApplicationDbContext context) { 
            this.context = context;
        }
        public List<University> AllUniversities (){
            return context.universities.ToList();
        }
    }
}
