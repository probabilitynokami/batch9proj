

using CalculatorLib;





class Substraction : IOperation {
    public override int Operate(int a, int b)
    {
        return a-b;
    }
};

class Program{

    static void Main(){

        Calculator calc = new();
        Console.WriteLine(calc.Calculate(1,1,(new Addition())));
        Console.WriteLine(calc.Calculate(1,1,(new Substraction())));
        return;
    }
}