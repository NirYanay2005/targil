using System;
using System.Collections.Generic;
using System.Text;

namespace targil
{
    class NumericalExpression
    {
        
        private double mainNumber;
        private static string[] factor = { "", " thousands,", " millions,", " billions," };
        private static string[] singles = { "", "one", "two", "three", "four", "five", "six", "seven", "eight", "nine" };
        private static string[] tensWithOnes = { "", "eleven", "twelve", "thirteen", "fourteen", "fifteen", "sixteen", "seventeen", "eighteen", "nineteen" };
        private static string[] tens = { "", "ten", "twenty", "thirty", "forty", "fifty", "sixty", "seventy", "eighty", "ninety" };

        public NumericalExpression(double pNumber) => mainNumber = pNumber;
        
        /*
         * To String gets a number, separate it by the factor values
         * And by using ReadNumber it builds the complete number for right to left
         */
        public override string ToString()
        {
            double number = mainNumber;
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

        /*
         * Read Number is an helper function for ToString.
         * It gets a number max 999
         * Creates a string, breaks the number down and build the string using the constants at top
         * Finally it returns the number as a string
         */
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
        public double GetValue() { return mainNumber; } 


        /*
         * Function Overloading:
         * אם עושים שתי פונקציות עם אותו השם אשר מקבלות פרמטרים שונים -> זה נקרא כך.
         * המשתמש בקוד יוכל לקרוא לפונקציות עם איזה מסוגי הפרמטרים שירצה והוא יגיע למקום הנכון
         */
        public static int SumLetters(double number)
        {
            NumericalExpression tmp = new NumericalExpression(number);
            return SumLetters(tmp); // uses the other funtions so i wont reapet myself
        }
        public static int SumLetters(NumericalExpression numericalExpression)
        {
            string inWords = numericalExpression.ToString(); // Get as words
            string[] words = inWords.Split(null); // split for words
            int counter = 0;
            foreach (var word in words)
            {
                counter += word.Length; // count each word separatly
            }
            return counter;
        }
      
        

    }
}
