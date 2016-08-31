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
{//这里我们构建一个baby哭的场景
   
    //故事从这里开始
    static void Main()
    {
        //实例化一个baby
        Baby baby=new Baby();
        
        //添加 mummy 到委托链
        baby.onCry += new Baby.cryEventHandler(Mum.say);
        
        //添加 Dady 委托链
        baby.onCry  += new Baby.cryEventHandler(Dad.say);
        
        //触发事件，let the baby cry
        baby.cry();
    }
}

public class Baby
{
    //1.声明一个委托，其实就是个“命令”
    public delegate void cryEventHandler();
    
    //2.声明一个事件, 基于该“命令”
    public event cryEventHandler onCry;
    
    public  void cry()
    {
        //如果有人关注了这个事件，baby就哭
        //=如果有人在意baby哭，baby就哭
        if(onCry!=null)
        {
            Console.WriteLine("\n\tBaby crying : ....#%$&*((*$@)()_^~&#....\n");
        }
        
        //3. Fire the event 事件
        onCry();
        
    }
}

public class Mum
{
    public static void say()
    {
        Console.WriteLine("\tMummy: loves you.");
    }
}

public class Dad
{
    public static void say()
    {
        Console.WriteLine("\tDad: loves you.");
    }
}
