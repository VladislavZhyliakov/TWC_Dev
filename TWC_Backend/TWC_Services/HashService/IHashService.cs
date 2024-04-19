namespace TWC_Services.HashService
{
    public interface IHashService
    {
        public string HashPassword(string password, out byte[] salt);
        public bool PasswordVerification(string password, string hash, byte[] salt);
    }
}
