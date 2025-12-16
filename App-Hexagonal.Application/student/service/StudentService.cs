using App_Hexagonal.Application.student.ports.input;
using App_Hexagonal.Application.student.ports.output;
using App_Hexagonal.Domain.student.exception;
using App_Hexagonal.Domain.student.model;

namespace App_Hexagonal.Application.student.service
{
    public class StudentService : IStudentServicePort
    {

        private readonly IStudentPersistePort _studentPersistePort;
        public StudentService(IStudentPersistePort studentPersistePort)
        {
            _studentPersistePort = studentPersistePort;
        }
        public async Task deleteById(long id)
        {
            var student = await _studentPersistePort.findById(id);
            if (student == null)
                throw new StudentNotFountException($"No se encontró el estudiante con id {id}");
            await _studentPersistePort.deleteById(id);
        }

        public async Task<List<Student>> findAll()
        {
            return await _studentPersistePort.findAll();
        }

        public async Task<Student> findById(long id)
        {
            var student = await _studentPersistePort.findById(id);
            if (student == null)
                throw new StudentNotFountException($"No se encontró el estudiante con id {id}");
            return student;
        }

        public async Task save(Student student)
        {
            await _studentPersistePort.save(student);
        }

        public async Task<Student> update(long id, Student student)
        {
            var existingStudent = await _studentPersistePort.findById(id);
            if (existingStudent == null)
                throw new StudentNotFountException($"No se encontró el estudiante con id {id}");
            return await _studentPersistePort.update(id, student);
        }
    }
}