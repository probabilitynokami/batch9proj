
class Program{
    static void Main(){

	    // Action<params...>
	    // Action<T> -> delegate void Action(T t)
	    Action<int> action = NoReturnFunction;

	    // Func<params... , return type>
	    // Func<T.., V> -> delegate V Action(T..)
	    Func<int, float, int> functor =  ReturningFunction;

		action.Invoke(1);
		Console.WriteLine(functor.Invoke(1,2.0f));

    }
    static void NoReturnFunction(int x){
	    Console.WriteLine(x);
    }
    static int  ReturningFunction(int x, float y){
	    Console.WriteLine(x+y);
	    return x;
    }
}
