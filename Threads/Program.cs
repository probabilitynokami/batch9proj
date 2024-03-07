class Program{
    
    static int Main(){
        int data = 0;
        Thread t1 = new Thread(Process);
        Thread t2 = new Thread(Process);
        Thread t3 = new Thread(()=>Process(ref data));

        t3.Start();
        t1.Start();
        t2.Start();
        Thread.Sleep(1);
        if (data == 1){
            return -1;
        }
        return 0;

    }
    static void Process(){
        Console.WriteLine("Hohoho"+ Thread.CurrentThread.ManagedThreadId);
    }
    static void Process(ref int x){
        x = 1;
        Console.WriteLine("Hohoho"+ Thread.CurrentThread.ManagedThreadId +" "+x);
    }
}