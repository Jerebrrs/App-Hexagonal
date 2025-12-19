

namespace App_Hexagonal.student.Dtos.response
{
    public class StudentResponse
    {
        public Guid Id { get; set; }
        public string FileName { get; set; } = string.Empty;
        public string LastName { get; set; } = string.Empty;
        public int Age { get; set; }
        public string Adress { get; set; } = string.Empty;


        public StudentResponse(Guid id, string filename, string lastname, int age, string adress)
        {
            this.Id = id;
            this.FileName = filename;
            this.LastName = lastname;
            this.Age = age;
            this.Adress = adress;
        }
    }
}