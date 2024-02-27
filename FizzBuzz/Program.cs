using FooBar;

class Program{
    static void Main(){
        Func<int,string> operation = (int x)=>{
            string ret = "";
            if (x%3 == 0){
                ret += "Foo";
            }
            if (x%5 == 0){
                ret += "Bar";
            }
            return ret;
        };

        Console.WriteLine(FooBarProcess.Run(100, operation));


        Console.WriteLine("=====================separator===================");

        // 2nd way
        operation = (new FooBarOperationBuilder())
                    .AddOperation((int x)=>(x%3==0)?"Foo":"")
                    .AddOperation((int x)=>(x%5==0)?"Bar":"")
                    .Build();

        Console.WriteLine(FooBarProcess.Run(100, operation));
    }
    

}
