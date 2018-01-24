using System;

namespace Intership_7
{
    class Program
    {
        static void Main(string[] args)
        {
            string str; // str - кодовое слово Хэмминга
            int num = 0, numOfError = 0, sum, ratio, index = 0; // num - количество контрольных битов, numOfError - номер бита с ошибкой, sum - сумма контролируемых битов
            double j; // j - 2 в определённой степени

            str = checkByte("Введите кодовое слово: ");
            int[] mas = new int[str.Length];

            for (int i = 0; i < str.Length; i++)
            {
                if (str[i] == '0') mas[i] = 0;
                if (str[i] == '1') mas[i] = 1;
            }

            num = degree(str.Length); // Степень двойки

            for (int i = 0; i <= num; i++)
            {
                sum = 0;
                ratio = 1;
                j = Math.Pow(2, i);

                do
                {
                    for (int k = 0; k < j; k++)
                    {
                        index = k + (int) j * ratio - 1;
                        if (index >= str.Length) break;
                        sum += mas[index];
                    }
                    if (j == 1) ratio += 2; else ratio += (int) j;

                } while (index < str.Length);

                if (sum % 2 != mas[((int) j)-1]) numOfError += (int) j;
            }


            if (numOfError != 0)
            {
                if (numOfError >= mas.Length) numOfError = mas.Length-1;
                if (numOfError == 1) numOfError = 0;
                if (mas[numOfError] == 0) mas[numOfError] = 1; else
                if (mas[numOfError] == 1) mas[numOfError] = 0;
                Console.WriteLine("Ошибка найдена в {0} разряде кодового слова", numOfError+1);
                Console.Write("Кодовое слово: ");

                for (int i = 0; i < str.Length; i++)
                {
                    Console.Write(mas[i]);
                }

                Console.WriteLine();
            }
            else Console.WriteLine("В кодовом слове не найдена ошибка");
        }

        static string checkByte(string message)
        {
            bool ok; // Проверка ввода
            string str; // Битовая строка


            do
            {
                ok = true;
                Console.Write(message);
                str = Console.ReadLine();

                for (int i = 0; i < str.Length; i++)
                {
                    if (!((str[i] == '0') || (str[i] == '1')))
                    {
                        ok = false; 
                        break;
                    }
                }

                if (!ok) Console.WriteLine("Ошибка! Введите битовую строку!");
            } while (!ok);

            return str;
        }

        static int degree(int str) // Вычисление степени двойки
        {
            int pow = 0;

            while (str > 0)
            {
                str = str / 2;
                pow++;
            }

            pow--;

            return pow;
        }
    }
}
