using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TWGameEngine.Core.Communications;
using TWGameEngine.Core.Library.GameObjects;

namespace TWGameEngine.Core.GameCommands
{
    public class ScoreCommand : IGameCommand
    {
        public string CommandName { get; }
        public string HelpDescription { get; }

        public ScoreCommand()
        {
            CommandName = "score";
            HelpDescription = "This command reveals your current health, maximum health, your current energy, maximum energy, your current mana, and maximum mana.";
        }

        public void ExecuteCommand(IMessageReceiver receiver, string[] args)
        {
            receiver.ReceiveMessage("You ran score!");
        }
    }
}
