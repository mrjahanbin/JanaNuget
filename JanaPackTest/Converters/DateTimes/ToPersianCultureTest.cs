using JanaPack.Converters;
using System.Globalization;

namespace JanaPackTest.Converters.DateTimes
{
    /*
     * میخوایم تست کنیم ببینیم تاریخ فارسی رو چطوری به میلادی تبدیل کنیم   
     */
    public class ToPersianCultureTest
    {

        #region ToPersianCultureTest
        [Theory]
        [InlineData(622, 3, 22)]
        public void ShamsiDateTime_Value_Correct(int Year, int Month, int Day)
        {
            //arrange
            DateTime? Input = new DateTime(Year, Month, Day, new GregorianCalendar());
            var Ex = "01/01/0001 12:00:00 ق.ظ-1/01/01 (-511567 روز دیگر برابر -73081 هفته و 0 روز )";

            //act
            var Act = Input.GetValueOrDefault().ToPersianCulture();

            //assert
            Assert.Equal(Ex, Act);

        }

        [Theory]
        [InlineData(2045, 03, 20)]
        public void ShamsiDateTime_Value_Correct2(int Year, int Month, int Day)
        {
            //arrange
            DateTime? Input = new DateTime(Year, Month, Day, new GregorianCalendar());
            var Ex = "01/01/1424 12:00:00 ق.ظ-1424/01/01 (8172 روز دیگر برابر 1167 هفته و 3 روز )";

            //act
            var Act = Input.GetValueOrDefault().ToPersianCulture();

            //assert
            Assert.Equal(Ex, Act);

        }


        [Fact]
        public void ShamsiDateTime_Value_Null()
        {
            //arrange
            DateTime? Input = null;
            var Ex = "0001-01-01T00:00:00- (-738462 روز دیگر برابر -105494 هفته و -4 روز )";

            //act
            var Act = Input.GetValueOrDefault().ToPersianCulture();

            //assert
            Assert.Equal(Ex, Act);
        }




        #endregion
    }
}