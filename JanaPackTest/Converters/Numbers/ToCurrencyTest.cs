using JanaPack.Converters;
using System.Globalization;

namespace JanaPackTest.Converters.Numbers
{
    /*
     * میخوایم تست کنیم ببینیم تاریخ فارسی رو چطوری به میلادی تبدیل کنیم   
     */
    public class ToCurrencyTest
    {
        #region ToCurrencyTest

        [Theory]
        [InlineData(622, "#,#.00")]
        public void Value_Correct(decimal Input, string Format)
        {
            //arrange

            //act
            var Act = Input.ToCurrency(Format);

            //assert
            Assert.Equal("622.00", Act);

        }
        [Theory]
        [InlineData(622, "#,0")]
        public void Value_Correct_Rial(decimal Input, string Format)
        {
            //arrange

            //act
            var Act = Input.ToCurrency(Format);

            //assert
            Assert.Equal("622", Act);

        }
        

        [Theory]
        [InlineData(622)]
        public void Int_Value_Empty_ToCurrency(decimal Input)
        {
            //arrange

            //act
            var Act = Input.ToCurrency();

            //assert
            Assert.Equal("622", Act);

        }
        [Theory]
        [InlineData(622.22)]
        public void Decimal_Value_Empty_ToCurrency(decimal Input)
        {
            //arrange

            //act
            var Act = Input.ToCurrency();

            //assert
            Assert.Equal("622", Act);

        }

        
        [Theory]
        [InlineData(0, "#,#.00")]
        public void Value_Zero_Correct(decimal Input, string Format)
        {
            //arrange

            //act
            var Act = Input.ToCurrency(Format);

            //assert
            Assert.Equal("", Act);

        }
        [Theory]
        [InlineData(0, "#,0")]
        public void Value_Zero_Correct_Rial(decimal Input, string Format)
        {
            //arrange

            //act
            var Act = Input.ToCurrency(Format);

            //assert
            Assert.Equal("", Act);

        }
        


        [Theory]
        [InlineData(9999999999999999999, "#,#.00")]
        public void Big_Value_Correct(decimal Input, string Format)
        {
            //arrange

            //act
            var Act = Input.ToCurrency(Format);

            //assert
            Assert.Equal("9,999,999,999,999,999,999.00", Act);

        }
        [Theory]
        [InlineData(9999999999999999999, "#,0")]
        public void Big_Value_Correct_Rial(decimal Input, string Format)
        {
            //arrange

            //act
            var Act = Input.ToCurrency(Format);

            //assert
            Assert.Equal("9,999,999,999,999,999,999", Act);

        }


        [Fact]
        public void Big_Value_Correct2()
        {
            //arrange
            string Format = "#,#.00";
            decimal Input = 99999999999999999999.999999M;
            //act
            var Act = Input.ToCurrency(Format);

            //assert
            Assert.Equal("99,999,999,999,999,999,999.99", Act);

        }
        [Fact]
        public void Big_Value_Correct_Rial2()
        {
            //arrange
            string Format = "#,0";
            decimal Input = 99999999999999999999.999999M;
            //act
            var Act = Input.ToCurrency(Format);

            //assert
            Assert.Equal("99,999,999,999,999,999,999", Act);

        }


        [Theory]
        [InlineData(622345, "#,#.00")]
        public void Value_LargeNumber_Correct_With_Format(decimal Input, string Format)
        {
            //arrange

            //act
            var Act = Input.ToCurrency(Format);

            //assert
            Assert.Equal("622,345.00", Act);

        }
        [Theory]
        [InlineData(622345, "#,0")]
        public void Value_LargeNumber_Correct_With_Format_Rial(decimal Input, string Format)
        {
            //arrange

            //act
            var Act = Input.ToCurrency(Format);

            //assert
            Assert.Equal("622,345", Act);

        }


        [Theory]
        [InlineData(622, "")]
        public void Value_Correct_Without_Format(decimal Input, string Format)
        {
            //arrange

            //act
            var Act = Input.ToCurrency(Format);

            //assert
            Assert.Equal("622", Act);
        }
        [Theory]
        [InlineData(622, null)]
        public void Value_Correct_Null_Format(decimal Input, string Format)
        {
            //arrange

            //act
            var Act = Input.ToCurrency(Format);

            //assert
            Assert.Equal("622", Act);
        }


        [Theory]
        [InlineData(0, "")]
        public void Value_Zero_Without_Format(decimal Input, string Format)
        {
            //arrange

            //act
            var Act = Input.ToCurrency(Format);

            //assert
            Assert.Equal("", Act);

        }
        [Theory]
        [InlineData(0, null)]
        public void Value_Zero_Null_Format_Rial(decimal Input, string Format)
        {
            //arrange

            //act
            var Act = Input.ToCurrency(Format);

            //assert
            Assert.Equal("", Act);

        }


        [Theory]
        [InlineData(622, "kjhkjh")]
        [InlineData(622, "*&^*&^*&")]
        [InlineData(622, "98767687")]
        [InlineData(622, " 997987 ")]
        [InlineData(622, " 997987             ")]
        [InlineData(622, "            997987 ")]
        [InlineData(622, "            9979        87     ")]
        [InlineData(622, "            (*&(        (*&(     ")]
        [InlineData(622, "            hkjl       kjh     ")]
        [InlineData(622, "            hkjl       (*&   98789     ")]
        [InlineData(622, "            hkjl       (*&        ")]
        public void Value_Not_Correct_Format(decimal Input, string Format)
        {
            //arrange

            //act
            var Act = Input.ToCurrency(Format);

            //assert
            Assert.Equal("", Act);
        }


        #endregion


    }
}