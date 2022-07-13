using System.Globalization;
using System.Text.RegularExpressions;

namespace JanaPack.Converters
{
    public static class DateTimeConvertor
    {

        #region Miladi

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
            var IsLetterOrDigit = value.All(char.IsLetterOrDigit);
            var IsSymbol = value.All(char.IsSymbol);
            //var IsHighSurrogate = value.All(Char.IsHighSurrogate);
            var IsPunctuation = value.All(char.IsPunctuation);
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
        public static string ToMiladiYear(this string value)
        {

            if (string.IsNullOrWhiteSpace(value))
            {
                return "";
            }
            if (value.Length > 10 || value.Length < 5)
            {
                return "";
            }
            var IsLetterOrDigit = value.All(char.IsLetterOrDigit);
            var IsSymbol = value.All(char.IsSymbol);
            //var IsHighSurrogate = value.All(Char.IsHighSurrogate);
            var IsPunctuation = value.All(char.IsPunctuation);
            //var IsSeparator = value.All(Char.IsSeparator);
            //var IsSurrogate = value.All(Char.IsSurrogate);
            var IsWhiteSpace = value.Contains(" ");

            if (IsLetterOrDigit || IsPunctuation || IsSymbol || IsWhiteSpace)
            {
                return "";
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
            return Result.Year.ToString();
        }
        #endregion


        #region Shamsi
        public static string ToShamsi(this DateTime value)
        {

            if (value.Year < 622)
            {
                return "";
            }
            if (value.Year < 622 && value.Month < 3)
            {
                return "";
            }
            if (value.Year < 622 && value.Month < 3 && value.Day < 22)
            {
                return "";
            }

            PersianCalendar pc = new();
            var Result = pc.GetYear(value) + "/" + pc.GetMonth(value).ToString("00") + "/" + pc.GetDayOfMonth(value).ToString("00");
            return Result;
        }

        public static string ToShamsiYear(this DateTime value)
        {

            if (value.Year < 622)
            {
                return "";
            }
            if (value.Year < 622 && value.Month < 3)
            {
                return "";
            }
            if (value.Year < 622 && value.Month < 3 && value.Day < 22)
            {
                return "";
            }

            PersianCalendar pc = new();
            var Result = pc.GetYear(value).ToString();
            return Result;
        }
        #endregion
    }
}