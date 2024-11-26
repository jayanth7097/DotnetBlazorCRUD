using dummy.Data;

using System.Numerics;
using dummy.Models;
using Microsoft.EntityFrameworkCore;

namespace dummy.Services
{
    public class StudentsServices : IStudentsServices
    {
       
            private readonly AppDbContext _context;

            public StudentsServices(AppDbContext context)
            {
                _context = context;
            }

            public async Task AddStudentsAsync(Students student)
            {
                _context.Students.Add(student);
                await _context.SaveChangesAsync();
            }
            public async Task DeleteStudentsAsync(int id)
            {
                var student = await _context.Students.FindAsync(id);
                if (student != null)
                {
                    _context.Students.Remove(student);
                    await _context.SaveChangesAsync();
                }
            }
            public async Task<List<Students>> GetAllStudentsAsync()
            {
                var result = await _context.Students.ToListAsync();
                return result;
            }

            public async Task<Students?> GetStudentsByIdAsync(int id)
            {
                var student = await _context.Students.FindAsync(id);
                return student;
            }



            public async Task UpdateStudentsAsync(Students student, int id)
            {
                var dbStudent = await _context.Students.FindAsync(id);
                if (dbStudent != null)
                {
                dbStudent.Name = student.Name;
                dbStudent.Specialty = student.Specialty;
                    await _context.SaveChangesAsync();
                }
            }

            public async Task<bool> DoesStudentsExist(int studentId)
            {
                return await _context.Students.AnyAsync(d => d.StudentId == studentId);
            }



        }

    }

