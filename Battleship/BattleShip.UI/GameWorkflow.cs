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
    public class GameWorkflow
    {
        private SetupWorkflow _setup = new SetupWorkflow();

        internal void StartBattleship()
        {
            _setup.Start();
            Play();
        }

        public void Play()
        {
            var playerTurn = _setup.Player1GoesFirst;

            bool playOn = true;

            while (playOn)
            {
                ShotStatus status = new ShotStatus();

                Console.Clear();

                if (playerTurn)
                {
                    status = FireShotPrompt(_setup.Player2Board, _setup.Player1Name);
                }

                else
                {
                    status = FireShotPrompt(_setup.Player1Board, _setup.Player2Name);
                }

                if (status == ShotStatus.Invalid || status == ShotStatus.Duplicate)
                {
                    playerTurn = !playerTurn;
                }

                playerTurn = !playerTurn;

                if (status != ShotStatus.Victory)
                {
                    playOn = true;
                }

                else
                {
                    playOn = false;

                    Console.WriteLine("Press ENTER to play again or press Q to quit.");

                    if (Console.ReadKey().Key == ConsoleKey.Q)
                    {
                        return;
                    }

                    else
                    {
                        SetupWorkflow restart = new SetupWorkflow();
                        restart.Start();
                    }
                }
            }
        }

        private ShotStatus FireShotPrompt(Board ShotBoard, string playerName)
        {
            Output.PrintBoard(ShotBoard);
            Console.WriteLine("");

            Console.WriteLine("");
            Console.WriteLine("{0}, select your shot location, then press ENTER.", playerName);

            Coordinate shotCoordinate = Input.GetCoordinateFromUser(playerName);

            var fire = ShotBoard.FireShot(shotCoordinate);

            if (fire.ShotStatus == ShotStatus.Invalid)
                Console.WriteLine("INVALID - Try Again");

            else if (fire.ShotStatus == ShotStatus.Duplicate)
                Console.WriteLine("DUPLICATE - Try Again");

            else if (fire.ShotStatus == ShotStatus.Miss)
                Console.WriteLine("MISS - Press ENTER for next player's turn.");

            else if (fire.ShotStatus == ShotStatus.Hit)
                Console.WriteLine("HIT - Press ENTER for next player's turn.");

            else if (fire.ShotStatus == ShotStatus.HitAndSunk)
                Console.WriteLine("HIT & SINK - Press ENTER for next player's turn.");

            else if (fire.ShotStatus == ShotStatus.Victory)
                Console.WriteLine("VICTORY - NICE WIN - Press any key to continue.");
                Console.ReadKey();

            return fire.ShotStatus;
        }
    }
}
