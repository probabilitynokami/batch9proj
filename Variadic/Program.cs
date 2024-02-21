// See https://aka.ms/new-console-template for more information

class Program{

    public static void Main(){
        Console.WriteLine(Accumulate(100,1,2,3,4));
        Console.WriteLine(Sum(1,2,3,4));
    }

    public static int Accumulate(int init, params int[] args){
        foreach(var x in args){
            init += x;
        }
        return init;
    }
    public static int Sum(params int[] args){
        int init = 0;
        foreach(var x in args){
            init += x;
        }
        return init;
    }
}
