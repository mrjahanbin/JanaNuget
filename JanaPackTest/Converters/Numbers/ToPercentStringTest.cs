using JanaPack.Converters;

namespace JanaPackTest.Converters.Numbers
{
    /*
     * میخوایم تست کنیم ببینیم تاریخ فارسی رو چطوری به میلادی تبدیل کنیم   
     */
    public class ToPercentStringStringTest
    {
        #region ToPercentStringStringTest
        [Theory]
        [InlineData(622)]
        public void Value_Correct(decimal Input)
        {
            //arrange

            //act
            var Act = Input.ToPercentString();

            //assert
            Assert.Equal("622", Act);

        }

        [Fact]
        public void Value_Correct5()
        {
            //arrange
            decimal Input = 99999999999.99999999999999999M;
            //act
            var Act = Input.ToPercentString();

            //assert
            Assert.Equal("99,999,999,999.9999", Act);

        }
        
        [Fact]
        public void Value_Correct6()
        {
            //arrange
            decimal Input = 99999999999.99999999999999999M;
            //act
            var Act = Input.ToPercentString(false);

            //assert
            Assert.Equal("99999999999.9999", Act);

        }

        [Theory]
        [InlineData(3.2)]
        [InlineData(22.8)]
        [InlineData(2022.9887)]
        [InlineData(2021.9876)]
        public void Value_Correct1(decimal Input)
        {
            //arrange

            //act
            var Act = Input.ToPercentString();

            //assert
            Assert.NotEqual("0", Act);
            Assert.Contains(".", Act.ToString());

        }
        [Theory]
        [InlineData(3)]
        [InlineData(22)]
        [InlineData(2022)]
        [InlineData(2021)]
        public void Value_Correct2(decimal Input)
        {
            //arrange

            //act
            var Act = Input.ToPercentString();

            //assert
            Assert.NotEqual("0", Act);
            Assert.DoesNotContain(".", Act.ToString());

        }

        [Fact]
        public void Value_Correct3()
        {
            //arrange
            decimal? Input = null;
            //act
            var Act = Input.GetValueOrDefault().ToPercentString();

            //assert
            Assert.Equal("", Act);
            Assert.DoesNotContain(".", Act.ToString());

        }




        #endregion


    }
}