using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace TerminalEmulator
{
    public class TerminalEmulator
    {
        private Catalog users;
        private Catalog enable;
        private Catalog config;

        public TerminalEmulator()
        {
            DirectoryInitializer();
        }


        private void DirectoryInitializer()
        {
            UserListCommand();
            EnableListCommand();
            ConfigListCommand();
        }
        private void UserListCommand()
        {
            users = new Catalog("User");
            users.AddCommand("Hi", () => Console.WriteLine("Hello)"));
            users.AddCommand("Enable", () => enable.Operation());
        }
        private void EnableListCommand()
        {
            enable = new Catalog("Enable", users.path);
            enable.AddCommand("Configurate terminal", () => config.Operation());

        }
        private void ConfigListCommand()
        {
            config = new Catalog("Configurate terminal", enable.path);
            config.AddCommand("ColorRed", () => Console.ForegroundColor = ConsoleColor.Red);
        }
        public void RunningTerminal() { users.Operation(); }


    }

}
