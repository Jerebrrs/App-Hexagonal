using App_Hexagonal.Application.student.ports;
using App_Hexagonal.Domain.student.exception;
using App_Hexagonal.Domain.student.model;
using App_Hexagonal.Infrastructura.data;
using App_Hexagonal.Infrastructura.student.persistence.entity;
using Mapster;
using Microsoft.EntityFrameworkCore;

namespace App_Hexagonal.Infrastructura.student.persistence.repository
{
    public class StudentRepository : IStudentPersistePort
    {
        private readonly ApplicationDbContext _context;

        public StudentRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task AddAsync(Student student)
        {
            var entity = student.Adapt<StudentEntity>();

            _context.Students.Add(entity);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(Guid id)
        {
            var entity = await _context.Students.FindAsync(id);
            if (entity != null)
            {
                _context.Students.Remove(entity);
                await _context.SaveChangesAsync();
            }
        }

        public async Task<IEnumerable<Student>> GetAllAsync()
        {
            var entities = await _context.Students.ToListAsync();
            return entities.Adapt<List<Student>>();
        }

        public async Task<Student?> GetByIdAsync(Guid id)
        {
            var entity = await _context.Students.FindAsync(id);
            return entity?.Adapt<Student>();
        }

        public async Task UpdateAsync(Student student)
        {
            var entity = await _context.Students.FindAsync(student.Id);
            if (entity == null) throw new StudentNotFountException();
            student.Adapt(entity);
            await _context.SaveChangesAsync();
        }


    }
}