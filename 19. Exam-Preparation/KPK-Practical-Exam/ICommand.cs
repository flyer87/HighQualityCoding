using System;
using System.Linq;
using System.Text;

namespace FreeContentCatalog
{
    public interface ICommand
    {
        CommandType Type { get; set; }

        string OriginalForm { get; set; }

        string Name { get; set; }

        string[] Parameters { get; set; }

        CommandType ParseCommandType(string commandName);

        string ParseName();

        string[] ParseParameters();
    }
}
