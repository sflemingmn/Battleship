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
    public class SetupWorkflow
    {
        public Board Player1Board { get; private set; }
        public Board Player2Board { get; private set; }

        public string Player1Name { get; private set; }
        public string Player2Name { get; private set; }

        public bool Player1GoesFirst { get; private set; }

        public void Start()
        {
            Console.WriteLine();
            Console.WriteLine("***************************************");  
            Console.WriteLine("***      WELCOME TO BATTLESHIP      ***");
            Console.WriteLine("***************************************");
            Console.WriteLine("***     PRESS ENTER TO PLAY NOW     ***");
            Console.WriteLine("***************************************");
            Console.ReadLine();

            this.Player1Name = Input.GetPlayerName(1);
            this.Player2Name = Input.GetPlayerName(2);

            this.Player1Board = this.SetupBoard(this.Player1Name);
            this.Player2Board = this.SetupBoard(this.Player2Name);

            this.Player1GoesFirst = this.DecideWhoGoesFirst();
        }

        internal bool DecideWhoGoesFirst()
        {
            return Randomizer.CoinFlip();
        }

        private void PlaceShip(Board placeOn, ShipType currentType, string playerName)
        {
            bool validPlacement = false;

            while (!validPlacement)
            {

                Output.PlaceShipNow(playerName, currentType);

                var req = new PlaceShipRequest
                              {
                                  ShipType = currentType,
                                  Coordinate = Input.GetCoordinateFromUser(playerName),
                                  Direction = Input.GetDirectionFromUser()
                              };

                var placementResult = placeOn.PlaceShip(req);

                switch (placementResult)
                {
                    case ShipPlacement.NotEnoughSpace: Output.NoSpace();
                        break;
                    case ShipPlacement.Ok: validPlacement = true;
                        break;
                    case ShipPlacement.Overlap: Output.Overlap();
                        break;
                }
            }
        }

        private Board SetupBoard(string playerName)
        {
            var toReturn = new Board();

            for (var currentType = ShipType.Destroyer; currentType <= ShipType.Carrier; currentType++)
            {
                this.PlaceShip(toReturn, currentType, playerName);
            }
            return toReturn;
        }
    }
}