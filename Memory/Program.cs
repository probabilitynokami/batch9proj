using System.Text;


class Program{

    static void Main(){
        Console.WriteLine("Hello, World!");

        {
            StringBuilder sb = new();

            Console.ReadLine();

            sb.Capacity = 64;
            Console.ReadLine();

            sb.Capacity = 100;
            Console.ReadLine();

            sb.Capacity = 100_000;
            Console.ReadLine();

            sb.Capacity = 1000_000;
            Console.ReadLine();

            sb.Capacity = 10_000_000;
            Console.WriteLine("call gc now");
            Console.ReadLine();

            sb.Capacity = 10_000;
            sb.Append(Enumerable.Repeat("a",9_999));
            Console.ReadLine();
        }

        Console.WriteLine("stringbuilder should be freed rn, if not call GC");
        Console.ReadLine();
    }

}

