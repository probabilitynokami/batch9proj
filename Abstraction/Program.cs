// See https://aka.ms/new-console-template for more information
Console.WriteLine("Hello, World!");


public abstract class A{
    public abstract void ImplementThis();
}

public class B : A {
    public override void ImplementThis()
    {
        throw new System.NotImplementedException();
    }
}

// Illegal
// public class C : A {
//  // did not implement ImplementThis()
// }




