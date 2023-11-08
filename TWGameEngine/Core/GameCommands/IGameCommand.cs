using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TWGameEngine.Core.Communications;
using TWGameEngine.Core.Library.GameObjects;

namespace TWGameEngine.Core.GameCommands
{
    public interface IGameCommand
    {
        public string CommandName { get; }
        public string HelpDescription { get; }

        public void ExecuteCommand(IMessageReceiver receiver, string[] args);
    }
}
