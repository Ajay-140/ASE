using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

public class CommandParser
{
    private Dictionary<string, Action<string[]>> commandDictionary;

    public CommandParser()
    {
        commandDictionary = new Dictionary<string, Action<string[]>>
        {
            {"run", RunCommand},
            {"save", SaveCommand},
            {"load", LoadCommand}
            // commands to be added as needed
        };
    }

    public void ParseCommand(string input)
    {
        string[] parts = input.Split(' ');
        string command = parts[0].ToLower();

        if (commandDictionary.ContainsKey(command))
        {
            string[] parameters = parts.Length > 1 ? parts.Skip(1).ToArray() : new string[0];

            //exceptions
            try
            {
                commandDictionary[command](parameters);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error executing command '{command}': {ex.Message}");
            }
        }
        else
        {
            Console.WriteLine($"Invalid command: {command}");
        }
    }

    private void RunCommand(string[] parameters)
    {
        // Check for valid parameters
        if (parameters.Length != 1)
        {
            throw new ArgumentException("Invalid number of parameters for 'run' command. Usage: run <program>");
        }

        // Execute the program (replace with actual logic)
        Console.WriteLine($"Executing program: {parameters[0]}");
    }

    private void SaveCommand(string[] parameters)
    {
        // Check for valid parameters
        if (parameters.Length != 2)
        {
            throw new ArgumentException("Invalid number of parameters for 'save' command. Usage: save <program> <filename>");
        }

        // Save the program to a text file
        string program = parameters[0];
        string filename = parameters[1];
        File.WriteAllText(filename, program);
        Console.WriteLine($"Program saved to {filename}");
    }

    private void LoadCommand(string[] parameters)
    {
        // Check for valid parameters
        if (parameters.Length != 1)
        {
            throw new ArgumentException("Invalid number of parameters for 'load' command. Usage: load <filename>");
        }

        // Load the program from a text file
        string filename = parameters[0];
        string program = File.ReadAllText(filename);
        Console.WriteLine($"Program loaded from {filename}: {program}");
    }
}
