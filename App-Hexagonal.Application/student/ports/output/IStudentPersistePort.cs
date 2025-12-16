

using App_Hexagonal.Domain.student.model;

namespace App_Hexagonal.Application.student.ports.output
{
    public interface IStudentPersistePort
    {
        Task<Student> findById(long id);
        Task<List<Student>> findAll();
        Task save(Student student);
        Task<Student> update(long id, Student student);
        Task deleteById(long id);
    }
}