namespace App_Hexagonal.Domain.student.exception
{
    public class StudentNotFountException : ApplicationException
    {
        public StudentNotFountException() : base("Error al crear el student.") { }
        public StudentNotFountException(string msg) : base(msg) { }
        public StudentNotFountException(string msg, Exception exception) : base(msg, exception) { }
    }
}