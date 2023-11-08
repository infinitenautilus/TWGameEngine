using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TWGameEngine.Core.Communications;
using TWGameEngine.Core.GameCommands;
using TWGameEngine.Core.Library.GameObjects;

namespace TWGameEngine.Core.Wizards
{
    public class GameCommandWizard
    {
        /// <summary>
        /// Setup the Lazy instance
        /// </summary>
        private static readonly Lazy<GameCommandWizard> lazyInstance = new(() => new GameCommandWizard());
        public static readonly GameCommandWizard Instance = lazyInstance.Value;

        private Dictionary<string, IGameCommand> globalCommands = new();

        private GameCommandWizard() 
        {
            RegisterCommand(new ScoreCommand());
            //RegisterCommand(new KillCommand());

        }        

        private void RegisterCommand(IGameCommand command)
        {
            if(globalCommands.ContainsKey(command.CommandName))
            {
                throw new InvalidOperationException($"A command with the name '{command.CommandName} is already registered.");
            }

            globalCommands[command.CommandName] = command;
        }

        public bool Handle(IMessageReceiver receiver, string command, string[] args)
        {
            if(globalCommands.TryGetValue(command, out IGameCommand? cmd))
            {
                if(cmd == null)
                {
                    Console.WriteLine("Found null input.");
                    return false;
                }

                cmd.ExecuteCommand(receiver, args);

                return true;
            }

            return false;
        }

        
    }
}
