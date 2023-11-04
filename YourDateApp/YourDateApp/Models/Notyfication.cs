namespace YourDateApp.Models
{
    public class Notyfication
    {
        public Notyfication(string message, string type)
        {
            Message = message;
            Type = type;
        }
        public string Message { get; set; }
        public string Type { get; set; }
    }
}