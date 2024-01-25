namespace UcenjeCS.V04LjubavniKalkulator
{
    internal class Program
    {
        public static void Izvedi()
        {
            LoveCall();
        }

        private static string Input(string message)
        {
            while (true) // Infinite loop with condition inside to break the loop
            {
                Console.Write(message);
                string userInput = Console.ReadLine();

                string validationMessage = ValidateInput(userInput); // Calls ValidateInput

                if (string.IsNullOrEmpty(validationMessage))
                {
                    return userInput;
                }

                Console.WriteLine(validationMessage); // If input is invalid, print the validation message and continuesthe loop

            }
        }

        // Checks if 'input' is null or numeric characters and returns correct messages for each exception
        private static string ValidateInput(string input)
        {
            if (string.IsNullOrEmpty(input))
            {
                return "Name cannot be null.";
            }

            foreach (char c in input)
            {
                if (!char.IsLetter(c))
                {
                    return "You cannot enter a number.";
                }
            }

            return string.Empty; // If input is valid then it returns an empty string
        }

        private static void LoveCall()
        {
            Console.WriteLine(new LoveCalculator(Input("First name: "), Input("Second name: ")).Result());
        }
    }
}
