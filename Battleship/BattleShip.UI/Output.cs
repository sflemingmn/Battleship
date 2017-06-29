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
    internal static class Output
    {
        internal static void PromptForName(int playerNumber)
        {
            Console.Write($"Player {playerNumber}, please type your name and press ENTER:  ");
        }

        internal static void PromptForCoordinate(string playerName)
        {
            Console.Write($"\n{playerName}, enter a coordinate by pressing A-J, followed by 1-10, then press ENTER: ");
        }

        public static void PlaceShipNow(string playerName, ShipType currentType)
        {
            Console.Write($"\n{playerName} place your {currentType} now. ");
        }

        public static void NoSpace()
        {
            Console.Write("This space is off the board. Please place ship in another location.\n ");
        }

        public static void Overlap()
        {
            Console.Write("This overlaps another ship. Please place ship in another location.\n ");
        }

        public static void PrintBoard(Board shootingBoard)
        {
            Console.WriteLine("  1  2  3  4  5  6  7  8  9  10");

            for (int row = 1; row < 11; row++)
            {
                char col = (char)('A' + row - 1);
                Console.Write(col + " ");

                for (int column = 1; column < 11; column++)
                {
                    var shotStatus = shootingBoard.CheckCoordinate(new Coordinate(row, column));

                    switch (shotStatus)
                    {
                        case ShotHistory.Hit:
                            Console.ForegroundColor = ConsoleColor.Red;
                            Console.Write(" H ");
                            Console.ResetColor();
                            break;

                        case ShotHistory.Miss:
                            Console.ForegroundColor = ConsoleColor.DarkGreen;
                            Console.Write(" M ");
                            Console.ResetColor();
                            break;

                        case ShotHistory.Unknown:
                            Console.Write(" _ ");
                            break;
                    }
                }
                Console.WriteLine("");
            }
            Console.Write(""); 
        }
    }
}