// Partial Class -> separate class to multifile

using Partials;
public partial class Program{

    static void Main(){
        PartialClassDemo p = new();
        p.Hello();
        p.World();
    }
}

namespace Partials{
    public partial class PartialClassDemo{
        int x=69;
        public void Hello(){
            Console.WriteLine("Hello");
        }
    }
}