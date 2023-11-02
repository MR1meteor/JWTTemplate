namespace JWTTemplate.Models.DbModels
{
    public class DbUser
    {
        public string Login { get; set; }
        public byte[] PasswordHash { get; set; }
    }
}
