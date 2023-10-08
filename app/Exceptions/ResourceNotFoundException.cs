namespace App.Exceptions
{
    public class ResourceNotFoundException : Exception
    {
        public ResourceNotFoundException() : base($"O recurso que você procurava não foi encontrado")
        {
        }
    }
}