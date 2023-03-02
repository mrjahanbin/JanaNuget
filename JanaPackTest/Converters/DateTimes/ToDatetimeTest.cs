using JanaPack;
using JanaPack.Converters;
using System.Globalization;
using Xunit;

namespace JanaPackTest.Converters.DateTimes
{
    /*
     * میخوایم تست کنیم ببینیم تاریخ فارسی رو چطوری به میلادی تبدیل کنیم   
     */
    public class ToDatetimeTest
    {
        #region ToDatetime
        [Theory]
        [InlineData(null)]
        [InlineData("")]
        [InlineData(" ")]
        [InlineData("                        ")]
        [InlineData(",,")]
        [InlineData("^")]
        [InlineData(",")]
        [InlineData("~")]
        [InlineData(".")]
        [InlineData("//")]
        [InlineData("099087987kjhghg")]
        [InlineData("768768768")]
        [InlineData("hgjhgjh")]
        [InlineData("         kjhkj            ")]
        [InlineData("         12213214            ")]
        [InlineData("kjhkj         jhgjhgjhg")]
        [InlineData("1765,76,57         2164352176")]
        public void Value_Not_Correct(string Input)
        {
            //arrange
            DateTime Expected = new(1, 1, 1);

            //act
            var Act = Fixer.Fix(Input).ToDateTime();

            //assert
            Assert.Equal(Expected, Act);
        }

        [Theory]
        [InlineData("1989,09,11")]
        [InlineData("1989/09/11")]
        [InlineData("1989,9,11")]
        public void Value_Correct(string Input)
        {
            //arrange
            DateTime Expected = new(1989, 9, 11);

            //act
            var Act = Input.ToDateTime();

            //assert
            Assert.Equal(Expected, Act);
        }

        [Theory]
        [InlineData("168,9,11")]
        public void Value_Correct2(string Input)
        {
            //arrange0789-12-02
            DateTime Expected = new(168, 9, 11);

            //act
            var Act = Input.ToDateTime();

            //assert
            Assert.Equal(Expected, Act);
        }

        [Theory]
        [InlineData("1,1,1")]
        public void Value_Correct3(string Input)
        {
            //arrange0622-03-22
            DateTime Expected = new(1, 1, 1);

            //act
            var Act = Input.ToDateTime();

            //assert
            Assert.Equal(Expected, Act);
        }

        [Theory]
        [InlineData("68,9,11")]
        [InlineData("1399,12,30")]
        [InlineData("68,9,1")]
        public void Value_Correct4(string Input)
        {
            //arrange0622-03-22
            DateTime Expected = new(1, 1, 1);

            //act
            var Act = Input.ToDateTime();

            //assert
            Assert.NotEqual(Expected, Act);
        }
        #endregion

        #region ToMiladiDateTime
        [Theory]
        [InlineData(null)]
        [InlineData("")]
        [InlineData(" ")]
        [InlineData("                        ")]
        [InlineData(",,")]
        [InlineData("^")]
        [InlineData(",")]
        [InlineData("~")]
        [InlineData(".")]
        [InlineData("//")]
        [InlineData("099087987kjhghg")]
        [InlineData("768768768")]
        [InlineData("hgjhgjh")]
        [InlineData("         kjhkj            ")]
        [InlineData("         12213214            ")]
        [InlineData("kjhkj         jhgjhgjhg")]
        [InlineData("1765,76,57")]
        [InlineData("1765,76,57         2164352176")]
        public void DateTimeValue_Not_Correct(string Input)
        {
            //arrange
            DateTime Expected = new(1, 1, 1, 0, 0, 0);

            //act
            var Act = Input.ToDateTime();

            //assert
            Assert.Equal(Expected.Date, Act.Date);
            Assert.Equal(Expected.Hour, Act.Hour);
            Assert.Equal(Expected.Minute, Act.Minute);
            Assert.Equal(Expected.Second, Act.Second);
        }

        [Theory]
        [InlineData("1368,09,11")]
        [InlineData("1368,9,11")]
        [InlineData("1368/09/11")]
        [InlineData("1368/9/11")]
        [InlineData("1368-09-11")]
        [InlineData("1368-9-11")]
        public void DateTimeValue_Correct(string Input)
        {
            //arrange
            DateTime Expected = new(1368, 9, 11);

            //act
            var Act = Input.ToDateTime();

            //assert
            Assert.Equal(Expected, Act);
        }

