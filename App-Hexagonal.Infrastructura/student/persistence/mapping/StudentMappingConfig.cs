using App_Hexagonal.Domain.student.model;
using App_Hexagonal.Infrastructura.student.persistence.entity;
using Mapster;

namespace App_Hexagonal.Infrastructura.student.persistence.mapping
{
    public static class StudentMappingConfig
    {
        public static void Register()
        {
            TypeAdapterConfig<StudentEntity, Student>.NewConfig();
            TypeAdapterConfig<Student, StudentEntity>.NewConfig();
        }
    }
}
