namespace App.Exceptions
{
    public class IncorrectUserOrPasswordException : Exception
    {
        public IncorrectUserOrPasswordException() : base($"Usuário ou senha incorretos")
        {
        }
    }
}