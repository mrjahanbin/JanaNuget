using JanaPack;

namespace JanaPackTest
{



    /*
     میخوایم تست کنیم ببینیم تاریخ فارسی رو چطوری به میلادی تبدیل کنیم
    پس ما یک تاریخ بهش پاس میدیم
    1- ممکنه تاریخ نال بهش پاس بدیم پس جلوش باید گرفته بشه
     
     */
    public class PersianDatetimeTest
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
            var Act = Input.Fix().ToMiladiDate();

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


    }
}