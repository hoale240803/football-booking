namespace FootballBooking.Application.Configurations
{
    public class JwtTokenValidationParameters
    {

        public static string ValidIssuer = "https://localhost:5001";
        public static string ValidAudience = "https://localhost:5001";
        public static string IssuerSigningKey = "superSecretKey@345";
    }
}