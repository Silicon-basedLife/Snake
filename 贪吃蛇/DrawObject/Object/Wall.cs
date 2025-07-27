using System;
using System.Collections.Generic;
using System.Text;


namespace 贪吃蛇.DrawObject.Object
{
    class Wall : GameObject
    {
        public Wall(int x, int y)
        {
            pos = new Position(x, y);
        }

        public override void Draw()
        {
            Console.SetCursorPosition(pos.x, pos.y);
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("■");
        }
    }
}
