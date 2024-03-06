class MyClass : IDisposable
{
    FileStream fs;
    List<int> managedStuff;

    public MyClass(){
        fs = File.Open("C:\\Users\\Batch 9\\Downloads\\dotnet-sdk-8.0.201-win-x64.exe",FileMode.Open,FileAccess.Read, FileShare.Read);
        managedStuff = Enumerable.Repeat(100,100000).ToList();
    }

    private bool disposedValue;

    protected virtual void Dispose(bool disposing)
    {
        if (!disposedValue)
        {
            if (disposing)
            {
                // TODO: dispose managed state (managed objects)
                Console.WriteLine("Explicitly called by programmer");
            }
            else{
                Console.WriteLine("called from finalizer");
            }

            // TODO: free unmanaged resources (unmanaged objects) and override finalizer
            // TODO: set large fields to null
            disposedValue = true;
            fs.Close();
            fs.Dispose();
        }
    }

    // TODO: override finalizer only if 'Dispose(bool disposing)' has code to free unmanaged resources
    ~MyClass()
    {
        // Do not change this code. Put cleanup code in 'Dispose(bool disposing)' method
        Dispose(disposing: false);
    }

    public void Dispose()
    {
        // Do not change this code. Put cleanup code in 'Dispose(bool disposing)' method
        Dispose(disposing: true);
        GC.SuppressFinalize(this);
    }
}


class Program{


    static void StackFrameWithDispose(){
        MyClass a = new();
        Console.ReadLine();
        a.Dispose();
    }

    static void StackFrame(){
        MyClass a = new();
        Console.ReadLine();
    }

    static void Main(){
        Console.ReadLine();
        StackFrameWithDispose();
        GC.Collect();
        StackFrame();
        GC.Collect();
        Console.ReadLine();
    }
}