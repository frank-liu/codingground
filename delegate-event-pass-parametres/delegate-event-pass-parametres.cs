/*本例说明在 委托-事件 中传递参数的用法
本例中有4个关键类：
1. Senario ：应用场景
2. Baby : 事件的发布者 Publisher
3. Mum :  事件的接受者 subscriber
4. Dad :  事件的接受者 subscriber
本例中有1个用来传递参数的类：
5. currentTime : EventArgs 
*/
using System;
 
//构建一个自定义的时间参数类
//用来在event-delegate中传递参数
public class currentTime : EventArgs
{
	public string Time;
}

public class Senario
{ //这里我们构建一个baby哭的场景
	//故事从这里开始
	public static void Main()
	{
		//实例化一个baby
		Baby baby = new Baby();
		//实例化一个Mum
		Listener_Mum m = new Listener_Mum();
		m.Subscribe(baby); //mum 关注baby哭这件事
		//实例化一个Dad
		Listener_Dad d = new Listener_Dad();
		d.Subscribe(baby); //dad 关注baby哭这件事
		
        //触发事件，事情发生了。let the baby cry
		baby.cry();
	}
}

public class Baby
{
	//声明 事件参数 实例
	public EventArgs e = null;
	//1.声明一个委托，其实就是个“命令”
	public delegate void cryEventHandler(Baby sender, currentTime e);
	//2.声明一个事件, 基于该“命令”
	public event cryEventHandler onCry;
    //3. Fire the event 事件
	public void cry()
	{		
		if (onCry != null) //如果有人关注了这个事件，baby就哭
		{
			Console.WriteLine("\n\tBaby crying : ....#%$&*((*$@)()_^~&#....\n");
			currentTime t = new currentTime();
			t.Time = " [pass parametre here]";
			//3. Fire the event 事件
			onCry(this, t);
		}
	}
}

public class Listener_Mum
{
	public void Subscribe(Baby b)
	{
		b.onCry += new Baby.cryEventHandler(HeardIt);
	}

	private void HeardIt(Baby b, currentTime e)
	{
		System.Console.WriteLine("Mum HEARD IT. get:"+e.Time+".Do something here");
	
	}
}

public class Listener_Dad
{
	public void Subscribe(Baby b)
	{
		b.onCry += new Baby.cryEventHandler(HeardIt);
	}

	private void HeardIt(Baby b, currentTime e)
	{
		System.Console.WriteLine("Daddy HEARD IT. get:"+e.Time+".Do something here");
	}
}