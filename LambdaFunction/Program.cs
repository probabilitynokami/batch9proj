
class Program{

    static void Main(){

        CalculationPipeline calcPipe = new();
        calcPipe.AddOperation((int prev,int now) => prev+now);
        calcPipe.AddOperation((int prev,int now) => prev-now);
        calcPipe.AddOperation((int prev,int now) => prev*now);
        calcPipe.AddOperation((int prev,int now) => (prev+now)*now);

        int[] initData = new int[10];
        initData = [1,2,3,4,5,6,7,8,9,10];
        int[] functionParams = [2,2,2,2];

        foreach(var x in calcPipe.Calculate(initData,functionParams)){
            Console.WriteLine(x);
        }

        return;
    }

}




public class CalculationPipeline{

    private Func<int, int, int> funcs = null;

    public void AddOperation(Func<int,int,int> f){
        funcs += f;
    }

    public int[] Calculate(int[] data, int[] functionParams){
        int[] retval = (int[])data.Clone();
        int paramidx = 0;
        foreach(var f in funcs.GetInvocationList()){
            var ff = (Func<int,int,int>)f;

            // this might be parallelizable
            for(int i=0;i<data.Length;i++){
                retval[i] = ff.Invoke(retval[i],functionParams[paramidx]);
            }

            paramidx++;
        }

        return retval;
    }
}