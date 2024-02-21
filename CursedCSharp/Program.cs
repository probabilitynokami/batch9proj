// See https://aka.ms/new-console-template for more information
// Console.WriteLine("Hello, World!");


class S{
	public int s = 0;
	public void Call(){
		Console.WriteLine("S");
	}
}
class SS : S{
	public void CallCall(){
        Console.WriteLine("SS");
	}
}

class Program{
	public static void Main(){
		//Program.Main();

		int b=1;
		int a = 0;
		float x = 0.0f;

		a = (int)(x+b);

		Console.WriteLine(a);

		object boxed = new S();
		S cls = (S)boxed;
		cls.Call();
		cls.ToString();



		object asdf = "asdffdsa";
		object fdsa = "fdsaasdf";
		
		
		
		asdf = 1;
		fdsa = 2;
		int zxc = 0;
		zxc = Convert.ToInt32(Console.ReadLine());
		
		if (asdf is int && zxc==10){
			asdf = "asdffdsa";
			fdsa = "fdsaasdf";
		}

		Program.test(asdf,fdsa);

        dynamic cursed = new S();
        cursed.Call();
        if (zxc == 11){
            cursed.Hello();
        }

	}
	public static int test(object obj1, object obj2){
		return (int)obj1 + (int)obj2;
	}
}