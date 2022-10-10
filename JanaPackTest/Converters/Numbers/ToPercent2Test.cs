using JanaPack.Converters;

namespace JanaPackTest.Converters.Numbers
{
    /*
     * میخوایم تست کنیم ببینیم تاریخ فارسی رو چطوری به میلادی تبدیل کنیم   
     */
    public class ToPercent2Test
    {
        #region ToPercent2Test


        [Theory]
        [InlineData(622, 0)]
        [InlineData(622, 4)]
        public void Value_Correct_Rial(decimal Input, int Format)
        {
            //arrange

            //act
            var Act = Input.ToPercent(Format);

            //assert
            Assert.Equal(622, Act);

        }

        [Theory]
        [InlineData(622.435465, 4)]
        public void Value_Correct_Rial2(decimal Input, int Format)
        {
            //arrange

            //act
            var Act = Input.ToPercent(Format);

            //assert
            Assert.Equal(622.4354M, Act);

        }


        [Theory]
        [InlineData(622.22)]
        public void Decimal_Value_Empty_ToCurrency(decimal Input)
        {
            //arrange

            //act
            var Act = Input.ToPercent();

            //assert
            Assert.Equal(622.22M, Act);

        }


        [Theory]
        [InlineData(0, 2)]
        public void Value_Zero_Correct(decimal Input, int Format)
        {
            //arrange

            //act
            var Act = Input.ToPercent(Format);

            //assert
            Assert.Equal(0, Act);

        }
        [Theory]
        [InlineData(0, 0)]
        public void Value_Zero_Correct_Rial(decimal Input, int Format)
        {
            //arrange

            //act
            var Act = Input.ToPercent(Format);

            //assert
            Assert.Equal(0, Act);

        }



        [Theory]
        [InlineData(9999999999999999999, 2)]
        public void Big_Value_Correct(decimal Input, int Format)
        {
            //arrange

            //act
            var Act = Input.ToPercent(Format);

            //assert
            Assert.Equal(9999999999999999999.00M, Act);

        }
        [Theory]
        [InlineData(9999999999999999999, 0)]
        public void Big_Value_Correct_Rial(decimal Input, int Format)
        {
            //arrange

            //act
            var Act = Input.ToPercent(Format);

            //assert
            Assert.Equal(9999999999999999999M, Act);

        }


        [Fact]
        public void Big_Value_Correct2()
        {
            //arrange
            int Format = 2;
            decimal Input = 99999999999999999999.999999M;
            //act
            var Act = Input.ToPercent(Format);

            //assert
            Assert.Equal(99999999999999999999.99M, Act);

        }
        [Fact]
        public void Big_Value_Correct_Rial2()
        {
            //arrange
            int Format = 0;
            decimal Input = 99999999999999999.999999M;
            //act
            var Act = Input.ToPercent(Format);

            //assert
            Assert.Equal(99999999999999999, Act);

        }


        [Theory]
        [InlineData(622345, 2)]
        public void Value_LargeNumber_Correct_With_Format(decimal Input, int Format)
        {
            //arrange

            //act
            var Act = Input.ToPercent(Format);

            //assert
            Assert.Equal(622345.00M, Act);

        }
        [Theory]
        [InlineData(622345, 0)]
        public void Value_LargeNumber_Correct_With_Format_Rial(decimal Input, int Format)
        {
            //arrange

            //act
            var Act = Input.ToPercent(Format);

            //assert
            Assert.Equal(622345, Act);

        }


        [Theory]
        [InlineData(622, 0)]
        public void Value_Correct_Without_Format(decimal Input, int Format)
        {
            //arrange

            //act
            var Act = Input.ToPercent(Format);

            //assert
            Assert.Equal(622, Act);
        }
        [Theory]
        [InlineData(622, null)]
        public void Value_Correct_Null_Format(decimal Input, int? Format)
        {
            //arrange

            //act
            var Act = Input.ToPercent(Format);

            //assert
            Assert.Equal(622, Act);
        }


        [Theory]
        [InlineData(0, 0)]
        public void Value_Zero_Without_Format(decimal Input, int Format)
        {
            //arrange

            //act
            var Act = Input.ToPercent(Format);

            //assert
            Assert.Equal(0, Act);

        }
        [Theory]
        [InlineData(0, null)]
        public void Value_Zero_Null_Format_Rial(decimal Input, int? Format)
        {
            //arrange

            //act
            var Act = Input.ToPercent(Format);

            //assert
            Assert.Equal(0, Act);

        }


        [Theory]
        [InlineData(622, 9876876)]
        public void Value_Not_Correct_Format(decimal Input, int Format)
        {
            //arrange

            //act
            var Act = Input.ToPercent(Format);

            //assert
            Assert.Equal(0, Act);
        }

        [Theory]
        [InlineData(622.22, 9876876)]
        public void Value_Not_Correct_Format2(decimal Input, int Format)
        {
            //arrange

            //act
            var Act = Input.ToPercent(Format);

            //assert
            Assert.Equal(0, Act);
        }


        #endregion


    }
}