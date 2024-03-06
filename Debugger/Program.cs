// See https://aka.ms/new-console-template for more information
class Program{
    static async Task Main(){
        Func<int,int,int> myfunc = null;
        ReftypeStuff rft = new();

        HeheBoy(ref myfunc, rft);

        while(true){
            myfunc.Invoke(1,2);
            Console.WriteLine(rft.a + " "+rft.b);
            Thread.Sleep(100);
            await Task.Delay(100);
        }
    }

    static void HeheBoy(ref Func<int,int,int> myFunc, ReftypeStuff something){
        var sus = (int l, int r) =>{
            l = something.a;
            l = l*2+1;
            r = r*2+1;
            int result = ((l-r)*4);
            return result;
        };
        myFunc += sus;
    }

}

class ReftypeStuff{
    public int a = 0;
    public int b = 0;
}