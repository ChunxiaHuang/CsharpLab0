using System.IO;

namespace Lab0BasicsOfCsharp
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //int low;
            //int high;

            int low = GetValidIntegerInput("low");
            //Console.Write("Enter a low number: ");
            //low = int.Parse(Console.ReadLine());

            while (low < 0)
            {
                Console.WriteLine("Lower number must be positive.");
                low = GetValidIntegerInput("low");
                //Console.Write("Enter a low number: ");
                //low = int.Parse(Console.ReadLine());
            }

            int high = GetValidIntegerInput("high");
            //Console.Write("Enter a high number: ");
            //int high = int.Parse(Console.ReadLine());

            while (high <= low)
            {
                Console.WriteLine("Higher number must be greater than low.");
                high = GetValidIntegerInput("high");
                //Console.Write("Enter a high number: ");
                //high = int.Parse(Console.ReadLine());
            }

            int difference = high - low;

            Console.WriteLine($"The difference between the high and low is: {difference}");

            int[] nums = new int[difference - 1];

            for (int n = low + 1, i = 0; i <= difference - 2; n++, i++)
            {
                nums[i] = n;
                //Console.WriteLine(n);
            }

            StreamWriter streamWrite = File.CreateText("numbers.txt");

            for (int i = difference - 2; i >= 0; i--)
            {
                streamWrite.WriteLine(nums[i]);
            }

            streamWrite.Close();

            Console.WriteLine("Wrote to file: numbers.txt");

            StreamReader streamReader = File.OpenText("numbers.txt");

            double sum = 0;

            string line = streamReader.ReadLine();

            Console.WriteLine("Read from file: numbers.txt");

            while (line != null)
            {
                Console.WriteLine(line);
                double num = double.Parse(line);
                sum = sum + num;

                line = streamReader.ReadLine();
            }

            Console.WriteLine($"The sum of the numbers is {sum}.");

            foreach (int n in nums)
            {
                if (IsPrime(n))
                {
                    Console.WriteLine($"{n} is a prime number.");
                }
            }
        }

        static int GetValidIntegerInput(string name)
        {
            bool IsCheck = true;

            for (; IsCheck;)
            {
                Console.Write($"Enter a {name} number: ");
                string info = Console.ReadLine();

                try
                {
                    int n = int.Parse(info);
                    IsCheck = false;
                    return n;
                }
                catch
                {
                    Console.WriteLine("Invalid input, please enter an interger.");
                }
            }
            return 0;
        }

        static bool IsPrime(int n)
        {
            for (int denominator = 2; denominator < n; denominator++)
            {
                if (n % denominator == 0)
                {
                    return false;
                }
            }

            return true;
        }
    }
}