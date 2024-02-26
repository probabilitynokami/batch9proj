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
    }
    static string FooBar(int n, Func<int,string> f){
        string fOutput = f(0);
        if (fOutput == "")
            fOutput = "0";
        string retVal = "0";

        for(int i=1;i<=n;i++){
            fOutput = f(i);
            if(fOutput == "")
                fOutput = i.ToString();
            retVal += ", "+fOutput; 
        }

        return retVal;
    }

}