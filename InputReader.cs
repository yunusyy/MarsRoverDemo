﻿using System;
using System.IO;
using System.Text.RegularExpressions;

namespace MarsRoverDemo
{
    public class InputReader
    {
        private Plateau _plateau;

        private static readonly Regex PlateauCoordinatesInputRegex = new Regex(@"^\d+\s\d+$");
        private static readonly Regex RoverCoordinatesInputRegex = new Regex(@"^\d+\s\d+\s[NSWE]$");
        private static readonly Regex RoverCommandsInputRegex = new Regex(@"^[LRM]+$");

        public InputReader(string input)
        {
            ReadInput(input);
        }

        private void ReadInput(string input)
        {
            if (input.Length == 0)
            {
                Console.WriteLine("Empty string");
            }

            using (var reader = new StringReader(input))
            {
                var roverCoordinates = string.Empty;
                var roverCommands = string.Empty;

                string currentLine;
                while ((currentLine = reader.ReadLine()) != null)
                {
                    if (PlateauCoordinatesInputRegex.Match(currentLine).Success)
                    {
                        _plateau = new Plateau(currentLine);
                    }
                    else if (RoverCoordinatesInputRegex.Match(currentLine).Success)
                    {
                        roverCoordinates = currentLine;
                    }
                    else if (RoverCommandsInputRegex.Match(currentLine).Success)
                    {
                        roverCommands = currentLine;
                    }
                    else
                    {
                        Console.WriteLine("Input data is in wrong format");
                    }

                    if (roverCoordinates.Equals(string.Empty) || roverCommands.Equals(string.Empty)) continue;

                    var rover = new Rover(roverCoordinates, roverCommands, _plateau);

                    roverCoordinates = string.Empty;
                    roverCommands = string.Empty;
                }
            }
        }
    }
}