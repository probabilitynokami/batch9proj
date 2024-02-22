// See https://aka.ms/new-console-template for more information

A a = new();

Console.WriteLine(A.e); //e is static
Console.WriteLine(a.e); //compile error
Console.WriteLine(a.x);
// a.x = 1; // compile error


class A{
    public readonly int x;
    public const float e = 2.718f;

    public A(){
        x = 0; // the only allowed time to write on x;
        // e = 2.1; // const can't do that here 
    }

    // public void ChangeX(){ // compile error
    //     x = 1;
    // }
}
