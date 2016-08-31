/*本例说明委托 事件 的联合用法
本例中有4个类：
1. Senario ：应用场景
2. Baby : 事件的发布者 Publisher
3. Mum :  事件的接受者 subscriber
4. Dad :  事件的接受者 subscriber
*/

using System.IO;
using System;


class Senario
{//构建一个baby哭的场景
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
      
        
    }
}

class Baby
{
    public static void cry()
    {
        Console.WriteLine("....#%$&*((*$@)()_^~&#....");
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
