using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using 贪吃蛇.Games;

namespace 贪吃蛇.Scene
{
    class BeginScene : BeginOrEndBaseScene
    {
        public BeginScene() 
        {
            strTitle = "贪吃蛇";
            strOne = "开始游戏";
        }
        public override void EnterJDoSomething()
        {
            if (nowSelIndex == 0)
            {
                Game.ChangeScene(E_SceneType.Game);
            }
            else 
            {
                Environment.Exit(0);
            }
        }
    }
}
