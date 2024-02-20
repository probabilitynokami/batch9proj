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
}

class Program{

    static int Main(){
        A obj = new A("ohla",12);

        Console.WriteLine(obj.foo);
        Console.WriteLine(obj.bar);
        Console.WriteLine(obj.dar);


        A obj2 = new A("ohla",12,13) ;
        Console.WriteLine(obj2.foo);
        Console.WriteLine(obj2.bar);
        Console.WriteLine(obj2.dar);

        return -1;
    }


}