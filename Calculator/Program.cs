// See https://aka.ms/new-console-template for more information
//Console.WriteLine("Hello, World!");

class Calculator {

    public int offsets = 0;
    public int s = 0;
    private int testPrivate = 0;

    public int Add(int a, int b){
        return a+b + this.s; 
    }
    public int Mul(int a, int b){
        return a*b*this.s;
    }

}


class Program{

    static void Main(){
        Calculator calc = new Calculator() {
            offsets = 1
        };
        string s = "test " + (new Calculator()) + (new Calculator()) ;
        int result = calc.Add(1,1);
        Console.WriteLine(s);
        Console.WriteLine(result);
    }
}