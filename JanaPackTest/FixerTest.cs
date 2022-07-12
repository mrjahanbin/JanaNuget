using JanaPack;

namespace JanaPackTest
{
    /*
     * میخوایم استرینگ ها رو مرتب و خوشگل کنیم که تر و تمیز توی دیتابیس ذخیره بشن
     * 
     */
    public class FixerTest
    {
        #region Fixer
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
        public void Value_Not_Contain_Two_Space(string Input)
        {
            //arrange
            var Expected = "  ";


            //act
            var Act = Input.Fix();

            //assert
            Assert.DoesNotContain(Expected, Act);
        }

        [Theory]
        [InlineData("Jana")]
        [InlineData("Jana         ")]
        [InlineData("           Jana")]
        [InlineData("      Jana       ")]
        public void Value_Correct(string Input)
        {
            //arrange
            var Expected = "Jana";


            //act
            var Act = Input.Fix();

            //assert
            Assert.Equal(Expected, Act);
        }

        [Theory]
        [InlineData("      J   a   n   a       ")]
        public void Value_Correct3(string Input)
        {
            //arrange
            var Expected = "J a n a";


            //act
            var Act = Input.Fix();

            //assert
            Assert.Equal(Expected, Act);
        }

        [Theory]
        [InlineData("جانا")]
        [InlineData("جانا          ")]
        [InlineData("         جانا")]
        [InlineData("        جانا         ")]
        [InlineData("  جانا ")]
        public void Value_Correct2(string Input)
        {
            //arrange
            var Expected = "جانا";


            //act
            var Act = Input.Fix();

            //assert
            Assert.Equal(Expected, Act);
        }

        #endregion


    }
}