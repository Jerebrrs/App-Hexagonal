using App_Hexagonal.Application.student.ports.output;
using App_Hexagonal.Domain.student.model;
using App_Hexagonal.Infrastructura.data;
using App_Hexagonal.Infrastructura.student.ports.output.persistence.entity;
using Mapster;
using Microsoft.EntityFrameworkCore;

namespace App_Hexagonal.Infrastructura.student.ports.output.persistence.repository
{
    public class StudentRepository : IStudentPersistePort
    {
        private readonly ApplicationDbContext _context;

        public StudentRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<Student> findById(long id)
        {
            var entity = await _context.Students.FindAsync(id);
            return entity == null ? null : entity.Adapt<Student>();
        }

        public async Task<List<Student>> findAll()
        {
            var entities = await _context.Students.ToListAsync();
            return entities.Adapt<List<Student>>();
        }

        public async Task save(Student student)
        {
            var entity = student.Adapt<StudentEntity>();
            _context.Students.Add(entity);
            await _context.SaveChangesAsync();
        }

        public async Task<Student> update(long id, Student student)
        {
            var entity = await _context.Students.FindAsync(id);
            if (entity == null) return null;
            student.Adapt(entity); // Mapster actualiza la entidad existente
            await _context.SaveChangesAsync();
            return entity.Adapt<Student>();
        }

        public async Task deleteById(long id)
        {
            var entity = await _context.Students.FindAsync(id);
            if (entity != null)
            {
                _context.Students.Remove(entity);
                await _context.SaveChangesAsync();
            }
        }
    }
}