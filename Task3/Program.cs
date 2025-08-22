namespace Task3
{
    internal class Program
    {
        static void PrintMenu()
        {
            Console.WriteLine("P - Print numbers");
            Console.WriteLine("A - Add a number");
            Console.WriteLine("M - Display mean of the numbers");
            Console.WriteLine("S - Display the smallest number");
            Console.WriteLine("L - Display the largest number");
            Console.WriteLine("F - Find a number");
            Console.WriteLine("C - Clear the whole list");
            Console.WriteLine("Q - Quit");
            Console.Write("Enter your choice: ");

        }
        static char GetChoice()
        {
            char choice = Convert.ToChar(Console.ReadLine().ToUpper());
            return choice;

        }
        static void PrintNumbers(List<int> numbers)
        {
            if (numbers.Count == 0)
            {
                Console.WriteLine("list is empty");
            }
            else
            {
                Console.Write("[");
                for (int i = 0; i < numbers.Count; i++)
                {
                    Console.Write(numbers[i]);
                    if (i < numbers.Count - 1)
                    {
                        Console.Write(",");
                    }
                }
                Console.Write("]");
                Console.WriteLine();
            }

        }
        static void AddNumber(List<int> Numbers)
        {
            Console.WriteLine("Enter number to add");
            string input = Console.ReadLine();
            if (input.All(char.IsDigit))
            {
                int number = Convert.ToInt32(input);
                if (Numbers.Contains(number))
                {
                    Console.WriteLine("Number already exists in the list.");
                }
                else
                {
                    Numbers.Add(number);
                    Console.WriteLine("Number added successfully.");
                }

            }
            else
            {
                Console.WriteLine("invalid input, Please enter integer  number");
            }
        }
        static double Mean(List<int> numbers)
        {
            if (numbers.Count == 0)
                return 0;

            double sum = 0;
            for (int i = 0; i < numbers.Count; i++)
            {
                sum += numbers[i];
            }
            return sum / numbers.Count;
        }
        static int Smallest(List<int> numbers)
        {
            if (numbers.Count == 0)
                return 0;
            int smallest = numbers[0];
            for (int i = 1; i < numbers.Count; i++)
            {
                if (numbers[i] < smallest)
                {
                    smallest = numbers[i];
                }
            }
            return smallest;
        }
        static int Largest(List<int> numbers)
        {
            if (numbers.Count == 0)
                return 0;
            int largest = numbers[0];
            for (int i = 1; i < numbers.Count; i++)
            {
                if (numbers[i] > largest)
                {
                    largest = numbers[i];
                }
            }
            return largest;
        }
        static bool FindNumber(List<int> numbers, int number)
        {

            if (!numbers.Contains(number))
                return false;
            return true;
        }
        static string Clear(List<int> numbers)
        {
            numbers.Clear();
            return "lis cleared successful";
        }
        static void Quit()
        {
            Console.WriteLine("Goodbye");
        }



        static void Main(string[] args)
        {
            List<int> numbers = new List<int>();
            bool valid = true;
            do
            {
                PrintMenu();
                char choice = GetChoice();

                switch (choice)
                {
                    case 'P':
                        PrintNumbers(numbers);
                        break;
                    case 'A':
                        AddNumber(numbers);
                        break;
                    case 'M':
                        double mean = Mean(numbers);
                        if (mean == 0)
                        {
                            Console.WriteLine("List is empty, cannot calculate mean.");
                        }
                        else
                        {
                            Console.WriteLine($"Mean: {mean}");
                        }
                        break;
                    case 'S':
                        int smallest = Smallest(numbers);
                        if (smallest == 0 && numbers.Count == 0)
                        {
                            Console.WriteLine("List is empty, cannot find smallest number.");
                        }
                        else
                        {
                            Console.WriteLine($"Smallest number: {smallest}");
                        }
                        break;
                    case 'L':
                        int largest = Largest(numbers);
                        if (largest == 0 && numbers.Count == 0)
                        {
                            Console.WriteLine("List is empty, cannot find largest number.");
                        }
                        else
                        {
                            Console.WriteLine($"Largest number: {largest}");
                        }
                        break;
                    case 'F':
                        Console.WriteLine("Enter number to find:");
                        int input = Convert.ToInt32(Console.ReadLine());
                        if (FindNumber(numbers, input))
                        {
                            Console.WriteLine($"Number {input} found in the list.");
                        }
                        else
                        {
                            Console.WriteLine($"Number {input} not found in the list.");
                        }
                        break;
                    case 'C':
                        string result = Clear(numbers);
                        Console.WriteLine(result);
                        break;

                    case 'Q':
                        Quit();
                        valid = false;
                        break;
                    default:
                        Console.WriteLine("Invalid choice, please try again.");
                        break;
                }
            } while (valid);


        }
    }
}