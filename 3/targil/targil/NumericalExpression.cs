using System;
using System.Collections.Generic;
using System.Text;

namespace targil
{
    class NumericalExpression
    {
        
        private double MainNumber;
        private static string[] factor = { "", " thousands,", " millions,", " billions," };
        private static string[] singles = { "", "one", "two", "three", "four", "five", "six", "seven", "eight", "nine" };
        private static string[] tensWithOnes = { "", "eleven", "twelve", "thirteen", "fourteen", "fifteen", "sixteen", "seventeen", "eighteen", "nineteen" };
        private static string[] tens = { "", "ten", "twenty", "thirty", "forty", "fifty", "sixty", "seventy", "eighty", "ninety" };
        public NumericalExpression(long pNumber) => MainNumber = pNumber;

        private string readNumber(int number)
        {
            StringBuilder numInWords = new StringBuilder();
            if (number >= 100) 
            {
                numInWords.Append(singles[number / 100] + " hundred");
                number %= 100;
                if(number % 100 > 0)
                {
                    numInWords.Append(" and ");
                }
            }

            if (number > 10 && number < 20)
            {
                numInWords.Append(tensWithOnes[number % 10]);
            }
            else
            {
                numInWords.Append(tens[number / 10] + " ");
                numInWords.Append(singles[number % 10]);
            }
            return numInWords.ToString();
        }

        public override string ToString()
        {
            double number = MainNumber;
            int factorCounter = 0;
            StringBuilder numInWords = new StringBuilder();

            while (number != 0)
            {
                if (number % 1000 != 0)
                {
                    numInWords.Insert(0, readNumber(Convert.ToInt32(number % 1000)) + factor[factorCounter] + " ");
                }
                number -= number % 1000;
                number /= 1000;
                factorCounter++;
            }
            return numInWords.ToString();
        }

    }
}
