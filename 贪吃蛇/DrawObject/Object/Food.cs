using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using 贪吃蛇.Object;

namespace 贪吃蛇.DrawObject
{
    internal class Food : GameObject
    {
        public Food(int x,int y) 
        {
            pos = new Position(x,y);
        }
        public override void Draw()
        {
            Console.SetCursorPosition(pos.x, pos.y);
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.Write("🍎");
        }
        //随机位置
    }
}
