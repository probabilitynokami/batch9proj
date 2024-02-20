// See https://aka.ms/new-console-template for more information

class A{

    public string foo;
    public int bar;
    public A(string foo, int bar){
        Console.WriteLine("an instance of "+ this + " is built");
        this.foo = foo;
        this.bar = bar;
    }
    public void tobeoverrided(){
        Console.WriteLine("hello");
    }
}

class Program{

    static void Main(){
        A obj = new A("ohla",12);

        Console.WriteLine(obj.foo);
        Console.WriteLine(obj.bar);

        obj.tobeoverrided();

        return;
    }


}