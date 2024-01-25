using System.Diagnostics.CodeAnalysis;
using System.Runtime.CompilerServices;
using System.Text;

namespace UcenjeCS.V04LjubavniKalkulator
{

    // Enter two names and write how many times each letter repeated in new array.
    // Sum up first and last element of array, then second and second-to-last and so on... If last element is unpaired then print it into array.
    // When you end with that row, go in the next one, then again...till you get 100 or less % of love

    internal class LoveCalculator
    {
        // Declaring field as 'private readonly' means that field should not be modified after it's initialized
        // This also means that this two fields can only be asigned values in the constructor, and their values canot be changed afterwards
        private readonly string FirstName;
        private readonly string SecondName;
        private readonly StringBuilder sb = new StringBuilder();

        public LoveCalculator(string firstName, string secondName) // Parameterized constructor
        {
            FirstName = firstName;
            SecondName = secondName;
        }

        public string Result()
        {
            return Calculate(LetterCountArray(FirstName+SecondName)) + " %";
        }

        private int Calculate(int[] numbers)
        {
            if (numbers.Length < 3) // If array has two elements, stop with the recursion and return the FinalizedArray
            {
                return FinalisedArray(numbers);
            }

            // Create an array to store the sums of first & last elements, then proceeds with the recursion
            int[] sums = new int[numbers.Length / 2 + numbers.Length % 2];

            for (int i = 0; i < (numbers.Length + 1) / 2; i++)
            {
                // Calculate the sum of the current element and its correspoding pair from the end of the array
                int sum = numbers[i] + numbers[numbers.Length - 1 - i];

                if (i >= (numbers.Length - 1) / 2 && numbers.Length % 2 != 0) // If 'i' don't have pair, print value of element in array from index 'i'
                {
                    sums[i] = numbers[i]; // Copy the value of the current element from 'numbers' to 'sums'
                }
                else
                {
                    sums[i] = sum; // Store the calculated sum in the 'sums' array
                }
            }

            var convertedToIndividualDigits = ConvertArray(sums);

            Console.WriteLine(string.Join(",", convertedToIndividualDigits));


            return Calculate(ConvertArray(sums)); // Recursive call with the transformed array
        }

        private int[] ConvertArray(int[] numbers) // Method to convert an array of numbers into a new array with individual digits (splitted two-digit numbers)
        {
            int maxLength = numbers.Length * 2;
            int[] result = new int[maxLength];
            int index = 0; // Counter for the new array (how many elements it needs to have)

            foreach (int num in numbers) // For each element in numbers
            {
                if (num < 10) // If num is less than 10, print element in new array
                {
                    result[index++] = num; 
                }
                else
                {
                    // Split 'num' into tens and ones
                    int tensDigit = num / 10;
                    int onesDigit = num % 10;

                    // Copy the tens and ones to the 'result' array
                    result[index++] = tensDigit;
                    result[index++] = onesDigit;
                }
            }

            Array.Resize(ref result, index); // Resize array on correct size. Length of the array is equal to Index

            return result;
        }

        // Converts an array of single-digit integers into a clean two-digit number
        private int FinalisedArray(int[] array)
        {
            string stringArray = string.Join("", array);

            int result = int.Parse(stringArray);

            return result;
        }

        private int[] LetterCountArray(string names)
        {
            int total;
            int index = 0;
            names = names.Replace(" ", "").ToLower(); // Remove spaces and converts to lowercase.

            int[] numbers = new int[names.Length];

            foreach (char c in names)
            {
                total = 0;
                foreach (char cc in names)
                {
                    if (c == cc)
                    {
                        total++;
                    }
                }
                numbers[index++] = total;
            }

            Console.WriteLine(names);
            Console.WriteLine(string.Join(",", numbers)); // Separate elements with ','

            return numbers;
        }
    }
}
