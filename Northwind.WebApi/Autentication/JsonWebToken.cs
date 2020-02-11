
namespace Northwind.WebApi.Autentication
{
    public class JsonWebToken
    {
        public string Access_Token { get; set; }
        public string Token_Type { get; set; } = "bearer";
        public int Expires_in { get; set; }
        public string RefreshToken { get; set; }
    }
}
