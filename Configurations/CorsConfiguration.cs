namespace BraintreeServer.Configurations;

public class CorsConfiguration
{
    public string[] AllowedHeaders { get; set; } = new string[] { };
    public string[] AllowedMethods { get; set; } = new string[] { };
    public string[] AllowedOrigins { get; set; } = new string[] { };
}
