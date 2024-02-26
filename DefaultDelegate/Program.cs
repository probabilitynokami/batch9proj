
class Program{
    static void Main(){

	    // Action<params...>
	    // Action<T> -> delegate void Action(T t)
	    Action<int> action = NoReturnFunction;

	    // Func<params... , return type>
	    // Func<T.., V> -> delegate V Action(T..)
	    Func<int, float, int> functor =  ReturningFunction;


    }
    static void NoReturnFunction(int x){
	    Console.WriteLine(x);
    }
    static int  NoReturnFunction(int x, float y){
	    Console.WriteLine(x+y);
	    return x;
    }
}
