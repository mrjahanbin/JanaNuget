using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text.RegularExpressions;

namespace JanaPack.Converters
{
    public static class DateTimeConvertor
    {

        public static string ToPersianCulture(this string date)
        {
            var Days = (DateTime.Parse(date) - DateTime.Parse(DateTime.Now.ToShortDateString())).Days;

            var Week = Days / 7;
            var DaysOfWeek = Days % 7;
            return $"{date}-{DateTime.Parse(date).ToShamsi()} ({Days} روز دیگر برابر {Week} هفته و {DaysOfWeek} روز )";
        }

        public static string ToPersianCulture(this DateTime date)
        {

            var Days = (date - DateTime.Parse(DateTime.Now.ToShortDateString())).Days;

            var Week = Days / 7;
            var DaysOfWeek = Days % 7;
            return $"{date}-{date.ToShamsi()} ({Days} روز دیگر برابر {Week} هفته و {DaysOfWeek} روز )";
        }

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
            var IsPunctuation = value.All(char.IsPunctuation);
            var IsWhiteSpace = value.Contains(' ');

            if (IsLetterOrDigit || IsPunctuation || IsSymbol || IsWhiteSpace)
            {
                return new();
            }

            string ConvertPersianNumberToEng = Regex.Replace(value, "[۰-۹]", x => ((char)(x.Value[0] - '۰' + '0')).ToString());
            int[]? datePart;
            if (ConvertPersianNumberToEng.Contains(','))
            {
                datePart = ConvertPersianNumberToEng.Split(",").Select(d => int.Parse(d)).ToArray();
            }
            else if (ConvertPersianNumberToEng.Contains('-'))
            {
                datePart = ConvertPersianNumberToEng.Split("-").Select(d => int.Parse(d)).ToArray();
            }
            else
            {
                datePart = ConvertPersianNumberToEng.Split("/").Select(d => int.Parse(d)).ToArray();
            }


            PersianCalendar pc = new();

            if (datePart[2] > 99)
            {
                int Year = datePart[2];
                int Day = datePart[0];
                int Month = datePart[1];
                if (datePart[1] > 12)
                {
                    Day = datePart[1];
                    Month = datePart[0];
                }


                datePart[0] = Year;
                datePart[2] = Day;
                datePart[1] = Month;

            }
            if (datePart[0] > 9999 || datePart[1] > 12 || datePart[1] > 31)
            {
                return new();
            }


            var Result = new DateTime(datePart[0], datePart[1], datePart[2], pc);
            return Result;
        }
        public static DateTime ToMiladiDateTime(this string value)
        {
            DateTime DateOnly = new();
            List<int>? TimeOnly = null;

            value = Fixer.Fix(value);
            var Value = value.Split(" ");
            var Date = Value[0];
            if (!Date.Contains(':'))
            {
                DateOnly = Date.ToMiladiDate();
            }

            if (Value.Length > 1 || Value[0].Contains(':'))
            {
                var Time = Value[0].Contains(':') == true ? Value[0] : Value[1];
                if (Time.Contains('.'))
                {
                    var SplitTime = Time.Split('.');
                    Time = SplitTime[0];
                }

                if (string.IsNullOrWhiteSpace(Time) || Time.Length > 22 || Time.Length < 5)
                {
                    return new();
                }

                var IsLetterOrDigit = Time.All(char.IsLetterOrDigit);
                var IsNumber = !Time.Contains(':');
                var IsLetter = Time.Replace(" ", "").All(char.IsLetter);
                var IsSymbol = Time.All(char.IsSymbol);
                var IsPunctuation = Time.All(char.IsPunctuation);
                var IsWhiteSpace = Time.Count(Char.IsWhiteSpace) > 2;

                if (IsLetterOrDigit || IsPunctuation || IsSymbol || IsWhiteSpace || IsLetter || IsNumber)
                {
                    return new();
                }
                string ConvertPersianNumberToEng = Regex.Replace(Time, "[۰-۹]", x => ((char)(x.Value[0] - '۰' + '0')).ToString());
                ConvertPersianNumberToEng = ConvertPersianNumberToEng.Replace("AM", "").Replace("PM", "");
                ConvertPersianNumberToEng = ConvertPersianNumberToEng.Replace("ق.ظ", "").Replace("ب.ظ", "");
                ConvertPersianNumberToEng = ConvertPersianNumberToEng.Replace("T", " ");
                ConvertPersianNumberToEng = ConvertPersianNumberToEng.Replace("-", ":");
                ConvertPersianNumberToEng = ConvertPersianNumberToEng.Replace("/", ":");

                TimeOnly = ConvertPersianNumberToEng.Split(new[] { ':', ' ' }, StringSplitOptions.RemoveEmptyEntries).Select(d => int.Parse(d)).ToList();
                if (TimeOnly.Count == 2)
                {
                    TimeOnly.Add(0);
                }

                if (TimeOnly[0] > 24 || TimeOnly[1] > 60 || TimeOnly[2] > 60)
                {
                    if (DateOnly.Year != 1)
                    {
                        return DateOnly;
                    }
                    else
                    {
                        return new();
                    }
                }

            }

            PersianCalendar pc = new();
            DateTime Result = new();

            if (TimeOnly != null)
            {
                Result = new(DateOnly.Year, DateOnly.Month, DateOnly.Day, TimeOnly[0], TimeOnly[1], TimeOnly[2]);
            }
            else
            {
                Result = new(DateOnly.Year, DateOnly.Month, DateOnly.Day);
            }

            return Result;

        }
        public static DateTime? ToMiladiDateTime(this DateTime value)
        {
            var date = value.ToString().ToMiladiDateTime();
            return date;

        }

        public static string ToMiladiYear(this string value)
        {

            if (string.IsNullOrWhiteSpace(value) || value.Length > 10 || value.Length < 5)
            {
                return "";
            }

            var IsLetterOrDigit = value.All(char.IsLetterOrDigit);
            var IsSymbol = value.All(char.IsSymbol);
            var IsPunctuation = value.All(char.IsPunctuation);
            var IsWhiteSpace = value.Contains(' ');

            if (IsLetterOrDigit || IsPunctuation || IsSymbol || IsWhiteSpace)
            {
                return "";
            }

            string ConvertPersianNumberToEng = Regex.Replace(value, "[۰-۹]", x => ((char)(x.Value[0] - '۰' + '0')).ToString());
            int[]? datePart;
            if (ConvertPersianNumberToEng.Contains(','))
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
            var Result = $"{pc.GetYear(value)}/{pc.GetMonth(value):00}/{pc.GetDayOfMonth(value):00}";
            return Result;
        }
        public static string ToShamsiDateTime(this DateTime value)
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

            return $"{pc.GetYear(value)}/{pc.GetMonth(value):00}/{pc.GetDayOfMonth(value):00} {pc.GetHour(value)}:{pc.GetMinute(value)}:{pc.GetSecond(value)}";
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