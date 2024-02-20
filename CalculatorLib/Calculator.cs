namespace CalculatorLib;

public class Calculator
{
    public int Calculate(int a, int b, IOperation op){
        return op.Operate(a,b);
    }
}

public abstract class IOperation{
    public abstract int Operate(int a, int b);
}

public class Addition : IOperation{
    public override int Operate(int a, int b){
        return a+b;
    }
}
public class Multiplication : IOperation{
    public override int Operate(int a, int b){
        return a*b;
    }
}

