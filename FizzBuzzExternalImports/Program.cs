using FooBar;


class Program{

    static void Main(){

        var operation = (new FooBarOperationBuilder())
                    .AddOperation((int x)=>(x%3==0)?"Foo":"")
                    .AddOperation((int x)=>(x%5==0)?"Bar":"")
                    .AddOperation((int x)=>(x%7==0)?"Dar":"")
                    .Build();

        Console.WriteLine(FooBarProcess.Run(100, operation));

        return;
    }
}