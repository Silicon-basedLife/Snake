using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using 贪吃蛇.Scene;

namespace 贪吃蛇.Games
{
    //场景类型枚举

    enum E_SceneType
    {
        //开始场景
        Begin,
        //游戏场景
        Game,
        //结束场景
        End,
    }
    internal class Game
    {
        //因为不变到处都要用所以用const来访问
        public const int w = 80;
        public const int h = 20;

        public static ISceneUpdate nowScene;

        public Game() { 
            Console.CursorVisible = false;  //隐藏鼠标
            Console.SetWindowSize(w,h); //窗口大小
            Console.SetBufferSize(w,h); //缓冲区

            ChangeScene(E_SceneType.Begin);
        }

        public void Start()
        {
            //游戏主循环 主要负责 场景游戏逻辑更新
            while (true)
            {
                if (nowScene != null)
                {
                    nowScene.Update();
                }
            }
        }

        //静态方法不能使用成员变量所以nowScene也要改成静态的
        public static void ChangeScene(E_SceneType type) {
            //切场景之前，应该把上一个场景的绘制内容擦掉
            Console.Clear();

            switch (type)
            {
                case E_SceneType.Begin:
                    nowScene = new BeginScene();
                    break;
                case E_SceneType.Game:
                    nowScene = new GameScene();
                    break;
                case E_SceneType.End:
                    nowScene = new EndScene();
                    break;
            }

        }
    }
}
