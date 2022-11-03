using JanaPack.Converters;

namespace JanaPackTest.Converters.Numbers
{
    /*
     * میخوایم تست کنیم ببینیم تاریخ فارسی رو چطوری به میلادی تبدیل کنیم   
     */
    public class ToPercentTest
    {
        #region ToPercent
        [Theory]
        [InlineData(622)]
        public void Value_Correct(decimal Input)
        {
            //arrange

            //act
            var Act = Input.ToPercent();

            //assert
            Assert.Equal(622, Act);

        }

        [Fact]
        public void Value_Correct5()
        {
            //arrange
            decimal Input = 99999999999.99999999999999999M;
            //act
            var Act = Input.ToPercent();

            //assert
            Assert.Equal(99999999999.9999M, Act);

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
            var Act = Input.ToPercent();
            var ActString = Act.ToString();

            //assert
            Assert.NotEqual(0, Act);
            if (ActString.Contains("/"))
            {
                Assert.Contains("/", Act.ToString());
            }
            if (ActString.Contains("."))
            {
                Assert.Contains(".", Act.ToString());
            }


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
            var Act = Input.ToPercent();

            //assert
            Assert.NotEqual(0, Act);
            Assert.DoesNotContain(".", Act.ToString());

        }

        [Fact]
        public void Value_Correct3()
        {
            //arrange
            decimal? Input = null;
            //act
            var Act = Input.GetValueOrDefault().ToPercent();

            //assert
            Assert.Equal(0, Act);
            Assert.DoesNotContain(".", Act.ToString());

        }




        #endregion


    }
}