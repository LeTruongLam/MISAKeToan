namespace MISA.WebFresher072023.Demo
{
    public class Calculator
    {
        /// <summary>
        /// Hàm cộng 2 số nguyên
        /// </summary>
        /// <param name="x">Toán hạng 1</param>
        /// <param name="y">Toán hạng 2</param>
        /// <returns>Tổng 2 số nguyên</returns>
        /// Tạo bởi: Lê Trường Lam 13/9/2023
        public long Add(int x, int y)
        {
            return x + (long)y;
        }
        /// <summary>
        /// Hàm cộng các giá trị của chuỗi
        /// </summary>
        /// <param name="str">Chuỗi đầu vào chứa các giá trị cần cộng</param>
        /// <returns>Tổng các giá trị của chuỗi</returns>
        /// <remarks>
        /// Tác giả: Lê Trường Lam
        /// Ngày tạo: 13/9/2023
        /// </remarks>
        public long Add(string str)
        {
            if (string.IsNullOrEmpty(str))
            {
                return 0;
            }
            var numbers = str.Split(',');

            var sum = 0;
            var numbersNegative = new List<string>();

            foreach (string num in numbers)
            {
                var numTrimmed = num.Trim();
                if (!string.IsNullOrEmpty(numTrimmed))
                {
                    if (int.TryParse(numTrimmed, out int parsedNum))
                    {
                        if (parsedNum < 0)
                        {
                            numbersNegative.Add(numTrimmed);
                        }
                        else
                        {
                            sum += parsedNum;
                        }
                    }
                    else
                    {
                        throw new Exception("Lỗi định dạng");
                    }
                }
            }

            if (numbersNegative.Count > 0)
            {
                throw new Exception($"Không chấp nhận toán hạng âm: {string.Join(",", numbersNegative)}");
            }

            return sum;
        }

        /// <summary>
        /// Hàm trừ 2 số nguyên
        /// </summary>
        /// <param name="x">Toán hạng 1</param>
        /// <param name="y">Toán hạng 2</param>
        /// <returns>Hiệu 2 số nguyên</returns>
        /// Tạo bởi: Lê Trường Lam 13/9/2023
        public long Sub(int x, int y)
        {
            return x - (long)y;
        }
        /// <summary>
        /// Hàm nhân 2 số nguyên
        /// </summary>
        /// <param name="x"></param>
        /// <param name="y"></param>
        /// <returns></returns>
        /// <exception cref="NotImplementedException"></exception>
        public long Mul(int x, int y)
        {
            return x * (long)y;
        }
        public double Div(int x, int y)
        {
            if (y == 0)
            {
                new Exception("Không chia được cho 0");
            }
            return x / (double)y;
        }

    }
}
