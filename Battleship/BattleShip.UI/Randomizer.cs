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
    static class Randomizer
    {
        private static Random _gen = new Random();

        public static bool CoinFlip()
        {
            return _gen.NextDouble() > 0;
        }
    }
}
