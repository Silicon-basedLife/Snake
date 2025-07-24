using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace 贪吃蛇.Object
{
     abstract class GameObject : IDraw
    {
        //游戏对象位置
        public Position pos;

        public abstract void Draw();
    }
}
