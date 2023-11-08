using System;
using TWGameEngine.Core.Communications;
using TWGameEngine.Core.GameCommands;
using TWGameEngine.Core.Library.GameObjects;

namespace TWGameEngine.Core
{
    public class Program
    {
        private static readonly Lazy<Program> lazyInstance = new(() => new Program());
        
        public static readonly Program Instance = lazyInstance.Value;

        public MessageDispatcher dispatcher = new();

        public bool GameIsRunning = true;

        public Program()
        {

        }

        static void Main(string[] args)
        {
            Program.Instance.BeginGame();
        }

        private void BeginGame()
        {
            Actor player = new("Player");

            while(GameIsRunning)
            {
                Console.Write("> ");

                string? input = Console.ReadLine();

                if(input == null || string.IsNullOrEmpty(input))
                {
                    Console.WriteLine("What?");
                }
                else
                {
                    CommandParser.Instance.Parse(input, player);
                }
            }
        }

    }
}