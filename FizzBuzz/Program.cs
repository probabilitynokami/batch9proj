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

        Console.WriteLine(FooBar(100, operation));


        Console.WriteLine("=====================separator===================");

        // 2nd way
        operation = (new FooBarOperationBuilder())
                    .AddOperation((int x)=>(x%3==0)?"Foo":"")
                    .AddOperation((int x)=>(x%5==0)?"Bar":"")
                    .Build();

        Console.WriteLine(FooBar(100, operation));
    }
    static string FooBar(int n, Func<int,string> operation){
        string operationResult = operation(0);
        if (operationResult == "")
            operationResult = "0";
        string finalString = "0"; // because 0 still should 0

        for(int i=1;i<=n;i++){
            operationResult = operation(i);
            if(operationResult == "")
                operationResult = i.ToString();
            finalString += ", "+operationResult; 
        }

        return finalString;
    }

}

public class FooBarOperationBuilder{
    private Func<int, string> operations = null;
    public FooBarOperationBuilder AddOperation(Func<int,string> operation){
        operations += operation;
        return this; 
    }
    public Func<int, string> Build(){
        Func<int, string> result = (int x) => {
            string ret = "";
            foreach(var ops in operations.GetInvocationList()){
                ret += ((Func<int,string>)ops).Invoke(x);
            }
            return ret;
        };

        return result;
    }
}