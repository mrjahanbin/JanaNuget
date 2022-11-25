using JanaPack.Converters;
using System.Globalization;

namespace JanaPackTest.Converters.DateTimes
{
    /*
     * میخوایم تست کنیم ببینیم تاریخ فارسی رو چطوری به میلادی تبدیل کنیم   
     */
    public class ToPersianTest
    {
        #region ToShamsiDate
        [Theory]
        [InlineData(622, 3, 22)]
        public void Shamsi_Value_Correct(int Year, int Month, int Day)
        {
            //arrange
            DateTime? Input = new DateTime(Year, Month, Day, new GregorianCalendar());

            //act
            var Act = Input.GetValueOrDefault().ToShamsi();

            //assert
            Assert.Equal("1/01/01", Act);

        }

        [Theory]
        [InlineData("1/1/0001 12:00:00 AM")]
        [InlineData("1/1/0001 00:00:00 AM")]
        [InlineData("1/1/0001 00:00:00")]
        public void Shamsi_Value_Correct8(string value)
        {
            //arrange
            DateTime? Input = DateTime.Parse(value);

            //act
            var Act = Input.GetValueOrDefault().ToShamsi();

            //assert
            Assert.Equal("", Act);

        }

        [Theory]
        [InlineData("0001-01-01T00:00:00")]
        public void Shamsi_Value_Correct88(string value)
        {
            //arrange
            DateTime? Input = DateTime.Parse(value);

            //act
            var Act = Input.GetValueOrDefault().ToShamsi();

            //assert
            Assert.Equal("", Act);

        }

        [Theory]
        [InlineData(623, 3, 22)]
        [InlineData(2022, 5, 12)]
        [InlineData(2021, 03, 20)]
        public void Shamsi_Value_Correct2(int Year, int Month, int Day)
        {
            //arrange
            DateTime? Input = new DateTime(Year, Month, Day, new GregorianCalendar());

            //act
            var Act = Input.GetValueOrDefault().ToShamsi();

            //assert
            Assert.NotEqual("", Act);
            Assert.NotEqual("1/01/01", Act);

        }

        [Theory]
        [InlineData(621, 3, 22)]
        [InlineData(1, 1, 1)]
        public void Shamsi_Value_Not_Correct(int Year, int Month, int Day)
        {
            //arrange
            DateTime? Input = new DateTime(Year, Month, Day, new GregorianCalendar());

            //act
            var Act = Input.GetValueOrDefault().ToShamsi();

            //assert
            Assert.Equal("", Act);

        }

        [Theory]
        [InlineData(1, 1, 1)]
        [InlineData(1111, 1, 1)]
        [InlineData(1111, 11, 11)]
        public void Shamsi_Value_Not_Correct2(int Year, int Month, int Day)
        {
            Assert.False(Year == 0);
            Assert.False(Year > 9999);
            Assert.False(Year < 1);

            Assert.False(Month == 0);
            Assert.False(Month > 99);
            Assert.False(Month < 1);

            Assert.False(Day == 0);
            Assert.False(Day > 99);
            Assert.False(Day < 1);

        }



        [Fact]
        public void Shamsi_Value_Null()
        {
            //arrange
            DateTime? Input = null;

            //act
            var Act = Input.GetValueOrDefault().ToShamsi();

            //assert
            Assert.Equal("", Act);
        }




        #endregion

        #region ToShamsiDateTime
        [Theory]
        [InlineData(622, 3, 22)]
        public void ShamsiDateTime_Value_Correct(int Year, int Month, int Day)
        {
            //arrange
            DateTime? Input = new DateTime(Year, Month, Day, new GregorianCalendar());

            //act
            var Act = Input.GetValueOrDefault().ToShamsiDateTime();

            //assert
            Assert.Equal("1/01/01 0:0:0", Act);

        }

        [Theory]
        [InlineData(623, 3, 22)]
        [InlineData(2022, 5, 12)]
        [InlineData(2021, 03, 20)]
        public void ShamsiDateTime_Value_Correct2(int Year, int Month, int Day)
        {
            //arrange
            DateTime? Input = new DateTime(Year, Month, Day, new GregorianCalendar());

            //act
            var Act = Input.GetValueOrDefault().ToShamsiDateTime();

            //assert
            Assert.NotEqual("", Act);
            Assert.NotEqual("1/01/01", Act);

        }

