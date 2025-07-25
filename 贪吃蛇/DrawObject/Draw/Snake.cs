using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using 贪吃蛇.Object;

namespace 贪吃蛇.DrawObject
{
    enum E_MoveDir
    {
        Up,
        Down,
        Left,
        Right
    }

    class Snake : IDraw
    {
        SnakeBody[] bodys;
        //记录当前蛇长度
        int nowNum;
        //当前移动方向
        E_MoveDir dir;

        public Snake(int x, int y)
        {
            //粗暴声明空间
            bodys = new SnakeBody[400];

            bodys[0] = new SnakeBody(E_SnakeBody_Type.Head, x, y);
            nowNum = 1;
            dir = E_MoveDir.Right; // 初始方向向右
        }
        public void Draw()
        {
            //画一节节身子
            for (int i = 0; i < nowNum; i++)
            {
                bodys[i].Draw();
            }
        }
        public void Move()
        {
            //擦除最后一个位置
            SnakeBody lastbody = bodys[nowNum - 1];
            Console.SetCursorPosition(lastbody.pos.x, lastbody.pos.y);
            Console.Write("  "); // 擦除最后一个位置

            //再动
            switch (dir)
            {
                case E_MoveDir.Up:
                    --bodys[0].pos.y;
                    break;
                case E_MoveDir.Down:
                    ++bodys[0].pos.y;
                    break;
                case E_MoveDir.Left:
                    bodys[0].pos.x -= 2;
                    break;
                case E_MoveDir.Right:
                    bodys[0].pos.x += 2;
                    break;  
            }
        }


    }   

}
