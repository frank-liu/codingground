///本例说明委托的用法
///

using System.IO;
using System;

class Baby
{
    //声明一个委托，其实就是个“命令”
    public delegate void cryEventHandler();
    
    //声明事件, 基于该“命令”
    
    
    //Fire the event 事件
    
    
    static void Main()
    {
        cryEventHandler babyCrying=null;
        //添加委托链
        babyCrying += new cryEventHandler(Mum.say);
        //添加委托链
        babyCrying += new cryEventHandler(Dad.say);
        
        //触发事件，let the baby cry
        babyCrying();
        
    }
}

 class Mum
{
    public static void say()
    {
        
        Console.WriteLine("Mummy loves you.");
    }
}

class Dad
{
    public static void say()
    {
        Console.WriteLine("Dad loves you.");
    }
}
