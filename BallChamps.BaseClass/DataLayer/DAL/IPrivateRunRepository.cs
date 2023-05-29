using BallChamps.Domain;
using DataLayer.DTO;

namespace DataLayer.DAL
{
    public interface IPrivateRunRepository : IDisposable
    {
        Task<List<PrivateRun>> GetPrivateRuns();
        Task<PrivateRun> GetPrivateRunById(string Id);
        Task<PrivateRunDTO> GetPrivateRunByHostId(string Id, string connStr);
        Task InsertPrivateRun(PrivateRun model);
        Task DeletePrivateRun(string Id);
        Task UpdatePrivateRun(PrivateRun blog);
        Task<int> Save();
    }
}
