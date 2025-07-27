using System;
using System.Collections.Generic;
using System.Text;
using 贪吃蛇.DrawObject.Object;
using 贪食蛇.DrawObject;


namespace 贪吃蛇.DrawObject.Draw
{

    enum E_MoveDir
    {
        Up,
        Down,
        Left,
        Right,
    }


    class Snake : IDraw
    {
        SnakeBody[] bodys;
        //来记录当前蛇的长度
        int nowNum;
        //当前移动的方向
        E_MoveDir dir;

        public Snake(int x, int y)
        {
            //粗暴的 申明200个空间 游戏中 基本不会出现蛇长度达到200个身体
            bodys = new SnakeBody[200];

            bodys[0] = new SnakeBody(E_SnakeBody_Type.Head, x, y);
            nowNum = 1;

            dir = E_MoveDir.Right;
        }

        public void Draw()
        {
            //画一节一节的身子
            for (int i = 0; i < nowNum; i++)
            {
                bodys[i].Draw();
            }
        }


        public void Move()
        {
            //移动前
            //擦除最后一个位置
            //擦屁股
            SnakeBody lastBody = bodys[nowNum - 1];
            Console.SetCursorPosition(lastBody.pos.x, lastBody.pos.y);
            Console.Write("  ");

            #region Lesson11 身体移动
            //在蛇头移动之前 从蛇尾开始 不停的 让后一个的位置 等于前一个的位置
            for (int i = nowNum - 1; i > 0; i--)
            {
                bodys[i].pos = bodys[i - 1].pos;
            }


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

        public void ChangeDir(E_MoveDir dir)
        {
            //只有头部的时候 可以直接左转右 右转左  上转下 下转上
            //有身体时 这种情况就不能直接转、
            if( dir == this.dir ||
                nowNum > 1 && 
                (this.dir == E_MoveDir.Left && dir == E_MoveDir.Right ||
                 this.dir == E_MoveDir.Right && dir == E_MoveDir.Left ||
                 this.dir == E_MoveDir.Up && dir == E_MoveDir.Down ||
                 this.dir == E_MoveDir.Down && dir == E_MoveDir.Up))
            {
                return;
            }

            //只要没有return 就记录外面传入的方向 之后就会按照这个方向去移动
            this.dir = dir;
        }


        public bool CheckEnd( Map map )
        {
            //是否和墙体位置重合
            for (int i = 0; i < map.walls.Length; i++)
            {
                if( bodys[0].pos == map.walls[i].pos )
                {
                    return true;
                }
            }

            for (int i = 1; i < nowNum; i++)
            {
                if(bodys[0].pos == bodys[i].pos)
                {
                    return true;
                }
            }

            return false;
        }

        //通过传入一个位置 来判断这个位置 是不是和蛇重合
        public bool CheckSamePos(Position p)
        {
            for (int i = 0; i < nowNum; i++)
            {
                if(bodys[i].pos == p)
                {
                    return true;
                }
            }
            return false;
        }

        public void CheckEatFood(Food food)
        {
            if( bodys[0].pos == food.pos )
            {
                //吃到了 就应该让食物 位置再随机 增加蛇身体的长度
                food.RandomPos(this);
                //长身体
                AddBody();
            }
        }

        private void AddBody()
        {
            SnakeBody frontBody = bodys[nowNum - 1];
            //先长 
            bodys[nowNum] = new SnakeBody(E_SnakeBody_Type.Body, frontBody.pos.x, frontBody.pos.y);
            //再加长度
            ++nowNum;
        }
    }
}