        [Theory]
        [InlineData("1989,09,11 08:37:15 AM")]
        [InlineData("1989,9,11 08:37:15 AM")]
        [InlineData("1989/09/11 08:37:15 AM")]
        [InlineData("1989/9/11 08:37:15 AM")]
        [InlineData("1989-09-11 08:37:15 AM")]
        [InlineData("1989-9-11 08:37:15 AM")]
        public void DateTimeValue_Correct8(string Input)
        {
            //arrange
            DateTime Expected = new(1989, 9, 11, 08, 37, 15);

            //act
            var Act = Input.ToDateTime();

            //assert
            Assert.Equal(Expected.Date, Act.Date);
            Assert.Equal(Expected.Hour, Act.Hour);
            Assert.Equal(Expected.Minute, Act.Minute);
            Assert.Equal(Expected.Second, Act.Second);
        }

        [Theory]
        [InlineData("9368,09,11 98:97:95 AM")]
        [InlineData("9368,9,11 98:97:95 AM")]
        [InlineData("9368/09/11 98:97:95 AM")]
        [InlineData("9368/9/11 98:97:95 AM")]
        [InlineData("9368-09-11 98:97:95 AM")]
        [InlineData("9368-9-11 98:97:95 AM")]
        public void DateTimeValue_Correct9(string Input)
        {
            //arrange
            DateTime Expected = new(9368, 9, 11, 0, 0, 0);

            //act
            var Act = Input.ToDateTime();

            //assert
            Assert.Equal(Expected.Date, Act.Date);
            Assert.Equal(Expected.Hour, Act.Hour);
            Assert.Equal(Expected.Minute, Act.Minute);
            Assert.Equal(Expected.Second, Act.Second);
        }


        [Theory]
        [InlineData("12/08/2022 12:00:00 ق.ظ")]
        [InlineData("12/08/2022 12:00:00 ب.ظ")]
        public void DateTimeValue_Correct1(string Input)
        {
            //arrange
            DateTime Expected = new(2022, 08, 12, 12, 0, 0);

            //act
            var Act = Input.ToDateTime();

            //assert
            Assert.Equal(Expected.Date, Act.Date);
            Assert.Equal(Expected.Hour, Act.Hour);
            Assert.Equal(Expected.Minute, Act.Minute);
            Assert.Equal(Expected.Second, Act.Second);
        }
        
        [Theory]
        [InlineData("8/14/2022 12:00:00 AM")]
        public void DateTimeValue_CorrectN(string Input)
        {
            //arrange
            DateTime Expected = new(2022, 8, 14, 12, 0, 0);

            //act
            var Act = Input.ToDateTime();

            //assert
            Assert.Equal(Expected.Date, Act.Date);
            Assert.Equal(Expected.Hour, Act.Hour);
            Assert.Equal(Expected.Minute, Act.Minute);
            Assert.Equal(Expected.Second, Act.Second);
        }
        [Theory]
        [InlineData("12/08/2022 00:00:00 ق.ظ")]
        [InlineData("12/08/2022 00:00:00 ب.ظ")]
        public void DateTimeValue_Correct22(string Input)
        {
            //arrange
            DateTime Expected = new(2022, 08, 12, 00, 0, 0);

            //act
            var Act = Input.ToDateTime();

            //assert
            Assert.Equal(Expected.Date, Act.Date);
            Assert.Equal(Expected.Hour, Act.Hour);
            Assert.Equal(Expected.Minute, Act.Minute);
            Assert.Equal(Expected.Second, Act.Second);
        }




        [Theory]
        [InlineData("11:31:16 AM")]
        [InlineData("11:31:16")]
        public void DateTimeValue_Correct_Time(string Input)
        {
            //arrange
            DateTime Expected = new(1, 1, 1, 11, 31, 16);

            //act
            var Act = Input.ToDateTime();

            //assert
            Assert.Equal(Expected.Date, Act.Date);
            Assert.Equal(Expected.Hour, Act.Hour);
            Assert.Equal(Expected.Minute, Act.Minute);
            Assert.Equal(Expected.Second, Act.Second);
        }


