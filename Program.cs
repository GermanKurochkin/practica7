using System;

namespace practica7
{
    class Program
    {
        static int n, m,count;
        static bool[] arr = new bool[1];
        static int InputNum(int maxNum)
        {
            int num;
            string input;
            bool ok;
            do
            {
                input = Console.ReadLine();
                ok = int.TryParse(input, out num);
                if (!ok) Console.WriteLine("Некорректный ввод");
                else if (num < 1 || num > maxNum) Console.WriteLine($"Некорректный ввод. Введите число не больше {maxNum}");
            } while (!ok || num < 1 || num > maxNum);

            return num;

        }
        static void Write(int[] mas)
        {
            count++;
            if (count < 100) Console.Write($" ");
            if (count<10) Console.Write($" ");
            Console.Write($"{count}:   ");
            for (int i = 0; i < mas.Length; i++)
                Console.Write($"{mas[i]}  ");
            Console.WriteLine();
        }
        static bool Next (ref int[] mas)
        {
            int j;
            j = m - 1;
            while (j != -1 && mas[j]==n-j) j--;
            if (j == -1) return false;//последнее размещение

         

            for (int i = mas.Length - 1; i >= 0; i--)//следующее размещение с повторениями
            {
                if (mas[i] < n)
                {
                    mas[i]++;
                    if (i == mas.Length - 1)
                    {
                        break;
                    }
                    else
                    {
                        for (int k=i+1;k<mas.Length;k++)
                        {
                            mas[k] = 1;

                        }
                        break;
                    }
                   
                }
            }
            bool ok = false;
            for (int i = 0; i < arr.Length; i++)
            {
                arr[i] = true;
            }
            for (int i2 = 0; i2 < mas.Length; i2++) //проверка на наличие повторений
            {
                arr[mas[i2] - 1] = !arr[mas[i2] - 1];
                if (arr[mas[i2] - 1])
                {
                    ok = true;
                }
            }
            if(ok)return Next(ref mas);

            return true;

        }

        static void Main(string[] args)
        {
            /*
            18.	Сгенерировать все размещения из N элементов по K без повторений и выписать их в лексикографическом порядке.
            */

            Console.WriteLine("Введите n");
            n = InputNum(100);
            Console.WriteLine("Введите k");
            m = InputNum(100);
            if (m > n)
            {
                Console.WriteLine("n должно быть больше k");
            }
            else
            {
                int[] mas = new int[m];
                arr = new bool[n];
                for (int i = 0; i < mas.Length; i++)
                    mas[i] = i +1;
                count = 0;
                Write(mas);
                while (Next(ref mas))
                {
                    Write(mas);
                }

            }
        }
    }
}
