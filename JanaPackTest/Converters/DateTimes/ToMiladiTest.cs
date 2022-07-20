using JanaPack;
using JanaPack.Converters;

namespace JanaPackTest.Converters.DateTimes
{
    /*
     * میخوایم تست کنیم ببینیم تاریخ فارسی رو چطوری به میلادی تبدیل کنیم   
     */
    public class ToMiladiTest
    {
        #region ToMiladiDate
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
            var Act = Fixer.Fix(Input).ToMiladiDate();

            //assert
            Assert.Equal(Expected, Act);
        }

        [Theory]
        [InlineData("1368,09,11")]
        [InlineData("1368/09/11")]
        [InlineData("1368,9,11")]
        public void Value_Correct(string Input)
        {
            //arrange
            DateTime Expected = new(1989, 12, 02);

            //act
            var Act = Input.ToMiladiDate();

            //assert
            Assert.Equal(Expected, Act);
        }

        [Theory]
        [InlineData("168,9,11")]
        public void Value_Correct2(string Input)
        {
            //arrange0789-12-02
            DateTime Expected = new(789, 12, 02);

            //act
            var Act = Input.ToMiladiDate();

            //assert
            Assert.Equal(Expected, Act);
        }

        [Theory]
        [InlineData("1,1,1")]
        public void Value_Correct3(string Input)
        {
            //arrange0622-03-22
            DateTime Expected = new(622, 3, 22);

            //act
            var Act = Input.ToMiladiDate();

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
            var Act = Input.ToMiladiDate();

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
            var Act = Input.ToMiladiDateTime();

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
            DateTime Expected = new(1989, 12, 02);

            //act
            var Act = Input.ToMiladiDateTime();

            //assert
            Assert.Equal(Expected, Act);
        }

        [Theory]
        [InlineData("1368,09,11 08:37:15 AM")]
        [InlineData("1368,9,11 08:37:15 AM")]
        [InlineData("1368/09/11 08:37:15 AM")]
        [InlineData("1368/9/11 08:37:15 AM")]
        [InlineData("1368-09-11 08:37:15 AM")]
        [InlineData("1368-9-11 08:37:15 AM")]
        public void DateTimeValue_Correct8(string Input)
        {
            //arrange
            DateTime Expected = new(1989, 12, 02, 08, 37, 15);

            //act
            var Act = Input.ToMiladiDateTime();

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
            DateTime Expected = new(9989, 11, 28, 0, 0, 0);

            //act
            var Act = Input.ToMiladiDateTime();

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
            var Act = Input.ToMiladiDateTime();

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
            var Act = Input.ToMiladiDateTime();

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
            var Act = Input.ToMiladiDateTime();

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
            DateTime Expected = new(2023, 03, 11, 11, 31, 16);

            //act
            var Act = Input.ToMiladiDateTime();

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
            DateTime Expected = new(622, 03, 22, 12, 0, 0);

            //act
            var Act = Input.ToMiladiDateTime();

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
            DateTime Expected = new(622, 03, 22, 12, 0, 0);

            //act
            var Act = Input.ToMiladiDateTime();

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
            DateTime Expected = new(622, 03, 22, 22, 0, 0);

            //act
            var Act = Input.ToMiladiDateTime();

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
            DateTime Expected = new(789, 12, 02);

            //act
            var Act = Input.ToMiladiDateTime();

            //assert
            Assert.Equal(Expected, Act);
        }

        [Theory]
        [InlineData("1,1,1")]
        public void DateTimeValue_Correct3(string Input)
        {
            //arrange0622-03-22
            DateTime Expected = new(622, 3, 22);

            //act
            var Act = Input.ToMiladiDateTime();

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
            var Act = Input.ToMiladiDateTime();

            //assert
            Assert.NotEqual(Expected, Act);
        }
        #endregion

        #region ToMiladiYear
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
        public void MiladiYear_Value_Not_Correct(string Input)
        {
            //arrange

            //act
            var Act = Fixer.Fix(Input).ToMiladiYear();

            //assert
            Assert.Equal("", Act);
        }

        [Theory]
        [InlineData("1368,09,11")]
        [InlineData("1368/09/11")]
        [InlineData("1368,9,11")]
        public void MiladiYear_Value_Correct(string Input)
        {
            //arrange
            string Expected = "1989";

            //act
            var Act = Input.ToMiladiYear();

            //assert
            Assert.NotEqual("", Act);
            Assert.Equal(Expected, Act);
        }

        [Theory]
        [InlineData("168,9,11")]
        public void MiladiYear_Value_Correct2(string Input)
        {
            //arrange0789-12-02
            string Expected = "789";

            //act
            var Act = Input.ToMiladiYear();

            //assert
            Assert.NotEqual("", Act);
            Assert.Equal(Expected, Act);
        }

        [Theory]
        [InlineData("1,1,1")]
        public void MiladiYear_Value_Correct3(string Input)
        {
            //arrange0622-03-22
            string Expected = "622";

            //act
            var Act = Input.ToMiladiYear();

            //assert
            Assert.NotEqual("", Act);
            Assert.Equal(Expected, Act);
        }

        [Theory]
        [InlineData("68,9,11")]
        [InlineData("1399,12,30")]
        [InlineData("68,9,1")]
        public void MiladiYear_Value_Correct4(string Input)
        {
            //arrange0622-03-22
            string Expected = "1";

            //act
            var Act = Input.ToMiladiYear();

            //assert
            Assert.NotEqual("", Act);
            Assert.NotEqual(Expected, Act);
        }
        #endregion
    }
}