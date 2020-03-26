using System;

namespace CreditCardChecker
{
    public class CreditCardChecker
    {
        /// <summary>
        /// Diese Methode überprüft eine Kreditkartenummer, ob diese gültig ist.
        /// Regeln entsprechend der Angabe.
        /// </summary>
        public static bool IsCreditCardValid(string creditCardNumber)
        {
            bool isValid = false;
            if (creditCardNumber.Length == 16 && CheckString(creditCardNumber))
            {
                if ((GetNumberSumOnEvenPosition(creditCardNumber) + 
                    GetNumberSumOnOddPosition(creditCardNumber) + 
                    (Convert.ToInt32(creditCardNumber[15] - '0'))) % 10 == 0)
                {
                    isValid = true;
                }
            }
            return isValid;
        }

        private static bool CheckString(string creditCardNumber)
        {
            bool isOk = true;
            for (int i = 0; i < creditCardNumber.Length; i++)
            {
                if (char.IsLetter(creditCardNumber[i]))
                {
                    isOk = false;
                }
            }
            return isOk;
        }

        private static int GetNumberSumOnOddPosition(string creditCardNumber)
        {
            int result = 0;
            for (int i = 1; i <= 13; i += 2)
            {
                int number = Convert.ToInt32(creditCardNumber[i] - '0');
                result += number;
            }
            return result;
        }

        private static int GetNumberSumOnEvenPosition(string creditCardNumber)
        {
            int result = 0;
            for (int i = 0; i <= 14; i += 2)
            {
                int number = Convert.ToInt32(creditCardNumber[i] - '0');
                int digitSum = CalculateDigitSum(number * 2);
                result += digitSum;
            }
            return result;
        }


        /// <summary>
        /// Berechnet die Ziffernsumme einer Zahl.
        /// </summary>
        private static int CalculateDigitSum(int number)
        {
            int result = 0;
            while (number > 0)
            {
                result += (number % 10);
                number /= 10;
            }
            return result;
        }

        //private static int ConvertToInt(char ch)
        //{
        //    throw new NotImplementedException();
        //}
    }
}
