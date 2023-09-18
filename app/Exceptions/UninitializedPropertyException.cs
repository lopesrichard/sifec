namespace App.Exceptions
{
    public class UninitializedPropertyException : Exception
    {
        public UninitializedPropertyException(string property) : base($"Property {property} was not initialized")
        {
        }
    }
}