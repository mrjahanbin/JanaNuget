using JanaPack;
using JanaPack.Converters;
using System.Globalization;

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