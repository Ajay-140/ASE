using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ASEProject
{
    /// <summary>
    /// This is my ASE Project 
    /// </summary>
    internal static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new Form1());

            //shows basic dialog text for fun
            Console.WriteLine("Hello Rainy Leeds!");
            Console.WriteLine("Need chocolate");

            CommandParser commandParser = new CommandParser();
            //command parser set up for main method
            while (true)
            {
                Console.Write("Enter command: ");
                string input = Console.ReadLine();

                if (input.ToLower() == "exit")
                {
                    break;
                }

                commandParser.ParseCommand(input);


            }

        }
    }
}
