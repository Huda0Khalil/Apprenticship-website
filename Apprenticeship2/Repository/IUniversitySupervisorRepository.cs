using Apprenticeship2.Data.Entities;

namespace Apprenticeship2.Repository
{
    public interface IUniversitySupervisorRepository
    {
        public List<UniversitySupervisor> GetAllSupervisor();
        public Task addSupervisor(UniversitySupervisor sup, string password);
        public UniversitySupervisor selectOne(string sup);
        public void updateSupervisorRecord(UniversitySupervisor sup);
        public void deleteSupervisor(string sup);

    }
}
