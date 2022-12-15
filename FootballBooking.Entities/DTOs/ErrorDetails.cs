using System.Text.Json;

namespace FootballBooking.Entities.DTOs
{
    public class ErrorDetails
    {
        public override string ToString()
        {
            return JsonSerializer.Serialize(this);
        }

        public int StatusCode { get; set; }
        public string Message { get; set; }
    }
}