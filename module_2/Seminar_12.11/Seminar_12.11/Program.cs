using System;

namespace Seminar_12._11
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("List of exceptions:\n" +
                              "1) IndexOutOfRangeException\n" +
                              "2) FileNotFoundException\n" +
                              "3) NullReferenceException\n" +
                              "4) DivideByZeroException\n" +
                              "5) InvalidCastException\n" +
                              "6) ArgumentOutOfRangeException\n" +
                              "7) StackOverflowException (crashes program)\n" +
                              "8) FormatException\n" +
                              "9) OverflowException\n" +
                              "10) OutOfMemoryException\n" +
                              "11) NotADragonException (custom one)");

            var exceptionNumber = GetUserNumber();
            while (exceptionNumber != 0)
            {
                switch (exceptionNumber)
                {
                    case 1:
                        ExceptionGenerator.IndexOutOfRangeException();
                        break;
                    case 2:
                        ExceptionGenerator.FileNotFoundException();
                        break;
                    case 3:
                        ExceptionGenerator.NullReferenceException(null);
                        break;
                    case 4:
                        ExceptionGenerator.DivideByZeroException();
                        break;
                    case 5:
                        ExceptionGenerator.InvalidCastException();
                        break;
                    case 6:
                        ExceptionGenerator.ArgumentOutOfRangeException();
                        break;
                    case 7:
                        ExceptionGenerator.StackOverflowException();
                        break;
                    case 8:
                        ExceptionGenerator.FormatException();
                        break;
                    case 9:
                        ExceptionGenerator.OverflowException();
                        break;
                    case 10:
                        ExceptionGenerator.OutOfMemoryException();
                        break;
                    case 11:
                        ExceptionGenerator.CustomException();
                        break;
                    default:
                        Console.WriteLine("Unknown command");
                        break;
                }
                
                exceptionNumber = GetUserNumber();
            }
        }

        static int GetUserNumber()
        {
            int numberOfException;
            do
            {
                Console.WriteLine("Choose any exception by number or type 0 to exit");
            } while (!int.TryParse(Console.ReadLine(), out numberOfException));

            return numberOfException;
        }
    }
}