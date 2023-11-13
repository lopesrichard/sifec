namespace App.Extensions
{
    public static class DecimalExtensions
    {
        public static string Format(this decimal value)
        {
            return value.ToString("0.00");
        }
    }
}