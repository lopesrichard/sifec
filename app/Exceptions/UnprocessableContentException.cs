namespace App.Exceptions
{
    public class UnprocessableContentException : Exception
    {
        public UnprocessableContentException() : base($"Sua solicitação não pode ser processada")
        {
        }
    }
}