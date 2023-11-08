using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TWGameEngine.Core.Communications;
using TWGameEngine.Core.Library.GameObjects;
using TWGameEngine.Core.Wizards;

namespace TWGameEngine.Core.GameCommands
{
    public class CommandParser
    {
        private static readonly Lazy<CommandParser> lazyInstance = new(() => new CommandParser());

        public static CommandParser Instance
        {
            get
            {
                return lazyInstance.Value;
            }
        }

        private CommandParser()
        {

        }

        public void Parse(string inputString, IMessageReceiver receiver)
        {
            string[] tokens = inputString.Split(' ');
            
            string mainCommand = tokens[0];

            string[] args = new string[tokens.Length - 1];

            Array.Copy(tokens, 1, args, 0, args.Length);

            if(GameCommandWizard.Instance.Handle(receiver, mainCommand, args))
            {
                return;
            }

            Console.WriteLine("Command not recognized.");
        }
    }
}
