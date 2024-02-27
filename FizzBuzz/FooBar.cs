namespace FooBar;

public class FooBarProcess
{
    public static string Run(int n, Func<int,string> operation){
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