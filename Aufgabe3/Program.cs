using System;

namespace Aufgabe3
{
    class Program
    {
        static void Main(string[] args)
        {
            int number = Convert.ToInt32(args[0]);
            int toBase = Convert.ToInt32(args[1]);
            int fromBase = Convert.ToInt32(args[2]);
            Console.WriteLine(number + " in Hexadezimal ist " + ConvertDecimalToHexal(number));
            Console.WriteLine(number + " in Dezimal ist " + ConvertHexalToDezimal(number));
            //Console.WriteLine(ConvertToBaseFromDecimal(toBase, number));
            //Console.WriteLine(ConvertToDecimalFromBase(fromBase, number));
        }

        static int ConvertDecimalToHexal(int dec)
        {
            int firstNumDec = dec / 6;
            int remainderDec = dec % 6;
            int solutionDec = firstNumDec * 10 + remainderDec;

            return solutionDec;
        }

        static int ConvertHexalToDezimal(int hex)
        {
            int firstNumHex = hex / 10;
            int remainderHex = hex % 10;
            int solutionHex = firstNumHex * 6 + remainderHex;

            return solutionHex;
        }

        static int ConvertToBaseFromDecimal(int toBase, int dec)
        {
            int firstNumToBaseFromDecimal = dec / toBase;
            int remainderToBaseFromDecimal = dec % toBase;
            int solutionToBaseFromDecimal = firstNumToBaseFromDecimal * 10 + remainderToBaseFromDecimal;

            return solutionToBaseFromDecimal;
        }

        static int ConvertToDecimalFromBase(int fromBase, int number)
        {
            int firstNumToDecimalFromBase = number / fromBase;
            int remainderToDecimalFromBase = number % fromBase;
            int solutionToDecimalFromBase = firstNumToDecimalFromBase * 6 + remainderToDecimalFromBase;

            return solutionToDecimalFromBase;
        }

        public static int ConvertNumberToBaseFromBase(int number, int toBase, int fromBase)
        {

            if (2 <= fromBase && fromBase <= 10 && 2 <= toBase && toBase <= 10)
            {
                int dec = ConvertToDecimalFromBase(fromBase, number);
                int solutionNumberToBaseFromBase = ConvertToBaseFromDecimal(toBase, dec);
                return solutionNumberToBaseFromBase;
            }
            return -1;
        }
    }
}
