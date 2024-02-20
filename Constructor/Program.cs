// See https://aka.ms/new-console-template for more information

class A{

    public string foo;
    public int bar;

    public int dar;

    public A(string foo, int bar){
        Console.WriteLine("an instance of "+ this + " is built with foobar");
        this.foo = foo;
        this.bar = bar;
    }

    public A(string foo, int bar, int dar){
        Console.WriteLine("an instance of "+ this + " is built with foobardar");
        this.foo = foo;
        this.bar = bar;
        this.dar = dar;
    }

    public void Func1(){
        Console.WriteLine("func1 is called without params;" + this.foo);
    }
    public void Func1(int a){
        Console.WriteLine("func1 is called with params "+a+";"+this.foo);
    }
}

class Program{

    static int Main(){
        A obj = new("ohla",12);

        Console.WriteLine(obj.foo);
        Console.WriteLine(obj.bar);
        Console.WriteLine(obj.dar);

        Console.WriteLine("\n");

        obj.Func1();
        obj.Func1(1);

        Console.WriteLine("\n");


        A obj2 = new("ohla",12,13) ;
        Console.WriteLine(obj2.foo);
        Console.WriteLine(obj2.bar);
        Console.WriteLine(obj2.dar);

        A obj3 = new("ohla",13,12){
            foo = "hehe",
            bar = 12,
            dar = 13
        }; // does this ignore the constructor? yes
        Console.WriteLine(obj3.foo+obj3.bar+obj3.dar);
        return -1;
    }


}