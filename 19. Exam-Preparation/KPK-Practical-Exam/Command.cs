using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FreeContentCatalog
{
    public class Command : ICommand
    {
        private readonly char[] paramsSeparators = { ';' };

        private readonly char commandEnd = ':';

        private int commandNameEndIndex;

        public Command(string input)
        {
            this.OriginalForm = input.Trim();
            this.Parse();
        }

        public CommandType Type { get; set; }

        public string OriginalForm { get; set; }

        public string Name { get; set; }

        public string[] Parameters { get; set; }

        public CommandType ParseCommandType(string commandName)
        {
            if (commandName.Contains(':') || commandName.Contains(';'))
            {
                throw new FormatException();
            }

            CommandType type;
            switch (commandName.Trim())
            {
                case "Add book":
                    type = CommandType.AddBook;
                    break;

                case "Add movie":
                    type = CommandType.AddMovie;
                    break;

                case "Add song":
                    type = CommandType.AddSong;
                    break;

                case "Add application":
                    type = CommandType.AddApplication;
                    break;

                case "Update":
                    type = CommandType.Update;
                    break;

                case "Find":
                    type = CommandType.Find;
                    break;

                default:
                    throw new MissingFieldException("Invalid command name!");
            }

            return type;
        }

        public string ParseName()
        {
            string name = this.OriginalForm.Substring(0, this.commandNameEndIndex + 1);

            return name;
        }

        public string[] ParseParameters()
        {
            int paramsLength = this.OriginalForm.Length - (this.commandNameEndIndex + 3);

            string paramsOriginalForm = this.OriginalForm.Substring(this.commandNameEndIndex + 3, paramsLength);

            string[] parameters = paramsOriginalForm.Split(this.paramsSeparators, StringSplitOptions.RemoveEmptyEntries);

            for (int i = 0; i < parameters.Length; i++)
            {
                parameters[i] = parameters[i];
            }

            return parameters;
        }

        public int GetCommandNameEndIndex()
        {
            int endIndex = this.OriginalForm.IndexOf(this.commandEnd) - 1;

            return endIndex;
        }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();

            sb.Append(string.Empty + this.Name + " ");
            foreach (string param in this.Parameters)
            {
                sb.Append(param + " ");
            }

            return sb.ToString();
        }

        private void TrimParams()
        {
            for (int i = 0; i < this.Parameters.Length; i++)
            {
                this.Parameters[i] = this.Parameters[i].Trim();
            }
        }

        private void Parse()
        {
            this.commandNameEndIndex = this.GetCommandNameEndIndex();

            this.Name = this.ParseName();
            this.Parameters = this.ParseParameters();
            this.TrimParams();

            this.Type = this.ParseCommandType(this.Name);
        }
    }
}
