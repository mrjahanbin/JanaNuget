using JanaPack.Calculates;
using JanaPack.Converters;

namespace JanaPackTest.Converters.Numbers
{
    /*
     * میخوایم تست کنیم ببینیم تاریخ فارسی رو چطوری به میلادی تبدیل کنیم   
     */
    public class MathTest
    {
        #region MathTest

        [Theory]
        [InlineData(2000, 10)]
        [InlineData(2000, 0)]
        [InlineData(2000, 1000)]
        [InlineData(20, 1000)]
        public void Value_Correct(decimal Input, decimal Percentage)
        {
            //arrange
            var Expected = (Input*Percentage)/100;

            //act
            var Act = Input.Percentage(Percentage);

            //assert
            Assert.Equal(Expected, Act);

        }
        #endregion


    }
}