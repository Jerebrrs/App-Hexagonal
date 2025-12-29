
using App_Hexagonal.Domain.Common;

namespace App_Hexagonal.Domain.student.model
{
    public class Student : BaseEntity<Guid>
    {
        public string FileName { get; private set; } = string.Empty;
        public string LastName { get; private set; } = string.Empty;
        public int Age { get; private set; }
        public string Adress { get; private set; } = string.Empty;
        public Student()
        {

        }
        public Student(string filename, string lastname, int age, string adress)
         : base(Guid.NewGuid(), Guid.NewGuid())
        {
            FileName = filename;
            LastName = lastname;
            Age = age;
            Adress = adress;
            MarkCreated();
        }

        public void Update(string filename, string lastname, int age, string adress)
        {

            this.FileName = filename;
            this.LastName = lastname;
            this.Age = age;
            this.Adress = adress;
            MarkUpdated();
        }
    }
}