        [Theory]
        [InlineData("91:91:96 AM")]
        [InlineData("91:91:96")]
        public void DateTimeValue_Correct_Time3(string Input)
        {
            //arrange
            DateTime Expected = new(1, 1, 1, 0, 0, 0);

            //act
            var Act = Input.ToDateTime();

            //assert
            Assert.Equal(Expected.Date, Act.Date);
            Assert.Equal(Expected.Hour, Act.Hour);
            Assert.Equal(Expected.Minute, Act.Minute);
            Assert.Equal(Expected.Second, Act.Second);
        }

        [Theory]
        [InlineData("11:31 AM")]
        [InlineData("11:31")]
        public void DateTimeValue_Correct_Time2(string Input)
        {
            //arrange
            DateTime Expected = new(1, 1, 1, 11, 31, 0);

            //act
            var Act = Input.ToDateTime();

            //assert
            Assert.Equal(Expected.Date, Act.Date);
            Assert.Equal(Expected.Hour, Act.Hour);
            Assert.Equal(Expected.Minute, Act.Minute);
            Assert.Equal(Expected.Second, Act.Second);
        }

        [Fact]
        public void DateTimeValue_Correct5()
        {
            //arrange
            string Input = "1401/12/20 11:31:16 AM";
            DateTime Expected = new(1401, 12, 20, 11, 31, 16);

            //act
            var Act = Input.ToDateTime();

            //assert
            Assert.Equal(Expected.Date, Act.Date);
            Assert.Equal(Expected.Hour, Act.Hour);
            Assert.Equal(Expected.Minute, Act.Minute);
            Assert.Equal(Expected.Second, Act.Second);
        }

        [Fact]
        public void DateTimeValue_Correct10()
        {
            //arrange
            string Input = "1/1/1 12:00:00 AM";
            DateTime Expected = new(1, 1, 1, 12, 0, 0);

            //act
            var Act = Input.ToDateTime();

            //assert
            Assert.Equal(Expected.Date, Act.Date);
            Assert.Equal(Expected.Hour, Act.Hour);
            Assert.Equal(Expected.Minute, Act.Minute);
            Assert.Equal(Expected.Second, Act.Second);
        }

        [Fact]
        public void DateTimeValue_Correct11()
        {
            //arrange
            string Input = "01-01-01 12:00:00.9545454";
            DateTime Expected = new(1, 1, 1, 12, 0, 0);

            //act
            var Act = Input.ToDateTime();

            //assert
            Assert.Equal(Expected.Date, Act.Date);
            Assert.Equal(Expected.Hour, Act.Hour);
            Assert.Equal(Expected.Minute, Act.Minute);
            Assert.Equal(Expected.Second, Act.Second);
        }

        [Fact]
        public void DateTimeValue_Correct12()
        {
            //arrange
            string Input = "01-01-01 22:00:00.9545454";
            DateTime Expected = new(1, 1, 1, 22, 0, 0);

            //act
            var Act = Input.ToDateTime();

            //assert
            Assert.Equal(Expected.Date, Act.Date);
            Assert.Equal(Expected.Hour, Act.Hour);
            Assert.Equal(Expected.Minute, Act.Minute);
            Assert.Equal(Expected.Second, Act.Second);
        }

        [Theory]
        [InlineData("168,9,11")]
        public void DateTimeValue_Correct2(string Input)
        {
            //arrange0789-12-02
            DateTime Expected = new(168, 9, 11);

            //act
            var Act = Input.ToDateTime();

            //assert
            Assert.Equal(Expected, Act);
        }

        [Theory]
        [InlineData("1,1,1")]
        public void DateTimeValue_Correct3(string Input)
        {
            //arrange0622-03-22
            DateTime Expected = new(1, 1, 1);

            //act
            var Act = Input.ToDateTime();

            //assert
            Assert.Equal(Expected, Act);
        }

        [Theory]
        [InlineData("68,9,11")]
        [InlineData("1399,12,30")]
        [InlineData("68,9,1")]
        public void DateTimeValue_Correct4(string Input)
        {
            //arrange0622-03-22
            DateTime Expected = new(1, 1, 1);

            //act
            var Act = Input.ToDateTime();

            //assert
            Assert.NotEqual(Expected, Act);
        }
        #endregion

    }
}