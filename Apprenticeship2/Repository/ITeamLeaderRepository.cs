using Apprenticeship2.Data.Entities;

namespace Apprenticeship2.Repository
{
    public interface ITeamLeaderRepository
    {
        public List<TeamLeader> GetAllLeaders();
        public Task addLeader(TeamLeader leader, string password);
        public TeamLeader selectOne(string leader);
        public void updateLeaderRecord(TeamLeader teamleader);
        public void deleteLeder(string leader);
    }
}
