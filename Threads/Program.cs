class Program{
    
    static int Main(){
        int data = int.MaxValue;
        int data2 = 0;
        Console.WriteLine(data+1);
        Thread t1 = new Thread(Process);
        Thread t2 = new Thread(Process);
        Thread t3 = new Thread(()=>Process(ref data));
        Thread t4 = new Thread(()=>{data2 = Process2();});

        t1.Priority = ThreadPriority.Highest;
        t2.Priority = ThreadPriority.Highest;
        t3.Priority = ThreadPriority.Highest;
        // for(int i=0;i<100;i++){
        //     Thread t = new Thread(Process);
        //     // t.Priority = ThreadPriority.Highest;
        //     t.Start();
        // }

        t3.Start();
        t1.Start();
        t2.Start();
        t4.Start();

        Thread.Sleep(1);
        Console.WriteLine(data.ToString()+" "+data2);
        if (data == 1){
            return -1;
        }
        return 0;

    }
    static void Process(){
        Console.WriteLine("Hohoho"+ Thread.CurrentThread.ManagedThreadId);
        ulong x = 1;
        while(x!=0){
            x++;
            if (x==ulong.MaxValue -1){
                Console.WriteLine("wow you reached here...");
            }
        }
    }
    static void Process(ref int x){
        x = 1;
        Console.WriteLine("Hohoho"+ Thread.CurrentThread.ManagedThreadId +" "+x);
    }

    static int Process2(){
        Thread.Sleep(100);
        return 69;
    }
}