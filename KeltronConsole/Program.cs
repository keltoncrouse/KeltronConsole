using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Keltron;

namespace Keltron
{
    class Program
    {
        static void Main(string[] args)
        {

            AskUser();


            void GamePlay(string programSelected)
            {
                switch (programSelected)
                {

                    case "00":
                        {
                            break;
                        }
                    case "1":
                        {
                            Console.Clear();
                            Games.RandomNumberGame();
                            Console.WriteLine("");
                            RestartOrNew("1");
                            break;
                        }
                    case "2":
                        {
                            Console.Clear();
                            Games.SpeedCamera();
                            Console.WriteLine("");
                            RestartOrNew("2");
                            break;
                        }
                    case "3":
                        {
                            Console.Clear();
                            Games.DisplayGreaterNumber();
                            Console.WriteLine("");
                            RestartOrNew("3");
                            break;
                        }
                    case "4":
                        {
                            Console.Clear();
                            Games.ImageOrientationDisplayer();
                            Console.WriteLine("");
                            RestartOrNew("4");
                            break;
                        }
                    case "5":
                        {
                            Console.Clear();
                            Games.NumberValidator();
                            Console.WriteLine("");
                            RestartOrNew("5");
                            break;
                        }
                    default:
                        {
                            Console.WriteLine("Stop it. I didn't give you that option.");
                            System.Threading.Thread.Sleep(1000);
                            AskUser();
                            break;
                        }
                }
            }

            void AskUser()
            {
                Console.Clear();
                string selectionMenu = "Select an option:\n1: Random Number Game\n2: Speed Camera\n3: Display Greater Number\n4: Image Orientation Checker\n5: Number Validation Demo\n00: Exit Program";
                Console.WriteLine(selectionMenu);
                string choiceMade = "0";
                choiceMade = Console.ReadLine();
                GamePlay(choiceMade);
            }

            void RestartOrNew(String gameCalledFrom)
            {
                Console.WriteLine("Select an option:\n1:Play again\n0:Exit game");
                string optionSelected = Console.ReadLine();
                switch (optionSelected)
                {
                    case "1":
                        {
                            GamePlay(gameCalledFrom);
                            break;
                        }
                    case "0":
                        {
                            AskUser();
                            break;
                        }

                    default:
                        {
                            Console.Clear();
                            Console.WriteLine("Stop it. I didn't give you that option.");
                            System.Threading.Thread.Sleep(1000);
                            Console.Clear();
                            RestartOrNew(gameCalledFrom);
                            break;
                        }

                }
            }
        }
    }

}








