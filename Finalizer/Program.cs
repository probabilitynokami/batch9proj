using System.Diagnostics;
using System.Runtime.InteropServices;
using System.Text;
class Finalizor{
    public Finalizor(){
        Console.WriteLine("Finalizor Created");
    }
    public void DoSmth(){
        Console.WriteLine("smth");
    }
    ~Finalizor(){
        Console.WriteLine("Finalizer of Finalizor runnin "+ Thread.CurrentThread.ManagedThreadId);
        var sw = new Stopwatch();
        sw.Start();
        long elapsed = sw.ElapsedMilliseconds;
        long print_second = elapsed/1000+1;
        while(elapsed <= 10000){
            if (elapsed/1000 == print_second){
                Console.WriteLine("\tfinalizer processing"+elapsed);
                print_second++;
            }
            elapsed = sw.ElapsedMilliseconds;
        }
        Console.WriteLine("Finalizer of Finalizor finish");
    }
}


class Program{
    static void Wait(){
        Console.WriteLine("\t\t\tWait runnin "+ Thread.CurrentThread.ManagedThreadId);
        //var sw = new Stopwatch();
        //sw.Start();
        //long elapsed = sw.ElapsedMilliseconds;
        //long print_second = elapsed/1000+1;
        //while(elapsed <= 10000){
        //    if (elapsed/1000 == print_second){
        //        Console.WriteLine("\t\t\tWait"+elapsed);
        //        print_second++;
        //    }
        //    elapsed = sw.ElapsedMilliseconds;
        //}
    }
    static void Main(){
        {
            Thread newth = new Thread(new ThreadStart(Wait));
            Thread newth1 = new Thread(new ThreadStart(Wait));
            Thread newth2 = new Thread(new ThreadStart(Wait));
            Thread newth3 = new Thread(new ThreadStart(Wait));
            newth.Start();
            newth1.Start();
            newth2.Start();
            newth3.Start();
            // Thread newth2 = new Thread(new ThreadStart(Wait));
            // newth2.Start();
            {
                FinalizorDoinShits();
                FinalizorDoinShits();
                Console.WriteLine("is this blocked by finalizer?");
            }
            GC.Collect();
            // GC.WaitForPendingFinalizers();
            Console.WriteLine("is this blocked by finalizer?");
        }
        Console.WriteLine("main thread"+ Thread.CurrentThread.ManagedThreadId);
        Console.WriteLine("is this blocked by finalizer?");
        StringBuilder sb = new();
        Console.WriteLine("is this blocked by finalizer?");

        sb.Capacity = 1000;
        Console.ReadLine();
        Console.WriteLine("is this blocked by finalizer?");

        sb.Capacity = 10000;
        Console.ReadLine();
        Console.WriteLine("is this blocked by finalizer?");

        sb.Capacity = 100000;
        Console.ReadLine();
        Console.WriteLine("is this blocked by finalizer?");
    }
    static void FinalizorDoinShits(){
        Finalizor s = new();
        s.DoSmth();
    }
}