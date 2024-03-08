

class Program{

    static int counter;
    static object obj=new object();
    
    static SemaphoreSlim semaphore = new SemaphoreSlim(3);

    static void Main(){
        //// Task t1 = Task.Run(ConcurrentlyAccessedMethodMonitorLock);
        //// Task t2 = Task.Run(ConcurrentlyAccessedMethodMonitorLock); // expected final output 200k
        //Task t1 = Task.Run(ConcurrentlyAccessedMethod);
        //Task t2 = Task.Run(ConcurrentlyAccessedMethod); // idk final output

        //Task.WaitAll(t1,t2);
        //Console.WriteLine("counting result"+counter);


        // semaphore
        // expected behavior, only 3 processing at a time
        Task[] tasks = new Task[22];
        for(int i=0;i<tasks.Length;i++){
            tasks[i] = Task.Run(async () => await ConcurrentlyAccessedMethodSemaphore());
        }

        Task.WaitAll(tasks);

        Console.WriteLine("program done");

        return;
    }

    static void ConcurrentlyAccessedMethod(){
        for(int i=0;i<100000;i++){
            counter++;
            Console.WriteLine("Thread "+Thread.CurrentThread.ManagedThreadId+": " +counter);
        }
    }

    static void ConcurrentlyAccessedMethodMonitorLock(){
        for(int i=0;i<100000;i++){
            lock(obj){
                counter++;
                Console.WriteLine("Thread "+Thread.CurrentThread.ManagedThreadId+": " +counter);
            }
        }
    }

    static async Task ConcurrentlyAccessedMethodSemaphore(){
        Console.WriteLine("Thread "+Thread.CurrentThread.ManagedThreadId +" access");

        await semaphore.WaitAsync();
        await Task.Delay(500);
        Console.WriteLine("Thread "+Thread.CurrentThread.ManagedThreadId +" processing");
        await Task.Delay(500);
        semaphore.Release();

        Console.WriteLine("Thread "+Thread.CurrentThread.ManagedThreadId +" done");
    }


}