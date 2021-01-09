using System;

namespace MarsRoverDemo
{
    public class Rover
    {
        private int XCurrentRoverCoordinate { get; set; }
        private int YCurrentRoverCoordinate { get; set; }
        private string Facing { get; set; }

        public Rover(string inputCoordinates, string inputCommands, Plateau plateau)
        {
            var coordinates = inputCoordinates.Split(' ');
            var commands = inputCommands.ToCharArray();

            XCurrentRoverCoordinate = int.Parse(coordinates[0]);
            YCurrentRoverCoordinate = int.Parse(coordinates[1]);
            Facing = coordinates[2];

            if (!IsRoverInPlateau(plateau))
            {
                Console.WriteLine("Rover is not in plateau.");

                return;
            }

            //"M" - move rover
            //"L" or "R" - rotate rover
            foreach (var command in commands)
            {
                if (command.ToString().Equals("M"))
                {
                    MoveRover();
                }
                else
                {
                    RotateRover(command.ToString());
                }
            }

            Console.WriteLine(XCurrentRoverCoordinate + " " + YCurrentRoverCoordinate + " " + Facing);
        }

        private void MoveRover()
        {
            switch (Facing)
            {
                case "N":
                    YCurrentRoverCoordinate += 1;
                    break;
                case "W":
                    XCurrentRoverCoordinate -= 1;
                    break;
                case "S":
                    YCurrentRoverCoordinate -= 1;
                    break;
                case "E":
                    XCurrentRoverCoordinate += 1;
                    break;
            }
        }

        private void RotateRover(string direction)
        {
            if (direction.ToUpper().Equals("L"))
            {
                TurnRoverLeft();
            }
            else if (direction.ToUpper().Equals("R"))
            {
                TurnRoverRight();
            }
            else
            {
                Console.WriteLine("Cannot read a command.");
            }
        }

        private bool IsRoverInPlateau(Plateau plateau)
        {
            return XCurrentRoverCoordinate >= 0 &&
                   XCurrentRoverCoordinate < plateau.PlateauWidth &&
                   YCurrentRoverCoordinate >= 0 &&
                   YCurrentRoverCoordinate < plateau.PlateauHeight;
        }

        private void TurnRoverLeft()
        {
            switch (Facing)
            {
                case "N":
                    Facing = "W";
                    break;
                case "W":
                    Facing = "S";
                    break;
                case "S":
                    Facing = "E";
                    break;
                case "E":
                    Facing = "N";
                    break;
            }
        }

        private void TurnRoverRight()
        {
            switch (Facing)
            {
                case "N":
                    Facing = "E";
                    break;
                case "E":
                    Facing = "S";
                    break;
                case "S":
                    Facing = "W";
                    break;
                case "W":
                    Facing = "N";
                    break;
            }
        }
    }
}