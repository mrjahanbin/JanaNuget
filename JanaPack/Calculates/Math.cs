namespace JanaPack.Calculates
{
    public static class Math
    {
        public static decimal Percentage(this decimal value, decimal Percentage)
        {
            var decimalResult = (value * Percentage) / 100;
            return decimalResult;
        }
    }
}
