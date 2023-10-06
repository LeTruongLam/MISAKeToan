namespace MISA.WebFresher072023.Demo.UnitTests
{
    /// <summary>
    /// TestFixture: Đánh dấu đây là class test
    /// </summary>
    [TestFixture]
    public class CalculatorTests
    {

        #region Add Testcase
        /// <summary>
        /// Hàm Unit Test tổng 2 số
        /// </summary>
        [TestCase(1, 2, 3)]
        [TestCase(5, -2, 3)]
        [TestCase(4, 2, 6)]
        [TestCase(3, int.MaxValue, int.MaxValue + (long)3)]
        public void Add_ValidInput_Sum2Digit(int x, int y, long expectedResult)
        {
            // Arrange
            var calculator = new Calculator();

            // Act
            var actualResult = calculator.Add(x, y);

            // Assert
            Assert.That(actualResult, Is.EqualTo(expectedResult));


        }
        /// <summary>
        /// Hàm Unitest tổng các số trong chuỗi
        /// TH: Trong chuối nhập vào có số âm
        /// </summary>
        /// <remarks>
        /// Tác giả: Lê Trường Lam.
        /// Ngày tạo: 13/9/2023.
        /// </remarks>

        [TestCase("2, 0, -1", "Không chấp nhận toán hạng âm: -1")]
        [TestCase("-3,-4,-5,-6,-7,9 ", "Không chấp nhận toán hạng âm: -3,-4,-5,-6,-7")]
        [TestCase("-1,-2,-3 ", "Không chấp nhận toán hạng âm: -1,-2,-3")]
        [TestCase("1,-2,-3 ", "Không chấp nhận toán hạng âm: -2,-3")]
        [TestCase("-1,2,-3 ", "Không chấp nhận toán hạng âm: -1,-3")]
        public void Add_NegativeNumbers_ThrowException(string str, string expectedMessage)
        {
            // Arrange
            var calculator = new Calculator();
            // Act
            try
            {
                var actualResult = calculator.Add(str);
            }
            catch (Exception ex)
            {
                //Assert
                Assert.That(ex.Message, Is.EqualTo(expectedMessage));
            }
        }

        /// <summary>
        /// Hàm Unitest tổng các số trong chuỗi
        /// TH: Thảo mãn các điều kiện
        /// </summary>
        /// <remarks>
        /// Tác giả: Lê Trường Lam.
        /// Ngày tạo: 13/9/2023.
        /// </remarks>
        /// 
        [TestCase("", 0)]
        [TestCase("1,2,3", 6)]
        [TestCase("1, 2, 3", 6)]
        [TestCase("1", 1)]
        [TestCase("0,1", 1)]
        [TestCase("1,1000", 1001)]

        public void Add_ValidString_SumOfNumbers(string str, long expectedResult)
        {
            // Arrange
            var calculator = new Calculator();

            // Act 
            var actualResult = calculator.Add(str);

            //Assert
            Assert.That(actualResult, Is.EqualTo(expectedResult));
        }
        #endregion

        #region Sub Testcase
        /// <summary>
        /// Hàm Unit Test Hiệu 2 số
        /// </summary>
        [TestCase(3, 2, 1)]
        [TestCase(2, -2, 4)]
        [TestCase(4, 2, 2)]
        [TestCase(3, int.MaxValue, (long)3 - int.MaxValue)]
        public void Sub_ValidInput_Sub2Digit(int x, int y, long expectedResult)
        {
            // Arrange
            var calculator = new Calculator();
            // Act
            var actualResult = calculator.Sub(x, y);
            // Assert
            Assert.That(actualResult, Is.EqualTo(expectedResult));
        }
        #endregion

        #region Mul Testcase
        /// <summary>
        /// Hàm Unit Test Tích 2 số
        /// </summary>
        [TestCase(3, 1, 3)]
        [TestCase(2, -2, -4)]
        [TestCase(4, 2, 8)]
        [TestCase(int.MinValue, int.MaxValue, (long)int.MaxValue * int.MinValue)]
        public void Mul_ValidInput_Mul2Digit(int x, int y, long expectedResult)
        {
            // Arrange
            var calculator = new Calculator();
            // Act
            var actualResult = calculator.Mul(x, y);
            // Assert
            Assert.That(actualResult, Is.EqualTo(expectedResult));
        }
        #endregion

        #region Div Testcase
        /// <summary>
        /// Hàm Unit Test Thương 2 số 
        /// TH: Chia cho 0
        /// </summary>
        [Test]
        public void Div_DivideByZero_ThrowException()
        {
            // Arrange

            var x = 1;
            var y = 0;
            var expectedMessage = "Không chia được cho 0";
            var calculator = new Calculator();

            // Act & Assert
            try
            {
                var actualResult = calculator.Div(x, y);
            }
            catch (Exception ex)
            {
                Assert.That(ex.Message, Is.EqualTo(expectedMessage));
            }

        }

        /// <summary>
        /// Hàm Unit Test Thương 2 số
        /// </summary>
        [TestCase(3, 9, 1 / (double)3)]
        [TestCase(4, 8, 0.5)]
        public void Div_ValidInput_Div2Digit(int x, int y, double expectedResult)
        {
            // Arrange
            var calculator = new Calculator();
            // Act
            var actualResult = calculator.Div(x, y);
            // Assert
            Assert.That(actualResult, Is.EqualTo(expectedResult));
        } 
        #endregion

    }
}
