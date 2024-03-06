
class Program{

    static void Main(){
#if BINBOWS
        Console.WriteLine("BINBOWS");
#elif LINOWS
        Console.WriteLine("LINOWS");
#endif

        return;
    }

}