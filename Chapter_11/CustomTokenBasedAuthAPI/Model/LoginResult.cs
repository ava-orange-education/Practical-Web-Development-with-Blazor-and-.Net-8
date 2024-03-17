namespace CustomTokenBasedAuthAPI.Model
{
    public class LoginResult
    {
        public string? Token { get; set; }
        public DateTime Expiry { get; set; }
    }
}
