using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

/// <summary>
/// 作为公用控制器,控制游戏的全局变量及全局方法
/// 静态类模式   , 如当前玩到第几大关第几小关，玩家的彩色数量等。
/// 
/// </summary>
/// 
class Global
{
    public static bool isBattle = false;
    public static bool enemyattack = false;

    //玩家属性合集：
    public int life = 100;
    public int attack = 10;
    public int defence = 5;
}
