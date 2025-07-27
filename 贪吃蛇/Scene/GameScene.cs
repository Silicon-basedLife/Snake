using System;
using System.Collections.Generic;
using System.Text;
using 贪吃蛇.DrawObject.Draw;
using 贪吃蛇.DrawObject.Object;
using 贪吃蛇.Games;


namespace 贪吃蛇.Scene
{
    class GameScene : ISceneUpdate
    {
        Map map;
        Snake snake;
        Food food;

        int updateIndex = 0;

        public GameScene()
        {
            map = new Map();
            snake = new Snake(40, 10);
            food = new Food(snake);
        }

        public void Update()
        {
            if(updateIndex % 4444 == 0)
            {
                map.Draw();
                food.Draw();

                snake.Move();
                snake.Draw();

                //检测是否撞墙
                if(snake.CheckEnd(map))
                {
                    //结束逻辑
                    Game.ChangeScene(E_SceneType.End);
                }

                snake.CheckEatFood(food);

                updateIndex = 0;
            }
            ++updateIndex;

            //在控制台中 检测玩家输入 让程序不被检测卡主
            //判断 有没有键盘输入 如果有 才为true
            if( Console.KeyAvailable )
            {
                //检测输入输出 不能再 间隔帧里面去处理 应该每次都检测 这样才准确
                switch (Console.ReadKey(true).Key)
                {
                    case ConsoleKey.W:
                        snake.ChangeDir(E_MoveDir.Up);
                        break;
                    case ConsoleKey.A:
                        snake.ChangeDir(E_MoveDir.Left);
                        break;
                    case ConsoleKey.S:
                        snake.ChangeDir(E_MoveDir.Down);
                        break;
                    case ConsoleKey.D:
                        snake.ChangeDir(E_MoveDir.Right);
                        break;
                }
            }
        }
    }
}
