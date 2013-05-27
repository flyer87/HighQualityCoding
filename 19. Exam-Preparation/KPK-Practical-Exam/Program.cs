using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FreeContentCatalog
{
    public class Program
    {
        public static void Main()
        {
            StringBuilder output = new StringBuilder();
            Catalog catalog = new Catalog();
            ICommandExecutor commandExecutor = new CommandExecutor();

            List<ICommand> commands = ReadInput();
            foreach (ICommand cmd in commands)
            {
                commandExecutor.ExecuteCommand(catalog, cmd, output);
            }

            Console.Write(output);
        }

        private static List<ICommand> ReadInput()
        {
            List<ICommand> commands = new List<ICommand>();

            bool endCommandFound = false;
            while (true)
            {
                string line = Console.ReadLine();
                
                if (line.Trim() == "End")
                {
                    endCommandFound = true;
                }                

                if (endCommandFound)
                {
                    break;
                }
                else
                {
                    commands.Add(new Command(line));
                }               
            }

            return commands;
        }
    } 
}
