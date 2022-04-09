using System;

namespace DelegateLesson
{
    delegate bool CheckNumber(int num);

    delegate int Calc(int num1, int num2);

    internal class Program
    {
        static void Main(string[] args)
        {
            int[] nums = { 1, 2, 3, 4, 5, 6, 7, 8, 9, };

            //Console.WriteLine(SumEven(nums));
            //Console.WriteLine(SumOdd(nums));
            //Console.WriteLine(SumDividedBy3(nums));
            Console.WriteLine(Sum(nums,IsEven,Add));

            CheckNumber checkIsOdd = IsOdd;

            Console.WriteLine(Sum(nums, checkIsOdd,Add));


            CheckNumber isDividedBy3 = delegate (int num) { return num % 3 == 0; };

            Console.WriteLine(Sum(nums,isDividedBy3,Add));

            Console.WriteLine(Sum(nums,delegate(int num) { return num % 7 == 0; },Add));


            CheckNumber isDividedBy11 = (x) => x % 11 == 0;


            int sumOfEven = Sum(nums, IsEven,Add);
            int sumOfDividedBy3 = Sum(nums, x => x % 3 == 0,Add);

            int sumOfSums = sumOfEven + sumOfDividedBy3;

            Console.WriteLine(sumOfSums);

            Calc calc1 = null;
            Console.WriteLine(calc1?.Invoke(4,5));

            int? result = calc1?.Invoke(4, 5);


            Calc calc2 = (x, y) => x - y;

            Console.WriteLine(Sum(nums,x=>x%3==0,(x,y)=>x-y));

            Func<int, bool> func1 = IsEven;
            Func<string> func2 = GetInfo;
            Func<int, int, int> func3 = Add;

            Action<string, string> action1 = ShowFullName;
            action1("hikmet", "abbsov");


            Action action = GetInfo2;

            Predicate<int> predicate = x => x % 2 == 0;
        }

        static string GetInfo()
        {
            return  "Hiket Abbasov";
        }

        static void GetInfo2()
        {
            Console.Write("Hiket Abbasov");
        }

        static void ShowFullName(string name,string surname)
        {
            Console.WriteLine($"{name} {surname}");
        }

        static bool IsEven(int num)
        {
            return num % 2 == 0;    
        }

        static bool IsOdd(int num)
        {
            return num % 2 == 1;
        }



        static int SumEven(int[] numbers)
        {
            int sum = 0;

            foreach (var num in numbers)
            {
                if (num % 2 == 0)
                    sum += num;
            }

            return sum;
        }

        static int SumOdd(int[] numbers)
        {
            int sum = 0;

            foreach (var num in numbers)
            {
                if (num % 2 == 1)
                    sum += num;
            }

            return sum;
        }

        static int SumDividedBy3(int[] numbers)
        {
            int sum = 0;

            foreach (var num in numbers)
            {
                if (num % 3 == 0)
                    sum += num;
            }

            return sum;
        }

        static int Sum(int[] numbres, CheckNumber check,Calc calc)
        {
            int sum = 0;
            foreach (var item in numbres)
            {
                if (check(item))
                {
                    sum = calc(sum, item);
                }
            }

            return sum;
        }


        static int Add(int num1,int num2)
        {
            return num1 + num2;
        }
    }
}
