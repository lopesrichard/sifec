namespace App.Security
{
    public class Password
    {
        public static string Generate(string password)
        {
            return BCrypt.Net.BCrypt.HashPassword(password, GenerateSalt());
        }

        public static bool Verify(string password, string hash)
        {
            try
            {
                return BCrypt.Net.BCrypt.Verify(password, hash);
            }
            catch
            {
                return false;
            }
        }

        private static string GenerateSalt()
        {
            return BCrypt.Net.BCrypt.GenerateSalt(12);
        }
    }
}