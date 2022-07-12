using System.Globalization;
using System.Text.RegularExpressions;

namespace JanaPack
{
    public static class DateTimeConvertor
    {


        public static DateTime ToMiladiDate(this string value)
        {

            if (string.IsNullOrWhiteSpace(value))
            {
                return new();
            }
            if (value.Length > 10 || value.Length < 5)
            {
                return new();
            }
            var IsLetterOrDigit = value.All(Char.IsLetterOrDigit);
            var IsSymbol = value.All(Char.IsSymbol);
            //var IsHighSurrogate = value.All(Char.IsHighSurrogate);
            var IsPunctuation = value.All(Char.IsPunctuation);
            //var IsSeparator = value.All(Char.IsSeparator);
            //var IsSurrogate = value.All(Char.IsSurrogate);
            var IsWhiteSpace = value.Contains(" ");

            if (IsLetterOrDigit || IsPunctuation || IsSymbol || IsWhiteSpace)
            {
                return new();
            }

            string ConvertPersianNumberToEng = Regex.Replace(value, "[۰-۹]", x => ((char)(x.Value[0] - '۰' + '0')).ToString());
            int[]? datePart;
            if (ConvertPersianNumberToEng.Contains(","))
            {
                datePart = ConvertPersianNumberToEng.Split(",").Select(d => int.Parse(d)).ToArray();
            }
            else
            {
                datePart = ConvertPersianNumberToEng.Split("/").Select(d => int.Parse(d)).ToArray();

            }

            PersianCalendar pc = new();
            var Result = new DateTime(datePart[0], datePart[1], datePart[2], pc);
            return Result;
        }
    }
}