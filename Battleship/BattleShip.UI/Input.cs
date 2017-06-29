using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BattleShip.BLL.GameLogic;
using BattleShip.BLL.Requests;
using BattleShip.BLL.Responses;
using BattleShip.BLL.Ships;

namespace BattleShip.UI
{

    internal static class Input
    {
        internal static string GetPlayerName(int playerNum)
        {
            string playerName = null;
            Output.PromptForName(playerNum);

            playerName = Console.ReadLine();
            return playerName;
        }

        internal static Coordinate GetCoordinateFromUser(string playerName)
        {
            int x = 0;
            int y = 0;

            bool isNotValid = true;

            while (isNotValid)
            {
                Output.PromptForCoordinate(playerName);

                var userInput = Console.ReadLine().ToUpper();

                if (userInput.Length >= 2)
                {
                    var yPart = userInput[0];
                    var xPart = userInput.Substring(1);

                    y = yPart - 'A' + 1;
                    bool num = int.TryParse(xPart, out x);

                    if (!num || x > 10 || y > 10 || x < 0 || y < 0)
                    {
                        Console.WriteLine("INVALID - Please try again.");
                    }
                    else
                    {
                        isNotValid = false;
                    }
                }
            }

            Coordinate coord = new Coordinate(y, x);
            return coord;
        }

        internal static ShipDirection GetDirectionFromUser()
        {
            var direction = ShipDirection.Up;

            Console.Write("Enter a direction of U - Up, D = Down, L = Left & R = Right: ");
            var directionInput = Console.ReadLine().ToLower();

            if (directionInput == "u") direction = ShipDirection.Up;
            else if (directionInput == "d") direction = ShipDirection.Down;
            else if (directionInput == "l") direction = ShipDirection.Left;
            else if (directionInput == "r") direction = ShipDirection.Right;

            return direction;
        }

    }
}