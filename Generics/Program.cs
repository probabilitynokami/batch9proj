// See https://aka.ms/new-console-template for more information
// Console.WriteLine("Hello, World!");

using System;
using System.Numerics;

class Program{

    static void Main(){
        int x = 2;
        x.Dump();
        A<string> aa = new();
        aa.Check("foobar");

        A<int> aaa = new();
        aaa.Check(21);

        B<int,string> bb = new();
        bb.Check(1);
        bb.Check2("siuuuu");


        C<int> cc = new();
        cc.Check(2).Dump();

        Console.WriteLine(cc); // will throw not-implemented exception
    }
}
class A<T>{ // generic example

    T? store;
    public T Check(T x){
        this.store = x;
        Console.WriteLine(x);
        return this.store;
    }
}



class B<T,X>{ //generic with 2 type

    T? store;
    X? store2;
    public T Check(T x){
        this.store = x;
        Console.WriteLine(x);
        return this.store;
    }
    public X Check2(X x){
        this.store2 = x;
        Console.WriteLine(x);
        return this.store2;
    }
}

class C<T> where T : INumber<T>{ // generic with constraint for T
    T? store;
    public T Check(T x){
        return x+x;
    }
}
class D<T> : IFormattable where T : INumber<T>{ // generic with constraint for T and inherits/implements a class/interface
    T? store;
    public T Check(T x){
        return x+x;
    }

    public string ToString(string? format, IFormatProvider? formatProvider)
    {
        throw new NotImplementedException();
    }
}

static class DumpyDump{
    public static void Dump<T> (this T x) where T : IFormattable{ //generic on methods
        Console.WriteLine(x);
    }

}