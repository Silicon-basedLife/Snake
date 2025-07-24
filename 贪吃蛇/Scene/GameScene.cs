using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using 贪吃蛇.Games;

namespace 贪吃蛇.Scene
{
    class GameScene : ISceneUpdate
    {
        public void Update()
        {
            Console.SetCursorPosition(0, 0);
            Console.WriteLine("游戏场景");
        }
    }
}
