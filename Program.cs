namespace Gerador_de_Senhas___Password_Generator;
using System;
class Program
{
    static void Main(string[] args)
    {
        bool generateAnother = true;

        while(generateAnother)
        {
            Console.Clear();
            Console.WriteLine("Welcome to the password generator.");

            Console.Write("Enter the desired length of the password: ");
            string lengthInput = Console.ReadLine();
            int passwordLength = 0;

            while(!int.TryParse(lengthInput, out passwordLength))
            {
                Console.Write("Please, enter an integer for the password length: ");
                lengthInput = Console.ReadLine();
            }

            string finalPassword = PasswordGenerator(passwordLength);
            Console.WriteLine($"\nThis is your password: {finalPassword}");

            Console.Write("\nDo you want to generate another password? (y/n): ");
            string response = Console.ReadLine().ToLower();

            while (response != "y" && response != "Y" && response != "n" && response != "N" )
            {
                Console.Write("Please, enter 'y' or 'n': ");
                response = Console.ReadLine();
            }

            generateAnother = response == "y";
        }
        
    }

    static string PasswordGenerator (int length)
    {
        string lowerCaseChars = "abcdefghijklmnopqrstuvwxyz";
        string upperCaseChars = "ABCDEFGHIJKLMNOPQRSTUVWXYZ";
        string digits = "1234567890";
        string specialChars = "!@#$%&?()=+-*/_";

        Random random = new Random();
        char[] password = new char[length];

        for (int i = 0; i < length; i++)
        {
            //this variable is used to select which type of character will be generated 
            //to the password on each iteration of the loop
            int typeOfCharSelector = random.Next(4);

            switch (typeOfCharSelector)
            {
                case 0: //lower case char
                    password[i] = lowerCaseChars[random.Next(lowerCaseChars.Length)];
                    break;
                case 1://upper case char
                    password[i] = upperCaseChars[random.Next(upperCaseChars.Length)];
                    break;
                case 2: //digit
                    password[i] = digits[random.Next(digits.Length)];
                    break;
                case 3: //special char
                    password[i] = specialChars[random.Next(specialChars.Length)];
                    break;
            }
        }
        return new string(password);
    }
}
