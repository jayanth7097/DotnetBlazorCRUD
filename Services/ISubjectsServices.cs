using dummy.Models;

namespace dummy.Services
{
    public interface ISubjectsServices
    {
        Task<List<Subjects>> GetAllSubjectsAsync();
        Task<Subjects?> GetSubjectsByIdAsync(int id);
        Task AddSubjectsAsync(Subjects subject);
        Task UpdateSubjectsAsync(Subjects subject, int id);
        Task DeleteSubjectsAsync(int id);

    }
}
