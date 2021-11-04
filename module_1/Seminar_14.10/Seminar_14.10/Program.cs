using System;
using System.IO;
using System.Text;

namespace ConsoleApp23 
{
    class Program 
    {
        static void Main(string[] args) 
        {
            string path = @"Data.txt";

            // Создаем файл с данными
            if (File.Exists(path)) 
            {
                // Сейчас данные для записи вбиты в коде
                // TODO1: сохранить в файл целые случайные значения из диапазона [10;100)
                Console.WriteLine("Введите кол-во чисел: ");
                int n = int.Parse(Console.ReadLine());
                var rand = new Random();
                string createText = "";
                
                for (var i = 0; i < n; i++)
                {
                    if (i % 5 == 0)
                        Console.WriteLine();
                    
                    createText += rand.Next(10, 100) + " ";
                }
                
                File.WriteAllText(path, createText, Encoding.UTF8);
            }

            // Open the file to read from
            if (File.Exists(path)) 
            {
                string readText = File.ReadAllText(path);
                string[] stringValues = readText.Split(' ');
                int[] arr = StringArrayToIntArray(stringValues);
                
                foreach(int i in arr) {
                    Console.Write(i + " ");
                }

                // обрабатываем элементы массива
                // TODO2: Создать два массива по исходному
                // в первый поместить индексы чётных элементов, во второй - нечётных
                // TODO3: Заменяем все нечётные числа исходного массива нулями
                int[] arrayOfEven = new int[1];
                int[] arrayOfOdd = new int[1];
                int oddCount = 0;
                int evenCount = 0;
                for (int i = 0; i < arr.Length; i++)
                {
                    
                    if (arr[i] % 2 == 0)
                    {
                        arrayOfEven[evenCount] = i;
                        evenCount++;
                        Array.Resize(ref arrayOfEven,evenCount + 1);
                    }
                    else if (arr[i] % 2 != 0)
                    {
                        arrayOfOdd[oddCount] = i;
                        oddCount++;
                        Array.Resize(ref arrayOfOdd,oddCount + 1);
                        arr[i] = 0;
                    }
                }
                Console.WriteLine("Массив четных индексов:");
                foreach (var i in arrayOfEven)
                {
                    Console.Write(i + " ");
                }
                Console.WriteLine();
                
                Console.WriteLine("Массив нечетных индексов:");
                foreach (var i in arrayOfOdd)
                {
                    Console.Write(i + " ");
                }
                Console.WriteLine();
                
                Console.WriteLine("Исходный массив чисел:");
                foreach (var i in arr)
                {
                    Console.Write(i + " ");
                }
                Console.WriteLine();
            }
        } // end of Main()
        // преобразование массива строк в массив целых чисел
        public static int[] StringArrayToIntArray(string[] str) 
        {
            int[] arr = null;
            if (str.Length != 0) 
            {
                arr = new int[0];
                foreach (string s in str) 
                {
                    int tmp;
                    if (int.TryParse(s, out tmp)) 
                    {
                        Array.Resize(ref arr, arr.Length + 1);
                        arr[arr.Length - 1] = tmp;
                    }
                } // end of foreach (string s in str)      
            }
            return arr;
        } // end of StringToIntArray()
    } // end of Program
}