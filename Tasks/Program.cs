class Program{

    static void Main(){
        Task.Run(Main);  // wont explode because default background
        // Thread t = new Thread(Main); // will explode
        // t.Start();
        Console.WriteLine("hello "+Thread.CurrentThread.ManagedThreadId);
        int x = 0;
        while(x!=int.MaxValue-1){
            x++;
        }
    }

}