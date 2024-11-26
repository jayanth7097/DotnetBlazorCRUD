using dummy.Data;
using dummy.Models;
using Microsoft.EntityFrameworkCore;
using static dummy.Services.SubjectsServices;

namespace dummy.Services
{
    public class SubjectsServices : ISubjectsServices
    {


        private readonly AppDbContext _context;
        private readonly IStudentsServices _studentService;

        public SubjectsServices(AppDbContext context, IStudentsServices studentService)
        {
            _context = context;
            _studentService = studentService;
        }

        public async Task<List<Subjects>> GetAllSubjectsAsync()
        {
            var result = await _context.Subjects.ToListAsync();
            return result;
        }

        public async Task<Subjects?> GetSubjectsByIdAsync(int id)
        {
            var subjects = await _context.Subjects.FindAsync(id);
            return subjects;
        }

       
        public async Task AddSubjectsAsync(Subjects subject)
        {
            if (subject.StudentId == 0 || !await _studentService.DoesStudentsExist(subject.StudentId))
            {
                throw new Exception("Invalid DoctorId. Please select a valid doctor.");
            }

            _context.Subjects.Add(subject);
            await _context.SaveChangesAsync();
        }




        public async Task UpdateSubjectsAsync(Subjects subject, int id)
        {
            var dbSubjects = await _context.Subjects.FindAsync(id);
            if (dbSubjects == null)
            {
                throw new Exception("Patient not found.");
            }

            if (subject.StudentId == 0 || !await _studentService.DoesStudentsExist(subject.StudentId))
            // if (patient.DoctorId == 0 || !await _doctorService.DoesDoctorExist(patient.DoctorId))

            {
                throw new Exception("Invalid DoctorId. Please select a valid doctor.");
            }

            dbSubjects.Name = subject.Name;
            dbSubjects.Age = subject.Age;
            dbSubjects.Grade = subject.Grade;
            dbSubjects.StudentId = subject.StudentId;

            await _context.SaveChangesAsync();
        }


        public async Task DeleteSubjectsAsync(int id)
        {
            var subject = await _context.Subjects.FindAsync(id);
            if (subject != null)
            {
                _context.Subjects.Remove(subject);
                await _context.SaveChangesAsync();
            }


        }
    }
}
    
