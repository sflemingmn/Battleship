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
    public class Program
    {
        private static void Main(string[] args)
        {
            GameWorkflow play = new GameWorkflow();
            play.StartBattleship();
        }
    }
}