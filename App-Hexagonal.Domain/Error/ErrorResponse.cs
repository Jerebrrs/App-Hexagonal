

namespace App_Hexagonal.Domain.Error
{
    public class ErrorResponse
    {
        public int Code { get; set; }
        public string ErrorMessage { get; set; }
        public List<string> Details { get; set; }
        private DateTime fecha { get; set; } = DateTime.Now;

    }
}