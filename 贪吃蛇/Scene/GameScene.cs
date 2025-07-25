using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using 贪吃蛇.DrawObject;
using 贪吃蛇.Games;

namespace 贪吃蛇.Scene
{
    class GameScene : ISceneUpdate
    {
        Map map;
        Snake snake;

        int updateIndex = 0;
        public GameScene()
        {
            map = new Map();
            snake = new Snake(40, 10); // 初始化蛇的位置
        }
        public void Update()
        {

            if(updateIndex % 100000000 == 0)
            {
                map.Draw();
                snake.Move();
                snake.Draw();

                updateIndex = 0;
            }
            ++updateIndex;
        }
    }
}