        [Theory]
        [InlineData(621, 3, 22)]
        [InlineData(1, 1, 1)]
        public void ShamsiDateTime_Value_Not_Correct(int Year, int Month, int Day)
        {
            //arrange
            DateTime? Input = new DateTime(Year, Month, Day, new GregorianCalendar());

            //act
            var Act = Input.GetValueOrDefault().ToShamsiDateTime();

            //assert
            Assert.Equal("", Act);

        }

        [Theory]
        [InlineData(1, 1, 1)]
        [InlineData(1111, 1, 1)]
        [InlineData(1111, 11, 11)]
        public void ShamsiDateTime_Value_Not_Correct2(int Year, int Month, int Day)
        {
            Assert.False(Year == 0);
            Assert.False(Year > 9999);
            Assert.False(Year < 1);

            Assert.False(Month == 0);
            Assert.False(Month > 99);
            Assert.False(Month < 1);

            Assert.False(Day == 0);
            Assert.False(Day > 99);
            Assert.False(Day < 1);

        }



        [Fact]
        public void ShamsiDateTime_Value_Null()
        {
            //arrange
            DateTime? Input = null;

            //act
            var Act = Input.GetValueOrDefault().ToShamsiDateTime();

            //assert
            Assert.Equal("", Act);
        }




        #endregion

        #region ToShamsiYear
        [Theory]
        [InlineData(622, 3, 22)]
        public void ShamsiYear_Value_Correct(int Year, int Month, int Day)
        {
            //arrange
            DateTime? Input = new DateTime(Year, Month, Day, new GregorianCalendar());

            //act
            var Act = Input.GetValueOrDefault().ToShamsiYear();

            //assert
            Assert.Equal("1", Act);

        }

        [Theory]
        [InlineData(623, 3, 22)]
        [InlineData(2022, 5, 12)]
        [InlineData(2021, 03, 20)]
        public void ShamsiYear_Value_Correct2(int Year, int Month, int Day)
        {
            //arrange
            DateTime? Input = new DateTime(Year, Month, Day, new GregorianCalendar());

            //act
            var Act = Input.GetValueOrDefault().ToShamsiYear();

            //assert
            Assert.NotEqual("", Act);
            Assert.NotEqual("1", Act);

        }

        [Theory]
        [InlineData(2022, 03, 20)]
        public void ShamsiYear_Value_Correct3(int Year, int Month, int Day)
        {
            //arrange
            DateTime? Input = new DateTime(Year, Month, Day, new GregorianCalendar());

            //act
            var Act = Input.GetValueOrDefault().ToShamsiYear();

            //assert
            Assert.Equal("1400", Act);

        }

        [Theory]
        [InlineData(621, 3, 22)]
        [InlineData(1, 1, 1)]
        public void ShamsiYear_Value_Not_Correct(int Year, int Month, int Day)
        {
            //arrange
            DateTime? Input = new DateTime(Year, Month, Day, new GregorianCalendar());

            //act
            var Act = Input.GetValueOrDefault().ToShamsiYear();

            //assert
            Assert.Equal("", Act);

        }

        [Theory]
        [InlineData(1, 1, 1)]
        [InlineData(1111, 1, 1)]
        [InlineData(1111, 11, 11)]
        public void ShamsiYear_Value_Not_Correct2(int Year, int Month, int Day)
        {
            Assert.False(Year == 0);
            Assert.False(Year > 9999);
            Assert.False(Year < 1);

            Assert.False(Month == 0);
            Assert.False(Month > 99);
            Assert.False(Month < 1);

            Assert.False(Day == 0);
            Assert.False(Day > 99);
            Assert.False(Day < 1);

        }



        [Fact]
        public void ShamsiYear_Value_Null()
        {
            //arrange
            DateTime? Input = null;

            //act
            var Act = Input.GetValueOrDefault().ToShamsiYear();

            //assert
            Assert.Equal("", Act);
        }




        #endregion
    }
}