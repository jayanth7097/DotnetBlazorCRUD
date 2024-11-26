using System.Numerics;
using dummy.Models;

namespace dummy.Services
{
    public interface IStudentsServices
    {
        Task<List<Students>> GetAllStudentsAsync();
        Task<Students> GetStudentsByIdAsync(int id);
        Task AddStudentsAsync(Students student);
        Task UpdateStudentsAsync(Students student, int id);
        Task DeleteStudentsAsync(int id);
        Task<bool> DoesStudentsExist(int studentId);

    }
}
