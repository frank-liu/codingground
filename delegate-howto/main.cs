using System.IO;
using System;

class Baby
{
    //声明委托
    public delegate void cryEventHandler();
    
    //声明事件
    
    
    //触发事件
    
    
    static void Main()
    {
        cryEventHandler myDelegate=null;
        myDelegate += new cryEventHandler(Mum.feed);
        myDelegate+=new cryEventHandler(Dad.playBall);
        myDelegate();
        
    }
}

 class Mum
{
    public static void feed()
    {
        Console.WriteLine("Don't cry, baby.");
        Console.WriteLine("Mummy feeds you.");
    }
}

class Dad
{
    public static void playBall()
    {
        Console.WriteLine("Dad plays ball with you.");
    }
}
