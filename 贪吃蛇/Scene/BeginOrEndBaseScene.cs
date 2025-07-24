using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using 贪吃蛇.Games;

namespace 贪吃蛇.Scene
{
    abstract class BeginOrEndBaseScene : ISceneUpdate
    {
        protected int nowSelIndex = 0;
        protected string strTitle;
        protected string strOne;

        //按下J键留到子类实现
        public abstract void EnterJDoSomething();

        public void Update() { 
            //开始和结束场景的游戏逻辑
            //选择当前的选项 然后监听 键盘输入wasd
            Console.ForegroundColor = ConsoleColor.White;//标题颜色
            //显示标题
            Console.SetCursorPosition( Game.w/2 - strTitle.Length, 5 );
            Console.Write(strTitle);
            //显示下方的选项
            Console.SetCursorPosition(Game.w / 2 - strTitle.Length, 8);
            Console.ForegroundColor = nowSelIndex == 0 ? ConsoleColor.Red : ConsoleColor.White;
            Console.Write(strOne);
            //结束选项
            Console.SetCursorPosition(Game.w / 2 - strTitle.Length, 10);
            Console.ForegroundColor = nowSelIndex == 1 ? ConsoleColor.Red : ConsoleColor.White;
            Console.Write("结束游戏");
            //检测输入
            switch (Console.ReadKey(true).Key) {
                case ConsoleKey.W:
                    --nowSelIndex;
                    if( nowSelIndex < 0)
                    {
                        nowSelIndex = 0;
                    }
                    break;
                case ConsoleKey.S:
                    ++nowSelIndex;
                    if (nowSelIndex > 1)
                    {
                        nowSelIndex = 1;
                    }
                    break;
                case ConsoleKey.J:
                    EnterJDoSomething ();
                    break;
            }
        }
    }
}
