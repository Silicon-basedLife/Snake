using System;
using System.Collections.Generic;
using System.Text;
using 贪吃蛇.DrawObject.Draw;
using 贪吃蛇.Games;


namespace 贪吃蛇.DrawObject.Object
{
    class Food : GameObject
    {
        public Food(Snake snake)
        {
            RandomPos(snake);
        }

        public override void Draw()
        {
            Console.SetCursorPosition(pos.x, pos.y);
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.Write("¤");
        }
        
        //随机位置的行为 行为 和蛇的位置 有关系 有了蛇再来考虑
        public void RandomPos(Snake snake)
        {
            //随机位置
            Random r = new Random();
            int x = r.Next(2, Game.w / 2 - 1) * 2;
            int y = r.Next(1, Game.h - 4);
            pos = new Position(x, y);
            //得到蛇
            //如果重合 就会进if语句
            if(snake.CheckSamePos(pos))
            {
                RandomPos(snake);
            }
        } 
    }
}
