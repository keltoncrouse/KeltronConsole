using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Keltron;

namespace Keltron
{
    public enum Orientations
    {
        Landscape,
        Portrait
    }


    public class Games
    {
        public static int numberOfInvalids = 0;
        public static string password = "";


        public static void TamperProtection(string prompt)
        {
            if (numberOfInvalids > 1 && numberOfInvalids < 3)
            {
                Console.Clear();
                Console.WriteLine("Stop trying to break my program.");
                System.Threading.Thread.Sleep(2000);
                Console.Clear();
                Console.WriteLine("Let's try this again. ;)");
                System.Threading.Thread.Sleep(2000);
                Console.Clear();
                Console.WriteLine(prompt);


            }
            else if (numberOfInvalids == 3)
            {
                password = "im sorry";
                AppLock();
                Console.Clear();
                Console.WriteLine(prompt);
            }
            else if (numberOfInvalids == 4)
            {
                password = "you win";
                AppLock();
                Console.Clear();
                Console.WriteLine(prompt);

            }
        }

        public static Int64 AskForInt(string prompt, Int64 minimumValue = 0)
        {
            bool valid = false;
            Int64 thevalueis = 0;
            Console.WriteLine(prompt);
            while (!valid)
            {

                valid = Int64.TryParse(Console.ReadLine(), out thevalueis)
                    && thevalueis >= minimumValue;

                if (!valid)
                {
                    Console.Clear();
                    Console.WriteLine("ERROR: invalid input recieved, try again. (You must use a positive, non decimal number)\n" + prompt);
                    numberOfInvalids++;
                    TamperProtection(prompt);

                }

            }
            return thevalueis;
        }

        public static void AppLock()
        {
            bool locked = true;
            string passwordAttempt = "";
            Console.Clear();

            while (locked)
            {
                Console.WriteLine("The application has been locked to prevent malicious behavior. Enter password to regain access.");
                if (password == "you win")
                {
                    Console.WriteLine("The password has been changed this time, since you think you're so smart.");
                }
                passwordAttempt = Console.ReadLine();

                if (passwordAttempt == password)
                {
                    locked = false;

                }
                else
                {
                    Console.WriteLine("Incorrect password");
                    System.Threading.Thread.Sleep(1000);
                    Console.Clear();
                }
            }
        }


        public static void RandomNumberGame()
        {
            int guessesRemaining = 4;

            int secretnumber = new Random().Next(1, 11);

            for (int i = 0; i < 4;)
            {
                Console.Clear();
                if (guessesRemaining == 4)
                {
                    Console.WriteLine("A random number has been generated, you have four attempts to guess it");
                    Console.WriteLine("You have 4 attempts remaining.");
                }
                if (guessesRemaining == 3)
                {
                    Console.WriteLine("You have 3 attempts remaining.");
                }
                if (guessesRemaining == 2)
                {
                    Console.WriteLine("You have 2 attempts remaining."); ;
                }
                if (guessesRemaining == 1)
                {
                    Console.WriteLine("This is your last attempt.");
                }
                Int64 guess = AskForInt("Guess The Secret Number");

                guessesRemaining--;
                i++;

                if (guess == secretnumber)
                {
                    Console.WriteLine("You won!");
                    return;
                }
            }
            Console.WriteLine("You Lost");
        }

        public static void SpeedCamera()
        {
            Console.WriteLine("Here is a program to demonstrate the logic of a speed camera. It awards points to - or suspends a license if a driver is speeding.\n");

            Int64 speedLimit = AskForInt("What's the speed limit?");
            Int64 carSpeed = AskForInt("How fast is the car going?");

            if (carSpeed <= speedLimit)
            {
                Console.WriteLine("***Car is not speeding***");
            }
            else
            {
                const int mphPerPoint = 5;
                Int64 pointsGiven = (carSpeed - speedLimit) / mphPerPoint;
                if (pointsGiven >= 12)
                {
                    Console.WriteLine("***License suspended***");
                }
                else
                {
                    Console.WriteLine("***Driver incurs " + pointsGiven + " point penalty.***");
                }

            }
        }

        public static void DisplayGreaterNumber()
        {
            Console.WriteLine("Here you can enter two numbers and the program will tell you which is greater\n");


            Int64 firstnumber = AskForInt("Enter first number");
            Int64 secondnumber = AskForInt("Enter second number");

            Int64 biggernum = (firstnumber > secondnumber) ? firstnumber : secondnumber;
            if (firstnumber != secondnumber)
            {
                Console.WriteLine("The bigger number is " + biggernum);
            }
            else
            {
                Console.WriteLine("You entered " + firstnumber + " twice. How could one " + firstnumber + " be different than another " + firstnumber + "?");
            }
        }

        public static void ImageOrientationDisplayer()
        {
            Console.WriteLine("Here we will take dimensions of an image and outpt whether the image is landscape or portrait.");


            Int64 width = AskForInt("Please enter your width", 1);
            Int64 height = AskForInt("Please enter your height");
            Orientations orientation = height > width ? Orientations.Portrait : Orientations.Landscape;
            Console.WriteLine(orientation);


        }



        public static void NumberValidator()
        {
            Console.WriteLine("Here is a simple example of validation. Checks whether you followed instructions or not.");
            Int64 number = AskForInt("Enter a number between 1 and 10");
            if (number >= 1 && number <= 10)
                Console.WriteLine("Valid");
            else
                Console.WriteLine("Not valid");
        }
    }
}
